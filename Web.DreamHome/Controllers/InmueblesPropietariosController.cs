namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Linq;
    using System.Web.Mvc;

    public class InmueblesPropietariosController : BaseController
    {
        public ActionResult Crear(int _idPropietario)
        {
            ViewBag.IDF_PROPIETARIO_PROP = _idPropietario;
            ViewBag.IDF_INMUEBLE_PROP = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(InmueblesPropietariosDTO inmueblesPropietariosDTO)
        {
            inmueblesPropietariosDTO.SESSION = GetSession();
            ViewBag.IDF_INMUEBLE_PROP = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", inmueblesPropietariosDTO.IDF_INMUEBLE_PROP);
            return RedirectToAction("Inicial", "Propietarios", new { _mensaje = new InmueblesPropietariosRepositorio().ValidarInmueblesPropietario(inmueblesPropietariosDTO) });
        }

        public ActionResult Editar(int _id)
        {
            InmueblesPropietariosDTO datos = new InmueblesPropietariosRepositorio().ConsultaInmueblesPropietarios((int)GetSession()).Where(x => x.ID_INMUEBLE_PROPIETARIO == _id).FirstOrDefault();
            ViewBag.IDF_INMUEBLE_PROP = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", datos.IDF_INMUEBLE_PROP);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(InmueblesPropietariosDTO inmueblesPropietariosDTO)
        {
            ViewBag.IDF_INMUEBLE_PROP = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", inmueblesPropietariosDTO.IDF_INMUEBLE_PROP); 
            inmueblesPropietariosDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Propietarios", new { _mensaje = new InmueblesPropietariosRepositorio().ActualizarInmueblesPropietario(inmueblesPropietariosDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Propietarios", new { _mensaje = new InmueblesPropietariosRepositorio().EliminarInmueblesPropietario(new InmueblesPropietariosDTO { ID_INMUEBLE_PROPIETARIO = _id, SESSION = GetSession() }) });
        }

    }
}