namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Configuration;

    public class ContactosEmpleadosDB
    {
        public string CrearContactosEmpleado(ContactosEmpleadosDTO contactosEmpleadosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfEmpleadoCntct", OracleDbType.Decimal)).Value = contactosEmpleadosDTO.IDF_EMPLEADO_CNTCT;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfTipoContactoCntct", OracleDbType.Decimal)).Value = contactosEmpleadosDTO.IDF_TIPO_CONTACTO_CNTCT;
                    objCommand.Parameters.Add(new OracleParameter("I_DatoCntctEmp", OracleDbType.Varchar2, 200)).Value = contactosEmpleadosDTO.DATO_CNTCT_EMP;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = contactosEmpleadosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_EMPLEADOS.PR_AgregarContactosEmpleados";
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

        public string EditarContactosEmpleado(ContactosEmpleadosDTO contactosEmpleadosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdContactoEmpleado", OracleDbType.Decimal)).Value = contactosEmpleadosDTO.ID_CONTACTO_EMPLEADO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfEmpleadoCntct", OracleDbType.Decimal)).Value = contactosEmpleadosDTO.IDF_EMPLEADO_CNTCT;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfTipoContactoCntct", OracleDbType.Decimal)).Value = contactosEmpleadosDTO.IDF_TIPO_CONTACTO_CNTCT;
                    objCommand.Parameters.Add(new OracleParameter("I_DatoCntctEmp", OracleDbType.Varchar2, 200)).Value = contactosEmpleadosDTO.DATO_CNTCT_EMP;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = contactosEmpleadosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_EMPLEADOS.PR_ModificarContactosEmpleados";

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

        public string EliminarContactosEmpleado(ContactosEmpleadosDTO contactosEmpleadosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdContactoEmpleado", OracleDbType.Decimal)).Value = contactosEmpleadosDTO.ID_CONTACTO_EMPLEADO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = contactosEmpleadosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_EMPLEADOS.PR_BorrarContactosEmpleados";

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

        public List<ContactosEmpleadosDTO> ListaContactosEmpleado(int _session)
        {
            List<ContactosEmpleadosDTO> retorno = new List<ContactosEmpleadosDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_EMPLEADOS.PR_ConsultarContactosEmpleados";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    ContactosEmpleadosDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new ContactosEmpleadosDTO
                        {
                            ID_CONTACTO_EMPLEADO = int.Parse(row["ID_CONTACTO_EMPLEADO"].ToString()),
                            TIPO_CONTACTO = row["TIPO_CONTACTO"].ToString(),
                            DATO_CNTCT_EMP = row["DATO_CNTCT_EMP"].ToString(),
                            IDF_EMPLEADO_CNTCT = int.Parse(row["IDF_EMPLEADO_CNTCT"].ToString()),
                            NOMBRE_RH = row["NOMBRE_RH"].ToString(),
                            IDF_TIPO_CONTACTO_CNTCT = int.Parse(row["IDF_TIPO_CONTACTO_CNTCT"].ToString())
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
