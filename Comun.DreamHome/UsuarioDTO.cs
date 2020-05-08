using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
    public class UsuarioDTO
    {
        public int Usuario_id { get; set; }
        public string Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public int Rol_id { get; set; }
        public int Sesion_id { get; set; }
        public string Mensaje { get; set; }
    }
}
