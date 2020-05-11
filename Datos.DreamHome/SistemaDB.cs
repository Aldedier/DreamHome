namespace Datos.DreamHome
{
    using Comun.DreamHome;
    using Datos.DreamHome.ConexionOracle;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Data;

    public class SistemaDB
    {
        public UsuarioDTO ValidarUsuario(LoginDTO loginDTO)
        {
            UsuarioDTO registro = new UsuarioDTO();
            string connectionString = new Utilidades().GetConnectionStringByName("ContextoDH");

            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfUsr", OracleDbType.Varchar2, 100)).Value = loginDTO.Email;
                    objCommand.Parameters.Add(new OracleParameter("I_Clave", OracleDbType.Varchar2, 300)).Value = loginDTO.Password;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "DB_DREAM_HOME.PKG_SISTEMA.PR_ValidarUsuario";

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
                catch (Exception ex)
                {
                    throw new ArgumentException($"{ex.Message} {ex.InnerException}");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();

                    if (objCommand != null)
                        objCommand.Dispose();
                }
            }
            return registro;
        }
    }
}
