namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(VST_INMUEBLES), Schema = "BD_DREAM_HOME")]
    public class VST_INMUEBLES
    {
        [Key]
        public int ID_INMUEBLE { get; set; }
        public int IDF_TIPO_INM { get; set; }
        public string NOMBRE_TIPO { get; set; }
        public string DIRECCION_INM { get; set; }
        public string APARTADO_INM { get; set; }
        public int ACTIVO_INM { get; set; }
        public DateTime FECHA_INM { get; set; }
    }
}
