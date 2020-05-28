namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class ContactosEmpleadosRepositorio
    {
        public string ValidarContactosEmpleado(ContactosEmpleadosDTO contactosEmpleadosDTO)
        {
            string resultado = new ContactosEmpleadosDB().CrearContactosEmpleado(contactosEmpleadosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarContactosEmpleado(ContactosEmpleadosDTO contactosEmpleadosDTO)
        {
            string resultado = new ContactosEmpleadosDB().EditarContactosEmpleado(contactosEmpleadosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarContactosEmpleado(ContactosEmpleadosDTO contactosEmpleadosDTO)
        {
            string resultado = new ContactosEmpleadosDB().EliminarContactosEmpleado(contactosEmpleadosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<ContactosEmpleadosDTO> ConsultaContactosEmpleados(int _session)
        {
            return new ContactosEmpleadosDB().ListaContactosEmpleado(_session);
        }
    }
}
