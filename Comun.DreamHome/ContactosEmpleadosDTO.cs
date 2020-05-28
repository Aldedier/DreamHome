using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
    public class ContactosEmpleadosDTO
    {
        public int ID_CONTACTO_EMPLEADO { get; set; }
        public int IDF_EMPLEADO_CNTCT { get; set; }
        public int IDF_TIPO_CONTACTO_CNTCT { get; set; }
        public string DATO_CNTCT_EMP { get; set; }
        public string NOMBRE_RH { get; set; }
        public string TIPO_CONTACTO { get; set; }
        public int? SESSION { get; set; } = null;

    }
}
