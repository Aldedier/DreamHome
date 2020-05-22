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
        //public virtual IDbSet<LOG_ERROR> LOG_ERROR { get; set; }

    }
}
