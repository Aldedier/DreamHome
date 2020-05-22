namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(USUARIOS), Schema = "BD_DREAM_HOME")]
    public class USUARIOS
    {
        [Key]
        public int ID_USUARIO { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRE_USR { get; set; }
        public int IDF_ROL_USR { get; set; }
        public string CLAVE { get; set; }
        public int ACTIVO_USR { get; set; }
        public DateTime FECHA_USR { get; set; }
    }
}
