using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
   public class PagosDTO
    {
        public int  ID_PAGO { get; set; }
        public int  IDF_CONTRATO_PG { get; set; }
        public DateTime FECHA_PAGO { get; set; }
        public int VALOR_PAGO { get; set; }
        public String OBSERVACION { get; set; }
        public int? SESSION { get; set; } = null;

    }
}
