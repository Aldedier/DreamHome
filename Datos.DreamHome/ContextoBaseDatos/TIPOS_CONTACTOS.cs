namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(TIPOS_CONTACTOS), Schema = "BD_DREAM_HOME")]
    public class TIPOS_CONTACTOS
    {
        [Key]
        public decimal ID_TIPO_CONTACTO { get; set; }
        public string TIPO_CONTACTO { get; set; }

    }
}
