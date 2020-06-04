using Comun.DreamHome;
using Negocio.DreamHome.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.DreamHome.Controllers
{
    public class ContactosPeriodicosController :BaseController
    {
        public ActionResult Crear(int _idPropietario)
        {
            //ViewBag.IDF_TIPO_CONTACTO_PROP = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO");
            //ViewBag.IDF_PROPIETARIO_CNTCT = _idPropietario;
            //ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ContactosPeriodicoDTO contactosPeriodicosDTO)
        {
            contactosPeriodicosDTO.SESSION = GetSession();
         //   ViewBag.IDF_TIPO_CONTACTO_PROP = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", contactosPropietariosDTO.IDF_TIPO_CONTACTO_PROP);
            return RedirectToAction("Inicial", "Periodicos", new { _mensaje = new ContactosPeriodicosRepositorio().ValidarContactoPeriodico(contactosPeriodicosDTO) });
        }

        public ActionResult Editar(int _id)
        {
            ContactosPeriodicoDTO datos = new ContactosPeriodicosRepositorio().ConsultaContactosPeriodicos((int)GetSession()).Where(x => x.ID_CONTACTO_PERIODICO == _id).FirstOrDefault();
         //   ViewBag.IDF_TIPO_CONTACTO_PROP = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", datos.IDF_TIPO_CONTACTO_PROP);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(ContactosPeriodicoDTO contactosperiodicosDTO)
        {
           // ViewBag.IDF_TIPO_CONTACTO_PROP = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", contactosPropietariosDTO.IDF_TIPO_CONTACTO_PROP);
            contactosperiodicosDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Periodicos", new { _mensaje = new ContactosPeriodicosRepositorio().ActualizarContactoPeriodicos(contactosperiodicosDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Periodicos", new { _mensaje = new ContactosPeriodicosRepositorio().EliminarContactoPeriodicos(new  ContactosPeriodicoDTO{  ID_CONTACTO_PERIODICO= _id, SESSION = GetSession() }) });
        }

    }
}