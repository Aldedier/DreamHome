namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class VisitasController : BaseController
    {
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;

            List<VisitasDTO> visitasDTOs = new VisitasRepositorio().ConsultaVisitas((int)GetSession());

            return View(visitasDTOs);
        }

        public ActionResult Crear()
        {
            ViewBag.IDF_CLIENTE_VST = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT");
            ViewBag.IDF_INMUEBLE_REG_VST = new SelectList(new InmueblesRegistradosRepositorio().ConsultaInmueblesRegistrados(new InmueblesRegistradosDTO { SESSION = GetSession()}), "ID_INMUEBLE_REGISTRADO", "DESCRIPCION");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(VisitasDTO visitasDTO)
        {
            visitasDTO.SESSION = GetSession();
            ViewBag.IDF_CLIENTE_VST = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT", visitasDTO.IDF_CLIENTE_VST);
            ViewBag.IDF_INMUEBLE_REG_VST = new SelectList(new InmueblesRegistradosRepositorio().ConsultaInmueblesRegistrados(new InmueblesRegistradosDTO { SESSION = GetSession() }), "ID_INMUEBLE_REGISTRADO", "DESCRIPCION", visitasDTO.IDF_INMUEBLE_REG_VST);
            return RedirectToAction("Inicial", "Visitas", new { _mensaje = new VisitasRepositorio().ValidarVisita(visitasDTO) });
        }

        public ActionResult Editar(int _id)
        {
            VisitasDTO datos = new VisitasRepositorio().ConsultaVisitas((int)GetSession()).Where(x => x.ID_VISITA == _id).FirstOrDefault();
            ViewBag.IDF_CLIENTE_VST = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT", datos.IDF_CLIENTE_VST);
            ViewBag.IDF_INMUEBLE_REG_VST = new SelectList(new InmueblesRegistradosRepositorio().ConsultaInmueblesRegistrados(new InmueblesRegistradosDTO { SESSION = GetSession() }), "ID_INMUEBLE_REGISTRADO", "DESCRIPCION", datos.IDF_INMUEBLE_REG_VST);
            ViewBag.REALIZADA = new SelectList(new List<SelectListItem>{ new SelectListItem { Value = "1", Text = "Si" }, new SelectListItem { Value = "0", Text = "No" } }, "Value", "Text");
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(VisitasDTO visitasDTO)
        {
            ViewBag.IDF_CLIENTE_VST = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT", visitasDTO.IDF_CLIENTE_VST);
            ViewBag.IDF_INMUEBLE_REG_VST = new SelectList(new InmueblesRegistradosRepositorio().ConsultaInmueblesRegistrados(new InmueblesRegistradosDTO { SESSION = GetSession() }), "ID_INMUEBLE_REGISTRADO", "DESCRIPCION", visitasDTO.IDF_INMUEBLE_REG_VST);
            ViewBag.REALIZADA = new SelectList(new List<SelectListItem> { new SelectListItem { Value = "1", Text = "Si" }, new SelectListItem { Value = "0", Text = "No" } }, "Value", "Text");
            visitasDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Visitas", new { _mensaje = new VisitasRepositorio().ActualizarVisita(visitasDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Visitas", new { _mensaje = new VisitasRepositorio().EliminarVisita(new VisitasDTO { ID_VISITA = _id, SESSION = GetSession() }) });
        }

    }
}