namespace Comun.DreamHome
{
    using System;
    using System.Collections.Generic;

    public class RequerimientosClientesDTO
    {
        public decimal ID_REQUERIMIENTO { get; set; }
        public string REQUERIMIENTO { get; set; }
        public decimal IDF_CLIENTE_RQRM { get; set; }
        public string NOMBRE_CLINT { get; set; }
        public decimal IDF_OFICINA_RQRM { get; set; }
        public string OFICINA { get; set; }
        public decimal IDF_EMPLEADO_RQRM { get; set; }
        public string NOMBRE_RH { get; set; }
        public decimal IDF_TIPO_RQRM { get; set; }
        public string NOMBRE_TIPO { get; set; }
        public decimal IDF_ESTADO_RQRM { get; set; }
        public string ESTADO_REQUERIMIENTO { get; set; }
        public DateTime FECHA_RQRM { get; set; }
        public int? SESSION { get; set; } = null;
    }
}
