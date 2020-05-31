using Comun.DreamHome;
using Datos.DreamHome.LogicaBaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DreamHome.LogicaNegocio
{
   public class ContactosPeriodicosRepositorio
    {
        public string ValidarContactoPeriodico(ContactosPeriodicoDTO ContactoPeriodicosDTO)
        {
            string resultado = new ContactosPeriodicosDB().CrearContactosPeriodicos(ContactoPeriodicosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarContactoPeriodicos(ContactosPeriodicoDTO ContactoPeriodicosDTO)
        {
            string resultado = new ContactosPeriodicosDB().EditarContactosPeriodicos(ContactoPeriodicosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarContactoPeriodicos(ContactosPeriodicoDTO ContactoPeriodicosDTO)
        {
            string resultado = new ContactosPeriodicosDB().EliminarContactosPeriodicos(ContactoPeriodicosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<ContactosPeriodicoDTO> ConsultaContactosPeriodicos(int _session)
        {
            return new ContactosPeriodicosDB().ListaContactosPeriodicos(_session);
        }
    }
}
