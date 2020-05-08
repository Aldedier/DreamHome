namespace Datos.DreamHome
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Data;
    using Datos.DreamHome.ConexionOracle;
    using System.Collections.Generic;

    public class SistemaDB 
    {
        public UsuarioDTO ValidarUsuario(LoginDTO loginDTO)
        {
            UsuarioDTO registro = new UsuarioDTO();
            ConDBOracle cnOracle = new ConDBOracle("ContextoDH");
            OracleCommand objCommand = new OracleCommand();

            try
            {
                objCommand.Parameters.Clear();
                objCommand.Parameters.Add(new OracleParameter("I_IdfUsr", OracleDbType.Varchar2, 100)).Value = loginDTO.Email;
                objCommand.Parameters.Add(new OracleParameter("I_Clave", OracleDbType.Varchar2, 300)).Value = loginDTO.Password;
                objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                
                objCommand.Connection = cnOracle.Conexion;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "DB_DREAM_HOME.PKG_SISTEMA.PR_ValidarUsuario";
                //objCommand.BindByName = true;

                if (cnOracle.Conectar())
                {
                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new UsuarioDTO
                        {
                            Usuario_id = int.Parse(row[0].ToString()),
                            Usuario = row[1].ToString(),
                            Nombre_Usuario = row[2].ToString(),
                            Rol_id = Convert.ToInt32(row[3].ToString()),
                            Sesion_id = Convert.ToInt32(row[4].ToString()),
                            Mensaje = row[5].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error !!!");
            }
            finally
            {
                cnOracle.Desconectar();
                if (objCommand != null) { objCommand.Dispose(); }
            }

            return registro;
        }
    }
}
