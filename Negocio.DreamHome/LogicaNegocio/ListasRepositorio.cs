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

        public List<GeneroDTO> ConsultarGeneros()
        {
            List<GeneroDTO> lista = new List<GeneroDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.GENEROS.Select(x => new GeneroDTO { ID_GENERO = x.ID_GENERO, GENERO = x.GENERO }).ToList();
            }

            return lista;
        }

        public List<UsuarioDTO> ConsultarUsuarios()
        {
            List<UsuarioDTO> lista = new List<UsuarioDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.USUARIOS.Select(x => new UsuarioDTO { Usuario_id = x.ID_USUARIO, Nombre_Usuario = x.NOMBRE_USR }).ToList();
            }

            return lista;
        }

        public List<CiudadDTO> ConsultarCiudades()
        {
            List<CiudadDTO> lista = new List<CiudadDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.CIUDADES.Select(x => new CiudadDTO { ID_CIUDAD = x.ID_CIUDAD, CIUDAD = x.CIUDAD }).ToList();
            }

            return lista;
        }

    }
}
