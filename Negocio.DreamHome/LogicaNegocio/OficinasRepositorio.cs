namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class OficinasRepositorio
    {
        public string ValidarOficina(OficinasDTO empleadosDTO)
        {
            string resultado = new OficinasDB().CrearOficina(empleadosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarOficina(OficinasDTO empleadosDTO)
        {
            string resultado = new OficinasDB().EditarOficina(empleadosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarOficina(OficinasDTO empleadosDTO)
        {
            string resultado = new OficinasDB().EliminarOficina(empleadosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<OficinasDTO> ConsultaOficinas(int _session)
        {
            return new OficinasDB().ListaOficinas(_session);
        }
    }
}
