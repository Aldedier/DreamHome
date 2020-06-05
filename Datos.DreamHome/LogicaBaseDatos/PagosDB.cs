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
   public class PagosDB
    {
        public string CrearPago(PagosDTO pagosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdContrato", OracleDbType.Decimal)).Value = pagosDTO.IDF_CONTRATO_PG;
                    objCommand.Parameters.Add(new OracleParameter("I_FechaPago", OracleDbType.Date)).Value = pagosDTO.FECHA_PAGO;
                    objCommand.Parameters.Add(new OracleParameter("I_ValorPago", OracleDbType.Varchar2, 100)).Value = pagosDTO.VALOR_PAGO;
                    objCommand.Parameters.Add(new OracleParameter("I_Observacion", OracleDbType.Varchar2, 100)).Value = pagosDTO.OBSERVACION;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = pagosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_PAGOS.PR_AgregarPago";
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

        public string EditarPago(PagosDTO pagosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdPago", OracleDbType.Decimal)).Value = pagosDTO.ID_PAGO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdContrato", OracleDbType.Decimal)).Value = pagosDTO.IDF_CONTRATO_PG;
                    objCommand.Parameters.Add(new OracleParameter("I_FechaPago", OracleDbType.Date)).Value = pagosDTO.FECHA_PAGO;
                    objCommand.Parameters.Add(new OracleParameter("I_ValorPago", OracleDbType.Varchar2, 100)).Value = pagosDTO.VALOR_PAGO;
                    objCommand.Parameters.Add(new OracleParameter("I_Observacion", OracleDbType.Varchar2, 100)).Value = pagosDTO.OBSERVACION;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = pagosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_PAGOS.PR_ModificarPago";

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

        public string EliminarPago(PagosDTO pagosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdPago", OracleDbType.Decimal)).Value = pagosDTO.ID_PAGO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = pagosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_PAGOS.PR_BorrarPago";

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
        public List<PagosDTO> ListaPagos(int _session)
        {
            List<PagosDTO> retorno = new List<PagosDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_PAGOS.PR_ConsultarPago";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    PagosDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new PagosDTO
                        {
                            ID_PAGO = int.Parse(row["ID_PAGO"].ToString()),
                            IDF_CONTRATO_PG = int.Parse(row["IDF_CONTRATO_PG"].ToString()),
                            FECHA_PAGO = DateTime.Parse(row["FECHA_PAGO"].ToString()),
                            VALOR_PAGO = int.Parse(row["VALOR_PAGO"].ToString()),
                            OBSERVACION = row["OBSERVACION"].ToString()
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
