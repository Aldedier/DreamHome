using Comun.DreamHome;
using Datos.DreamHome;
using System.Collections.Generic;

namespace Negocio.DreamHome
{
    public class SistemaRepositorio
    {
        public string ValidarLogin(LoginDTO loginDTO)
        {
            List<UsuarioDTO> resultado = new SistemaDB().ValidarUsuario(loginDTO);

            if (resultado == null)
                return null;
            else
                return "Exito";
        }

    }
}
