namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Configuration;

    public class InmueblesRegistradosDB
    {
        public string CrearInmueblesRegistrado(InmueblesRegistradosDTO inmueblesRegistradosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfInmueble", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.IDF_INMUEBLE_REG;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfOficina", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.IDF_OFICINA_REG;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfEmpleado", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.IDF_EMPLEADO_REG;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_INMUEBLES_REGISTRADOS.PR_AgregarInmuebleRegstrd";
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

        public string EditarInmueblesRegistrado(InmueblesRegistradosDTO inmueblesRegistradosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfInmuebleReg", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.ID_INMUEBLE_REGISTRADO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfOficina", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.IDF_OFICINA_REG;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfEmpleado", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.IDF_EMPLEADO_REG;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfEstado", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.IDF_ESTADO_REG;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_INMUEBLES_REGISTRADOS.PR_ModificarInmuebleRegstrd";

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

        public string EliminarInmueblesRegistrado(InmueblesRegistradosDTO inmueblesRegistradosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfInmuebleReg", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.ID_INMUEBLE_REGISTRADO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_INMUEBLES_REGISTRADOS.PR_BorrarInmuebleRegstrd";

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

        public List<InmueblesRegistradosDTO> ListaInmueblesRegistrados(InmueblesRegistradosDTO inmueblesRegistradosDTO)
        {
            List<InmueblesRegistradosDTO> retorno = new List<InmueblesRegistradosDTO>();

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfOficina", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.IDF_OFICINA_REG;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfEmpleado", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.IDF_EMPLEADO_REG;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfEstado", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.IDF_ESTADO_REG;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = inmueblesRegistradosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_INMUEBLES_REGISTRADOS.PR_ConsultarInmuebleRegstrd";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    InmueblesRegistradosDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new InmueblesRegistradosDTO
                        {
                            ID_INMUEBLE_REGISTRADO = int.Parse(row["ID_INMUEBLE_REGISTRADO"].ToString()),
                            IDF_INMUEBLE_REG = int.Parse(row["IDF_INMUEBLE_REG"].ToString()),
                            IDF_OFICINA_REG = int.Parse(row["IDF_OFICINA_REG"].ToString()),
                            OFICINA = row["OFICINA"].ToString(),
                            IDF_EMPLEADO_REG = int.Parse(row["IDF_EMPLEADO_REG"].ToString()),
                            NOMBRE_RH = row["NOMBRE_RH"].ToString(),
                            IDF_ESTADO_REG = int.Parse(row["IDF_ESTADO_REG"].ToString()),
                            ESTADO_INMUEBLE = row["ESTADO_INMUEBLE"].ToString(),
                            FECHA_REGISTRO = DateTime.Parse(row["FECHA_REGISTRO"].ToString())
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
            return retorno.Where(x => x.ESTADO_INMUEBLE != "Inactivo").ToList();
        }
    }
}
