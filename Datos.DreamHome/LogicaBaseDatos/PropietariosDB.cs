namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Configuration;

    public class PropietariosDB
    {
        public string CrearPropietario(PropietariosDTO propietariosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfUsuario", OracleDbType.Decimal)).Value = propietariosDTO.IDF_USUARIO_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_Nombre", OracleDbType.Varchar2, 200)).Value = propietariosDTO.NOMBRE_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_Direccion", OracleDbType.Varchar2, 200)).Value = propietariosDTO.DIRECCION_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_Apartado", OracleDbType.Varchar2, 200)).Value = propietariosDTO.APARTADO_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_Activo", OracleDbType.Decimal)).Value = 1;
                    objCommand.Parameters.Add(new OracleParameter("I_Fecha", OracleDbType.Date)).Value = DateTime.Now;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = propietariosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_PROPIETARIOS.PR_AgregarPropietario";
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

        public string EditarPropietario(PropietariosDTO propietariosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdPropietario", OracleDbType.Decimal)).Value = propietariosDTO.ID_PROPIETARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfUsuario", OracleDbType.Decimal)).Value = propietariosDTO.IDF_USUARIO_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_Nombre", OracleDbType.Varchar2, 200)).Value = propietariosDTO.NOMBRE_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_Direccion", OracleDbType.Varchar2, 200)).Value = propietariosDTO.DIRECCION_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_Apartado", OracleDbType.Varchar2, 200)).Value = propietariosDTO.APARTADO_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_Activo", OracleDbType.Decimal)).Value = 1;
                    objCommand.Parameters.Add(new OracleParameter("I_Fecha", OracleDbType.Date)).Value = DateTime.Now;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = propietariosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_PROPIETARIOS.PR_ModificarPropietario";

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

        public string EliminarPropietario(PropietariosDTO propietariosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdPropietario", OracleDbType.Decimal)).Value = propietariosDTO.ID_PROPIETARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = propietariosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_PROPIETARIOS.PR_BorrarPropietario";

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

        public List<PropietariosDTO> ListaPropietarios(int _session)
        {
            List<PropietariosDTO> retorno = new List<PropietariosDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_PROPIETARIOS.PR_ConsultarPropietarios";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    PropietariosDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new PropietariosDTO
                        {
                            ID_PROPIETARIO = int.Parse(row["ID_PROPIETARIO"].ToString()),
                            NOMBRE_PROP = row["NOMBRE_PROP"].ToString(),
                            APARTADO_PROP = row["APARTADO_PROP"].ToString(),
                            ACTIVO_PROP = int.Parse(row["ACTIVO_PROP"].ToString()),
                            DIRECCION_PROP = row["DIRECCION_PROP"].ToString(),
                            USUARIO = row["USUARIO"].ToString(),
                            FECHA_PROP = DateTime.Parse(row["FECHA_PROP"].ToString()),
                            IDF_USUARIO_PROP = int.Parse(row["IDF_USUARIO_PROP"].ToString())
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
            return retorno.Where(x => x.ACTIVO_PROP != 0).ToList();
        }
    }
}
