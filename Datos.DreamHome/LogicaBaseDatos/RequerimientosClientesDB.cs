namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Configuration;

    public class RequerimientosClientesDB
    {
        public string CrearRequerimientosCliente(RequerimientosClientesDTO requerimientosClientesDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("requerimiento", OracleDbType.Varchar2, 200)).Value = requerimientosClientesDTO.REQUERIMIENTO;
                    objCommand.Parameters.Add(new OracleParameter("idf_cliente_rqrm", OracleDbType.Decimal)).Value = requerimientosClientesDTO.IDF_CLIENTE_RQRM;
                    objCommand.Parameters.Add(new OracleParameter("idf_oficina_rqrm", OracleDbType.Decimal)).Value = requerimientosClientesDTO.IDF_OFICINA_RQRM;
                    objCommand.Parameters.Add(new OracleParameter("idf_empleado_rqrm", OracleDbType.Decimal)).Value = requerimientosClientesDTO.IDF_EMPLEADO_RQRM;
                    objCommand.Parameters.Add(new OracleParameter("idf_tipo_rqrm", OracleDbType.Decimal)).Value = requerimientosClientesDTO.IDF_TIPO_RQRM;
                    objCommand.Parameters.Add(new OracleParameter("idf_estado_rqrm", OracleDbType.Decimal)).Value = requerimientosClientesDTO.IDF_ESTADO_RQRM;
                    objCommand.Parameters.Add(new OracleParameter("fecha_rqrm", OracleDbType.Date)).Value = DateTime.Now;
                    objCommand.Parameters.Add(new OracleParameter("i_idfsesion", OracleDbType.Decimal)).Value = requerimientosClientesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("o_salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.pkg_requerimientos_clientes.PR_AgregarReqrmntClint";
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

        public string EditarRequerimientosCliente(RequerimientosClientesDTO requerimientosClientesDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("id_requerimiento", OracleDbType.Decimal)).Value = requerimientosClientesDTO.ID_REQUERIMIENTO;
                    objCommand.Parameters.Add(new OracleParameter("requerimiento", OracleDbType.Varchar2, 200)).Value = requerimientosClientesDTO.REQUERIMIENTO;
                    objCommand.Parameters.Add(new OracleParameter("idf_cliente_rqrm", OracleDbType.Decimal)).Value = requerimientosClientesDTO.IDF_CLIENTE_RQRM;
                    objCommand.Parameters.Add(new OracleParameter("idf_oficina_rqrm", OracleDbType.Decimal)).Value = requerimientosClientesDTO.IDF_OFICINA_RQRM;
                    objCommand.Parameters.Add(new OracleParameter("idf_empleado_rqrm", OracleDbType.Decimal)).Value = requerimientosClientesDTO.IDF_EMPLEADO_RQRM;
                    objCommand.Parameters.Add(new OracleParameter("idf_tipo_rqrm", OracleDbType.Decimal)).Value = requerimientosClientesDTO.IDF_TIPO_RQRM;
                    objCommand.Parameters.Add(new OracleParameter("idf_estado_rqrm", OracleDbType.Decimal)).Value = requerimientosClientesDTO.IDF_ESTADO_RQRM;
                    objCommand.Parameters.Add(new OracleParameter("fecha_rqrm", OracleDbType.Date)).Value = DateTime.Now;
                    objCommand.Parameters.Add(new OracleParameter("i_idfsesion", OracleDbType.Decimal)).Value = requerimientosClientesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("o_salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.pkg_requerimientos_clientes.pr_ModificarReqrmntClint";

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

        public string EliminarRequerimientosCliente(RequerimientosClientesDTO requerimientosClientesDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("id_requerimiento", OracleDbType.Decimal)).Value = requerimientosClientesDTO.ID_REQUERIMIENTO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = requerimientosClientesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.pkg_requerimientos_clientes.PR_BorrarReqrmntClint";

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

        public List<RequerimientosClientesDTO> ListaRequerimientosClientes(int _session)
        {
            List<RequerimientosClientesDTO> retorno = new List<RequerimientosClientesDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.pkg_requerimientos_clientes.PR_ConsultarReqrmntClint";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    RequerimientosClientesDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new RequerimientosClientesDTO
                        {
                            ID_REQUERIMIENTO = int.Parse(row["ID_REQUERIMIENTO"].ToString()),
                            REQUERIMIENTO = row["REQUERIMIENTO"].ToString(),
                            NOMBRE_CLINT = row["NOMBRE_CLINT"].ToString(),
                            OFICINA = row["OFICINA"].ToString(),
                            NOMBRE_RH = row["NOMBRE_RH"].ToString(),
                            NOMBRE_TIPO = row["NOMBRE_TIPO"].ToString(),
                            ESTADO_REQUERIMIENTO = row["ESTADO_REQUERIMIENTO"].ToString(),
                            FECHA_RQRM = DateTime.Parse(row["FECHA_RQRM"].ToString())
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
            return retorno.Where(x => x.ESTADO_REQUERIMIENTO != "Inactivo").ToList();
        }
    }
}
