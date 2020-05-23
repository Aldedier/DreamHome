using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
    public class OficinasDTO
    {
        public decimal ID_OFICINA { get; set; }
        public string OFICINA { get; set; }
        public int IDF_CIUDAD_OFC { get; set; }
        public string CIUDAD { get; set; }
        public string DIRECCION_OFC { get; set; }
        public string APARTADO_OFC { get; set; }
        public int ACTIVO_OFC { get; set; }
        public string ESTADO_OFC { get; set; }
        public int? SESSION { get; set; } = null;
    }
}
