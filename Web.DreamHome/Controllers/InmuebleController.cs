using Comun.DreamHome;
using Negocio.DreamHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.DreamHome.Controllers
{
    public class InmuebleController : Controller
    {
        public ActionResult Inicial()
        {
            return View(new InmueblesRepositorio().ConsultaInmuebles());
        }

        public ActionResult Crear()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem { Value = "1", Text = "Apartamento" });
            lista.Add(new SelectListItem { Value = "2", Text = "Casa" });
            ViewBag.IDF_TIPO_INM = new SelectList(lista, "Value", "Text");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(InmueblesDTO inmueblesDTO)
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem { Value = "1", Text = "Apartamento" });
            lista.Add(new SelectListItem { Value = "2", Text = "Casa" });
            ViewBag.IDF_TIPO_INM = new SelectList(lista, "Value", "Text");

            if (ModelState.IsValid)
            {
                new InmueblesRepositorio().ValidarInmueble(inmueblesDTO);
                return RedirectToAction("Inicial", "Inmueble");
            }

            return View();
        }

        public ActionResult Editar(int _id)
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem { Value = "1", Text = "Apartamento" });
            lista.Add(new SelectListItem { Value = "2", Text = "Casa" });

            InmueblesDTO datos = new InmueblesRepositorio().ConsultaInmuebles().Where(x => x.ID_INMUEBLE == _id).FirstOrDefault();
            ViewBag.IDF_TIPO_INM = new SelectList(lista, "Value", "Text", datos.IDF_TIPO_INM);

            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(InmueblesDTO inmueblesDTO)
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem { Value = "1", Text = "Apartamento" });
            lista.Add(new SelectListItem { Value = "2", Text = "Casa" });

            InmueblesDTO datos = new InmueblesRepositorio().ConsultaInmuebles().Where(x => x.ID_INMUEBLE == inmueblesDTO.ID_INMUEBLE).FirstOrDefault();
            ViewBag.IDF_TIPO_INM = new SelectList(lista, "Value", "Text", datos.IDF_TIPO_INM);

            if (ModelState.IsValid)
            {
                new InmueblesRepositorio().ActualizarInmueble(inmueblesDTO);
                return RedirectToAction("Inicial", "Inmueble");
            }

            return View(datos);
        }

        public ActionResult Eliminar(int _id)
        {
            new InmueblesRepositorio().EliminarInmueble(new InmueblesDTO {ID_INMUEBLE = _id});
            return RedirectToAction("Inicial", "Inmueble");
        }

    }
}