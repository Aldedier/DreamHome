using Comun.DreamHome;
using Negocio.DreamHome.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.DreamHome.Controllers
{
    public class PagosController :BaseController
    {
        public ActionResult Crear(int _idPropietario)
        {
            //ViewBag.IDF_TIPO_CONTACTO_PROP = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO");
            //ViewBag.IDF_PROPIETARIO_CNTCT = _idPropietario;
            //ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(PagosDTO PagosDTO)
        {
            PagosDTO.SESSION = GetSession();
      //      ViewBag.IDF_TIPO_CONTACTO_PROP = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", contactosPropietariosDTO.IDF_TIPO_CONTACTO_PROP);
            return RedirectToAction("Inicial", "Pagos", new { _mensaje = new PagosRepositorio().ValidarPago(PagosDTO) });
        }

        public ActionResult Editar(int _id)
        {
            PagosDTO datos = new PagosRepositorio().ConsultaPagos((int)GetSession()).Where(x => x.ID_PAGO == _id).FirstOrDefault();
          //  ViewBag.IDF_TIPO_CONTACTO_PROP = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", datos.IDF_TIPO_CONTACTO_PROP);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(PagosDTO PagosDTO)
        {
            //    ViewBag.IDF_TIPO_CONTACTO_PROP = new SelectList(new ListasRepositorio().ConsultarTiposContactos(), "ID_TIPO_CONTACTO", "TIPO_CONTACTO", contactosPropietariosDTO.IDF_TIPO_CONTACTO_PROP);
            PagosDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Pagos", new { _mensaje = new PagosRepositorio().ActualizarPago(PagosDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Pagos", new { _mensaje = new PagosRepositorio().EliminarPago(new PagosDTO { ID_PAGO = _id, SESSION = GetSession() }) });
        }

    }
}