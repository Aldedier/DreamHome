namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(CARGOS), Schema = "BD_DREAM_HOME")]
    public class CARGOS
    {
        [Key]
        public int ID_CARGO { get; set; }
        public string CARGO { get; set; }

    }
}
