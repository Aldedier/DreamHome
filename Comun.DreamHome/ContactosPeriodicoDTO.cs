﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.DreamHome
{
    public class ContactosPeriodicoDTO
    {
        public int ID_CONTACTO_PERIODICO { get; set; }
        public int IDF_PERIODICO { get; set; }
        public int IDF_TIPO_CONTACTO { get; set; }
        public string DATO_CONTCT { get; set; }
        public string NOMBRE_PERIODICO { get; set; }
        public string TIPO_CONTACTO { get; set; }

        public int? SESSION { get; set; } = null;
    }
}
