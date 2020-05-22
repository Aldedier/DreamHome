namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(GENEROS), Schema = "BD_DREAM_HOME")]
    public class GENEROS
    {
        [Key]
        public string ID_GENERO { get; set; }
        public string GENERO { get; set; }

    }
}
