using Comun.DreamHome;
using Negocio.DreamHome.LogicaNegocio;
using Comun.DreamHome;
using Negocio.DreamHome.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.DreamHome.Controllers
{
    public class ContratosController :BaseController
    {
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;

            List<ContratosDTO> listaContratosDTO = new ContratosRepositorio().ConsultaContratos((int)GetSession());

            //List<InmueblesRegistradosDTO> listaInmueblesRegistradosDTO = new InmueblesRegistradosRepositorio().ConsultaInmueblesRegistrados(new InmueblesRegistradosDTO { SESSION = GetSession() });

            //foreach (var item in listaInmueblesDTO)
            //{
            //    item.DetallesInmueblesDTOs = new DetallesInmueblesRepositorio().ConsultaDetallesInmuebles(new DetallesInmueblesDTO { IDF_INMUEBLE = item.ID_INMUEBLE, SESSION = GetSession() });
            //    item.InmueblesRegistradosDTOs = listaInmueblesRegistradosDTO.Where(x => x.IDF_INMUEBLE_REG == item.ID_INMUEBLE).ToList();
            //}

            return View(listaContratosDTO);
        }

        public ActionResult Crear()
        {
            ViewBag.IDF_CLIENTE = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT");
            ViewBag.IDF_INMUEBLE = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM");
            ViewBag.IDF_FORMAPAGO = new SelectList(new ListasRepositorio().ConsultarTiposPagos(), "ID_FORMA_PAGO", "FORMA_PAGO");
            ViewBag.IDF_ESTADOCONTRATO = new SelectList(new ListasRepositorio().ConsultarEstadosContratos(), "ID_ESTADO_CONTRATO", "ESTADO_CONTRATO");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ContratosDTO contratosDTO)
        {
            contratosDTO.SESSION = GetSession();
            //   ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO", inmueblesDTO.IDF_TIPO_INM);
            ViewBag.IDF_CLIENTE = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT", contratosDTO.IDF_CLIENTE_CNTR);
            ViewBag.IDF_INMUEBLE = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", contratosDTO.IDF_INMBL_EMPLD_CNTR);
            ViewBag.IDF_FORMAPAGO = new SelectList(new ListasRepositorio().ConsultarTiposPagos(), "ID_FORMA_PAGO", "FORMA_PAGO", contratosDTO.IDF_FORMA_PAGO_CNTR);
            ViewBag.IDF_ESTADOCONTRATO = new SelectList(new ListasRepositorio().ConsultarEstadosContratos(), "ID_ESTADO_CONTRATO", "ESTADO_CONTRATO", contratosDTO.IDF_ESTADO_CONTRATO);
            return RedirectToAction("Inicial", "Contrato", new { _mensaje = new ContratosRepositorio().ValidarContrato(contratosDTO) });
        }

        public ActionResult Editar(int _id)
        {
            ContratosDTO datos = new ContratosRepositorio().ConsultaContratos((int)GetSession()).Where(x => x.ID_CONTRATO == _id).FirstOrDefault();
            //   ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO", datos.IDF_TIPO_INM);
            ViewBag.IDF_CLIENTE = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT", datos.IDF_CLIENTE_CNTR);
            ViewBag.IDF_INMUEBLE = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", datos.IDF_INMBL_EMPLD_CNTR);
            ViewBag.IDF_FORMAPAGO = new SelectList(new ListasRepositorio().ConsultarTiposPagos(), "ID_FORMA_PAGO", "FORMA_PAGO", datos.IDF_FORMA_PAGO_CNTR);
            ViewBag.IDF_ESTADOCONTRATO = new SelectList(new ListasRepositorio().ConsultarEstadosContratos(), "ID_ESTADO_CONTRATO", "ESTADO_CONTRATO", datos.IDF_ESTADO_CONTRATO);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(ContratosDTO contratosDTO)
        {
            // ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO", inmueblesDTO.IDF_TIPO_INM);
            ViewBag.IDF_CLIENTE = new SelectList(new ListasRepositorio().ConsultarClientes(), "ID_CLIENTE", "NOMBRE_CLINT", contratosDTO.IDF_CLIENTE_CNTR);
            ViewBag.IDF_INMUEBLE = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", contratosDTO.IDF_INMBL_EMPLD_CNTR);
            ViewBag.IDF_FORMAPAGO = new SelectList(new ListasRepositorio().ConsultarTiposPagos(), "ID_FORMA_PAGO", "FORMA_PAGO", contratosDTO.IDF_FORMA_PAGO_CNTR);
            ViewBag.IDF_ESTADOCONTRATO = new SelectList(new ListasRepositorio().ConsultarEstadosContratos(), "ID_ESTADO_CONTRATO", "ESTADO_CONTRATO", contratosDTO.IDF_ESTADO_CONTRATO);

            contratosDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Contrato", new { _mensaje = new ContratosRepositorio().ActualizarContrato(contratosDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Contrato", new { _mensaje = new ContratosRepositorio().EliminarContrato(new ContratosDTO{ ID_CONTRATO = _id, SESSION = GetSession() }) });
        }
    }
}