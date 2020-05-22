namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(CIUDADES), Schema = "BD_DREAM_HOME")]
    public class CIUDADES
    {
        [Key]
        public int ID_CIUDAD { get; set; }
        public string CIUDAD { get; set; }

    }
}
