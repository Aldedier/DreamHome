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
   public class AnunciosDB
    {

        public string CrearAnuncio(AnuncioDTO anuncioDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdInmueble", OracleDbType.Decimal)).Value = anuncioDTO.IDF_INMUEBLE_ANN;
                    objCommand.Parameters.Add(new OracleParameter("I_IdPeriodico", OracleDbType.Decimal)).Value = anuncioDTO.IDF_PERIODICO_ANN;
                    objCommand.Parameters.Add(new OracleParameter("I_InicioPublicacion", OracleDbType.Date)).Value = anuncioDTO.INICIO_PUBLICACION;
                    objCommand.Parameters.Add(new OracleParameter("I_FinPublicacion", OracleDbType.Date)).Value = anuncioDTO.FIN_PUBLICACION;
                    objCommand.Parameters.Add(new OracleParameter("I_CostoDia", OracleDbType.Decimal)).Value = anuncioDTO.COSTO_DIA;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = anuncioDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_ANUNCIOS.PR_AgregarAnuncio";
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

        public string EditarAnuncio(AnuncioDTO anuncioDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdAnuncio", OracleDbType.Decimal)).Value = anuncioDTO.ID_ANUNCIO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdInmueble", OracleDbType.Decimal)).Value = anuncioDTO.IDF_INMUEBLE_ANN;
                    objCommand.Parameters.Add(new OracleParameter("I_IdPeriodico", OracleDbType.Decimal)).Value = anuncioDTO.IDF_PERIODICO_ANN;
                    objCommand.Parameters.Add(new OracleParameter("I_InicioPublicacion", OracleDbType.Date)).Value = anuncioDTO.INICIO_PUBLICACION;
                    objCommand.Parameters.Add(new OracleParameter("I_FinPublicacion", OracleDbType.Date)).Value = anuncioDTO.FIN_PUBLICACION;
                    objCommand.Parameters.Add(new OracleParameter("I_CostoDia", OracleDbType.Decimal)).Value = anuncioDTO.COSTO_DIA;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = anuncioDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_ANUNCIOS.PR_ModificarAnuncio";

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

        public string EliminarAnuncio(AnuncioDTO anunciosDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdAnuncio", OracleDbType.Decimal)).Value = anunciosDTO.ID_ANUNCIO;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = anunciosDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_ANUNCIOS.PR_BorrarAnuncio";

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

        public List<AnuncioDTO> ListaAnuncios(int _session)
        {
            List<AnuncioDTO> retorno = new List<AnuncioDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_ANUNCIOS.PR_ConsultarPago";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    AnuncioDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new AnuncioDTO
                        {
                            ID_ANUNCIO = int.Parse(row["ID_ANUNCIO"].ToString()),
                            IDF_INMUEBLE_ANN = int.Parse(row["IDF_INMUEBLE_ANN"].ToString()),
                            IDF_PERIODICO_ANN = int.Parse(row["IDF_PERIODICO_ANN"].ToString()),
                            INICIO_PUBLICACION = DateTime.Parse(row["INICIO_PUBLICACION"].ToString()),
                            FIN_PUBLICACION = DateTime.Parse(row["FIN_PUBLICACION"].ToString()),
                            COSTO_DIA = int.Parse(row["COSTO_DIA"].ToString())
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
