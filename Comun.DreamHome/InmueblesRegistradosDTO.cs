namespace Comun.DreamHome
{
    using System;

    public class InmueblesRegistradosDTO
    {
        public int ID_INMUEBLE_REGISTRADO { get; set; }
        public int IDF_INMUEBLE_REG { get; set; } = 0;
        public string NOMBRE_TIPO { get; set; }
        public string DIRECCION_INM { get; set; }
        public int IDF_OFICINA_REG { get; set; } = 0;
        public string OFICINA { get; set; }
        public int IDF_EMPLEADO_REG { get; set; } = 0;

        /// <summary>
        /// EMPLEADO
        /// </summary>
        public string NOMBRE_RH { get; set; }

        /// <summary>
        /// PROPIETARIO
        /// </summary>
        public string NOMBRE_PROP { get; set; }

        public int IDF_ESTADO_REG { get; set; } = 0;
        public string ESTADO_INMUEBLE { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public int? SESSION { get; set; } = null;

        public string DESCRIPCION
        {
            get => this.NOMBRE_TIPO + " - " + this.DIRECCION_INM + " - " + this.OFICINA;
        }


        #region Reporte

        public int ID_INMUEBLE { get; set; }
        public string APARTADO_INM { get; set; }
        public DateTime FECHA_INM { get; set; }

        #endregion

    }
}
