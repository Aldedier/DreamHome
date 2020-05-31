using Comun.DreamHome;
using Datos.DreamHome.LogicaBaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DreamHome.LogicaNegocio
{
   public class PagosRepositorio
    {

        public string ValidarPago(PagosDTO pagoDTO)
        {
            string resultado = new PagosDB().CrearPago(pagoDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }
        public string ActualizarPago(PagosDTO pagoDTO)
        {
            string resultado = new PagosDB().EditarPago(pagoDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarPago(PagosDTO pagoDTO)
        {
            string resultado = new PagosDB().EliminarPago(pagoDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<PagosDTO> ConsultaPagos(int _session)
        {
            return new PagosDB().ListaPagos(_session);
        }
    }
}
