using Comun.DreamHome;
using Datos.DreamHome.LogicaBaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DreamHome.LogicaNegocio
{
 public   class ContratosRepositorio
    {
        public string ValidarContrato(ContratosDTO ContratosDTO)
        {
            string resultado = new ContratosDB().CrearContrato(ContratosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarContrato(ContratosDTO ContratosDTO)
        {
            string resultado = new ContratosDB().EditarContrato(ContratosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarContrato(ContratosDTO ContratosDTO)
        {
            string resultado = new ContratosDB().EliminarContrato(ContratosDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<ClientesDTO> ConsultaContratos(int _session)
        {
            return new ClientesDB().ListaClientes(_session);
        }
    }
}
