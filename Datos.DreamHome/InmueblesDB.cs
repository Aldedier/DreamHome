namespace Datos.DreamHome
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Data;
    using Datos.DreamHome.ConexionOracle;
    using System.Collections.Generic;

    public class InmueblesDB ///: DreamHomeDatosBase
    {
        public int CrearInmueble(InmueblesDTO inmueblesDTO)
        {
            ConDBOracle cnOracle = new ConDBOracle("ContextoDH");
            OracleCommand objCommand = new OracleCommand();
            int resultado = 0;
            try
            {
                objCommand.Parameters.Clear();
                objCommand.Parameters.Add(new OracleParameter("I_IdTipoInm", OracleDbType.Int32)).Value = inmueblesDTO.IDF_TIPO_INM;
                objCommand.Parameters.Add(new OracleParameter("I_DireccionInm", OracleDbType.Varchar2, 200)).Value = inmueblesDTO.DIRECCION_INM;
                objCommand.Parameters.Add(new OracleParameter("I_ApartadoInm", OracleDbType.Varchar2, 100)).Value = inmueblesDTO.APARTADO_INM;
                objCommand.Parameters.Add(new OracleParameter("I_Activo", OracleDbType.Int32)).Value = 1;
                objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Int32)).Direction = ParameterDirection.Output;

                objCommand.Connection = cnOracle.Conexion;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "SYSTEM.PKG_INMUEBLES.PR_AgregarInmueble";

                if (cnOracle.Conectar())
                {
                    objCommand.ExecuteNonQuery();
                    resultado = int.Parse(objCommand.Parameters["O_Salida"].Value.ToString());
                    inmueblesDTO.ID_INMUEBLE = resultado;
                }
            }
            catch (Exception ex)
            {
                //LogException.Nivel = LogException.TipoMensaje.M_ERROR;
                //LogException.err("Error Ejecutando Procedimiento:", ex);
            }
            finally
            {
                cnOracle.Desconectar();
                if (objCommand != null) { objCommand.Dispose(); }
            }

            return (resultado);
        }

        public int EditarInmueble(InmueblesDTO inmueblesDTO)
        {
            ConDBOracle cnOracle = new ConDBOracle("ContextoDH");
            OracleCommand objCommand = new OracleCommand();
            int resultado = 0;
            try
            {
                objCommand.Parameters.Clear();
                objCommand.Parameters.Add(new OracleParameter("I_IdInmueble", OracleDbType.Int32)).Value = inmueblesDTO.ID_INMUEBLE;
                objCommand.Parameters.Add(new OracleParameter("I_IdTipoInm", OracleDbType.Int32)).Value = inmueblesDTO.IDF_TIPO_INM;
                objCommand.Parameters.Add(new OracleParameter("I_DireccionInm", OracleDbType.Varchar2, 200)).Value = inmueblesDTO.DIRECCION_INM;
                objCommand.Parameters.Add(new OracleParameter("I_ApartadoInm", OracleDbType.Varchar2, 100)).Value = inmueblesDTO.APARTADO_INM;
                objCommand.Parameters.Add(new OracleParameter("I_Activo", OracleDbType.Int32)).Value = 1;
                objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Int32)).Direction = ParameterDirection.Output;

                objCommand.Connection = cnOracle.Conexion;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "SYSTEM.PKG_INMUEBLES.PR_ModificarInmueble";

                if (cnOracle.Conectar())
                {
                    objCommand.ExecuteNonQuery();
                    resultado = int.Parse(objCommand.Parameters["O_Salida"].Value.ToString());
                    inmueblesDTO.ID_INMUEBLE = resultado;
                }
            }
            catch (Exception ex)
            {
                //LogException.Nivel = LogException.TipoMensaje.M_ERROR;
                //LogException.err("Error Ejecutando Procedimiento:", ex);
            }
            finally
            {
                cnOracle.Desconectar();
                if (objCommand != null) { objCommand.Dispose(); }
            }

            return (resultado);
        }

        public int EliminarInmueble(InmueblesDTO inmueblesDTO)
        {
            ConDBOracle cnOracle = new ConDBOracle("ContextoDH");
            OracleCommand objCommand = new OracleCommand();
            int resultado = 0;
            try
            {
                objCommand.Parameters.Clear();
                objCommand.Parameters.Add(new OracleParameter("I_IdInmueble", OracleDbType.Int32)).Value = inmueblesDTO.ID_INMUEBLE;
                objCommand.Parameters.Add(new OracleParameter("O_Salida", OracleDbType.Int32)).Direction = ParameterDirection.Output;

                objCommand.Connection = cnOracle.Conexion;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "SYSTEM.PKG_INMUEBLES.PR_BorrarInmueble";

                if (cnOracle.Conectar())
                {
                    objCommand.ExecuteNonQuery();
                    resultado = int.Parse(objCommand.Parameters["O_Salida"].Value.ToString());
                    inmueblesDTO.ID_INMUEBLE = resultado;
                }
            }
            catch (Exception ex)
            {
                //LogException.Nivel = LogException.TipoMensaje.M_ERROR;
                //LogException.err("Error Ejecutando Procedimiento:", ex);
            }
            finally
            {
                cnOracle.Desconectar();
                if (objCommand != null) { objCommand.Dispose(); }
            }

            return (resultado);
        }

        public List<InmueblesDTO> ListaInmuebles()
        {
            List<InmueblesDTO> retorno = new List<InmueblesDTO>();
            ConDBOracle cnOracle = new ConDBOracle("ContextoDH");
            OracleCommand objCommand = new OracleCommand();

            try
            {
                objCommand.Parameters.Clear();
                objCommand.Parameters.Add(new OracleParameter("RETURN_VALUE", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

                objCommand.Connection = cnOracle.Conexion;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "SYSTEM.PKG_INMUEBLES.PR_ConsultarInmuebles";

                if (cnOracle.Conectar())
                {
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
            }
            catch (Exception ex)
            {
                //LogException.Nivel = LogException.TipoMensaje.M_ERROR;
                //LogException.err("Error Ejecutando f_ListarDominio:", ex);
            }
            finally
            {
                cnOracle.Desconectar();
                if (objCommand != null) { objCommand.Dispose(); }
            }

            return retorno;
        }
    }
}
