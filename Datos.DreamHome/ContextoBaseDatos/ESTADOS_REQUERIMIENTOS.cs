namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(ESTADOS_REQUERIMIENTOS), Schema = "BD_DREAM_HOME")]
    public class ESTADOS_REQUERIMIENTOS
    {
        [Key]
        public decimal ID_ESTADO_REQUERIMIENTO{ get; set; }
        public string ESTADO_REQUERIMIENTO { get; set; }

    }
}
