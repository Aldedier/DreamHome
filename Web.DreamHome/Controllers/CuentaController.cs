using Comun.DreamHome;
using System.Web.Mvc;
using Negocio.DreamHome;

namespace Web.DreamHome.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Login()
        {
            return View("Login", "_LoginBase");
        }

        [HttpPost]
        public ActionResult Login(LoginDTO loginDTO)
        {
            UsuarioDTO registro = new SistemaRepositorio().ValidarLogin(loginDTO);

            if (registro.Sesion_id != 0)
            {
                Session["Usuario_id"] = registro.Usuario_id;
                Session["Usuario"] = registro.Usuario;
                Session["Nombre_Usuario"] = registro.Nombre_Usuario;
                Session["Rol_id"] = registro.Rol_id;
                Session["Sesion_id"] = registro.Sesion_id;
                return RedirectToAction("Inicial", "Inmueble");
            }

            ViewBag.MENSAJE = registro.Mensaje;

            return View("Login", "_LoginBase");
        }

        public ActionResult LogOff()
        {
            Session["Usuario_id"] = null;
            Session["Usuario"] = null;
            Session["Nombre_Usuario"] = null;
            Session["Rol_id"] = null;
            Session["Sesion_id"] = null;
            return RedirectToAction("Login", "Cuenta");
        }

        public ActionResult Perfil()
        {
            return View();
        }


    }
}