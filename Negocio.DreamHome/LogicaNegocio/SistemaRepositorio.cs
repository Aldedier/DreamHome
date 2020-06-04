namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class SistemaRepositorio
    {
        public UsuarioDTO ValidarLogin(LoginDTO loginDTO)
        {
            UsuarioDTO resultado = new SistemaDB().ValidarUsuario(loginDTO);
            return resultado;
        }

        public List<AuditoriaDTO> ReporteAuditoria(AuditoriaDTO auditoriaDTO)
        {
            return new SistemaDB().ReporteAuditoria(auditoriaDTO);
        }
    }
}
