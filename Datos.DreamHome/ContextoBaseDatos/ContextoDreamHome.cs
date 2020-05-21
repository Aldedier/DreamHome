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

        //public virtual IDbSet<CADNETOIDROLES> CADNETOIDROLES { get; set; }
        //public virtual IDbSet<CADNETROLES> CADNETROLES { get; set; }
        //public virtual IDbSet<DISEC_SISTEMA> DISEC_SISTEMA { get; set; }
        //public virtual IDbSet<LOG_ERROR> LOG_ERROR { get; set; }

    }
}
