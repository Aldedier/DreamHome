using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
    public class ContactosPropietariosDTO
    {
        public int ID_CONTACTO_PROPIETARIO { get; set; }
        public int IDF_PROPIETARIO_CNTCT { get; set; }
        public int IDF_TIPO_CONTACTO_PROP { get; set; }
        public string TIPO_CONTACTO { get; set; }
        public string DATO_CNTCT_PROP { get; set; }
        public int? SESSION { get; set; } = null;

    }
}
