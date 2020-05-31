using Comun.DreamHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DreamHome.LogicaBaseDatos
{
  public  class PagosRepositorio
    {
        public string ValidarPago(PagosDTO PagosDTO)
        {
            string resultado = new PagosDB().CrearPago(PagosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarPago(PagosDTO PagosDTO)
        {
            string resultado = new PagosDB().EditarPago(PagosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarPago(PagosDTO pagosDTO)
        {
            string resultado = new PagosDB().EliminarPago(pagosDTO);

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
