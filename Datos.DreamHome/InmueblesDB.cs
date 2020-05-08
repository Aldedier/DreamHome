namespace Datos.DreamHome
{
    using Comun.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Data;
    using Datos.DreamHome.ConexionOracle;
    using System.Collections.Generic;

    public class InmueblesDB 
    {
        public string CrearInmueble(InmueblesDTO inmueblesDTO)
        {
            ConDBOracle cnOracle = new ConDBOracle("ContextoDH");
            OracleCommand objCommand = new OracleCommand();
            string resultado = string.Empty;
            try
            {
                objCommand.Parameters.Clear();
                objCommand.Parameters.Add(new OracleParameter("I_IdTipoInm", OracleDbType.Decimal)).Value = inmueblesDTO.IDF_TIPO_INM;
                objCommand.Parameters.Add(new OracleParameter("I_DireccionInm", OracleDbType.Varchar2, 200)).Value = inmueblesDTO.DIRECCION_INM;
                objCommand.Parameters.Add(new OracleParameter("I_ApartadoInm", OracleDbType.Varchar2, 100)).Value = inmueblesDTO.APARTADO_INM;
                objCommand.Parameters.Add(new OracleParameter("I_Activo", OracleDbType.Int32)).Value = 1;
                objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = 1;
                objCommand.Parameters.Add(new OracleParameter("l_mensaje", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.ReturnValue;

                objCommand.Connection = cnOracle.Conexion;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "DB_DREAM_HOME.PKG_INMUEBLES.FN_AgregarInmueble";
                objCommand.BindByName = true;

                if (cnOracle.Conectar())
                {
                    objCommand.ExecuteNonQuery();
                    resultado = objCommand.Parameters["l_mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error !!!");
            }
            finally
            {
                cnOracle.Desconectar();
                if (objCommand != null) { objCommand.Dispose(); }
            }

            return (resultado);
        }

        public string EditarInmueble(InmueblesDTO inmueblesDTO)
        {
            ConDBOracle cnOracle = new ConDBOracle("ContextoDH");
            OracleCommand objCommand = new OracleCommand();
            string resultado = string.Empty;
            try
            {
                objCommand.Parameters.Clear();
                objCommand.Parameters.Add(new OracleParameter("i_idinmueble", OracleDbType.Decimal)).Value = inmueblesDTO.ID_INMUEBLE;
                objCommand.Parameters.Add(new OracleParameter("i_idtipoinm", OracleDbType.Decimal)).Value = inmueblesDTO.IDF_TIPO_INM;
                objCommand.Parameters.Add(new OracleParameter("i_direccioninm", OracleDbType.Varchar2, 200)).Value = inmueblesDTO.DIRECCION_INM;
                objCommand.Parameters.Add(new OracleParameter("i_apartadoinm", OracleDbType.Varchar2, 100)).Value = inmueblesDTO.APARTADO_INM;
                objCommand.Parameters.Add(new OracleParameter("i_activo", OracleDbType.Int32)).Value = 1;
                objCommand.Parameters.Add(new OracleParameter("i_idfsesion", OracleDbType.Decimal)).Value = 1;
                objCommand.Parameters.Add(new OracleParameter("l_mensaje", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.ReturnValue;

                objCommand.Connection = cnOracle.Conexion;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "DB_DREAM_HOME.PKG_INMUEBLES.FN_ModificarInmueble";
                objCommand.BindByName = true;

                if (cnOracle.Conectar())
                {
                    objCommand.ExecuteNonQuery();
                    resultado = objCommand.Parameters["l_mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error !!!");
            }
            finally
            {
                cnOracle.Desconectar();
                if (objCommand != null) { objCommand.Dispose(); }
            }

            return (resultado);
        }

        public string EliminarInmueble(InmueblesDTO inmueblesDTO)
        {
            ConDBOracle cnOracle = new ConDBOracle("ContextoDH");
            OracleCommand objCommand = new OracleCommand();
            string resultado = string.Empty;
            try
            {
                objCommand.Parameters.Clear();
                objCommand.Parameters.Add(new OracleParameter("I_IdInmueble", OracleDbType.Decimal)).Value = inmueblesDTO.ID_INMUEBLE;
                objCommand.Parameters.Add(new OracleParameter("I_IdfSesion", OracleDbType.Decimal)).Value = 1;
                objCommand.Parameters.Add(new OracleParameter("l_mensaje", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.ReturnValue;

                objCommand.Connection = cnOracle.Conexion;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "DB_DREAM_HOME.PKG_INMUEBLES.FN_BorrarInmueble";
                objCommand.BindByName = true;

                if (cnOracle.Conectar())
                {
                    objCommand.ExecuteNonQuery();
                    resultado = objCommand.Parameters["l_mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error !!!");
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
                objCommand.CommandText = "DB_DREAM_HOME.PKG_INMUEBLES.PR_consultarinmuebles";

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
                Console.WriteLine("Ha ocurrido un error !!!");
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
