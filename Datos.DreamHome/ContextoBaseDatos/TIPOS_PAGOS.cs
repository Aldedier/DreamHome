namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(TIPOS_PAGOS), Schema = "BD_DREAM_HOME")]
    public class TIPOS_PAGOS
    {
        [Key]
        public decimal ID_FORMA_PAGO { get; set; }
        public string FORMA_PAGO { get; set; }

    }
}
