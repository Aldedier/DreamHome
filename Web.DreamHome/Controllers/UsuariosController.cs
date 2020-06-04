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
    public class UsuariosController :BaseController
    {
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;

            List<UsuariosDTO> listaContratosDTO = new UsuariosRepositorio().ConsultaUsuarios((int)GetSession());

         
            return View(listaContratosDTO);
        }

        public ActionResult Crear()
        {
            ViewBag.IDF_ROL_USR = new SelectList(new ListasRepositorio().ConsultarTiposUsuarios(), "ID_ROL", "ROL_USUARIO");
           
            ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(UsuariosDTO usuarioDTO)
        {
            usuarioDTO.SESSION = GetSession();
            ViewBag.IDF_ROL_USR = new SelectList(new ListasRepositorio().ConsultarTiposUsuarios(), "ID_ROL", "ROL_USUARIO", usuarioDTO.IDF_ROL_USR);


            return RedirectToAction("Inicial", "Usuarios", new { _mensaje = new UsuariosRepositorio().ValidarUsuarios(usuarioDTO) });
        }

        public ActionResult Editar(int _id)
        {
            UsuariosDTO datos = new UsuariosRepositorio().ConsultaUsuarios((int)GetSession()).Where(x => x.ID_USUARIO == _id).FirstOrDefault();
            ViewBag.IDF_ROL_USR = new SelectList(new ListasRepositorio().ConsultarTiposUsuarios(), "ID_ROL", "ROL_USUARIO", datos.IDF_ROL_USR);

            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(UsuariosDTO usuarioDTO)
        {
            ViewBag.IDF_ROL_USR = new SelectList(new ListasRepositorio().ConsultarTiposUsuarios(), "ID_ROL", "ROL_USUARIO", usuarioDTO.IDF_ROL_USR);

            usuarioDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Usuarios", new { _mensaje = new UsuariosRepositorio().ActualizarUsuarios(usuarioDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Usuarios", new { _mensaje = new UsuariosRepositorio().EliminarUsuarios(new UsuariosDTO{ ID_USUARIO = _id, SESSION = GetSession() }) });
        }
    }
}