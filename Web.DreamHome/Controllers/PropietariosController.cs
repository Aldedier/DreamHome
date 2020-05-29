namespace Web.DreamHome.Controllers
{
    using Comun.DreamHome;
    using Negocio.DreamHome.LogicaNegocio;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class PropietariosController : BaseController
    {
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;

            List<PropietariosDTO> listaPropietarios = new PropietariosRepositorio().ConsultaPropietarios((int)GetSession());

            List<InmueblesPropietariosDTO> listaInmueblesPropietarios = new InmueblesPropietariosRepositorio().ConsultaInmueblesPropietarios((int)GetSession());
            List<ContactosPropietariosDTO> listaContactos = new ContactosPropietariosRepositorio().ConsultaContactosPropietarios((int)GetSession());

            foreach (var item in listaPropietarios)
            {
                item.ContactosPropietariosDTOs = listaContactos.Where(x => x.IDF_PROPIETARIO_CNTCT == item.ID_PROPIETARIO).ToList();
                item.InmueblesPropietariosDTOs = listaInmueblesPropietarios.Where(x => x.IDF_PROPIETARIO_PROP == item.ID_PROPIETARIO).ToList();
            }

            return View(listaPropietarios);
        }

        public ActionResult Crear()
        {
            ViewBag.IDF_USUARIO_PROP = new SelectList(new ListasRepositorio().ConsultarUsuarios(), "Usuario_id", "Nombre_Usuario");
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(PropietariosDTO propietariosDTO)
        {
            propietariosDTO.SESSION = GetSession();
            ViewBag.IDF_USUARIO_PROP = new SelectList(new ListasRepositorio().ConsultarUsuarios(), "Usuario_id", "Nombre_Usuario", propietariosDTO.IDF_USUARIO_PROP);
            return RedirectToAction("Inicial", "Propietarios", new { _mensaje = new PropietariosRepositorio().Validarpropietario(propietariosDTO) });
        }

        public ActionResult Editar(int _id)
        {
            PropietariosDTO datos = new PropietariosRepositorio().ConsultaPropietarios((int)GetSession()).Where(x => x.ID_PROPIETARIO == _id).FirstOrDefault();
            ViewBag.IDF_USUARIO_PROP = new SelectList(new ListasRepositorio().ConsultarUsuarios(), "Usuario_id", "Nombre_Usuario", datos.IDF_USUARIO_PROP);
            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(PropietariosDTO propietariosDTO)
        {
            ViewBag.IDF_USUARIO_PROP = new SelectList(new ListasRepositorio().ConsultarUsuarios(), "Usuario_id", "Nombre_Usuario", propietariosDTO.IDF_USUARIO_PROP);
            propietariosDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Propietarios", new { _mensaje = new PropietariosRepositorio().Actualizarpropietario(propietariosDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Propietarios", new { _mensaje = new PropietariosRepositorio().Eliminarpropietario(new PropietariosDTO { ID_PROPIETARIO = _id, SESSION = GetSession() }) });
        }

    }
}