namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;

    public class SistemaRepositorio
    {
        public UsuarioDTO ValidarLogin(LoginDTO loginDTO)
        {
            UsuarioDTO resultado = new SistemaDB().ValidarUsuario(loginDTO);
            return resultado;
        }

    }
}
