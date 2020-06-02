using Comun.DreamHome;
using Negocio.DreamHome.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.DreamHome.Controllers
{
    public class AnunciosController :BaseController
    {
        public ActionResult Inicial(string _mensaje = null)
        {
            ViewBag.Mensaje = _mensaje;

            List<AnuncioDTO> listaInmueblesDTO = new AnunciosRepositorio().ConsultaAnuncios((int)GetSession());

            //List<InmueblesRegistradosDTO> listaInmueblesRegistradosDTO = new InmueblesRegistradosRepositorio().ConsultaInmueblesRegistrados(new InmueblesRegistradosDTO { SESSION = GetSession() });

            //foreach (var item in listaInmueblesDTO)
            //{
            //    item.DetallesInmueblesDTOs = new DetallesInmueblesRepositorio().ConsultaDetallesInmuebles(new DetallesInmueblesDTO { IDF_INMUEBLE = item.ID_INMUEBLE, SESSION = GetSession() });
            //    item.InmueblesRegistradosDTOs = listaInmueblesRegistradosDTO.Where(x => x.IDF_INMUEBLE_REG == item.ID_INMUEBLE).ToList();
            //}

            return View(listaInmueblesDTO);
        }

        public ActionResult Crear()
        {
            ViewBag.IDF_PERIODICO = new SelectList(new ListasRepositorio().ConsultarPeriodicos(), "ID_PERIODICO", "NOMBRE_PERIODICO");
            ViewBag.IDF_INMUEBLE = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM");

            //ViewBag.Mensaje = null;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(AnuncioDTO anuncioDTO)
        {
            anuncioDTO.SESSION = GetSession();
            ViewBag.IDF_PERIODICO = new SelectList(new ListasRepositorio().ConsultarPeriodicos(), "ID_PERIODICO", "NOMBRE_PERIODICO", anuncioDTO.IDF_PERIODICO_ANN);
            ViewBag.IDF_INMUEBLE = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", anuncioDTO.IDF_INMUEBLE_ANN);

            // ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO", inmueblesDTO.IDF_TIPO_INM);
            return RedirectToAction("Inicial", "Anuncio", new { _mensaje = new AnunciosRepositorio().ValidarAnuncio(anuncioDTO) });
        }

        public ActionResult Editar(int _id)
        {
            AnuncioDTO datos = new AnunciosRepositorio().ConsultaAnuncios((int)GetSession()).Where(x => x.ID_ANUNCIO == _id).FirstOrDefault();
            //    ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO", datos.IDF_TIPO_INM);
            ViewBag.IDF_PERIODICO = new SelectList(new ListasRepositorio().ConsultarPeriodicos(), "ID_PERIODICO", "NOMBRE_PERIODICO", datos.IDF_PERIODICO_ANN);
            ViewBag.IDF_INMUEBLE = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", datos.IDF_INMUEBLE_ANN);

            return View(datos);
        }

        [HttpPost]
        public ActionResult Editar(AnuncioDTO anuncioDTO)
        {
            //   ViewBag.IDF_TIPO_INM = new SelectList(new ListasRepositorio().ConsultarTiposPropiedades(), "ID_TIPO", "NOMBRE_TIPO", inmueblesDTO.IDF_TIPO_INM);
            ViewBag.IDF_PERIODICO = new SelectList(new ListasRepositorio().ConsultarPeriodicos(), "ID_PERIODICO", "NOMBRE_PERIODICO", anuncioDTO.IDF_PERIODICO_ANN);
            ViewBag.IDF_INMUEBLE = new SelectList(new ListasRepositorio().ConsultarInmuebles(), "ID_INMUEBLE", "DIRECCION_INM", anuncioDTO.IDF_INMUEBLE_ANN);
            anuncioDTO.SESSION = GetSession();
            return RedirectToAction("Inicial", "Anuncio", new { _mensaje = new AnunciosRepositorio().ActualizarAnuncio(anuncioDTO) });
        }

        public ActionResult Eliminar(int _id)
        {
            return RedirectToAction("Inicial", "Anuncio", new { _mensaje = new AnunciosRepositorio().EliminarAnuncio(new AnuncioDTO {ID_ANUNCIO = _id, SESSION = GetSession() }) });
        }

    }
}