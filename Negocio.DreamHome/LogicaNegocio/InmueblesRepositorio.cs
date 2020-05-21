namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

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

        public List<InmueblesDTO> ConsultaInmuebles(int _session)
        {
            return new InmueblesDB().ListaInmuebles(_session);
        }
    }
}
