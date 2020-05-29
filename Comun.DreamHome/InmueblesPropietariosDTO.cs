namespace Comun.DreamHome
{
    using System;

    public class InmueblesPropietariosDTO
    {
        public int ID_INMUEBLE_PROPIETARIO { get; set; }
        public int IDF_INMUEBLE_PROP { get; set; } = 0;
        public string INMUEBLE { get; set; }
        public int IDF_PROPIETARIO_PROP { get; set; }
        public DateTime FECHA_PROP { get; set; }
        public int? SESSION { get; set; } = null;
    }
}
