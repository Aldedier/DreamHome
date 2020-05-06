namespace Datos.DreamHome.ConexionOracle
{
    using System.Collections.Generic;

    /// <summary>
    /// Clase genérica heredada de Newton para procesar las respuestas desde el repositorio al controlador
    /// </summary>
    public class ResultadosOperacion
    {
        /// <summary>
        /// Indica si el resultado de una operación es satisfactorio
        /// </summary>
        public bool ResultadoExitoso { get; set; } = true;

        /// <summary>
        /// Indica si durante la operación se geeró un warning
        /// </summary>
        public bool Warning { get; set; } = false;

        /// <summary>
        /// Lista de errores de validación durante la operación
        /// </summary>
        public List<ErrorValidacion> ErroresValidacion { get; set; } = new List<ErrorValidacion>();

        /// <summary>
        /// Lista de warnigs durante la operación
        /// </summary>
        public List<ErrorValidacion> WarningValidacion { get; set; } = new List<ErrorValidacion>();

        /// <summary>
        /// Campo con el ID del registro insertado, luego de la encripción.
        /// </summary>
        private string _registroIdEncriptado = null;

        /// <summary>
        /// Propieadad con el ID creado, encriptado
        /// </summary>
        public string RegistroIdEncriptado
        {
            get
            {
                return _registroIdEncriptado;
            }
            set
            {
                _registroIdEncriptado = value;
            }
        }

        /// <summary>
        /// En caso de retornar un objeto, cotiene el objeto retornado
        /// </summary>
        public object ObjetoRetornado { get; set; }

        /// <summary>
        /// ID del registro creado, antes de encriptar
        /// </summary>
        public int RegistroId { get; set; }

        /// <summary>
        /// Método para agregar un error de validación
        /// </summary>
        /// <param name="Mensaje"></param>
        /// <param name="Campo"></param>
        public void AgregarErrorValidacion(string Mensaje, string Campo = "")
        {
            ResultadoExitoso = false;
            if (MensajeResultadoFinal == "Registro procesado correctamente")
            {
                MensajeResultadoFinal = "Se presentaron errores en la validación de los datos, por favor corrijalos para poder continuar";
            }
            if (ErroresValidacion == null)
            {
                ErroresValidacion = new List<ErrorValidacion>();
            }
            ErroresValidacion.Add(new ErrorValidacion()
            {
                Campo = Campo,
                Mensaje = Mensaje
            });
        }

        /// <summary>
        /// Método para agregar un warning
        /// </summary>
        /// <param name="Mensaje"></param>
        /// <param name="Campo"></param>
        public void AgregarWarningValidacion(string Mensaje, string Campo = "")
        {
            Warning = true;
            if (MensajeResultadoFinal == "Registro procesado correctamente")
            {
                MensajeResultadoFinal = "Se presentaron errores en la validación de los datos, por favor corrijalos para poder continuar";
            }
            if (ErroresValidacion == null)
            {
                ErroresValidacion = new List<ErrorValidacion>();
            }
            WarningValidacion.Add(new ErrorValidacion()
            {
                Campo = Campo,
                Mensaje = Mensaje
            });
        }

        /// <summary>
        /// Propieadad con el texto de resultado
        /// </summary>
        public string MensajeResultadoFinal { get; set; } = "Registro procesado correctamente";

        /// <summary>
        /// Método para uir dos Resultados de operación
        /// </summary>
        /// <param name="Resultados"></param>
        public void IntegrarResultados(ResultadosOperacion Resultados)
        {
            if (ResultadoExitoso && !Resultados.ResultadoExitoso)
            {
                ResultadoExitoso = false;
            }
            if (Resultados.Warning)
            {
                Warning = true;
            }
            foreach (var errorValidacion in Resultados.ErroresValidacion)
            {
                ErroresValidacion.Add(errorValidacion);
            }
            foreach (var warningValidacion in Resultados.WarningValidacion)
            {
                WarningValidacion.Add(warningValidacion);
            }
            if (string.IsNullOrEmpty(RegistroIdEncriptado) && !string.IsNullOrEmpty(Resultados.RegistroIdEncriptado))
            {
                RegistroIdEncriptado = Resultados.RegistroIdEncriptado;
            }
        }

        /// <summary>
        /// Estructura de datos para un error de validación
        /// </summary>
        public class ErrorValidacion
        {
            /// <summary>
            /// Campo de la vista sobre el que se indica el error, si no se especifica o es vacío, se muestra en la lista general de errores.
            /// Se debe tener precaución de ingresar correctamente el campo ya que si no se hace, el error no se mostrará claramente en la interfaz ya que no tiene campo asociado
            /// </summary>
            public string Campo { get; set; }

            /// <summary>
            /// Mensaje de validación a incluir.
            /// </summary>
            public string Mensaje { get; set; }
        }
    }
}
