using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datos.DreamHome.ContextoBaseDatos
{
    [Serializable]
    [Table(nameof(ESTADOS_CONTRATOS), Schema = "BD_DREAM_HOME")]
    public  class ESTADOS_CONTRATOS
    {
        [Key]
        public decimal ID_ESTADO_CONTRATO { get; set; }
        public string ESTADO_CONTRATO { get; set; }
    }
}
