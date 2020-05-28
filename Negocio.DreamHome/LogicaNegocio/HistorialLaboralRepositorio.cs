namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class HistorialLaboralRepositorio
    {
        public string ValidarHistorialLaboral(HistorialLaboralDTO historialLaboralDTO)
        {
            string resultado = new HistorialLaboralDB().CrearHistorialLaboral(historialLaboralDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarHistorialLaboral(HistorialLaboralDTO historialLaboralDTO)
        {
            string resultado = new HistorialLaboralDB().EditarHistorialLaboral(historialLaboralDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarHistorialLaboral(HistorialLaboralDTO historialLaboralDTO)
        {
            string resultado = new HistorialLaboralDB().EliminarHistorialLaboral(historialLaboralDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<HistorialLaboralDTO> ConsultaHistorialLaboral(int _session)
        {
            return new HistorialLaboralDB().ListaHistorialLaboral(_session);
        }
    }
}
