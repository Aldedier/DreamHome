namespace Datos.DreamHome
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(EMPLEADOS), Schema = "BD_DREAM_HOME")]
    public class EMPLEADOS
    {
        [Key]
        public int ID_EMPLEADO { get; set; }
        public int IDF_USUARIO_RH { get; set; }
        public string IDF_GENERO_RH { get; set; }
        public string NOMBRE_RH { get; set; }
        public string DIRECCION_RH { get; set; }
        public string APARTADO_RH { get; set; }
        public int ACTIVO_RH { get; set; }
        public DateTime FECHA_RH { get; set; }
    }
}
