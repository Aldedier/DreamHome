namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class InmueblesPropietariosRepositorio
    {
        public string ValidarInmueblesPropietario(InmueblesPropietariosDTO InmueblesPropietariosDTO)
        {
            string resultado = new InmueblesPropietariosDB().CrearInmueblesPropietario(InmueblesPropietariosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarInmueblesPropietario(InmueblesPropietariosDTO InmueblesPropietariosDTO)
        {
            string resultado = new InmueblesPropietariosDB().EditarInmueblesPropietario(InmueblesPropietariosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarInmueblesPropietario(InmueblesPropietariosDTO InmueblesPropietariosDTO)
        {
            string resultado = new InmueblesPropietariosDB().EliminarInmueblesPropietario(InmueblesPropietariosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<InmueblesPropietariosDTO> ConsultaInmueblesPropietarios(int _session)
        {
            return new InmueblesPropietariosDB().ListaInmueblesPropietarios(_session);
        }
    }
}
