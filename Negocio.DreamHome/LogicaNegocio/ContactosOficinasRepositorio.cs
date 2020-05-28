namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class ContactosOficinasRepositorio
    {
        public string ValidarContactosOficina(ContactosOficinasDTO contactosOficinasDTO)
        {
            string resultado = new ContactosOficinasDB().CrearContactosOficina(contactosOficinasDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarContactosOficina(ContactosOficinasDTO contactosOficinasDTO)
        {
            string resultado = new ContactosOficinasDB().EditarContactosOficina(contactosOficinasDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarContactosOficina(ContactosOficinasDTO contactosOficinasDTO)
        {
            string resultado = new ContactosOficinasDB().EliminarContactosOficina(contactosOficinasDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<ContactosOficinasDTO> ConsultaContactosOficinas(int _session)
        {
            return new ContactosOficinasDB().ListaContactosOficina(_session);
        }
    }
}
