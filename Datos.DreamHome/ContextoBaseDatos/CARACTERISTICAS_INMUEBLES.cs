namespace Datos.DreamHome.ContextoBaseDatos
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table(nameof(CARACTERISTICAS_INMUEBLES), Schema = "BD_DREAM_HOME")]
    public class CARACTERISTICAS_INMUEBLES
    {
        [Key]
        public int ID_CARACTERISTICA_PROP { get; set; }
        public string CARACTERISTICA { get; set; }
        public int FORZOSA { get; set; }
        public int BINARIA { get; set; }
    }
}
