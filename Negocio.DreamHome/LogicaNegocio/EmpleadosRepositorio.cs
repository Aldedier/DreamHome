namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class EmpleadosRepositorio
    {
        public string ValidarEmpleado(EmpleadosDTO empleadosDTO)
        {
            string resultado = new EmpleadosDB().CrearEmpleado(empleadosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarEmpleado(EmpleadosDTO empleadosDTO)
        {
            string resultado = new EmpleadosDB().EditarEmpleado(empleadosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarEmpleado(EmpleadosDTO empleadosDTO)
        {
            string resultado = new EmpleadosDB().EliminarEmpleado(empleadosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<EmpleadosDTO> ConsultaEmpleados(int _session)
        {
            return new EmpleadosDB().ListaEmpleados(_session);
        }
    }
}
