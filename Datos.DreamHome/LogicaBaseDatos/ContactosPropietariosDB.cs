namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Configuration;

    public class ContactosPropietariosDB
    {
        public string CrearContactosPropietario(ContactosPropietariosDTO contactosPropietarioDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfPropietario", OracleDbType.Decimal)).Value = contactosPropietarioDTO.IDF_PROPIETARIO_CNTCT;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfTipoContacto", OracleDbType.Decimal)).Value = contactosPropietarioDTO.IDF_TIPO_CONTACTO_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_Dato", OracleDbType.Varchar2, 200)).Value = contactosPropietarioDTO.DATO_CNTCT_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = contactosPropietarioDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_PROPIETARIOS.PR_AgregarContactoPropietario";
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

        public string EditarContactosPropietario(ContactosPropietariosDTO contactosPropietarioDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdContactoPropietario", OracleDbType.Decimal)).Value = contactosPropietarioDTO.ID_CONTACTO_PROPIETARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfPropietario", OracleDbType.Decimal)).Value = contactosPropietarioDTO.IDF_PROPIETARIO_CNTCT;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfTipoContacto", OracleDbType.Decimal)).Value = contactosPropietarioDTO.IDF_TIPO_CONTACTO_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_Dato", OracleDbType.Varchar2, 200)).Value = contactosPropietarioDTO.DATO_CNTCT_PROP;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = contactosPropietarioDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_PROPIETARIOS.PR_ModificarContactoPropietario";

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

        public string EliminarContactosPropietario(ContactosPropietariosDTO contactosPropietarioDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdContactoPropietario", OracleDbType.Decimal)).Value = contactosPropietarioDTO.ID_CONTACTO_PROPIETARIO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = contactosPropietarioDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_PROPIETARIOS.PR_BorrarContactoPropietario";

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

        public List<ContactosPropietariosDTO> ListaContactosPropietario(int _session)
        {
            List<ContactosPropietariosDTO> retorno = new List<ContactosPropietariosDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CONTACTOS_PROPIETARIOS.PR_ConsultarContactosPropietarios";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    ContactosPropietariosDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new ContactosPropietariosDTO
                        {
                            ID_CONTACTO_PROPIETARIO = int.Parse(row["ID_CONTACTO_PROPIETARIO"].ToString()),
                            TIPO_CONTACTO = row["TIPO_CONTACTO"].ToString(),
                            DATO_CNTCT_PROP = row["DATO_CNTCT_PROP"].ToString(),
                            IDF_TIPO_CONTACTO_PROP = int.Parse(row["IDF_TIPO_CONTACTO_PROP"].ToString()),
                            IDF_PROPIETARIO_CNTCT = int.Parse(row["IDF_PROPIETARIO_CNTCT"].ToString())
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
