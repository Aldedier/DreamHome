namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class DetallesInmueblesRepositorio
    {
        public string ValidarDetallesInmueble(DetallesInmueblesDTO detallesInmueblesDTO)
        {
            string resultado = new DetallesInmueblesDB().CrearDetallesInmueble(detallesInmueblesDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarDetallesInmueble(DetallesInmueblesDTO detallesInmueblesDTO)
        {
            string resultado = new DetallesInmueblesDB().EditarDetallesInmueble(detallesInmueblesDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarDetallesInmueble(DetallesInmueblesDTO detallesInmueblesDTO)
        {
            string resultado = new DetallesInmueblesDB().EliminarDetallesInmueble(detallesInmueblesDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<DetallesInmueblesDTO> ConsultaDetallesInmuebles(DetallesInmueblesDTO detallesInmueblesDTO)
        {
            return new DetallesInmueblesDB().ListaDetallesInmuebles(detallesInmueblesDTO);
        }

        public DetallesInmueblesDTO ConsultaDetallesInmueble(DetallesInmueblesDTO detallesInmueblesDTO)
        {
            return new DetallesInmueblesDB().DetallesInmuebles(detallesInmueblesDTO);
        }
    }
}
