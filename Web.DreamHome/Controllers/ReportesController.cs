namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Collections.Generic;
    using System.Web.Mvc;


    public class ReportesController : Controller
    {
        // Reporte Salpicon
        public ActionResult ReporteInmuebles()
        {
            ViewBag.REPORTE = new List<InmueblesRegistradosDTO>();
            return View();
        }


        [HttpPost]
        public ActionResult ReporteInmuebles(InmueblesRegistradosDTO inmueblesRegistradosDTO)
        {
            ViewBag.REPORTE = new InmueblesRegistradosRepositorio().ReporteInmueblesRegistrados(inmueblesRegistradosDTO);
            return View();
        }





    }
}