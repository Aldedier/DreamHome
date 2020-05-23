namespace Datos.DreamHome
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(CLIENTES), Schema = "BD_DREAM_HOME")]
    public class CLIENTES
    {
        [Key]
        public int ID_CLIENTE { get; set; }
        public int IDF_USUARIO_CLINT { get; set; }
        public string NOMBRE_CLINT { get; set; }
        public string DIRECCION_CLINT { get; set; }
        public int ACTIVO_CLINT { get; set; }
        public DateTime FECHA_CLINT { get; set; }
    }
}
