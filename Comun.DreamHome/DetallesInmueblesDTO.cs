using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
    public class DetallesInmueblesDTO
    {
        public int ID_DETALLE_INMBL { get; set; }
        public int IDF_INMUEBLE { get; set; }
        public int IDF_CARACTERISTICA { get; set; }
        public decimal VALOR { get; set; }
        public string CARACTERISTICA { get; set; }
        public int? SESSION { get; set; } = null;
    }
}
