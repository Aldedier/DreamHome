namespace Datos.DreamHome.ContextoBaseDatos
{
    using System.Data.Entity;

    public class ContextoDreamHome : DbContext
    {
        public ContextoDreamHome() : base("ContextoDH")
        {
            Database.SetInitializer<ContextoDreamHome>(null);
        }

        public virtual IDbSet<TIPOS_PROPIEDADES> TIPOS_PROPIEDADES { get; set; }
        public virtual IDbSet<GENEROS> GENEROS { get; set; }
        public virtual IDbSet<USUARIOS> USUARIOS { get; set; }
        public virtual IDbSet<CIUDADES> CIUDADES { get; set; }
        public virtual IDbSet<CARGOS> CARGOS { get; set; }
        public virtual IDbSet<OFICINAS> OFICINAS { get; set; }
        public virtual IDbSet<ESTADOS_REQUERIMIENTOS> ESTADOS_REQUERIMIENTOS { get; set; }
        public virtual IDbSet<ESTADOS_INMUEBLES> ESTADOS_INMUEBLES { get; set; }
        public virtual IDbSet<EMPLEADOS> EMPLEADOS { get; set; }
        public virtual IDbSet<CLIENTES> CLIENTES { get; set; }
        public virtual IDbSet<VST_INMUEBLES> VST_INMUEBLES { get; set; }
        public virtual IDbSet<CARACTERISTICAS_INMUEBLES> CARACTERISTICAS_INMUEBLES { get; set; }
        public virtual IDbSet<TIPOS_CONTACTOS> TIPOS_CONTACTOS { get; set; }

        public virtual IDbSet<TIPOS_PAGOS> TIPOS_PAGOS { get; set; }

        public virtual IDbSet<ESTADOS_CONTRATOS> ESTADOS_CONTRATOS{ get; set; }
        public virtual IDbSet<PERIODICOS> PERIODICOS { get; set; }


    }
}
