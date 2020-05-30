namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class ClientesController : BaseController
    {
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;

            List<ClientesDTO> clientesDTOs = new ClientesRepositorio().ConsultaClientes((int)GetSession());
            List<RequerimientosClientesDTO> listaRequerimientosClientesDTO  = new RequerimientosClientesRepositorio().ConsultaRequerimientosClientes((int)GetSession());

            foreach (var item in clientesDTOs)
            {
                item.requerimientosClientesDTOs = listaRequerimientosClientesDTO.Where(x => x.IDF_CLIENTE_RQRM == item.ID_CLIENTE).ToList();
            }

            return View(clientesDTOs);
        }

        public ActionResult Crear()
        {
            ViewBag.IDF_USUARIO_CLINT = new SelectList(new ListasRepositorio().ConsultarUsuarios(), "Usuario_id", "Nombre_Usuario");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ClientesDTO clientesDTO)
        {
            clientesDTO.SESSION = GetSession();
            ViewBag.IDF_USUARIO_CLINT = new SelectList(new ListasRepositorio().ConsultarUsuarios(), "Usuario_id", "Nombre_Usuario", clientesDTO.IDF_USUARIO_CLINT);
            return RedirectToAction("Inicial", "Clientes", new { _mensaje = new ClientesRepositorio().ValidarCliente(clientesDTO) });
        }

        public ActionResult Editar(int _id)
        {
            ClientesDTO datos = new ClientesRepositorio().ConsultaClientes((int)GetSession()).Where(x => x.ID_CLIENTE == _id).FirstOrDefault();
            ViewBag.IDF_USUARIO_CLINT = new SelectList(new ListasRepositorio().ConsultarUsuarios(), "Usuario_id", "Nombre_Usuario", datos.IDF_USUARIO_CLINT);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(ClientesDTO clientesDTO)
        {
            ViewBag.IDF_USUARIO_CLINT = new SelectList(new ListasRepositorio().ConsultarUsuarios(), "Usuario_id", "Nombre_Usuario", clientesDTO.IDF_USUARIO_CLINT);
            clientesDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Clientes", new { _mensaje = new ClientesRepositorio().ActualizarCliente(clientesDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Clientes", new { _mensaje = new ClientesRepositorio().EliminarCliente(new ClientesDTO { ID_CLIENTE = _id, SESSION = GetSession() }) });
        }

    }
}