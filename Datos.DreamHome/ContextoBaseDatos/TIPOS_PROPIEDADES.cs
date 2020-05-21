namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(TIPOS_PROPIEDADES), Schema = "BD_DREAM_HOME")]
    public class TIPOS_PROPIEDADES
    {
        [Key]
        public decimal ID_TIPO { get; set; }
        public string NOMBRE_TIPO { get; set; }

    }
}
