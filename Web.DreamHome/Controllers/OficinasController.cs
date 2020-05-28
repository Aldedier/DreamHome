namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class OficinasController : BaseController
    {
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;

            List<OficinasDTO> oficinasDTOs = new OficinasRepositorio().ConsultaOficinas((int)GetSession());
            List<ContactosOficinasDTO> contactosOficinasDTOs = new ContactosOficinasRepositorio().ConsultaContactosOficinas((int)GetSession());

            foreach (var item in oficinasDTOs)
            {
                item.ContactosOficinasDTOs = contactosOficinasDTOs.Where(x => x.IDF_OFICINA_CNTC == item.ID_OFICINA).ToList();
            }

            return View(oficinasDTOs);
        }

        public ActionResult Crear()
        {
            ViewBag.IDF_CIUDAD_OFC = new SelectList(new ListasRepositorio().ConsultarCiudades(), "ID_CIUDAD", "CIUDAD");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(OficinasDTO oficinasDTO)
        {
            oficinasDTO.SESSION = GetSession();
            ViewBag.IDF_CIUDAD_OFC = new SelectList(new ListasRepositorio().ConsultarCiudades(), "ID_CIUDAD", "CIUDAD", oficinasDTO.IDF_CIUDAD_OFC);
            return RedirectToAction("Inicial", "Oficinas", new { _mensaje = new OficinasRepositorio().ValidarOficina(oficinasDTO) });
        }

        public ActionResult Editar(int _id)
        {
            OficinasDTO datos = new OficinasRepositorio().ConsultaOficinas((int)GetSession()).Where(x => x.ID_OFICINA == _id).FirstOrDefault();
            ViewBag.IDF_CIUDAD_OFC = new SelectList(new ListasRepositorio().ConsultarCiudades(), "ID_CIUDAD", "CIUDAD", datos.IDF_CIUDAD_OFC);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(OficinasDTO oficinasDTO)
        {
            ViewBag.IDF_CIUDAD_OFC = new SelectList(new ListasRepositorio().ConsultarCiudades(), "ID_CIUDAD", "CIUDAD", oficinasDTO.IDF_CIUDAD_OFC);
            oficinasDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Oficinas", new { _mensaje = new OficinasRepositorio().ActualizarOficina(oficinasDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Oficinas", new { _mensaje = new OficinasRepositorio().EliminarOficina(new OficinasDTO { ID_OFICINA = _id, SESSION = GetSession() }) });
        }

    }
}