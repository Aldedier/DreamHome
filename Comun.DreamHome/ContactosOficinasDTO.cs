using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
    public class ContactosOficinasDTO
    {
        public int ID_CONTACTO_OFICINA { get; set; }
        public int IDF_OFICINA_CNTC { get; set; }
        public int IDF_TIPO_CNTC_OFC { get; set; }
        public string DATO_CNTCT_OFC { get; set; }
        public string OFICINA { get; set; }
        public string TIPO_CONTACTO { get; set; }
        public int? SESSION { get; set; } = null;

    }
}
