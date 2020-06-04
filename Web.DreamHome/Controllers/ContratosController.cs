using Comun.DreamHome;
using Negocio.DreamHome.LogicaNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Web.DreamHome.Controllers
{
    public class ContratosController :BaseController
    {
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;

            List<ContratosDTO> listaContratosDTO = new ContratosRepositorio().ConsultaContratos((int)GetSession());

            return View(listaContratosDTO);
        }

        public ActionResult Crear()
        {
            ViewBag.IDF_CLIENTE_CNTR = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT");
            ViewBag.IDF_INMUEBLE_CNTR = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM");
            ViewBag.IDF_FORMA_PAGO_CNTR = new SelectList(new ListasRepositorio().ConsultarTiposPagos(), "ID_FORMA_PAGO", "FORMA_PAGO");
            ViewBag.IDF_ESTADO_CONTRATO = new SelectList(new ListasRepositorio().ConsultarEstadosContratos(), "ID_ESTADO_CONTRATO", "ESTADO_CONTRATO");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ContratosDTO contratosDTO)
        {
            contratosDTO.SESSION = GetSession();
            ViewBag.IDF_CLIENTE_CNTR = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT", contratosDTO.IDF_CLIENTE_CNTR);
            ViewBag.IDF_INMUEBLE_CNTR = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", contratosDTO.IDF_INMUEBLE_CNTR);
            ViewBag.IDF_FORMA_PAGO_CNTR = new SelectList(new ListasRepositorio().ConsultarTiposPagos(), "ID_FORMA_PAGO", "FORMA_PAGO", contratosDTO.IDF_FORMA_PAGO_CNTR);
            ViewBag.IDF_ESTADO_CONTRATO = new SelectList(new ListasRepositorio().ConsultarEstadosContratos(), "ID_ESTADO_CONTRATO", "ESTADO_CONTRATO", contratosDTO.IDF_ESTADO_CONTRATO);
            return RedirectToAction("Inicial", "Contratos", new { _mensaje = new ContratosRepositorio().ValidarContrato(contratosDTO) });
        }

        public ActionResult Editar(int _id)
        {
            ContratosDTO datos = new ContratosRepositorio().ConsultaContratos((int)GetSession()).Where(x => x.ID_CONTRATO == _id).FirstOrDefault();
            ViewBag.IDF_CLIENTE_CNTR = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT", datos.IDF_CLIENTE_CNTR);
            ViewBag.IDF_INMUEBLE_CNTR = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", datos.IDF_INMUEBLE_CNTR);
            ViewBag.IDF_FORMA_PAGO_CNTR = new SelectList(new ListasRepositorio().ConsultarTiposPagos(), "ID_FORMA_PAGO", "FORMA_PAGO", datos.IDF_FORMA_PAGO_CNTR);
            ViewBag.IDF_ESTADO_CONTRATO = new SelectList(new ListasRepositorio().ConsultarEstadosContratos(), "ID_ESTADO_CONTRATO", "ESTADO_CONTRATO", datos.IDF_ESTADO_CONTRATO);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(ContratosDTO contratosDTO)
        {
            ViewBag.IDF_CLIENTE_CNTR = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT", contratosDTO.IDF_CLIENTE_CNTR);
            ViewBag.IDF_INMUEBLE_CNTR = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", contratosDTO.IDF_INMUEBLE_CNTR);
            ViewBag.IDF_FORMA_PAGO_CNTR = new SelectList(new ListasRepositorio().ConsultarTiposPagos(), "ID_FORMA_PAGO", "FORMA_PAGO", contratosDTO.IDF_FORMA_PAGO_CNTR);
            ViewBag.IDF_ESTADO_CONTRATO = new SelectList(new ListasRepositorio().ConsultarEstadosContratos(), "ID_ESTADO_CONTRATO", "ESTADO_CONTRATO", contratosDTO.IDF_ESTADO_CONTRATO);

            contratosDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Contratos", new { _mensaje = new ContratosRepositorio().ActualizarContrato(contratosDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Contratos", new { _mensaje = new ContratosRepositorio().EliminarContrato(new ContratosDTO{ ID_CONTRATO = _id, SESSION = GetSession() }) });
        }
    }
}