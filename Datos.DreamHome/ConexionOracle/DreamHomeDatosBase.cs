namespace Datos.DreamHome.ConexionOracle
{
    using System;

    /// <summary>
    /// Repositorio base, del cual desprenden los demás repositorios
    /// </summary>
    public class DreamHomeDatosBase
    {
        /// <summary>
        /// dbContext
        /// </summary>
        public ContextDH _db;

        /// <summary>
        /// Repositorio base que inicializa el dbContext
        /// </summary>
        /// <param name="datosSesion"></param>
        public DreamHomeDatosBase()
        {
            _db = new ContextDH();
        }

        /// <summary>
        /// Guarda los cambios y retorna true si guardó al menos un cambio
        /// </summary>
        /// <returns></returns>
        public ResultadosOperacion GuardarOperacion()
        {
            var retorno = new ResultadosOperacion();
            try
            {
                if (_db.SaveChanges() > 0)
                {
                    retorno.MensajeResultadoFinal = "La operación se ha guardado correctamente";
                }
                else
                {
                    retorno.AgregarErrorValidacion("No se pudo guardar la operación");
                    retorno.MensajeResultadoFinal = "Se presentó un error al procesar la operación";
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            _db.Database.Connection.Close();
            return retorno;
        }
    }
}
