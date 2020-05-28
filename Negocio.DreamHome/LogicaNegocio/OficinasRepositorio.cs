namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class OficinasRepositorio
    {
        public string ValidarOficina(OficinasDTO oficinasDTO)
        {
            string resultado = new OficinasDB().CrearOficina(oficinasDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarOficina(OficinasDTO oficinasDTO)
        {
            string resultado = new OficinasDB().EditarOficina(oficinasDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarOficina(OficinasDTO oficinasDTO)
        {
            string resultado = new OficinasDB().EliminarOficina(oficinasDTO);

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
