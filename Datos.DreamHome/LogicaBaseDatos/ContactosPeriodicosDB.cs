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
   public class ContactosPeriodicosDB
    {
        public string CrearContactosPeriodicos(ContactosPeriodicoDTO contactosPeriodicoDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdPeriodico", OracleDbType.Decimal)).Value = contactosPeriodicoDTO.IDF_PERIODICO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdTipoContacto", OracleDbType.Decimal)).Value = contactosPeriodicoDTO.IDF_TIPO_CONTACTO;
                    objCommand.Parameters.Add(new OracleParameter("I_DatoContactoPeriodico", OracleDbType.Varchar2, 100)).Value = contactosPeriodicoDTO.DATO_CONTCT;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = contactosPeriodicoDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_PERIODICOS.PR_AgregarContactoPeriodico";
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

        public string EditarContactosPeriodicos(ContactosPeriodicoDTO contactosPeriodicoDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdContactoPeriodico", OracleDbType.Decimal)).Value = contactosPeriodicoDTO.ID_CONTACTO_PERIODICO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdPeriodico", OracleDbType.Decimal)).Value = contactosPeriodicoDTO.IDF_PERIODICO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdTipoContacto", OracleDbType.Decimal)).Value = contactosPeriodicoDTO.IDF_TIPO_CONTACTO;
                    objCommand.Parameters.Add(new OracleParameter("I_DatoContactoPeriodico", OracleDbType.Varchar2, 100)).Value = contactosPeriodicoDTO.DATO_CONTCT;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = contactosPeriodicoDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_PERIODICOS.PR_ModificarContactoPeriodico";

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

        public string EliminarContactosPeriodicos(ContactosPeriodicoDTO contactosPeriodicoDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdContactoPeriodico", OracleDbType.Decimal)).Value = contactosPeriodicoDTO.ID_CONTACTO_PERIODICO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = contactosPeriodicoDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_PERIODICOS.PR_BorrarContactoPeriodico";

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
        public List<ContactosPeriodicoDTO> ListaContactosPeriodicos(int _session)
        {
            List<ContactosPeriodicoDTO> retorno = new List<ContactosPeriodicoDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_PERIODICOS.PR_ConsultarContactoPeriodico";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    ContactosPeriodicoDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new ContactosPeriodicoDTO
                        {

                            ID_CONTACTO_PERIODICO = int.Parse(row["ID_CONTACTO_PERIODICO"].ToString()),
                            IDF_PERIODICO = int.Parse(row["IDF_PERIODICO"].ToString()),
                            IDF_TIPO_CONTACTO = int.Parse(row["IDF_TIPO_CONTACTO"].ToString()),
                            DATO_CONTCT = row["DATO_CONTCT"].ToString(),
                            NOMBRE_PERIODICO = row["NOMBRE_PERIODICO"].ToString(),
                            TIPO_CONTACTO = row["TIPO_CONTACTO"].ToString()


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
