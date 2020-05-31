using Comun.DreamHome;
using Datos.DreamHome.LogicaBaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DreamHome.LogicaNegocio
{
   public class AnunciosRepositorio
    {
        public string ValidarAnuncio(AnuncioDTO anuncioDTO)
        {
            string resultado = new AnunciosDB().CrearAnuncio(anuncioDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string ActualizarAnuncio(AnuncioDTO anuncioDTO)
        {
            string resultado = new AnunciosDB().EditarAnuncio(anuncioDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public string EliminarAnuncio(AnuncioDTO anuncioDTO)
        {
            string resultado = new AnunciosDB().EliminarAnuncio(anuncioDTO);

            if (resultado == null)
                return null;
            else
                return resultado;
        }

        public List<AnuncioDTO> ConsultaAnuncios(int _session)
        {
            return new AnunciosDB().ListaAnuncios(_session);
        }
    }
}
