namespace Comun.DreamHome
{
    using System;
    using System.Collections.Generic;

    public class ClientesDTO
    {
        public int ID_CLIENTE { get; set; }
        public int IDF_USUARIO_CLINT { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRE_CLINT { get; set; }
        public string DIRECCION_CLINT { get; set; }
        public int ACTIVO_CLINT { get; set; }
        public DateTime FECHA_CLINT { get; set; }
        public string ESTADO { get; set; }
        public int? SESSION { get; set; } = null;
        public List<RequerimientosClientesDTO> requerimientosClientesDTOs { get; set; } = new List<RequerimientosClientesDTO>();
    }
}
