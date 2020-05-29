namespace Comun.DreamHome
{
    using System;
    using System.Collections.Generic;

    public class PropietariosDTO
    {
        public int ID_PROPIETARIO { get; set; }
        public int IDF_USUARIO_PROP { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRE_PROP { get; set; }
        public string DIRECCION_PROP { get; set; }
        public string APARTADO_PROP { get; set; }
        public int ACTIVO_PROP { get; set; }
        public DateTime FECHA_PROP { get; set; }
        public int? SESSION { get; set; } = null;
        public List<ContactosPropietariosDTO> ContactosPropietariosDTOs { get; set; } = new List<ContactosPropietariosDTO>();
    }
}
