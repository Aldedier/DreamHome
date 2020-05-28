namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Configuration;

    public class HistorialLaboralDB
    {
        public string CrearHistorialLaboral(HistorialLaboralDTO historialLaboralDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfEmpleadoHst", OracleDbType.Decimal)).Value = historialLaboralDTO.IDF_EMPLEADO_HST;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfCargoHst", OracleDbType.Decimal)).Value = historialLaboralDTO.IDF_CARGO_HST;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfOficinaHst", OracleDbType.Decimal)).Value = historialLaboralDTO.IDF_OFCINA_HST;
                    objCommand.Parameters.Add(new OracleParameter("I_VigenteHst", OracleDbType.Decimal)).Value = 1;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = historialLaboralDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_HISTORIAL_LABORAL.PR_AgregarHistorialLaboral";
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

        public string EditarHistorialLaboral(HistorialLaboralDTO historialLaboralDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdHistorialLabrl", OracleDbType.Decimal)).Value = historialLaboralDTO.ID_HISTORIAL_LABRL;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfEmpleadoHst", OracleDbType.Decimal)).Value = historialLaboralDTO.IDF_EMPLEADO_HST;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfCargoHst", OracleDbType.Decimal)).Value = historialLaboralDTO.IDF_CARGO_HST;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfOficinaHst", OracleDbType.Decimal)).Value = historialLaboralDTO.IDF_OFCINA_HST;
                    objCommand.Parameters.Add(new OracleParameter("I_VigenteHst", OracleDbType.Decimal)).Value = 1;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = historialLaboralDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_HISTORIAL_LABORAL.PR_ModificarHistorialLaboral";

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

        public string EliminarHistorialLaboral(HistorialLaboralDTO historialLaboralDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("i_idhistoriallabrl", OracleDbType.Decimal)).Value = historialLaboralDTO.ID_HISTORIAL_LABRL;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = historialLaboralDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_HISTORIAL_LABORAL.PR_BorrarHistorialLaboral";

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

        public List<HistorialLaboralDTO> ListaHistorialLaboral(int _session)
        {
            List<HistorialLaboralDTO> retorno = new List<HistorialLaboralDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_HISTORIAL_LABORAL.PR_ConsultarHistorialLaboral";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    HistorialLaboralDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new HistorialLaboralDTO
                        {
                            ID_HISTORIAL_LABRL = int.Parse(row["ID_HISTORIAL_LABRL"].ToString()),
                            IDF_OFCINA_HST = int.Parse(row["IDF_OFCINA_HST"].ToString()),
                            OFICINA = row["OFICINA"].ToString(),
                            IDF_CARGO_HST = int.Parse(row["IDF_CARGO_HST"].ToString()),
                            CARGO = row["CARGO"].ToString(),
                            IDF_EMPLEADO_HST = int.Parse(row["IDF_EMPLEADO_HST"].ToString()),
                            NOMBRE_RH = row["NOMBRE_RH"].ToString(),
                            FECHA_HST = DateTime.Parse(row["FECHA_HST"].ToString()),
                            VIGENTE_HST = int.Parse(row["VIGENTE_HST"].ToString())
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
            return retorno.Where(x => x.VIGENTE_HST == 1).ToList();
        }
    }
}
