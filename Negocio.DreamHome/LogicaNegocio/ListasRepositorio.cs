namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.ContextoBaseDatos;
    using System.Collections.Generic;
    using System.Linq;

    public class ListasRepositorio
    {
        public List<TiposPropiedadesDTO> ConsultarTiposPropiedades()
        {
            List<TiposPropiedadesDTO> lista = new List<TiposPropiedadesDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.TIPOS_PROPIEDADES.Select(x => new TiposPropiedadesDTO { ID_TIPO = x.ID_TIPO, NOMBRE_TIPO = x.NOMBRE_TIPO }).ToList();
            }

            return lista;
        }


    }
}
