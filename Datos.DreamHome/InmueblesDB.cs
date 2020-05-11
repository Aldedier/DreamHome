namespace Datos.DreamHome
{
    using Comun.DreamHome;
    using Datos.DreamHome.ConexionOracle;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class InmueblesDB
    {
        public string CrearInmueble(InmueblesDTO inmueblesDTO)
        {
            string resultado = string.Empty;
            string connectionString = new Utilidades().GetConnectionStringByName("ContextoDH");

            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdTipoInm", OracleDbType.Decimal)).Value = inmueblesDTO.IDF_TIPO_INM;
                    objCommand.Parameters.Add(new OracleParameter("I_DireccionInm", OracleDbType.Varchar2, 200)).Value = inmueblesDTO.DIRECCION_INM;
                    objCommand.Parameters.Add(new OracleParameter("I_ApartadoInm", OracleDbType.Varchar2, 100)).Value = inmueblesDTO.APARTADO_INM;
                    objCommand.Parameters.Add(new OracleParameter("I_Activo", OracleDbType.Int32)).Value = 1;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = inmueblesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "DB_DREAM_HOME.PKG_INMUEBLES.PR_AgregarInmueble";
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

        public string EditarInmueble(InmueblesDTO inmueblesDTO)
        {
            string resultado = string.Empty;
            string connectionString = new Utilidades().GetConnectionStringByName("ContextoDH");

            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("i_idinmueble", OracleDbType.Decimal)).Value = inmueblesDTO.ID_INMUEBLE;
                    objCommand.Parameters.Add(new OracleParameter("i_idtipoinm", OracleDbType.Decimal)).Value = inmueblesDTO.IDF_TIPO_INM;
                    objCommand.Parameters.Add(new OracleParameter("i_direccioninm", OracleDbType.Varchar2, 200)).Value = inmueblesDTO.DIRECCION_INM;
                    objCommand.Parameters.Add(new OracleParameter("i_apartadoinm", OracleDbType.Varchar2, 100)).Value = inmueblesDTO.APARTADO_INM;
                    objCommand.Parameters.Add(new OracleParameter("i_activo", OracleDbType.Int32)).Value = 1;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = inmueblesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "DB_DREAM_HOME.PKG_INMUEBLES.PR_ModificarInmueble";

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

        public string EliminarInmueble(InmueblesDTO inmueblesDTO)
        {
            string resultado = string.Empty;
            string connectionString = new Utilidades().GetConnectionStringByName("ContextoDH");

            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdInmueble", OracleDbType.Decimal)).Value = inmueblesDTO.ID_INMUEBLE;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = inmueblesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "DB_DREAM_HOME.PKG_INMUEBLES.PR_BorrarInmueble";

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

        public List<InmueblesDTO> ListaInmuebles(int _session)
        {
            List<InmueblesDTO> retorno = new List<InmueblesDTO>();
            string connectionString = new Utilidades().GetConnectionStringByName("ContextoDH");

            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = _session;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "DB_DREAM_HOME.PKG_INMUEBLES.PR_consultarinmuebles";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    InmueblesDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new InmueblesDTO
                        {
                            ID_INMUEBLE = int.Parse(row["ID_INMUEBLE"].ToString()),
                            IDF_TIPO_INM = int.Parse(row["IDF_TIPO_INM"].ToString()),
                            IDF_TIPO_INM_STR = row["NOMBRE_TIPO"].ToString(),
                            DIRECCION_INM = row["DIRECCION_INM"].ToString(),
                            APARTADO_INM = row["APARTADO_INM"].ToString(),
                            FECHA_INM = DateTime.Parse(row["FECHA_INM"].ToString()),
                            ACTIVO_INM = int.Parse(row["ACTIVO_INM"].ToString())
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
