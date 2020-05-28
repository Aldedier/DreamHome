namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Linq;
    using System.Web.Mvc;

    public class HistorialLaboralController : BaseController
    {
        public ActionResult Crear(int _idEmpleado)
        {
            ViewBag.IDF_EMPLEADO_HST = _idEmpleado;
            ViewBag.IDF_OFCINA_HST = new SelectList(new ListasRepositorio().ConsultarOficinas(), "ID_OFICINA", "OFICINA");
            ViewBag.IDF_CARGO_HST = new SelectList(new ListasRepositorio().ConsultarCargos(), "ID_CARGO", "CARGO");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(HistorialLaboralDTO historialLaboralDTO)
        {
            historialLaboralDTO.SESSION = GetSession();
            ViewBag.IDF_OFCINA_HST = new SelectList(new ListasRepositorio().ConsultarOficinas(), "ID_OFICINA", "OFICINA", historialLaboralDTO.IDF_OFCINA_HST);
            ViewBag.IDF_CARGO_HST = new SelectList(new ListasRepositorio().ConsultarCargos(), "ID_CARGO", "CARGO", historialLaboralDTO.IDF_CARGO_HST);
            return RedirectToAction("Inicial", "Empleados", new { _mensaje = new HistorialLaboralRepositorio().ValidarHistorialLaboral(historialLaboralDTO) });
        }

        public ActionResult Editar(int _id)
        {
            HistorialLaboralDTO datos = new HistorialLaboralRepositorio().ConsultaHistorialLaboral((int)GetSession()).Where(x => x.ID_HISTORIAL_LABRL == _id).FirstOrDefault();
            ViewBag.IDF_OFCINA_HST = new SelectList(new ListasRepositorio().ConsultarOficinas(), "ID_OFICINA", "OFICINA", datos.IDF_OFCINA_HST);
            ViewBag.IDF_CARGO_HST = new SelectList(new ListasRepositorio().ConsultarCargos(), "ID_CARGO", "CARGO", datos.IDF_CARGO_HST);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(HistorialLaboralDTO historialLaboralDTO)
        {
            ViewBag.IDF_OFCINA_HST = new SelectList(new ListasRepositorio().ConsultarOficinas(), "ID_OFICINA", "OFICINA", historialLaboralDTO.IDF_OFCINA_HST);
            ViewBag.IDF_CARGO_HST = new SelectList(new ListasRepositorio().ConsultarCargos(), "ID_CARGO", "CARGO", historialLaboralDTO.IDF_CARGO_HST);
            historialLaboralDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Empleados", new { _mensaje = new HistorialLaboralRepositorio().ActualizarHistorialLaboral(historialLaboralDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Empleados", new { _mensaje = new HistorialLaboralRepositorio().EliminarHistorialLaboral(new HistorialLaboralDTO { ID_HISTORIAL_LABRL = _id, SESSION = GetSession() }) });
        }

    }
}