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
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;

            List<PagosDTO> listaContratosDTO = new PagosRepositorio().ConsultaPagos((int)GetSession());

            return View(listaContratosDTO);
        }
        public ActionResult Crear()
        {
            ViewBag.IDF_CONTRATO_PG = new SelectList(new ListasRepositorio().ConsultarContratos(), "ID_CONTRATO", "ID_CONTRATO");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(PagosDTO PagosDTO)
        {
            PagosDTO.SESSION = GetSession();
            ViewBag.IDF_CONTRATO_PG = new SelectList(new ListasRepositorio().ConsultarContratos(), "ID_CONTRATO", "ID_CONTRATO", PagosDTO.IDF_CONTRATO_PG);
            return RedirectToAction("Inicial", "Pagos", new { _mensaje = new PagosRepositorio().ValidarPago(PagosDTO) });
        }

        public ActionResult Editar(int _id)
        {
            PagosDTO datos = new PagosRepositorio().ConsultaPagos((int)GetSession()).Where(x => x.ID_PAGO == _id).FirstOrDefault();
            ViewBag.IDF_CONTRATO_PG = new SelectList(new ListasRepositorio().ConsultarContratos(), "ID_CONTRATO", "ID_CONTRATO", datos.IDF_CONTRATO_PG);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(PagosDTO PagosDTO)
        {
            ViewBag.IDF_CONTRATO_PG = new SelectList(new ListasRepositorio().ConsultarContratos(), "ID_CONTRATO", "ID_CONTRATO", PagosDTO.IDF_CONTRATO_PG);
            PagosDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Pagos", new { _mensaje = new PagosRepositorio().ActualizarPago(PagosDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Pagos", new { _mensaje = new PagosRepositorio().EliminarPago(new PagosDTO { ID_PAGO = _id, SESSION = GetSession() }) });
        }

    }
}