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
            ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(InmueblesDTO inmueblesDTO)
        {
            inmueblesDTO.SESSION = GetSession();
            ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO", inmueblesDTO.IDF_TIPO_INM);
            return RedirectToAction("Inicial", "Inmueble", new { _mensaje = new InmueblesRepositorio().ValidarInmueble(inmueblesDTO) });
        }

        public ActionResult Editar(int _id)
        {
            InmueblesDTO datos = new InmueblesRepositorio().ConsultaInmuebles((int)GetSession()).Where(x => x.ID_INMUEBLE == _id).FirstOrDefault();
            ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO", datos.IDF_TIPO_INM);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(InmueblesDTO inmueblesDTO)
        {
            ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO", inmueblesDTO.IDF_TIPO_INM);
            inmueblesDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Inmueble", new { _mensaje = new InmueblesRepositorio().ActualizarInmueble(inmueblesDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Inmueble", new { _mensaje = new InmueblesRepositorio().EliminarInmueble(new InmueblesDTO { ID_INMUEBLE = _id, SESSION = GetSession() }) });
        }

    }
}