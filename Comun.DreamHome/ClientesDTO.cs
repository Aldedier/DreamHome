namespace Comun.DreamHome
{
    using System;

    public class ClientesDTO
    {
        public int ID_CLIENTE { get; set; }
        public int IDF_USUARIO_CLINT { get; set; }
        public string NOMBRE_CLINT { get; set; }
        public string DIRECCION_CLINT { get; set; }
        public int ACTIVO_CLINT { get; set; }
        public DateTime FECHA_CLINT { get; set; }
    }
}
