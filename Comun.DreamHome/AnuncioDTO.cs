using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
   public class AnuncioDTO
    {
        public int ID_ANUNCIO { get; set; }
        public int IDF_INMUEBLE_ANN { get; set; }
        public int IDF_PERIODICO_ANN { get; set; }
        public DateTime INICIO_PUBLICACION { get; set; }
        public DateTime FIN_PUBLICACION { get; set; }
        public int COSTO_DIA { get; set; }
        public int? SESSION { get; set; } = null;

    }
}
