namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Configuration;

    public class SistemaDB
    {
        public UsuarioDTO ValidarUsuario(LoginDTO loginDTO)
        {
            UsuarioDTO registro = new UsuarioDTO();

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_SISTEMA.PR_ValidarUsuario";

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

        public List<AuditoriaDTO> ReporteAuditoria(AuditoriaDTO auditoriaDTO)
        {
            List<AuditoriaDTO> retorno = new List<AuditoriaDTO>();

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_Usuario", OracleDbType.Varchar2, 200)).Value = auditoriaDTO.USUARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_Rol", OracleDbType.Varchar2, 200)).Value = auditoriaDTO.ROL_USR;
                    objCommand.Parameters.Add(new OracleParameter("I_ObjetoBD", OracleDbType.Varchar2, 200)).Value = auditoriaDTO.OBJETO_BD;
                    objCommand.Parameters.Add(new OracleParameter("I_Operacion", OracleDbType.Varchar2, 200)).Value = auditoriaDTO.OPERACION;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = auditoriaDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_SISTEMA.PR_RptRegistrosAuditoria";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    AuditoriaDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new AuditoriaDTO
                        {
                            ID_REGISTRO = int.Parse(row["ID_REGISTRO"].ToString()),
                            ID_SESION = int.Parse(row["ID_SESION"].ToString()),
                            USUARIO = row["USUARIO"].ToString(),
                            ROL_USR = row["ROL_USR"].ToString(),
                            OBJETO_BD = row["OBJETO_BD"].ToString(),
                            OPERACION = row["OPERACION"].ToString(),
                            DATO_VIEJO = row["DATO_VIEJO"].ToString(),
                            DATO_NUEVO = row["DATO_NUEVO"].ToString(),
                            ORIGEN = row["ORIGEN"].ToString(),
                            TIPO_REGISTRO = row["TIPO_REGISTRO"].ToString(),
                            FECHA_AUD = DateTime.Parse(row["FECHA_AUD"].ToString()),
                        };

                        retorno.Add(registro);
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
            return retorno;
        }
    }
}
