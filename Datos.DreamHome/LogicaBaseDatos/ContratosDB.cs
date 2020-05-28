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
  public  class ContratosDB
    {
        public string CrearContrato(ContratosDTO ContratoDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdCliente", OracleDbType.Decimal)).Value = ContratoDTO.IDF_CLIENTE_CNTR;
                    objCommand.Parameters.Add(new OracleParameter("I_IdEmpleado", OracleDbType.Decimal)).Value = ContratoDTO.IDF_INMBL_EMPLD_CNTR;
                    objCommand.Parameters.Add(new OracleParameter("I_FormaPago", OracleDbType.Decimal)).Value = ContratoDTO.IDF_FORMA_PAGO_CNTR;
                    objCommand.Parameters.Add(new OracleParameter("I_EstadoContrato", OracleDbType.Decimal)).Value = ContratoDTO.IDF_ESTADO_CONTRATO;
                    objCommand.Parameters.Add(new OracleParameter("I_CanonMes", OracleDbType.Decimal)).Value = ContratoDTO.CANON_MENSUAL;
                    objCommand.Parameters.Add(new OracleParameter("I_FechaInicio", OracleDbType.Date)).Value = ContratoDTO.FECHA_INICIO;
                    objCommand.Parameters.Add(new OracleParameter("I_FechaFin", OracleDbType.Date)).Value = ContratoDTO.FECHA_FIN;
                    objCommand.Parameters.Add(new OracleParameter("I_Consigna", OracleDbType.Varchar2, 100)).Value = ContratoDTO.CONSIGNAR;

                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = ContratoDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTRATOS.PR_AgregarContrato";
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

        public string EditarContrato(ContratosDTO ContratoDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdContrato", OracleDbType.Decimal)).Value = ContratoDTO.ID_CONTRATO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdCliente", OracleDbType.Decimal)).Value = ContratoDTO.IDF_CLIENTE_CNTR;
                    objCommand.Parameters.Add(new OracleParameter("I_IdEmpleado", OracleDbType.Decimal)).Value = ContratoDTO.IDF_INMBL_EMPLD_CNTR;
                    objCommand.Parameters.Add(new OracleParameter("I_FormaPago", OracleDbType.Decimal)).Value = ContratoDTO.IDF_FORMA_PAGO_CNTR;
                    objCommand.Parameters.Add(new OracleParameter("I_EstadoContrato", OracleDbType.Decimal)).Value = ContratoDTO.IDF_ESTADO_CONTRATO;
                    objCommand.Parameters.Add(new OracleParameter("I_CanonMes", OracleDbType.Decimal)).Value = ContratoDTO.CANON_MENSUAL;
                    objCommand.Parameters.Add(new OracleParameter("I_FechaInicio", OracleDbType.Date)).Value = ContratoDTO.FECHA_INICIO;
                    objCommand.Parameters.Add(new OracleParameter("I_FechaFin", OracleDbType.Date)).Value = ContratoDTO.FECHA_FIN;
                    objCommand.Parameters.Add(new OracleParameter("I_Consigna", OracleDbType.Varchar2, 100)).Value = ContratoDTO.CONSIGNAR;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = ContratoDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTRATOS.PR_ModificarContrato";

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

        public string EliminarContrato(ContratosDTO ContratoDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdContrato", OracleDbType.Decimal)).Value = ContratoDTO.ID_CONTRATO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = ContratoDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTRATOS.PR_BorrarContrato";

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

        public List<ContratosDTO> ListaContratos(int _session)
        {
            List<ContratosDTO> retorno = new List<ContratosDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTRATOS.PR_ConsultarContrato";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    ContratosDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new ContratosDTO
                        {

                            ID_CONTRATO = int.Parse(row["ID_CONTRATO"].ToString()),
                            IDF_CLIENTE_CNTR = int.Parse(row["IDF_CLIENTE_CNTR"].ToString()),
                            IDF_INMBL_EMPLD_CNTR = int.Parse(row["IDF_INMBL_EMPLD_CNTR"].ToString()),
                            IDF_FORMA_PAGO_CNTR = int.Parse(row["IDF_FORMA_PAGO_CNTR"].ToString()),
                            IDF_ESTADO_CONTRATO = int.Parse(row["IDF_ESTADO_CONTRATO"].ToString()),
                            CANON_MENSUAL = int.Parse(row["CANON_MENSUAL"].ToString()),
                            FECHA_INICIO = DateTime.Parse(row["FECHA_INICIO"].ToString()),
                            FECHA_FIN = DateTime.Parse(row["FECHA_FIN"].ToString()),
                            CONSIGNAR = row["CONSIGNAR"].ToString()

                   
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
