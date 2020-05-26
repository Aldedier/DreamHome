namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class InmueblesRegistradosController : BaseController
    {
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;
            InmueblesRegistradosDTO inmueblesRegistradosDTO = new InmueblesRegistradosDTO { SESSION = (int)GetSession() };
            return View(new InmueblesRegistradosRepositorio().ConsultaInmueblesRegistrados(inmueblesRegistradosDTO));
        }

        public ActionResult Crear()
        {
            ViewBag.IDF_INMUEBLE_REG = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM");
            ViewBag.IDF_OFICINA_REG = new SelectList(new ListasRepositorio().ConsultarOficinas(), "ID_OFICINA", "OFICINA");
            ViewBag.IDF_EMPLEADO_REG = new SelectList(new ListasRepositorio().ConsultarEmpleados(), "ID_EMPLEADO", "NOMBRE_RH");
            ViewBag.IDF_ESTADO_REG = new SelectList(new ListasRepositorio().ConsultarEstadosInmuebles(), "ID_ESTADO_INMUEBLE", "ESTADO_INMUEBLE");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(InmueblesRegistradosDTO inmueblesRegistradosDTO)
        {
            inmueblesRegistradosDTO.SESSION = GetSession();
            ViewBag.IDF_INMUEBLE_REG = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", inmueblesRegistradosDTO.IDF_INMUEBLE_REG);
            ViewBag.IDF_OFICINA_REG = new SelectList(new ListasRepositorio().ConsultarOficinas(), "ID_OFICINA", "OFICINA", inmueblesRegistradosDTO.IDF_OFICINA_REG);
            ViewBag.IDF_EMPLEADO_REG = new SelectList(new ListasRepositorio().ConsultarEmpleados(), "ID_EMPLEADO", "NOMBRE_RH", inmueblesRegistradosDTO.IDF_EMPLEADO_REG);
            ViewBag.IDF_ESTADO_REG = new SelectList(new ListasRepositorio().ConsultarEstadosInmuebles(), "ID_ESTADO_INMUEBLE", "ESTADO_INMUEBLE", inmueblesRegistradosDTO.IDF_ESTADO_REG);
            return RedirectToAction("Inicial", "InmueblesRegistrados", new { _mensaje = new InmueblesRegistradosRepositorio().ValidarInmueblesRegistrado(inmueblesRegistradosDTO) });
        }

        public ActionResult Editar(int _id)
        {
            InmueblesRegistradosDTO inmueblesRegistradosDTO = new InmueblesRegistradosDTO { SESSION = (int)GetSession() };
            InmueblesRegistradosDTO datos = new InmueblesRegistradosRepositorio().ConsultaInmueblesRegistrados(inmueblesRegistradosDTO).Where(x => x.ID_INMUEBLE_REGISTRADO == _id).FirstOrDefault();
            ViewBag.IDF_INMUEBLE_REG = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", datos.IDF_INMUEBLE_REG);
            ViewBag.IDF_OFICINA_REG = new SelectList(new ListasRepositorio().ConsultarOficinas(), "ID_OFICINA", "OFICINA", datos.IDF_OFICINA_REG);
            ViewBag.IDF_EMPLEADO_REG = new SelectList(new ListasRepositorio().ConsultarEmpleados(), "ID_EMPLEADO", "NOMBRE_RH", datos.IDF_EMPLEADO_REG);
            ViewBag.IDF_ESTADO_REG = new SelectList(new ListasRepositorio().ConsultarEstadosInmuebles(), "ID_ESTADO_INMUEBLE", "ESTADO_INMUEBLE", datos.IDF_ESTADO_REG);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(InmueblesRegistradosDTO inmueblesRegistradosDTO)
        {
            ViewBag.IDF_INMUEBLE_REG = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", inmueblesRegistradosDTO.IDF_INMUEBLE_REG);
            ViewBag.IDF_OFICINA_REG = new SelectList(new ListasRepositorio().ConsultarOficinas(), "ID_OFICINA", "OFICINA", inmueblesRegistradosDTO.IDF_OFICINA_REG);
            ViewBag.IDF_EMPLEADO_REG = new SelectList(new ListasRepositorio().ConsultarEmpleados(), "ID_EMPLEADO", "NOMBRE_RH", inmueblesRegistradosDTO.IDF_EMPLEADO_REG);
            ViewBag.IDF_ESTADO_REG = new SelectList(new ListasRepositorio().ConsultarEstadosInmuebles(), "ID_ESTADO_INMUEBLE", "ESTADO_INMUEBLE", inmueblesRegistradosDTO.IDF_ESTADO_REG);
            inmueblesRegistradosDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "InmueblesRegistrados", new { _mensaje = new InmueblesRegistradosRepositorio().ActualizarInmueblesRegistrado(inmueblesRegistradosDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "InmueblesRegistrados", new { _mensaje = new InmueblesRegistradosRepositorio().EliminarInmueblesRegistrado(new InmueblesRegistradosDTO { ID_INMUEBLE_REGISTRADO = _id, SESSION = GetSession() }) });
        }

    }
}