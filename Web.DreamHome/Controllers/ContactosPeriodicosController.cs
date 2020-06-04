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
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;

            List<ContactosPeriodicoDTO> listaContratosDTO = new ContactosPeriodicosRepositorio().ConsultaContactosPeriodicos((int)GetSession());


            return View(listaContratosDTO);
        }
        public ActionResult Crear()
        {
            ViewBag.IDF_TIPO_CONTACTO = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO");
            ViewBag.IDF_PERIODICO = new SelectList(new ListasRepositorio().ConsultarPeriodicos(), "ID_PERIODICO", "NOMBRE_PERIODICO");

            
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ContactosPeriodicoDTO contactosPeriodicosDTO)
        {
            contactosPeriodicosDTO.SESSION = GetSession();
            ViewBag.IDF_TIPO_CONTACTO = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", contactosPeriodicosDTO.IDF_TIPO_CONTACTO);
            ViewBag.IDF_PERIODICO = new SelectList(new ListasRepositorio().ConsultarPeriodicos(), "ID_PERIODICO", "NOMBRE_PERIODICO",contactosPeriodicosDTO.IDF_PERIODICO);

            return RedirectToAction("Inicial", "ContactosPeriodicos", new { _mensaje = new ContactosPeriodicosRepositorio().ValidarContactoPeriodico(contactosPeriodicosDTO) });
        }

        public ActionResult Editar(int _id)
        {
            ContactosPeriodicoDTO datos = new ContactosPeriodicosRepositorio().ConsultaContactosPeriodicos((int)GetSession()).Where(x => x.ID_CONTACTO_PERIODICO == _id).FirstOrDefault();
            ViewBag.IDF_TIPO_CONTACTO = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", datos.IDF_TIPO_CONTACTO);
            ViewBag.IDF_PERIODICO = new SelectList(new ListasRepositorio().ConsultarPeriodicos(), "ID_PERIODICO", "NOMBRE_PERIODICO",datos.IDF_PERIODICO);

            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(ContactosPeriodicoDTO contactosperiodicosDTO)
        {
            ViewBag.IDF_TIPO_CONTACTO = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", contactosperiodicosDTO.IDF_TIPO_CONTACTO);
            ViewBag.IDF_PERIODICO = new SelectList(new ListasRepositorio().ConsultarPeriodicos(), "ID_PERIODICO", "NOMBRE_PERIODICO",contactosperiodicosDTO.IDF_PERIODICO);

            contactosperiodicosDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "ContactosPeriodicos", new { _mensaje = new ContactosPeriodicosRepositorio().ActualizarContactoPeriodicos(contactosperiodicosDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "ContactosPeriodicos", new { _mensaje = new ContactosPeriodicosRepositorio().EliminarContactoPeriodicos(new  ContactosPeriodicoDTO{  ID_CONTACTO_PERIODICO= _id, SESSION = GetSession() }) });
        }

    }
}