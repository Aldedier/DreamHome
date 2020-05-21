namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Configuration;

    public class EmpleadosDB
    {
        public string CrearEmpleado(EmpleadosDTO empleadosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfUsuarioRh", OracleDbType.Decimal)).Value = empleadosDTO.IDF_USUARIO_RH;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfGeneroRh", OracleDbType.Varchar2, 200)).Value = empleadosDTO.IDF_GENERO_RH;
                    objCommand.Parameters.Add(new OracleParameter("I_NombreRh", OracleDbType.Varchar2, 200)).Value = empleadosDTO.NOMBRE_RH;
                    objCommand.Parameters.Add(new OracleParameter("I_DireccionRh", OracleDbType.Varchar2, 200)).Value = empleadosDTO.DIRECCION_RH;
                    objCommand.Parameters.Add(new OracleParameter("I_ApartadoRh", OracleDbType.Decimal)).Value = empleadosDTO.APARTADO_RH;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = empleadosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_empleadoS.PR_AgregarEmpleados";
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

        public string EditarEmpleado(EmpleadosDTO empleadosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdEmpleado", OracleDbType.Decimal)).Value = empleadosDTO.ID_EMPLEADO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfUsuarioRh", OracleDbType.Decimal)).Value = empleadosDTO.IDF_USUARIO_RH;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfGeneroRh", OracleDbType.Varchar2, 200)).Value = empleadosDTO.IDF_GENERO_RH;
                    objCommand.Parameters.Add(new OracleParameter("I_NombreRh", OracleDbType.Varchar2, 200)).Value = empleadosDTO.NOMBRE_RH;
                    objCommand.Parameters.Add(new OracleParameter("I_DireccionRh", OracleDbType.Varchar2, 200)).Value = empleadosDTO.DIRECCION_RH;
                    objCommand.Parameters.Add(new OracleParameter("I_ApartadoRh", OracleDbType.Decimal)).Value = empleadosDTO.APARTADO_RH;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = empleadosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_empleadoS.PR_ModificarEmpleados";

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

        public string EliminarEmpleado(EmpleadosDTO empleadosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdEmpleado", OracleDbType.Decimal)).Value = empleadosDTO.ID_EMPLEADO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = empleadosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_empleadoS.PR_BorrarEmpleados";

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

        public List<EmpleadosDTO> ListaEmpleados(int _session)
        {
            List<EmpleadosDTO> retorno = new List<EmpleadosDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_empleadoS.PR_consultarempleados";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    EmpleadosDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new EmpleadosDTO
                        {
                            ID_EMPLEADO = int.Parse(row["ID_EMPLEADO"].ToString()),
                            IDF_USUARIO_RH = int.Parse(row["IDF_USUARIO_RH"].ToString()),
                            IDF_GENERO_RH = row["IDF_GENERO_RH"].ToString(),
                            NOMBRE_RH = row["NOMBRE_RH"].ToString(),
                            DIRECCION_RH = row["DIRECCION_RH"].ToString(),
                            APARTADO_RH = row["APARTADO_RH"].ToString(),
                            FECHA_RH = DateTime.Parse(row["FECHA_RH"].ToString()),
                            ACTIVO_RH = int.Parse(row["ACTIVO_RH"].ToString())
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
