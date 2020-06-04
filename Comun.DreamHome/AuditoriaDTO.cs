using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
    public class AuditoriaDTO
    {
        public int ID_REGISTRO { get; set; }
        public int ID_SESION { get; set; }
        public string USUARIO { get; set; }
        public string ROL_USR { get; set; }
        public string OBJETO_BD { get; set; }
        public string OPERACION { get; set; }
        public string DATO_VIEJO { get; set; }
        public string DATO_NUEVO { get; set; }
        public string ORIGEN { get; set; }
        public string TIPO_REGISTRO { get; set; }
        public DateTime FECHA_AUD { get; set; }
        public int? SESSION { get; set; } = null;

    }
}
