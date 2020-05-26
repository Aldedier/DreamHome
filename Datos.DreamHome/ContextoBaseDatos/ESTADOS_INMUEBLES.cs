namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(ESTADOS_INMUEBLES), Schema = "BD_DREAM_HOME")]
    public class ESTADOS_INMUEBLES
    {
        [Key]
        public decimal ID_ESTADO_INMUEBLE { get; set; }
        public string ESTADO_INMUEBLE { get; set; }

    }
}
