namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class EmpleadosController : BaseController
    {
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;

            List<EmpleadosDTO> listaEmpleados = new EmpleadosRepositorio().ConsultaEmpleados((int)GetSession());
            List<HistorialLaboralDTO> listaHistorialLaboral = new HistorialLaboralRepositorio().ConsultaHistorialLaboral((int)GetSession());
            List<ContactosEmpleadosDTO> listaContactos = new ContactosEmpleadosRepositorio().ConsultaContactosEmpleados((int)GetSession());

            foreach (var item in listaEmpleados)
            {
                item.HistorialLaboralDTOs = listaHistorialLaboral.Where(x => x.IDF_EMPLEADO_HST == item.ID_EMPLEADO).ToList();
                item.ContactosEmpleadosDTOs = listaContactos.Where(x => x.IDF_EMPLEADO_CNTCT == item.ID_EMPLEADO).ToList();
            }

            return View(listaEmpleados);
        }

        public ActionResult Crear()
        {
            ViewBag.IDF_GENERO_RH = new SelectList(new ListasRepositorio().ConsultarGeneros(), "ID_GENERO", "GENERO");
            ViewBag.IDF_USUARIO_RH = new SelectList(new ListasRepositorio().ConsultarUsuarios(), "Usuario_id", "Nombre_Usuario");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(EmpleadosDTO empleadosDTO)
        {
            empleadosDTO.SESSION = GetSession();
            ViewBag.IDF_GENERO_RH = new SelectList(new ListasRepositorio().ConsultarGeneros(), "ID_GENERO", "GENERO", empleadosDTO.IDF_GENERO_RH);
            ViewBag.IDF_USUARIO_RH = new SelectList(new ListasRepositorio().ConsultarUsuarios(), "Usuario_id", "Nombre_Usuario", empleadosDTO.IDF_USUARIO_RH);
            return RedirectToAction("Inicial", "Empleados", new { _mensaje = new EmpleadosRepositorio().ValidarEmpleado(empleadosDTO) });
        }

        public ActionResult Editar(int _id)
        {
            EmpleadosDTO datos = new EmpleadosRepositorio().ConsultaEmpleados((int)GetSession()).Where(x => x.ID_EMPLEADO == _id).FirstOrDefault();
            ViewBag.IDF_GENERO_RH = new SelectList(new ListasRepositorio().ConsultarGeneros(), "ID_GENERO", "GENERO", datos.IDF_GENERO_RH);
            ViewBag.IDF_USUARIO_RH = new SelectList(new ListasRepositorio().ConsultarUsuarios(), "Usuario_id", "Nombre_Usuario", datos.IDF_USUARIO_RH);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(EmpleadosDTO empleadosDTO)
        {
            ViewBag.IDF_GENERO_RH = new SelectList(new ListasRepositorio().ConsultarGeneros(), "ID_GENERO", "GENERO", empleadosDTO.IDF_GENERO_RH);
            ViewBag.IDF_USUARIO_RH = new SelectList(new ListasRepositorio().ConsultarUsuarios(), "Usuario_id", "Nombre_Usuario", empleadosDTO.IDF_USUARIO_RH);
            empleadosDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Empleados", new { _mensaje = new EmpleadosRepositorio().ActualizarEmpleado(empleadosDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Empleados", new { _mensaje = new EmpleadosRepositorio().EliminarEmpleado(new EmpleadosDTO { ID_EMPLEADO = _id, SESSION = GetSession() }) });
        }

    }
}