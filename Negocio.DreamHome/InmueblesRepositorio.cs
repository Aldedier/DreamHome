namespace Negocio.DreamHome
{
    using Comun.DreamHome;
    using Datos.DreamHome;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class InmueblesRepositorio
    {
        public string ValidarInmueble(InmueblesDTO inmueblesDTO)
        {
            string resultado = new InmueblesDB().CrearInmueble(inmueblesDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarInmueble(InmueblesDTO inmueblesDTO)
        {
            string resultado = new InmueblesDB().EditarInmueble(inmueblesDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarInmueble(InmueblesDTO inmueblesDTO)
        {
            string resultado = new InmueblesDB().EliminarInmueble(inmueblesDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<InmueblesDTO> ConsultaInmuebles()
        {
            return new InmueblesDB().ListaInmuebles();
        }
    }
}
