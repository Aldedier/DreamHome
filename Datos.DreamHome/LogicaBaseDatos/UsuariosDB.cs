using Comun.DreamHome;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Datos.DreamHome.LogicaBaseDatos
{
   public class UsuariosDB
    {

        public string CrearUsuarios(UsuariosDTO usuarioDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_Usuario", OracleDbType.Varchar2)).Value = usuarioDTO.USUARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_NombreUsuario", OracleDbType.Varchar2)).Value = usuarioDTO.NOMBRE_USR;
                    objCommand.Parameters.Add(new OracleParameter("I_IdRol", OracleDbType.Decimal)).Value = usuarioDTO.IDF_ROL_USR;
                    objCommand.Parameters.Add(new OracleParameter("I_Clave", OracleDbType.Varchar2)).Value = usuarioDTO.CLAVE; 
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = usuarioDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_USUARIOS.PR_AgregarUsuario";
                    objCommand.ExecuteNonQuery();

                    resultado = objCommand.Parameters["O_Salida"].Value.ToString();
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

            return (resultado);
        }

        public string EditaUsuarios(UsuariosDTO usuarioDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdUsuario", OracleDbType.Decimal)).Value = usuarioDTO.ID_USUARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_Usuario", OracleDbType.Varchar2)).Value = usuarioDTO.USUARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_NombreUsuario", OracleDbType.Varchar2)).Value = usuarioDTO.NOMBRE_USR;
                    objCommand.Parameters.Add(new OracleParameter("I_IdRol", OracleDbType.Decimal)).Value = usuarioDTO.IDF_ROL_USR;
                    objCommand.Parameters.Add(new OracleParameter("I_Clave", OracleDbType.Varchar2)).Value = usuarioDTO.CLAVE;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = usuarioDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_USUARIOS.PR_ModificarUsuario";

                    objCommand.ExecuteNonQuery();
                    resultado = objCommand.Parameters["O_Salida"].Value.ToString();
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

            return (resultado);
        }

        public string EliminaUsuarios(UsuariosDTO usuarioDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdUsuario", OracleDbType.Decimal)).Value = usuarioDTO.ID_USUARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = usuarioDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_USUARIOS.PR_BorrarUsuario";

                    objCommand.ExecuteNonQuery();
                    resultado = objCommand.Parameters["O_Salida"].Value.ToString();
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

            return (resultado);
        }

        public List<UsuariosDTO> ListaUsuarios(int _session)
        {
            List<UsuariosDTO> retorno = new List<UsuariosDTO>();

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = _session;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_USUARIOS.PR_ConsultarUsuario";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    UsuariosDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new UsuariosDTO

                        {
                            ID_USUARIO = int.Parse(row["ID_USUARIO"].ToString()),
                            USUARIO = row["USUARIO"].ToString(),
                            NOMBRE_USR = row["NOMBRE_USR"].ToString(),
                            IDF_ROL_USR = int.Parse(row["IDF_ROL_USR"].ToString()),
                            CLAVE = row["CLAVE"].ToString(),
                            FECHA_USR = DateTime.Parse(row["FECHA_USR"].ToString()),
                            ROL_USUARIO = row["ROL_USUARIO"].ToString()

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
            return retorno.ToList();
        }
    }
}
