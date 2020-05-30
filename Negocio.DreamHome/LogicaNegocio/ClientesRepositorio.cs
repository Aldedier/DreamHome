namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.LogicaBaseDatos;
    using System.Collections.Generic;

    public class ClientesRepositorio
    {
        public string ValidarCliente(ClientesDTO clientesDTO)
        {
            string resultado = new ClientesDB().CrearCliente(clientesDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarCliente(ClientesDTO clientesDTO)
        {
            string resultado = new ClientesDB().EditarCliente(clientesDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarCliente(ClientesDTO clientesDTO)
        {
            string resultado = new ClientesDB().EliminarCliente(clientesDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<ClientesDTO> ConsultaClientes(int _session)
        {
            return new ClientesDB().ListaClientes(_session);
        }
    }
}
