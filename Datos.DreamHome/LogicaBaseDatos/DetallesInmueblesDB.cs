namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Configuration;

    public class DetallesInmueblesDB
    {
        public string CrearDetallesInmueble(DetallesInmueblesDTO detallesInmueblesDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfInmueble", OracleDbType.Decimal)).Value = detallesInmueblesDTO.IDF_INMUEBLE;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfCaracteristica", OracleDbType.Decimal)).Value = detallesInmueblesDTO.IDF_CARACTERISTICA;
                    objCommand.Parameters.Add(new OracleParameter("I_Valor", OracleDbType.Decimal)).Value = detallesInmueblesDTO.VALOR;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = detallesInmueblesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_DETALLES_INMUEBLES.PR_AgregarDetalleInmueble";
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

        public string EditarDetallesInmueble(DetallesInmueblesDTO detallesInmueblesDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdDetalleInmueble", OracleDbType.Decimal)).Value = detallesInmueblesDTO.ID_DETALLE_INMBL;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfInmueble", OracleDbType.Decimal)).Value = detallesInmueblesDTO.IDF_INMUEBLE;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfCaracteristica", OracleDbType.Decimal)).Value = detallesInmueblesDTO.IDF_CARACTERISTICA;
                    objCommand.Parameters.Add(new OracleParameter("I_Valor", OracleDbType.Decimal)).Value = detallesInmueblesDTO.VALOR;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = detallesInmueblesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_DETALLES_INMUEBLES.PR_ModificarDetalleInmueble";

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

        public string EliminarDetallesInmueble(DetallesInmueblesDTO detallesInmueblesDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdDetalleInmueble", OracleDbType.Decimal)).Value = detallesInmueblesDTO.ID_DETALLE_INMBL;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = detallesInmueblesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_DETALLES_INMUEBLES.PR_BorrarDetalleInmueble";

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

        public List<DetallesInmueblesDTO> ListaDetallesInmuebles(DetallesInmueblesDTO detallesInmueblesDTO)
        {
            List<DetallesInmueblesDTO> retorno = new List<DetallesInmueblesDTO>();

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfInmueble", OracleDbType.Decimal)).Value = detallesInmueblesDTO.IDF_INMUEBLE;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = detallesInmueblesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_DetallesInmuebleS.PR_consultarDetallesInmuebles";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    DetallesInmueblesDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new DetallesInmueblesDTO
                        {
                            ID_DETALLE_INMBL = int.Parse(row["ID_DETALLE_INMBL"].ToString()),
                            IDF_INMUEBLE = int.Parse(row["IDF_INMUEBLE"].ToString()),
                            IDF_CARACTERISTICA = int.Parse(row["IDF_CARACTERISTICA"].ToString()),
                            CARACTERISTICA = row["CARACTERISTICA"].ToString(),
                            VALOR = decimal.Parse(row["VALOR"].ToString())
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
