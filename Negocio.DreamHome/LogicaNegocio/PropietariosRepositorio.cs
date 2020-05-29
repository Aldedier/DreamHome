namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class PropietariosRepositorio
    {
        public string Validarpropietario(PropietariosDTO propietariosDTO)
        {
            string resultado = new PropietariosDB().CrearPropietario(propietariosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string Actualizarpropietario(PropietariosDTO propietariosDTO)
        {
            string resultado = new PropietariosDB().EditarPropietario(propietariosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string Eliminarpropietario(PropietariosDTO propietariosDTO)
        {
            string resultado = new PropietariosDB().EliminarPropietario(propietariosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<PropietariosDTO> ConsultaPropietarios(int _session)
        {
            return new PropietariosDB().ListaPropietarios(_session);
        }
    }
}
