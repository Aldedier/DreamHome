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
        public bool ValidarInmueble(InmueblesDTO inmueblesDTO)
        {
            if (inmueblesDTO.DIRECCION_INM == null)
                return false;

            int resultado = new InmueblesDB().CrearInmueble(inmueblesDTO);

            if (resultado == 1)
                return true;
            else
                return false;
        }

        public bool ActualizarInmueble(InmueblesDTO inmueblesDTO)
        {
            int resultado = new InmueblesDB().EditarInmueble(inmueblesDTO);

            if (resultado == 1)
                return true;
            else
                return false;
        }

        public bool EliminarInmueble(InmueblesDTO inmueblesDTO)
        {
            int resultado = new InmueblesDB().EliminarInmueble(inmueblesDTO);

            if (resultado == 1)
                return true;
            else
                return false;
        }

        public List<InmueblesDTO> ConsultaInmuebles()
        {
            return new InmueblesDB().ListaInmuebles();
        }
    }
}
