using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
   public class UsuariosDTO
    {
        public int ID_USUARIO { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRE_USR { get; set; }

        public int IDF_ROL_USR { get; set; }

        public string CLAVE { get; set; }

        public int ACTIVO_USR { get; set; }

        public DateTime FECHA_USR { get; set; }

        public string ROL_USUARIO { get; set; }
        public int? SESSION { get; set; } = null;

    }
}
