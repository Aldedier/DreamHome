namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Configuration;

    public class InmueblesPropietariosDB
    {
        public string CrearInmueblesPropietario(InmueblesPropietariosDTO inmueblesPropietariosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfInmueble", OracleDbType.Decimal)).Value = inmueblesPropietariosDTO.IDF_INMUEBLE_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfPropietario", OracleDbType.Decimal)).Value = inmueblesPropietariosDTO.IDF_PROPIETARIO_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_Fecha", OracleDbType.Date)).Value = inmueblesPropietariosDTO.FECHA_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = inmueblesPropietariosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_INMUEBLES_PROPIETARIOS.PR_AgregarInmueblePropietario";
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

        public string EditarInmueblesPropietario(InmueblesPropietariosDTO inmueblesPropietariosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdInmueblePropietario", OracleDbType.Decimal)).Value = inmueblesPropietariosDTO.ID_INMUEBLE_PROPIETARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfInmueble", OracleDbType.Decimal)).Value = inmueblesPropietariosDTO.IDF_INMUEBLE_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfPropietario", OracleDbType.Decimal)).Value = inmueblesPropietariosDTO.IDF_PROPIETARIO_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_Fecha", OracleDbType.Date)).Value = inmueblesPropietariosDTO.FECHA_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = inmueblesPropietariosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_INMUEBLES_PROPIETARIOS.PR_ModificarInmueblePropietario";

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

        public string EliminarInmueblesPropietario(InmueblesPropietariosDTO inmueblesPropietariosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdInmueblePropietario", OracleDbType.Decimal)).Value = inmueblesPropietariosDTO.ID_INMUEBLE_PROPIETARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = inmueblesPropietariosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_INMUEBLES_PROPIETARIOS.PR_BorrarInmueblePropietario";

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

        public List<InmueblesPropietariosDTO> ListaInmueblesPropietarios(int _session)
        {
            List<InmueblesPropietariosDTO> retorno = new List<InmueblesPropietariosDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_INMUEBLES_PROPIETARIOS.PR_ConsultarInmueblesPropietarios";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    InmueblesPropietariosDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new InmueblesPropietariosDTO
                        {
                            ID_INMUEBLE_PROPIETARIO = int.Parse(row["ID_INMUEBLE_PROPIETARIO"].ToString()),
                            IDF_INMUEBLE_PROP = int.Parse(row["IDF_INMUEBLE_PROP"].ToString()),
                            IDF_PROPIETARIO_PROP = int.Parse(row["IDF_PROPIETARIO_PROP"].ToString()),
                            INMUEBLE = row["INMUEBLE"].ToString(),
                            FECHA_PROP = DateTime.Parse(row["FECHA_PROP"].ToString())
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
