namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class ContactosPropietariosRepositorio
    {
        public string ValidarContactosPropietario(ContactosPropietariosDTO contactosPropietariosDTO)
        {
            string resultado = new ContactosPropietariosDB().CrearContactosPropietario(contactosPropietariosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarContactosPropietario(ContactosPropietariosDTO contactosPropietariosDTO)
        {
            string resultado = new ContactosPropietariosDB().EditarContactosPropietario(contactosPropietariosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarContactosPropietario(ContactosPropietariosDTO contactosPropietariosDTO)
        {
            string resultado = new ContactosPropietariosDB().EliminarContactosPropietario(contactosPropietariosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<ContactosPropietariosDTO> ConsultaContactosPropietarios(int _session)
        {
            return new ContactosPropietariosDB().ListaContactosPropietario(_session);
        }
    }
}
