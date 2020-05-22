using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
    public class EmpleadosDTO
    {
        public int ID_EMPLEADO { get; set; }
        public int IDF_USUARIO_RH { get; set; }
        public string USUARIO { get; set; }
        public string IDF_GENERO_RH { get; set; }
        public string GENERO { get; set; }
        public string NOMBRE_RH { get; set; }
        public string DIRECCION_RH { get; set; }
        public string APARTADO_RH { get; set; }
        public int ACTIVO_RH { get; set; }
        public DateTime FECHA_RH { get; set; }
        public int? SESSION { get; set; } = null;
    }
}
