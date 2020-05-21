namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class InmuebleController : BaseController
    {
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;
            return View(new InmueblesRepositorio().ConsultaInmuebles((int)GetSession()));
        }

        public ActionResult Crear()
        {
            ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "Value", "Text");
            ViewBag.Mensaje = null;

            return View();
        }

        [HttpPost]
        public ActionResult Crear(InmueblesDTO inmueblesDTO)
        {
            ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "Value", "Text");

            inmueblesDTO.SESSION = GetSession();

            return RedirectToAction("Inicial", "Inmueble", new { _mensaje = new InmueblesRepositorio().ValidarInmueble(inmueblesDTO) });
        }

        public ActionResult Editar(int _id)
        {
            ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "Value", "Text");

            InmueblesDTO datos = new InmueblesRepositorio().ConsultaInmuebles((int)GetSession()).Where(x => x.ID_INMUEBLE == _id).FirstOrDefault();

            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(InmueblesDTO inmueblesDTO)
        {
            ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "Value", "Text");

            inmueblesDTO.SESSION = GetSession();

            InmueblesDTO datos = new InmueblesRepositorio().ConsultaInmuebles((int)inmueblesDTO.SESSION).Where(x => x.ID_INMUEBLE == inmueblesDTO.ID_INMUEBLE).FirstOrDefault();

            return RedirectToAction("Inicial", "Inmueble", new { _mensaje = new InmueblesRepositorio().ActualizarInmueble(inmueblesDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Inmueble", new { _mensaje = new InmueblesRepositorio().EliminarInmueble(new InmueblesDTO { ID_INMUEBLE = _id, SESSION = GetSession() }) });
        }

    }
}