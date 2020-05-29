namespace Comun.DreamHome
{
    using System;

    public class VisitasDTO
    {
        public int ID_VISITA { get; set; }
        public int IDF_INMUEBLE_REG_VST { get; set; }
        public string INMUEBLE { get; set; }
        public int IDF_CLIENTE_VST { get; set; }
        public string CLIENTE { get; set; }
        public string COMENTARIO { get; set; }
        public DateTime FECHA_VST { get; set; }
        public DateTime HORA_VST { get; set; }
        public int REALIZADA { get; set; }
        public int? SESSION { get; set; } = null;
    }
}
