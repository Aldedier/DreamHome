namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class RequerimientosClientesRepositorio
    {
        public string ValidarRequerimientosCliente(RequerimientosClientesDTO requerimientosClientesDTO)
        {
            string resultado = new RequerimientosClientesDB().CrearRequerimientosCliente(requerimientosClientesDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarRequerimientosCliente(RequerimientosClientesDTO requerimientosClientesDTO)
        {
            string resultado = new RequerimientosClientesDB().EditarRequerimientosCliente(requerimientosClientesDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarRequerimientosCliente(RequerimientosClientesDTO requerimientosClientesDTO)
        {
            string resultado = new RequerimientosClientesDB().EliminarRequerimientosCliente(requerimientosClientesDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<RequerimientosClientesDTO> ConsultaRequerimientosClientes(int _session)
        {
            return new RequerimientosClientesDB().ListaRequerimientosClientes(_session);
        }
    }
}
