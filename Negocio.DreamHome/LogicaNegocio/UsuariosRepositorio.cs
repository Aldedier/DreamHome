using Comun.DreamHome;
using Datos.DreamHome.LogicaBaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DreamHome.LogicaNegocio
{
   public class UsuariosRepositorio
    {
        public string ValidarUsuarios(UsuariosDTO usuarioDTO)
        {
            string resultado = new UsuariosDB().CrearUsuarios(usuarioDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarUsuarios(UsuariosDTO usuarioDTO)
        {
            string resultado = new UsuariosDB().EditaUsuarios(usuarioDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarUsuarios(UsuariosDTO usuarioDTO)
        {
            string resultado = new UsuariosDB().EliminaUsuarios(usuarioDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<UsuariosDTO> ConsultaUsuarios(int _session)
        {
            return new UsuariosDB().ListaUsuarios(_session);
        }
    }
}
