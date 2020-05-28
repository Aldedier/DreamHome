namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Linq;
    using System.Web.Mvc;

    public class ContactosEmpleadosController : BaseController
    {
        public ActionResult Crear(int _idEmpleado)
        {
            ViewBag.IDF_TIPO_CONTACTO_CNTCT = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO");
            ViewBag.IDF_EMPLEADO_CNTCT = _idEmpleado;
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ContactosEmpleadosDTO contactosEmpleadosDTO)
        {
            contactosEmpleadosDTO.SESSION = GetSession();
            ViewBag.IDF_TIPO_CONTACTO_CNTCT = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", contactosEmpleadosDTO.IDF_TIPO_CONTACTO_CNTCT);
            return RedirectToAction("Inicial", "Empleados", new { _mensaje = new ContactosEmpleadosRepositorio().ValidarContactosEmpleado(contactosEmpleadosDTO) });
        }

        public ActionResult Editar(int _id)
        {
            ContactosEmpleadosDTO datos = new ContactosEmpleadosRepositorio().ConsultaContactosEmpleados((int)GetSession()).Where(x => x.ID_CONTACTO_EMPLEADO == _id).FirstOrDefault();
            ViewBag.IDF_TIPO_CONTACTO_CNTCT = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", datos.IDF_TIPO_CONTACTO_CNTCT);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(ContactosEmpleadosDTO contactosEmpleadosDTO)
        {
            ViewBag.IDF_TIPO_CONTACTO_CNTCT = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", contactosEmpleadosDTO.IDF_TIPO_CONTACTO_CNTCT);
            contactosEmpleadosDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Empleados", new { _mensaje = new ContactosEmpleadosRepositorio().ActualizarContactosEmpleado(contactosEmpleadosDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Empleados", new { _mensaje = new ContactosEmpleadosRepositorio().EliminarContactosEmpleado(new ContactosEmpleadosDTO { ID_CONTACTO_EMPLEADO = _id, SESSION = GetSession() }) });
        }

    }
}