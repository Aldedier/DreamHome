using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datos.DreamHome.ContextoBaseDatos
{
    [Serializable]
    [Table(nameof(VST_CONTRATOS), Schema = "BD_DREAM_HOME")]
    public  class VST_CONTRATOS
    {
        [Key]
        public int ID_CONTRATO { get; set; }
        public int IDF_CLIENTE_CNTR { get; set; }
        public string NOMBRE_CLINT { get; set; }
        public int IDF_INMUEBLE_CNTR { get; set; }
        public int IDF_FORMA_PAGO_CNTR { get; set; }
        public int IDF_ESTADO_CONTRATO { get; set; }
        public int CANON_MENSUAL { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FIN { get; set; }
        public string CONSIGNAR { get; set; }
        public string ESTADO { get; set; }
        public string DIRECCION { get; set; }

    }
}
