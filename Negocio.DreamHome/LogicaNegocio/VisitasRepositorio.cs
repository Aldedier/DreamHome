namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class VisitasRepositorio
    {
        public string ValidarVisita(VisitasDTO visitasDTO)
        {
            string resultado = new VisitasDB().CrearVisita(visitasDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarVisita(VisitasDTO visitasDTO)
        {
            string resultado = new VisitasDB().EditarVisita(visitasDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarVisita(VisitasDTO visitasDTO)
        {
            string resultado = new VisitasDB().EliminarVisita(visitasDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<VisitasDTO> ConsultaVisitas(int _session)
        {
            return new VisitasDB().ListaVisitas(_session);
        }
    }
}
