namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(PERIODICOS), Schema = "BD_DREAM_HOME")]
    public class PERIODICOS
    {
        [Key]
        public decimal ID_PERIODICO { get; set; }
        public string NOMBRE_PERIODICO { get; set; }
        public string CONTACTO
        {
            get; set;

        }
    }
}
