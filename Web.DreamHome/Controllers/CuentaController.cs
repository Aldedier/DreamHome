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
            new SistemaRepositorio().ValidarLogin(loginDTO);
            return View("Login", "_LoginBase");
        }
    }
}