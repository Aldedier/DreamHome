using Comun.DreamHome;
using Datos.DreamHome;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.DreamHome
{
    public class SistemaRepositorio
    {
        public UsuarioDTO ValidarLogin(LoginDTO loginDTO)
        {
            UsuarioDTO resultado = new SistemaDB().ValidarUsuario(loginDTO);
            return resultado;
        }

    }
}
