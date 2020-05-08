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
        public List<UsuarioDTO> ValidarUsuario(LoginDTO loginDTO)
        {
            List<UsuarioDTO> retorno = new List<UsuarioDTO>();
            ConDBOracle cnOracle = new ConDBOracle("ContextoDH");
            OracleCommand objCommand = new OracleCommand();

            try
            {
                objCommand.Parameters.Clear();
                objCommand.Parameters.Add(new OracleParameter("I_IdfUsr", OracleDbType.Varchar2, 100)).Value = loginDTO.Email;
                objCommand.Parameters.Add(new OracleParameter("I_Clave", OracleDbType.Varchar2, 300)).Value = loginDTO.Password;
                objCommand.Parameters.Add(new OracleParameter("Tabla_Usuario", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;
                
                objCommand.Connection = cnOracle.Conexion;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "DB_DREAM_HOME.PKG_SISTEMA.FN_ValidarUsuario";
                objCommand.BindByName = true;

                if (cnOracle.Conectar())
                {
                    DataTable resultado = new DataTable();
                    OracleDataReader datos = objCommand.ExecuteReader();
                    resultado.Load(datos);

                    UsuarioDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new UsuarioDTO
                        {
                            Usuario_id = int.Parse(row["Id_Usr"].ToString()),
                            Usuario = row["Usuario"].ToString(),
                            Nombre_Usuario = row["Nombre_Usr"].ToString(),
                            Rol_id = Convert.ToInt32(row["Id_Rol"].ToString()),
                            Sesion_id = Convert.ToInt32(row["Id_Sesion"].ToString()),
                            Mensaje = row["Mensaje"].ToString()
                        };

                        retorno.Add(registro);
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

            return retorno;
        }
    }
}
