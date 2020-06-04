namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Configuration;

    public class OficinasDB
    {
        public string CrearOficina(OficinasDTO oficinasDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_Oficina", OracleDbType.Varchar2, 200)).Value = oficinasDTO.OFICINA;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfCiudad", OracleDbType.Decimal)).Value = oficinasDTO.IDF_CIUDAD_OFC;
                    objCommand.Parameters.Add(new OracleParameter("I_DireccionOfc", OracleDbType.Varchar2, 200)).Value = oficinasDTO.DIRECCION_OFC;
                    objCommand.Parameters.Add(new OracleParameter("I_ApartadoOfc", OracleDbType.Varchar2, 200)).Value = oficinasDTO.APARTADO_OFC;
                    objCommand.Parameters.Add(new OracleParameter("I_ActivoOfc", OracleDbType.Decimal)).Value = 1;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = oficinasDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_OFICINAS.PR_AgregarOficina";
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

        public string EditarOficina(OficinasDTO oficinasDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdOficina", OracleDbType.Decimal)).Value = oficinasDTO.ID_OFICINA;
                    objCommand.Parameters.Add(new OracleParameter("I_Oficina", OracleDbType.Varchar2, 100)).Value = oficinasDTO.OFICINA;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfCiudad", OracleDbType.Decimal)).Value = oficinasDTO.IDF_CIUDAD_OFC;
                    objCommand.Parameters.Add(new OracleParameter("I_DireccionOfc", OracleDbType.Varchar2, 200)).Value = oficinasDTO.DIRECCION_OFC;
                    objCommand.Parameters.Add(new OracleParameter("I_ApartadoOfc", OracleDbType.Varchar2, 100)).Value = oficinasDTO.APARTADO_OFC;
                    objCommand.Parameters.Add(new OracleParameter("I_ActivoOfc", OracleDbType.Decimal)).Value = 1;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = oficinasDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_OFICINAS.PR_ModificarOficina";

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

        public string EliminarOficina(OficinasDTO oficinasDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdOficina", OracleDbType.Decimal)).Value = oficinasDTO.ID_OFICINA;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = oficinasDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_OFICINAS.PR_BorrarOficina";

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

        public List<OficinasDTO> ListaOficinas(int _session)
        {
            List<OficinasDTO> retorno = new List<OficinasDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_OFICINAS.PR_ConsultarOficina";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    OficinasDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new OficinasDTO
                        {
                            ID_OFICINA = int.Parse(row["ID_OFICINA"].ToString()),
                            CIUDAD = row["CIUDAD"].ToString(),
                            APARTADO_OFC = row["APARTADO_OFC"].ToString(),
                            ACTIVO_OFC = int.Parse(row["ACTIVO_OFC"].ToString()),
                            DIRECCION_OFC = row["DIRECCION_OFC"].ToString(),
                            ESTADO_OFC = row["ESTADO_OFC"].ToString(),
                            IDF_CIUDAD_OFC = int.Parse(row["IDF_CIUDAD_OFC"].ToString()),
                            OFICINA = row["OFICINA"].ToString()
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
            return retorno.Where(x => x.ACTIVO_OFC == 1).ToList();
        }

        public List<HistorialLaboralDTO> ReporteOficinasEmpleados(HistorialLaboralDTO historialLaboralDTO)
        {
            List<HistorialLaboralDTO> retorno = new List<HistorialLaboralDTO>();

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_Oficina", OracleDbType.Varchar2, 200)).Value = historialLaboralDTO.OFICINA;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = historialLaboralDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_OFICINAS.PR_RptOficinasEmpleados";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    HistorialLaboralDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new HistorialLaboralDTO
                        {
                            OFICINA = row["OFICINA"].ToString(),
                            CARGO = row["CARGO"].ToString(),
                            NOMBRE_RH = row["NOMBRE_RH"].ToString(),
                            FECHA_HST = DateTime.Parse(row["FECHA_HST"].ToString()),
                            VIGENTE_HST = int.Parse(row["VIGENTE_HST"].ToString()),
                            ESTADO_HST = row["ESTADO_HST"].ToString()
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
