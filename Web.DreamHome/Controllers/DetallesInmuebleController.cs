namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class DetallesInmuebleController : BaseController
    {
        public ActionResult Crear(int _idInmueble)
        {
            ViewBag.IDF_CARACTERISTICA = new SelectList(new ListasRepositorio().ConsultarCaracteristicasInmuebles(), "ID_CARACTERISTICA_PROP", "CARACTERISTICA");
            ViewBag.IDF_INMUEBLE = _idInmueble;
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(DetallesInmueblesDTO detallesInmueblesDTO)
        {
            detallesInmueblesDTO.SESSION = GetSession();
            ViewBag.IDF_CARACTERISTICA = new SelectList(new ListasRepositorio().ConsultarCaracteristicasInmuebles(), "ID_CARACTERISTICA_PROP", "CARACTERISTICA", detallesInmueblesDTO.IDF_CARACTERISTICA);
            return RedirectToAction("Inicial", "Inmueble", new { _mensaje = new DetallesInmueblesRepositorio().ValidarDetallesInmueble(detallesInmueblesDTO) });
        }

        public ActionResult Editar(int _idDetalleInmueble)
        {
            DetallesInmueblesDTO datos = new DetallesInmueblesRepositorio().ConsultaDetallesInmueble(new DetallesInmueblesDTO { ID_DETALLE_INMBL = _idDetalleInmueble, SESSION = GetSession() });
            ViewBag.IDF_CARACTERISTICA = new SelectList(new ListasRepositorio().ConsultarCaracteristicasInmuebles(), "ID_CARACTERISTICA_PROP", "CARACTERISTICA", datos.IDF_CARACTERISTICA);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(DetallesInmueblesDTO detallesInmueblesDTO)
        {
            ViewBag.IDF_CARACTERISTICA = new SelectList(new ListasRepositorio().ConsultarCaracteristicasInmuebles(), "ID_CARACTERISTICA_PROP", "CARACTERISTICA", detallesInmueblesDTO.IDF_CARACTERISTICA);
            detallesInmueblesDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Inmueble", new { _mensaje = new DetallesInmueblesRepositorio().ActualizarDetallesInmueble(detallesInmueblesDTO) });
        }

        public ActionResult Eliminar(int _idDetalleInmueble)
        {
            return RedirectToAction("Inicial", "Inmueble", new { _mensaje = new DetallesInmueblesRepositorio().EliminarDetallesInmueble(new DetallesInmueblesDTO { ID_DETALLE_INMBL = _idDetalleInmueble, SESSION = GetSession() }) });
        }

    }
}