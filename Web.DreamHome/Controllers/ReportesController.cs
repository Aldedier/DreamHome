namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Collections.Generic;
    using System.Web.Mvc;


    public class ReportesController : BaseController
    {
        public ActionResult ReporteInmuebles()
        {
            ViewBag.REPORTE = new List<InmueblesRegistradosDTO>();
            return View();
        }


        [HttpPost]
        public ActionResult ReporteInmuebles(InmueblesRegistradosDTO inmueblesRegistradosDTO)
        {
            inmueblesRegistradosDTO.SESSION = GetSession();
            ViewBag.REPORTE = new InmueblesRegistradosRepositorio().ReporteInmueblesRegistrados(inmueblesRegistradosDTO);
            return View();
        }


        public ActionResult ReporteAuditoria()
        {
            ViewBag.REPORTE = new List<InmueblesRegistradosDTO>();
            return View();
        }


        [HttpPost]
        public ActionResult ReporteAuditoria(AuditoriaDTO auditoriaDTO)
        {
            auditoriaDTO.SESSION = GetSession();
            ViewBag.REPORTE = new SistemaRepositorio().ReporteAuditoria(auditoriaDTO);
            return View();
        }



    }
}