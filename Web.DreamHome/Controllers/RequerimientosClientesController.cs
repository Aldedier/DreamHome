namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class RequerimientosClientesController : BaseController
    {
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;
            return View(new RequerimientosClientesRepositorio().ConsultaRequerimientosClientes((int)GetSession()));
        }

        public ActionResult Crear()
        {
            ViewBag.IDF_CLIENTE_RQRM = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT");
            ViewBag.IDF_OFICINA_RQRM = new SelectList(new ListasRepositorio().ConsultarOficinas(), "ID_OFICINA", "OFICINA");
            ViewBag.IDF_EMPLEADO_RQRM = new SelectList(new ListasRepositorio().ConsultarEmpleados(), "ID_EMPLEADO", "NOMBRE_RH");
            ViewBag.IDF_TIPO_RQRM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO");
            ViewBag.IDF_ESTADO_RQRM = new SelectList(new ListasRepositorio().ConsultarEstadosRequerimiento(), "ID_ESTADO_REQUERIMIENTO", "ESTADO_REQUERIMIENTO");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(RequerimientosClientesDTO requerimientosClientesDTO)
        {
            requerimientosClientesDTO.SESSION = GetSession();
            ViewBag.IDF_CLIENTE_RQRM = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT", requerimientosClientesDTO.IDF_CLIENTE_RQRM);
            ViewBag.IDF_OFICINA_RQRM = new SelectList(new ListasRepositorio().ConsultarOficinas(), "ID_OFICINA", "OFICINA", requerimientosClientesDTO.IDF_OFICINA_RQRM);
            ViewBag.IDF_EMPLEADO_RQRM = new SelectList(new ListasRepositorio().ConsultarEmpleados(), "ID_EMPLEADO", "NOMBRE_RH", requerimientosClientesDTO.IDF_EMPLEADO_RQRM);
            ViewBag.IDF_TIPO_RQRM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO", requerimientosClientesDTO.IDF_TIPO_RQRM);
            ViewBag.IDF_ESTADO_RQRM = new SelectList(new ListasRepositorio().ConsultarEstadosRequerimiento(), "ID_ESTADO_REQUERIMIENTO", "ESTADO_REQUERIMIENTO", requerimientosClientesDTO.IDF_ESTADO_RQRM);
            return RedirectToAction("Inicial", "RequerimientosClientes", new { _mensaje = new RequerimientosClientesRepositorio().ValidarRequerimientosCliente(requerimientosClientesDTO) });
        }

        public ActionResult Editar(int _id)
        {
            RequerimientosClientesDTO datos = new RequerimientosClientesRepositorio().ConsultaRequerimientosClientes((int)GetSession()).Where(x => x.ID_REQUERIMIENTO == _id).FirstOrDefault();
            ViewBag.IDF_CLIENTE_RQRM = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT", datos.IDF_CLIENTE_RQRM);
            ViewBag.IDF_OFICINA_RQRM = new SelectList(new ListasRepositorio().ConsultarOficinas(), "ID_OFICINA", "OFICINA", datos.IDF_OFICINA_RQRM);
            ViewBag.IDF_EMPLEADO_RQRM = new SelectList(new ListasRepositorio().ConsultarEmpleados(), "ID_EMPLEADO", "NOMBRE_RH", datos.IDF_EMPLEADO_RQRM);
            ViewBag.IDF_TIPO_RQRM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO", datos.IDF_TIPO_RQRM);
            ViewBag.IDF_ESTADO_RQRM = new SelectList(new ListasRepositorio().ConsultarEstadosRequerimiento(), "ID_ESTADO_REQUERIMIENTO", "ESTADO_REQUERIMIENTO", datos.IDF_ESTADO_RQRM);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(RequerimientosClientesDTO requerimientosClientesDTO)
        {
            ViewBag.IDF_CLIENTE_RQRM = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT", requerimientosClientesDTO.IDF_CLIENTE_RQRM);
            ViewBag.IDF_OFICINA_RQRM = new SelectList(new ListasRepositorio().ConsultarOficinas(), "ID_OFICINA", "OFICINA", requerimientosClientesDTO.IDF_OFICINA_RQRM);
            ViewBag.IDF_EMPLEADO_RQRM = new SelectList(new ListasRepositorio().ConsultarEmpleados(), "ID_EMPLEADO", "NOMBRE_RH", requerimientosClientesDTO.IDF_EMPLEADO_RQRM);
            ViewBag.IDF_TIPO_RQRM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO", requerimientosClientesDTO.IDF_TIPO_RQRM);
            ViewBag.IDF_ESTADO_RQRM = new SelectList(new ListasRepositorio().ConsultarEstadosRequerimiento(), "ID_ESTADO_REQUERIMIENTO", "ESTADO_REQUERIMIENTO", requerimientosClientesDTO.IDF_ESTADO_RQRM);
            requerimientosClientesDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "RequerimientosClientes", new { _mensaje = new RequerimientosClientesRepositorio().ActualizarRequerimientosCliente(requerimientosClientesDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "RequerimientosClientes", new { _mensaje = new RequerimientosClientesRepositorio().EliminarRequerimientosCliente(new RequerimientosClientesDTO { ID_REQUERIMIENTO = _id, SESSION = GetSession() }) });
        }

    }
}