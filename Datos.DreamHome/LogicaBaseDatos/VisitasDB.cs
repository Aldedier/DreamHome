namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Configuration;

    public class VisitasDB
    {
        public string CrearVisita(VisitasDTO visitasDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfInmuebleReg", OracleDbType.Decimal)).Value = visitasDTO.IDF_INMUEBLE_REG_VST;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfCliente", OracleDbType.Decimal)).Value = visitasDTO.IDF_CLIENTE_VST;
                    objCommand.Parameters.Add(new OracleParameter("I_Comentario", OracleDbType.Varchar2, 200)).Value = visitasDTO.COMENTARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_Fecha", OracleDbType.Date)).Value = visitasDTO.FECHA_VST;
                    objCommand.Parameters.Add(new OracleParameter("I_Hora", OracleDbType.Varchar2, 200)).Value = visitasDTO.FECHA_VST.Hour;
                    objCommand.Parameters.Add(new OracleParameter("I_Realizada", OracleDbType.Decimal)).Value = 0;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = visitasDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_VISITAS.PR_AgregarVisita";
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

        public string EditarVisita(VisitasDTO visitasDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdVisita", OracleDbType.Decimal)).Value = visitasDTO.ID_VISITA;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfInmuebleReg", OracleDbType.Decimal)).Value = visitasDTO.IDF_INMUEBLE_REG_VST;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfCliente", OracleDbType.Decimal)).Value = visitasDTO.IDF_CLIENTE_VST;
                    objCommand.Parameters.Add(new OracleParameter("I_Comentario", OracleDbType.Varchar2, 200)).Value = visitasDTO.COMENTARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_Fecha", OracleDbType.Date)).Value = visitasDTO.FECHA_VST;
                    objCommand.Parameters.Add(new OracleParameter("I_Hora", OracleDbType.Varchar2, 200)).Value = visitasDTO.FECHA_VST.Hour;
                    objCommand.Parameters.Add(new OracleParameter("I_Realizada", OracleDbType.Decimal)).Value = visitasDTO.REALIZADA;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = visitasDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_VISITAS.PR_ModificarVisita";

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

        public string EliminarVisita(VisitasDTO visitasDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdVisita", OracleDbType.Decimal)).Value = visitasDTO.ID_VISITA;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = visitasDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_VISITAS.PR_BorrarVisita";

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

        public List<VisitasDTO> ListaVisitas(int _session)
        {
            List<VisitasDTO> retorno = new List<VisitasDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_VISITAS.PR_ConsultarVisitas";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    VisitasDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new VisitasDTO
                        {
                            ID_VISITA = int.Parse(row["ID_VISITA"].ToString()),
                            CLIENTE = row["CLIENTE"].ToString(),
                            COMENTARIO = row["COMENTARIO"].ToString(),
                            IDF_CLIENTE_VST = int.Parse(row["IDF_CLIENTE_VST"].ToString()),
                            FECHA_VST = DateTime.Parse(row["FECHA_VST"].ToString()),
                            HORA_VST = DateTime.Parse(row["HORA_VST"].ToString()),
                            IDF_INMUEBLE_REG_VST = int.Parse(row["IDF_INMUEBLE_REG_VST"].ToString()),
                            INMUEBLE = row["INMUEBLE"].ToString()
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
