namespace Datos.DreamHome.LogicaBaseDatos
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Configuration;

    public class ClientesDB
    {
        public string CrearCliente(ClientesDTO clientesDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdfUsuarioClint", OracleDbType.Decimal)).Value = clientesDTO.IDF_USUARIO_CLINT;
                    objCommand.Parameters.Add(new OracleParameter("I_NombreClint", OracleDbType.Varchar2, 200)).Value = clientesDTO.NOMBRE_CLINT;
                    objCommand.Parameters.Add(new OracleParameter("I_DireccionClint", OracleDbType.Varchar2, 200)).Value = clientesDTO.DIRECCION_CLINT;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = clientesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CLIENTES.PR_AgregarCliente";
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

        public string EditarCliente(ClientesDTO clientesDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdCliente", OracleDbType.Decimal)).Value = clientesDTO.ID_CLIENTE;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfUsuarioClint", OracleDbType.Decimal)).Value = clientesDTO.IDF_USUARIO_CLINT;
                    objCommand.Parameters.Add(new OracleParameter("I_NombreClint", OracleDbType.Varchar2, 200)).Value = clientesDTO.NOMBRE_CLINT;
                    objCommand.Parameters.Add(new OracleParameter("I_ActivoClint", OracleDbType.Decimal)).Value = 1;
                    objCommand.Parameters.Add(new OracleParameter("I_DireccionClint", OracleDbType.Varchar2, 200)).Value = clientesDTO.DIRECCION_CLINT;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = clientesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CLIENTES.PR_ModificarCliente";

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

        public string EliminarCliente(ClientesDTO clientesDTO)
        {
            string resultado = string.Empty;

            using (OracleConnection connection = new OracleConnection(WebConfigurationManager.ConnectionStrings["ContextoDH"].ConnectionString))
            using (OracleCommand objCommand = connection.CreateCommand())
            {
                try
                {
                    objCommand.Parameters.Clear();
                    objCommand.Parameters.Add(new OracleParameter("I_IdCliente", OracleDbType.Decimal)).Value = clientesDTO.ID_CLIENTE;
                    objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = clientesDTO.SESSION;
                    objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;

                    connection.Open();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CLIENTES.PR_BorrarCliente";

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

        public List<ClientesDTO> ListaClientes(int _session)
        {
            List<ClientesDTO> retorno = new List<ClientesDTO>();

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
                    objCommand.CommandText = "BD_DREAM_HOME.PKG_CLIENTES.PR_ConsultarCliente";

                    DataTable resultado = new DataTable();
                    resultado.Load(objCommand.ExecuteReader());

                    ClientesDTO registro;
                    foreach (DataRow row in resultado.Rows)
                    {
                        registro = new ClientesDTO
                        {
                            ID_CLIENTE = int.Parse(row["ID_CLIENTE"].ToString()),
                            DIRECCION_CLINT = row["DIRECCION_CLINT"].ToString(),
                            NOMBRE_CLINT = row["NOMBRE_CLINT"].ToString(),
                            IDF_USUARIO_CLINT = int.Parse(row["IDF_USUARIO_CLINT"].ToString()),
                            USUARIO = row["USUARIO"].ToString(),
                            ESTADO = row["ESTADO"].ToString(),
                            FECHA_CLINT = DateTime.Parse(row["FECHA_CLINT"].ToString())
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
            return retorno.Where(x => x.ESTADO == "SI").ToList();
        }
    }
}
