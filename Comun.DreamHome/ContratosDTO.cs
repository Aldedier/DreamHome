using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
   public class ContratosDTO
    {
        

        public int ID_CONTRATO { get; set; }
        public int IDF_CLIENTE_CNTR { get; set; }
        public string NOMBRE_CLINT { get; set; }
        public int IDF_INMBL_EMPLD_CNTR { get; set; }
        public int IDF_FORMA_PAGO_CNTR { get; set; }
        public int IDF_ESTADO_CONTRATO { get; set; }
        public int CANON_MENSUAL { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FIN { get; set; }
        public string CONSIGNAR { get; set; }
        public string ESTADO { get; set; }
        public string DIRECCION{ get; set; }

        public int? SESSION { get; set; } = null;

    }
}
