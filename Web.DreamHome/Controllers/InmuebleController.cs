namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome;
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
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem { Value = "1", Text = "Apartamento" });
            lista.Add(new SelectListItem { Value = "2", Text = "Casa" });

            ViewBag.IDF_TIPO_INM = new SelectList(lista, "Value", "Text");
            ViewBag.Mensaje = null;

            return View();
        }

        [HttpPost]
        public ActionResult Crear(InmueblesDTO inmueblesDTO)
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem { Value = "1", Text = "Apartamento" });
            lista.Add(new SelectListItem { Value = "2", Text = "Casa" });

            ViewBag.IDF_TIPO_INM = new SelectList(lista, "Value", "Text");

            inmueblesDTO.SESSION = GetSession();

            string mensaje = new InmueblesRepositorio().ValidarInmueble(inmueblesDTO); ;

            return RedirectToAction("Inicial", "Inmueble", new { _mensaje = mensaje });
        }

        public ActionResult Editar(int _id)
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem { Value = "1", Text = "Apartamento" });
            lista.Add(new SelectListItem { Value = "2", Text = "Casa" });

            InmueblesDTO datos = new InmueblesRepositorio().ConsultaInmuebles((int)GetSession()).Where(x => x.ID_INMUEBLE == _id).FirstOrDefault();

            ViewBag.IDF_TIPO_INM = new SelectList(lista, "Value", "Text", datos.IDF_TIPO_INM);

            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(InmueblesDTO inmueblesDTO)
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem { Value = "1", Text = "Apartamento" });
            lista.Add(new SelectListItem { Value = "2", Text = "Casa" });

            inmueblesDTO.SESSION = GetSession();

            InmueblesDTO datos = new InmueblesRepositorio().ConsultaInmuebles((int)inmueblesDTO.SESSION).Where(x => x.ID_INMUEBLE == inmueblesDTO.ID_INMUEBLE).FirstOrDefault();

            ViewBag.IDF_TIPO_INM = new SelectList(lista, "Value", "Text", datos.IDF_TIPO_INM);
            string mensaje = new InmueblesRepositorio().ActualizarInmueble(inmueblesDTO);

            return RedirectToAction("Inicial", "Inmueble", new { _mensaje = mensaje });
        }

        public ActionResult Eliminar(int _id)
        {
            string mensaje = new InmueblesRepositorio().EliminarInmueble(new InmueblesDTO { ID_INMUEBLE = _id, SESSION = GetSession() });
            return RedirectToAction("Inicial", "Inmueble", new { _mensaje = mensaje });
        }

    }
}