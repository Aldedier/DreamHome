namespace Web.DreamHome.Controllers
{
    using System;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        public int? GetSession()
        {
            int? session = null;

            try
            {
                session = Convert.ToInt32(Session["Sesion_id"]);
            }
            catch
            {
                session = null;
            }

            return session;
        }
    }
}