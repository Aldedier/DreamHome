namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Linq;
    using System.Web.Mvc;

    public class ContactosPropietariosController : BaseController
    {
        public ActionResult Crear(int _idPropietario)
        {
            ViewBag.IDF_TIPO_CONTACTO_PROP = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO");
            ViewBag.IDF_PROPIETARIO_CNTCT = _idPropietario;
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ContactosPropietariosDTO contactosPropietariosDTO)
        { 
            contactosPropietariosDTO.SESSION = GetSession();
            ViewBag.IDF_TIPO_CONTACTO_PROP = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", contactosPropietariosDTO.IDF_TIPO_CONTACTO_PROP);
            return RedirectToAction("Inicial", "Propietarios", new { _mensaje = new ContactosPropietariosRepositorio().ValidarContactosPropietario(contactosPropietariosDTO) });
        }

        public ActionResult Editar(int _id)
        {
            ContactosPropietariosDTO datos = new ContactosPropietariosRepositorio().ConsultaContactosPropietarios((int)GetSession()).Where(x => x.ID_CONTACTO_PROPIETARIO == _id).FirstOrDefault();
            ViewBag.IDF_TIPO_CONTACTO_PROP = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", datos.IDF_TIPO_CONTACTO_PROP);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(ContactosPropietariosDTO contactosPropietariosDTO)
        {
            ViewBag.IDF_TIPO_CONTACTO_PROP = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", contactosPropietariosDTO.IDF_TIPO_CONTACTO_PROP);
            contactosPropietariosDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Propietarios", new { _mensaje = new ContactosPropietariosRepositorio().ActualizarContactosPropietario(contactosPropietariosDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Propietarios", new { _mensaje = new ContactosPropietariosRepositorio().EliminarContactosPropietario(new ContactosPropietariosDTO { ID_CONTACTO_PROPIETARIO = _id, SESSION = GetSession() }) });
        }

    }
}