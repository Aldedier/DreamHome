namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Configuration;

    public class ContactosOficinasDB
    {
        public string CrearContactosOficina(ContactosOficinasDTO contactosOficinaDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfOfcinaCntc", OracleDbType.Decimal)).Value = contactosOficinaDTO.IDF_OFICINA_CNTC;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfTipoCntcOfc", OracleDbType.Decimal)).Value = contactosOficinaDTO.IDF_TIPO_CNTC_OFC;
                    objCommand.Parameters.Add(new OracleParameter("I_DatoCntctOfc", OracleDbType.Varchar2, 200)).Value = contactosOficinaDTO.DATO_CNTCT_OFC;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = contactosOficinaDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_OFICINAS.PR_AgregarContactosOficinas";
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

        public string EditarContactosOficina(ContactosOficinasDTO contactosOficinaDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdContactoOficina", OracleDbType.Decimal)).Value = contactosOficinaDTO.ID_CONTACTO_OFICINA;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfOfcinaCntc", OracleDbType.Decimal)).Value = contactosOficinaDTO.IDF_OFICINA_CNTC;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfTipoCntcOfc", OracleDbType.Decimal)).Value = contactosOficinaDTO.IDF_TIPO_CNTC_OFC;
                    objCommand.Parameters.Add(new OracleParameter("I_DatoCntctOfc", OracleDbType.Varchar2, 200)).Value = contactosOficinaDTO.DATO_CNTCT_OFC;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = contactosOficinaDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_OFICINAS.PR_ModificarContactosOficinas";

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

        public string EliminarContactosOficina(ContactosOficinasDTO contactosOficinaDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdContactoOficina", OracleDbType.Decimal)).Value = contactosOficinaDTO.ID_CONTACTO_OFICINA;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = contactosOficinaDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_OFICINAS.PR_BorrarContactosOficinas";

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

        public List<ContactosOficinasDTO> ListaContactosOficina(int _session)
        {
            List<ContactosOficinasDTO> retorno = new List<ContactosOficinasDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_OFICINAS.PR_ConsultarContactosOficinas";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    ContactosOficinasDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new ContactosOficinasDTO
                        {
                            ID_CONTACTO_OFICINA = int.Parse(row["ID_CONTACTO_OFICINA"].ToString()),
                            TIPO_CONTACTO = row["TIPO_CONTACTO"].ToString(),
                            DATO_CNTCT_OFC = row["DATO_CNTCT_OFC"].ToString(),
                            IDF_OFICINA_CNTC = int.Parse(row["IDF_OFICINA_CNTC"].ToString()),
                            OFICINA = row["OFICINA"].ToString(),
                            IDF_TIPO_CNTC_OFC = int.Parse(row["IDF_TIPO_CNTC_OFC"].ToString())
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
