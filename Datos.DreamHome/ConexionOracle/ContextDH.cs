namespace Datos.DreamHome.ConexionOracle
{
    using System.Data;
    using System.Data.Entity;
    using System.Diagnostics;

    /// <summary>
    /// Contexto de datos de DreamHome (DbContext) para las conexiones de Entity Framework
    /// </summary>
    public partial class ContextDH : DbContext
    {
        public ContextDH() : base("ContextoDH")
        {
            // Deshabilitar la sincronización del modelo de base de datos
            //this.Database.Connection.StateChange += Connection_StateChange;
            Database.SetInitializer<ContextDH>(null);
            this.Database.Log = s => Debug.WriteLine(s);
        }

        /// <summary>
        /// Al detectar la conexión, se ejecuta el procedimiento almacenado para indicar a la base de datos la información de auditoría (usuario e IP)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            if (e.OriginalState == ConnectionState.Closed && e.CurrentState == ConnectionState.Open)
            {
                try
                {
                }
                catch { }
            }
        }

        /// <summary>
        /// Listado de DBSets de mapeo a la base de datos
        /// </summary>
        //public virtual IDbSet<StpAutoridad> StpAutoridad { get; set; }
        //public virtual IDbSet<StpConduccionPersonas> StpConduccionPersonas { get; set; }
        //public virtual IDbSet<StpConduVerificaCondicion> StpConduVerificaCondicion { get; set; }
        //public virtual IDbSet<StpIngresoElementos> StpIngresoElementos { get; set; }
        //public virtual IDbSet<StpMotivoDevolucion> StpMotivoDevolucion { get; set; }
        //public virtual IDbSet<StpPersona> StpPersona { get; set; }
        //public virtual IDbSet<StpFotoPersona> StpFotoPersona { get; set; }

    }
}