namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(TIPOS_USUARIOS), Schema = "BD_DREAM_HOME")]
    public class TIPOS_USUARIOS
    {
        [Key]
        public int ID_ROL { get; set; }
        public string ROL_USUARIO { get; set; }

    }
}
