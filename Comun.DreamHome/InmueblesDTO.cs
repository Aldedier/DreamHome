using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
    public class InmueblesDTO
    {
        public int ID_INMUEBLE { get; set; }
        public int IDF_TIPO_INM { get; set; }
        public string IDF_TIPO_INM_STR { get; set; }
        public string DIRECCION_INM { get; set; }
        public string APARTADO_INM { get; set; }
        public int ACTIVO_INM { get; set; }
        public DateTime FECHA_INM { get; set; }
        public int? SESSION { get; set; } = null;
    }
}
