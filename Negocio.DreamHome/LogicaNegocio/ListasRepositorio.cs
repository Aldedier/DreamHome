namespace Negocio.DreamHome.LogicaNegocio
{
    using Comun.DreamHome;
    using Datos.DreamHome.ContextoBaseDatos;
    using System.Collections.Generic;
    using System.Linq;

    public class ListasRepositorio
    {
        public List<TiposPropiedadesDTO> ConsultarTiposPropiedades()
        {
            List<TiposPropiedadesDTO> lista = new List<TiposPropiedadesDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.TIPOS_PROPIEDADES.Select(x => new TiposPropiedadesDTO { ID_TIPO = x.ID_TIPO, NOMBRE_TIPO = x.NOMBRE_TIPO }).ToList();
            }

            return lista;
        }

        public List<TiposPagosDTO> ConsultarTiposPagos()
        {
            List<TiposPagosDTO> lista = new List<TiposPagosDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.TIPOS_PAGOS.Select(x => new TiposPagosDTO { ID_FORMA_PAGO  = x.ID_FORMA_PAGO, FORMA_PAGO = x.FORMA_PAGO }).ToList();
            }

            return lista;
        }

        public List<GeneroDTO> ConsultarGeneros()
        {
            List<GeneroDTO> lista = new List<GeneroDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.GENEROS.Select(x => new GeneroDTO { ID_GENERO = x.ID_GENERO, GENERO = x.GENERO }).ToList();
            }

            return lista;
        }

        public List<PeriodicosDTO> ConsultarPeriodicos()
        {
            List<PeriodicosDTO> lista = new List<PeriodicosDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.PERIODICOS.Select(x => new PeriodicosDTO { ID_PERIODICO = x.ID_PERIODICO, NOMBRE_PERIODICO = x.NOMBRE_PERIODICO }).ToList();
            }

            return lista;
        }

        public List<UsuarioDTO> ConsultarUsuarios()
        {
            List<UsuarioDTO> lista = new List<UsuarioDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.USUARIOS.Select(x => new UsuarioDTO { Usuario_id = x.ID_USUARIO, Nombre_Usuario = x.NOMBRE_USR, Usuario = x.USUARIO }).ToList();
            }

            return lista;
        }

        public List<CiudadDTO> ConsultarCiudades()
        {
            List<CiudadDTO> lista = new List<CiudadDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.CIUDADES.Select(x => new CiudadDTO { ID_CIUDAD = x.ID_CIUDAD, CIUDAD = x.CIUDAD }).ToList();
            }

            return lista;
        }


        public List<EmpleadosDTO> ConsultarEmpleados()
        {
            List<EmpleadosDTO> lista = new List<EmpleadosDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.EMPLEADOS.Select(x => new EmpleadosDTO { ID_EMPLEADO = x.ID_EMPLEADO, NOMBRE_RH = x.NOMBRE_RH }).ToList();
            }

            return lista;
        }

        public List<ClientesDTO> ConsultarClientes()
        {
            List<ClientesDTO> lista = new List<ClientesDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.CLIENTES.Select(x => new ClientesDTO { ID_CLIENTE = x.ID_CLIENTE, NOMBRE_CLINT = x.NOMBRE_CLINT }).ToList();
            }

            return lista;
        }

        public List<OficinasDTO> ConsultarOficinas()
        {
            List<OficinasDTO> lista = new List<OficinasDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.OFICINAS.Select(x => new OficinasDTO { ID_OFICINA = x.ID_OFICINA, OFICINA = x.OFICINA }).ToList();
            }

            return lista;
        }

        public List<EstadosRequerimientosDTO> ConsultarEstadosRequerimiento()
        {
            List<EstadosRequerimientosDTO> lista = new List<EstadosRequerimientosDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.ESTADOS_REQUERIMIENTOS.Select(x => new EstadosRequerimientosDTO { ID_ESTADO_REQUERIMIENTO = x.ID_ESTADO_REQUERIMIENTO, ESTADO_REQUERIMIENTO = x.ESTADO_REQUERIMIENTO }).ToList();
            }

            return lista;
        }


        public List<EstadosContratosDTO> ConsultarEstadosContratos()
        {
            List<EstadosContratosDTO> lista = new List<EstadosContratosDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.ESTADOS_CONTRATOS.Select(x => new EstadosContratosDTO { ID_ESTADO_CONTRATO = x.ID_ESTADO_CONTRATO, ESTADO_CONTRATO = x.ESTADO_CONTRATO }).ToList();
            }

            return lista;
        }
        public List<InmueblesDTO> ConsultarInmuebles()
        {
            List<InmueblesDTO> lista = new List<InmueblesDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.VST_INMUEBLES.Select(x => new InmueblesDTO { ID_INMUEBLE = x.ID_INMUEBLE, DIRECCION_INM = x.DIRECCION_INM + " - " + x.NOMBRE_TIPO}).ToList();
            }

            return lista;
        }

        public List<EstadosInmueblesDTO> ConsultarEstadosInmuebles()
        {
            List<EstadosInmueblesDTO> lista = new List<EstadosInmueblesDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.ESTADOS_INMUEBLES.Select(x => new EstadosInmueblesDTO { ID_ESTADO_INMUEBLE = x.ID_ESTADO_INMUEBLE, ESTADO_INMUEBLE = x.ESTADO_INMUEBLE }).ToList();
            }

            return lista;
        }

        public List<CaracteristicasInmueblesDTO> ConsultarCaracteristicasInmuebles()
        {
            List<CaracteristicasInmueblesDTO> lista = new List<CaracteristicasInmueblesDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.CARACTERISTICAS_INMUEBLES.Select(x => new CaracteristicasInmueblesDTO { ID_CARACTERISTICA_PROP = x.ID_CARACTERISTICA_PROP, CARACTERISTICA = x.CARACTERISTICA }).ToList();
            }

            return lista;
        }

        public List<CargoDTO> ConsultarCargos()
        {
            List<CargoDTO> lista = new List<CargoDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.CARGOS.Select(x => new CargoDTO { ID_CARGO = x.ID_CARGO, CARGO = x.CARGO }).ToList();
            }

            return lista;
        }

        public List<TiposContactosDTO> ConsultarTiposContactos()
        {
            List<TiposContactosDTO> lista = new List<TiposContactosDTO>();

            using (ContextoDreamHome db = new ContextoDreamHome())
            {
                lista = db.TIPOS_CONTACTOS.Select(x => new TiposContactosDTO { ID_TIPO_CONTACTO = x.ID_TIPO_CONTACTO, TIPO_CONTACTO = x.TIPO_CONTACTO }).ToList();
            }

            return lista;
        }
    }
}
