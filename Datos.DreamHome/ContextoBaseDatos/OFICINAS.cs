namespace Datos.DreamHome
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(OFICINAS), Schema = "BD_DREAM_HOME")]
    public class OFICINAS
    {
        [Key]
        public decimal ID_OFICINA { get; set; }
        public string OFICINA { get; set; }
        public int IDF_CIUDAD_OFC { get; set; }
        public string DIRECCION_OFC { get; set; }
        public string APARTADO_OFC { get; set; }
        public int ACTIVO_OFC { get; set; }
    }
}
