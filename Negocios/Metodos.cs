using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;

namespace Negocios
{
    public class Metodos
    {
        #region AGENCIAS
        public List<Agencias> Agencias_ObtenerEscaneoDiario(int grupo)
        {
            List<Agencias> ListadoAgencias = new List<Agencias>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.AgenciasObtenerEscaneoDiario(grupo);

                foreach (var dato in i)
                {
                    Agencias agencia = new Agencias();

                    agencia.IdAgencia = dato.IdAgencia;
                    agencia.NombreAgencia = dato.NombreAgencia;
                    agencia.Ciudad = dato.Ciudad;
                    agencia.Provincia = dato.Provincia;
                    agencia.Subred = dato.Subred;
                    agencia.Estado = dato.Estado;
                    agencia.Grupo = dato.Grupo;

                    ListadoAgencias.Add(agencia);
                }

                return ListadoAgencias;
            }
        }

        public Agencias Agencias_SelectByIdAgencia(int idAgencia)
        {
            Agencias agencia = new Agencias();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.AgenciasSelectByIdAgencia(idAgencia);

                foreach (var dato in i)
                {
                    agencia.IdAgencia = dato.IdAgencia;
                    agencia.NombreAgencia = dato.NombreAgencia;
                    agencia.Ciudad = dato.Ciudad;
                    agencia.Provincia = dato.Provincia;
                    agencia.Subred = dato.Subred;
                    agencia.Estado = dato.Estado;
                    agencia.Grupo = dato.Grupo;
                }

                return agencia;
            }
        }

        public int Agencias_Insertar(Agencias agencia)
        {
            int id = 0;

            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.AgenciasInsertar(agencia.NombreAgencia, agencia.Ciudad, agencia.Provincia, agencia.Subred, agencia.Grupo);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
                    }
                }
            }
            catch (Exception)
            {
                id = -1;
            }

            return id;
        }

        public bool Agencias_SubredExiste(string subred)
        {
            bool id = false;

            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.AgenciaSubredExiste(subred);

                    foreach (var r in i)
                    {
                        if (Convert.ToInt32(r.ToString()) == 1)
                        {
                            id = true;
                        }                        
                    }
                }
            }
            catch (Exception)
            {
                id = false;
            }

            return id;
        }

        public List<Agencias> Agencias_HabilitadasDeshabilitadas(bool estado, string provincia, string ciudad)
        {
            List<Agencias> ListadoAgencias = new List<Agencias>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.Agencias_HabilitadasDeshabilitadas(estado, provincia, ciudad);

                foreach (var dato in i)
                {
                    Agencias agencia = new Agencias();

                    agencia.IdAgencia = dato.IdAgencia;
                    agencia.NombreAgencia = dato.NombreAgencia;
                    agencia.Ciudad = dato.Ciudad;
                    agencia.Provincia = dato.Provincia;
                    agencia.Subred = dato.Subred;
                    agencia.Estado = dato.Estado;
                    agencia.Grupo = dato.Grupo;

                    ListadoAgencias.Add(agencia);
                }

                return ListadoAgencias;
            }
        }

        public void Agencias_HabilitarDeshabilitar(int idAgencia, bool estado)
        {
            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.Agencias_HabilitarDeshabilitar(idAgencia, estado);
                }
            }
            catch (Exception)
            {

            }
        }

        public List<Agencias> Agencias_SelectByGrupo(int grupo)
        {
            List<Agencias> ListadoAgencias = new List<Agencias>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.Agencias_SelectByGrupo(grupo);

                foreach (var dato in i)
                {
                    Agencias agencia = new Agencias();

                    agencia.IdAgencia = dato.IdAgencia;
                    agencia.NombreAgencia = dato.NombreAgencia;
                    agencia.Ciudad = dato.Ciudad;
                    agencia.Provincia = dato.Provincia;
                    agencia.Subred = dato.Subred;
                    agencia.Estado = dato.Estado;
                    agencia.Grupo = dato.Grupo;

                    ListadoAgencias.Add(agencia);
                }

                return ListadoAgencias;
            }
        }

        public List<Agencias> Agencias_SelectActivas()
        {
            List<Agencias> ListadoAgencias = new List<Agencias>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.AgenciasObtenerActivas();

                foreach (var dato in i)
                {
                    Agencias agencia = new Agencias();

                    agencia.IdAgencia = dato.IdAgencia;
                    agencia.NombreAgencia = dato.NombreAgencia;
                    agencia.Ciudad = dato.Ciudad;
                    agencia.Provincia = dato.Provincia;
                    agencia.Subred = dato.Subred;
                    agencia.Estado = dato.Estado;
                    agencia.Grupo = dato.Grupo;

                    ListadoAgencias.Add(agencia);
                }

                return ListadoAgencias;
            }
        }

        public void Agencias_UpdateGrupo(int idAgencia, int grupo)
        {
            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    a.Agencias_UpdateGrupo(idAgencia, grupo);
                }
            }
            catch (Exception)
            {
                
            }
        }

        #endregion

        #region LOG
        public void LogsInsertar(LogEscaneo log)
        {
            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.LogEscaneoInsertar(log.SegmentoEscaneado, log.Accion, log.TTL);
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region ADMINISTRADORES
        public void AdministradoresInsertar(Administradores administrador)
        {
            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.AdministradoresInsertar(administrador.IdMaquina, administrador.Administrador);
                }
            }
            catch (Exception)
            {

            }
        }

        public void AdministradoresEliminar(Administradores administrador)
        {
            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.AdministradoresEliminar(administrador.IdMaquina, administrador.Administrador);
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region ADMINISTRADORES_NOVEDADES
        public List<AdministradoresNovedades> AdministradoresNovedades_Select()
        {
            List<AdministradoresNovedades> ListadoAdministradoresNovedades = new List<AdministradoresNovedades>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.AdministradoresNovedadesSelect();

                foreach (var dato in i)
                {
                    AdministradoresNovedades administradoresNovedades = new AdministradoresNovedades();

                    administradoresNovedades.IdMaquina = dato.IdMaquina;
                    administradoresNovedades.Administrador = dato.Administrador;
                    administradoresNovedades.Fecha = dato.Fecha;
                    administradoresNovedades.Accion = dato.Accion;

                    ListadoAdministradoresNovedades.Add(administradoresNovedades);
                }

                return ListadoAdministradoresNovedades;
            }
        }

        public int AdministradorEliminadoAntes(string equipo, string administrador)
        {
            int id = 0;

            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.AdministradorEliminadoAntes(equipo, administrador);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
                    }
                }
            }
            catch (Exception)
            {
                id = -1;
            }

            return id;
        }

        public void AdministradoresNovedadesEliminar(Administradores adminNovedades)
        {
            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.AdministradoresNovedadesEliminar(adminNovedades.IdMaquina, adminNovedades.Administrador);
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region ADMINISTRADORES_ESCANEADOS
        public void AdministradoresEscaneadosInsertar(Administradores administrador)
        {
            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.AdministradoresEscaneadosInsertar(administrador.IdMaquina, administrador.Administrador);
                }
            }
            catch (Exception)
            {

            }
        }

        public void EquipoAdminUpdate(string adminMensaje, int idMaquina)
        {
            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.EquiposAdministradoresEscaneados(adminMensaje, idMaquina);
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion        

        #region EQUIPOS
        public int EquiposInsertar(Equipos equipo)
        {
            int id = 0;

            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.EquiposInsertar(equipo.Ip, equipo.Equipo, equipo.SistemaOperativo, equipo.UltimoUsuarioLogeado, equipo.Antivirus);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
                    }
                }
            }
            catch (Exception)
            {
                id = -1;
            }

            return id;
        }

        public int EquiposModificar(Equipos equipo)
        {
            int id = 0;

            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.EquiposModificar(equipo.Ip, equipo.Equipo, equipo.SistemaOperativo, equipo.UltimoUsuarioLogeado, equipo.Antivirus);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
                    }
                }
            }
            catch (Exception)
            {
                id = -1;
            }

            return id;
        }

        public Equipos Equipos_SelectByEquipo(string equipo)
        {
            Equipos clequipo = new Equipos();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.EquiposSelectByEquipo(equipo);

                foreach (var dato in i)
                {
                    clequipo.IdMaquina = dato.IdMaquina;
                    clequipo.IdAgencia = dato.IdAgencia;
                    clequipo.Ip = dato.Ip;
                    clequipo.Equipo = dato.Equipo;
                    clequipo.SistemaOperativo = dato.SistemaOperativo;
                    clequipo.UltimoUsuarioLogeado = dato.UltimoUsuarioLogeado;
                    clequipo.FechaRegistro = dato.FechaRegistro;
                    clequipo.AdministradoresEscaneados = dato.AdministradoresEscaneados;
                    clequipo.Antivirus = dato.Antivirus;
                    clequipo.FechaActualizacion = dato.FechaActualizacion;
                }

                return clequipo;
            }
        }
        #endregion        

        #region EQUIPOS_NOVEDADES
        public List<EquiposNovedades> EquiposNovedades_Select()
        {
            List<EquiposNovedades> ListadoEquipos = new List<EquiposNovedades>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.EquiposNovedadesSelect();

                foreach (var dato in i)
                {
                    EquiposNovedades equipo = new EquiposNovedades();

                    equipo.IdMaquina = dato.IdMaquina;
                    equipo.IdAgencia = dato.IdAgencia;
                    equipo.Ip = dato.Ip;
                    equipo.Equipo = dato.Equipo;
                    equipo.SistemaOperativo = dato.SistemaOperativo;
                    equipo.UltimoUsuarioLogeado = dato.UltimoUsuarioLogeado;
                    equipo.FechaRegistro = dato.FechaRegistro;
                    if (dato.Antivirus == null)
                    {
                        equipo.Antivirus = -2;
                    }
                    else
                    {
                        equipo.Antivirus = dato.Antivirus;
                    }

                    ListadoEquipos.Add(equipo);
                }

                return ListadoEquipos;
            }
        }

        
        #endregion

        #region EQUIPOS_ESCANEADOS
        public int EquiposEscaneados_Insertar(Equipos equipo)
        {
            int id = 0;

            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.EquiposEscaneados_Insertar(equipo.Ip, equipo.Equipo, equipo.SistemaOperativo, equipo.UltimoUsuarioLogeado, equipo.Antivirus);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
                    }
                }
            }
            catch (Exception)
            {
                id = -1;
            }

            return id;
        }

        public void EquiposEscaneados_AdminUpdate(string adminMensaje, int idMaquina)
        {
            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.EquiposEscaneados_AdministradoresEscaneados(adminMensaje, idMaquina);
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        public Parametros ObtenerParametroPorCodigo(string codigo)
        {
            Parametros parametro = new Parametros();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.ParametrosObtenerValorParametroPorCodigo(codigo);

                foreach (var item in i)
                {
                    parametro.Codigo = item.Codigo;
                    parametro.Nombre = item.Nombre;
                    parametro.Valor = item.Valor;
                }

                return parametro;
            }
        }                        
        
        public bool AdministradorEstaExcepcionado(string equipo, string administrador)
        {
            int id = 0;

            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.AdministradorEstaExepcionado(equipo, administrador);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
                    }
                }
            }
            catch (Exception)
            {
                id = -1;
            }

            if (id == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int HistoricosDepurados_Insertar(EquiposNovedades equipo, AdministradoresNovedades administrador)
        {
            int id = 0;

            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.HistoricosDepurados_Insertar(equipo.IdMaquina, equipo.Ip, equipo.Equipo, 
                                                            equipo.SistemaOperativo, equipo.UltimoUsuarioLogeado, administrador.Administrador,
                                                            administrador.Fecha, administrador.Accion, equipo.Antivirus);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
                    }
                }
            }
            catch (Exception)
            {
                id = -1;
            }

            return id;
        }
        
        public List<EquiposNovedadesAntivirus> EquiposNovedadesAntivirus_Select()
        {
            List<EquiposNovedadesAntivirus> ListadoEquipos = new List<EquiposNovedadesAntivirus>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.EquiposNovedadesAntivirus_Select();

                foreach (var dato in i)
                {
                    EquiposNovedadesAntivirus equipo = new EquiposNovedadesAntivirus();
                    
                    equipo.IdAgencia = dato.IdAgencia;
                    equipo.Ip = dato.Ip;
                    equipo.Equipo = dato.Equipo;
                    equipo.SistemaOperativo = dato.SistemaOperativo;
                    equipo.FechaRegistro = dato.FechaRegistro;
                    equipo.Antivirus = dato.Antivirus;

                    ListadoEquipos.Add(equipo);
                }

                return ListadoEquipos;
            }
        }

        public List<Grupos_SelectAll> Grupos_Numeros()
        {
            List<Grupos_SelectAll> Listado = new List<Grupos_SelectAll>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.Grupos_SelectAll();

                foreach (var dato in i)
                {
                    Grupos_SelectAll objeto = new Grupos_SelectAll();
                
                    objeto.Grupo = dato.Grupo;

                    Listado.Add(objeto);
                }

                return Listado;
            }
        }

        #region PROVINCIAS

        public List<ProvinciasEcuador> ProvinciasEcuador_SelectAll()
        {
            List<ProvinciasEcuador> ListaProvincias = new List<ProvinciasEcuador>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.ProvinciasSelectAll();

                foreach (var dato in i)
                {
                    ProvinciasEcuador clLista = new ProvinciasEcuador();

                    clLista.IdProvincia = dato.IdProvincia;
                    clLista.Provincia = dato.Provincia;

                    ListaProvincias.Add(clLista);

                }

                return ListaProvincias;
            }
        }

        public List<ProvinciasEcuador> Provincias_HabilitadasDeshabilitadas(bool estado)
        {
            List<ProvinciasEcuador> ListaProvincias = new List<ProvinciasEcuador>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.Provincias_HabilitadasDeshabilitadas(estado);

                foreach (var dato in i)
                {
                    ProvinciasEcuador clLista = new ProvinciasEcuador();

                    clLista.IdProvincia = dato.IdProvincia;
                    clLista.Provincia = dato.Provincia;

                    ListaProvincias.Add(clLista);

                }

                return ListaProvincias;
            }
        }

        #endregion

        #region CIUDADES
        public List<CiudadesEcuador> CiudadesEcuador_SelectByIdProvincia(int idProvincia)
        {
            List<CiudadesEcuador> ListaProvincias = new List<CiudadesEcuador>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.CiudadesSelectByIdProvincia(idProvincia);

                foreach (var dato in i)
                {
                    CiudadesEcuador clLista = new CiudadesEcuador();

                    clLista.IdCiudad = dato.IdCiudad;
                    clLista.IdProvincia = dato.IdProvincia;
                    clLista.Ciudad = dato.Ciudad;

                    ListaProvincias.Add(clLista);

                }

                return ListaProvincias;
            }
        }

        public List<CiudadesEcuador> Ciudades_HabilitadasDeshabilitadas(bool estado, int idProvincia)
        {
            List<CiudadesEcuador> ListaProvincias = new List<CiudadesEcuador>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.Ciudades_HabilitadasDeshabilitadas(estado, idProvincia);

                foreach (var dato in i)
                {
                    CiudadesEcuador clLista = new CiudadesEcuador();

                    clLista.IdCiudad = dato.IdCiudad;
                    clLista.IdProvincia = dato.IdProvincia;
                    clLista.Ciudad = dato.Ciudad;

                    ListaProvincias.Add(clLista);

                }

                return ListaProvincias;
            }
        }
        #endregion        

        #region REPORTES

        public List<Reporte_EquiposPorAgenciaTotal> Reporte_EquiposPorAgencia()
        {
            List<Reporte_EquiposPorAgenciaTotal> Listado = new List<Reporte_EquiposPorAgenciaTotal>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.Reporte_EquiposPorAgencia_total();

                foreach (var dato in i)
                {
                    Reporte_EquiposPorAgenciaTotal objeto = new Reporte_EquiposPorAgenciaTotal();

                    objeto.Provincia = dato.Provincia;
                    objeto.Ciudad = dato.Ciudad;
                    objeto.Agencia = dato.Agencia;
                    objeto.Subred = dato.Subred;
                    objeto.Equipos = dato.Equipos;
                    

                    Listado.Add(objeto);
                }

                return Listado;
            }
        }

        public List<Reporte_AdministradoresNovedades_All> Reporte_AdministradoresNovedades()
        {
            List<Reporte_AdministradoresNovedades_All> Listado = new List<Reporte_AdministradoresNovedades_All>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.Reporte_AdministradoresNovedades_All();

                foreach (var dato in i)
                {
                    Reporte_AdministradoresNovedades_All objeto = new Reporte_AdministradoresNovedades_All();

                    objeto.Provincia = dato.Provincia;
                    objeto.Ciudad = dato.Ciudad;
                    objeto.Agencia = dato.Agencia;
                    objeto.Subred = dato.Subred;
                    objeto.Equipo = dato.Equipo;
                    objeto.SistemaOperativo = dato.SistemaOperativo;
                    objeto.UltimoUsuarioLogeado = dato.UltimoUsuarioLogeado;
                    objeto.Administrador = dato.Administrador;
                    objeto.NovedadesReportadas = dato.NovedadesReportadas;

                    Listado.Add(objeto);
                }

                return Listado;
            }
        }

        public List<Reporte_AdministradoresNovedades_ByEquipoYAdmin> Reporte_AdministradoresNovedades_ByRegistro(string equipo, string administrador)
        {
            List<Reporte_AdministradoresNovedades_ByEquipoYAdmin> Listado = new List<Reporte_AdministradoresNovedades_ByEquipoYAdmin>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.Reporte_AdministradoresNovedades_ByEquipoYAdmin(equipo, administrador);

                foreach (var dato in i)
                {
                    Reporte_AdministradoresNovedades_ByEquipoYAdmin objeto = new Reporte_AdministradoresNovedades_ByEquipoYAdmin();

                    objeto.Provincia = dato.Provincia;
                    objeto.Ciudad = dato.Ciudad;
                    objeto.Agencia = dato.Agencia;
                    objeto.Subred = dato.Subred;
                    objeto.Grupo = dato.Grupo;
                    objeto.Ip = dato.Ip;
                    objeto.Equipo = dato.Equipo;
                    objeto.SistemaOperativo = dato.SistemaOperativo;
                    objeto.UltimoUsuarioLogeado = dato.UltimoUsuarioLogeado;
                    objeto.Administrador = dato.Administrador;
                    objeto.Fecha = dato.Fecha;

                    Listado.Add(objeto);
                }

                return Listado;
            }
        }

        public List<Reporte_AdmisAdd_Mensual> Reporte_AdministradoresAnadidos(int mes, int ano)
        {
            List<Reporte_AdmisAdd_Mensual> Listado = new List<Reporte_AdmisAdd_Mensual>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.Reporte_AdmisAdd_Mensual(mes, ano);

                foreach (var dato in i)
                {
                    Reporte_AdmisAdd_Mensual objeto = new Reporte_AdmisAdd_Mensual();

                    objeto.Provincia = dato.Provincia;
                    objeto.Ciudad = dato.Ciudad;
                    objeto.NombreAgencia = dato.NombreAgencia;
                    objeto.Equipo = dato.Equipo;
                    objeto.Ip = dato.Ip;                    
                    objeto.Administrador = dato.Administrador;
                    objeto.FechaDeteccion = dato.FechaDeteccion;

                    Listado.Add(objeto);
                }

                return Listado;
            }
        }

        public List<Reporte_AdministradoresNovedades_All> Reporte_AdministradoresNovedades_Mensual(int mes, int ano)
        {
            List<Reporte_AdministradoresNovedades_All> Listado = new List<Reporte_AdministradoresNovedades_All>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.Reporte_AdministradoresNovedades_Mensual(mes, ano);

                foreach (var dato in i)
                {
                    Reporte_AdministradoresNovedades_All objeto = new Reporte_AdministradoresNovedades_All();

                    objeto.Provincia = dato.Provincia;
                    objeto.Ciudad = dato.Ciudad;
                    objeto.Agencia = dato.Agencia;
                    objeto.Subred = dato.Subred;
                    objeto.Equipo = dato.Equipo;
                    objeto.SistemaOperativo = dato.SistemaOperativo;
                    objeto.UltimoUsuarioLogeado = dato.UltimoUsuarioLogeado;
                    objeto.Administrador = dato.Administrador;
                    objeto.NovedadesReportadas = dato.NovedadesReportadas;

                    Listado.Add(objeto);
                }

                return Listado;
            }
        }

        public List<Log_RevisionEjecucion> Log_RevisionEjecucionByFecha(DateTime fecha)
        {
            List<Log_RevisionEjecucion> Listado = new List<Log_RevisionEjecucion>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.Log_RevisionEjecucion(fecha);

                foreach (var dato in i)
                {
                    Log_RevisionEjecucion objeto = new Log_RevisionEjecucion();

                    objeto.Fecha = dato.Fecha;
                    objeto.IpsActivas = dato.IpsActivas;
                    objeto.IpsInvalidas = dato.IpsInvalidas;
                    objeto.NGroup = dato.NGroup;
                    objeto.SegmentoEscaneado = dato.SegmentoEscaneado;                    

                    Listado.Add(objeto);
                }

                return Listado;
            }
        }

        public List<ReporteDetalleEquipos> Reporte_EquiposDetalle()
        {
            List<ReporteDetalleEquipos> Listado = new List<ReporteDetalleEquipos>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.Reporte_EquiposDetalle();

                foreach (var dato in i)
                {
                    ReporteDetalleEquipos objeto = new ReporteDetalleEquipos();

                    objeto.Provincia = dato.Provincia;
                    objeto.Ciudad = dato.Ciudad;
                    objeto.Agencia = dato.Agencia;
                    objeto.Subred = dato.Subred;
                    objeto.EstadoAgencia = dato.EstadoAgencia;
                    objeto.Equipo = dato.Equipo;
                    objeto.Ip = dato.Ip;
                    objeto.SistemaOperativo = dato.SistemaOperativo;
                    objeto.UltimoUsuarioLogeado = dato.UltimoUsuarioLogeado;
                    objeto.FechaRegistro = dato.FechaRegistro;
                    objeto.FechaUltimaActividad = dato.FechaUltimaActividad;
                    objeto.EstadoAntivirus = dato.EstadoAntivirus;
                    objeto.FechaActualizaciónAntivirus = dato.FechaActualizaciónAntivirus;

                    Listado.Add(objeto);
                }

                return Listado;
            }
        }

        #endregion

        #region LINEA_BASE

        public List<LineaBase> LineaBase_SelectAll()
        {
            List<LineaBase> Listado = new List<LineaBase>();

            using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
            {
                var i = a.LineaBaseSelectAll();

                foreach (var dato in i)
                {
                    LineaBase objeto = new LineaBase();

                    objeto.IdUsuario = dato.IdUsuario;
                    objeto.Usuario = dato.Usuario;

                    Listado.Add(objeto);
                }

                return Listado;
            }
        }

        public int LineaBaseInsertar(LineaBase objeto)
        {
            int id = 0;

            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.LineaBaseInsertar(objeto.Usuario);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
                    }
                }
            }
            catch (Exception)
            {
                id = -1;
            }

            return id;
        }

        public int LineaBaseModificar(LineaBase objeto)
        {
            int id = 0;

            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.LineaBaseModificar(objeto.IdUsuario, objeto.Usuario);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
                    }
                }
            }
            catch (Exception)
            {
                id = -1;
            }

            return id;
        }

        public int LineaBaseEliminar(LineaBase objeto)
        {
            int id = 0;

            try
            {
                using (ControlAdministradoresEntities a = new ControlAdministradoresEntities())
                {
                    var i = a.LineaBaseEliminar(objeto.IdUsuario);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
                    }
                }
            }
            catch (Exception)
            {
                id = -1;
            }

            return id;
        }

        #endregion
    }
}
