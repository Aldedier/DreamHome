using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
    public class HistorialLaboralDTO
    {
        public int ID_HISTORIAL_LABRL { get; set; }
        public int IDF_EMPLEADO_HST { get; set; }
        public string NOMBRE_RH { get; set; }
        public int IDF_CARGO_HST { get; set; }
        public string CARGO { get; set; }
        public int IDF_OFCINA_HST { get; set; }
        public string OFICINA { get; set; }
        public int VIGENTE_HST { get; set; }
        public DateTime FECHA_HST { get; set; }
        public int? SESSION { get; set; } = null;
    }
}
