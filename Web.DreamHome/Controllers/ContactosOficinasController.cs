namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Linq;
    using System.Web.Mvc;

    public class ContactosOficinasController : BaseController
    {
        public ActionResult Crear(int _idOficina)
        {
            ViewBag.IDF_TIPO_CNTC_OFC = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO");
            ViewBag.IDF_OFICINA_CNTC = _idOficina;
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ContactosOficinasDTO contactosOficinasDTO)
        {
            contactosOficinasDTO.SESSION = GetSession();
            ViewBag.IDF_TIPO_CNTC_OFC = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", contactosOficinasDTO.IDF_TIPO_CNTC_OFC);
            return RedirectToAction("Inicial", "Oficinas", new { _mensaje = new ContactosOficinasRepositorio().ValidarContactosOficina(contactosOficinasDTO) });
        }

        public ActionResult Editar(int _id)
        {
            ContactosOficinasDTO datos = new ContactosOficinasRepositorio().ConsultaContactosOficinas((int)GetSession()).Where(x => x.ID_CONTACTO_OFICINA == _id).FirstOrDefault();
            ViewBag.IDF_TIPO_CNTC_OFC = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", datos.IDF_TIPO_CNTC_OFC);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(ContactosOficinasDTO contactosOficinasDTO)
        {
            ViewBag.IDF_TIPO_CNTC_OFC = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", contactosOficinasDTO.IDF_TIPO_CNTC_OFC);
            contactosOficinasDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Oficinas", new { _mensaje = new ContactosOficinasRepositorio().ActualizarContactosOficina(contactosOficinasDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Oficinas", new { _mensaje = new ContactosOficinasRepositorio().EliminarContactosOficina(new ContactosOficinasDTO { ID_CONTACTO_OFICINA = _id, SESSION = GetSession() }) });
        }

    }
}