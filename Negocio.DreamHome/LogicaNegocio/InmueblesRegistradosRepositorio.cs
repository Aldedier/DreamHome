namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class InmueblesRegistradosRepositorio
    {
        public string ValidarInmueblesRegistrado(InmueblesRegistradosDTO InmueblesRegistradosDTO)
        {
            string resultado = new InmueblesRegistradosDB().CrearInmueblesRegistrado(InmueblesRegistradosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarInmueblesRegistrado(InmueblesRegistradosDTO InmueblesRegistradosDTO)
        {
            string resultado = new InmueblesRegistradosDB().EditarInmueblesRegistrado(InmueblesRegistradosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarInmueblesRegistrado(InmueblesRegistradosDTO InmueblesRegistradosDTO)
        {
            string resultado = new InmueblesRegistradosDB().EliminarInmueblesRegistrado(InmueblesRegistradosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<InmueblesRegistradosDTO> ConsultaInmueblesRegistrados(InmueblesRegistradosDTO InmueblesRegistradosDTO)
        {
            return new InmueblesRegistradosDB().ListaInmueblesRegistrados(InmueblesRegistradosDTO);
        }

        public List<InmueblesRegistradosDTO> ReporteInmueblesRegistrados(InmueblesRegistradosDTO InmueblesRegistradosDTO)
        {
            return new InmueblesRegistradosDB().ReporteInmueblesRegistrados(InmueblesRegistradosDTO);
        }
    }
}
