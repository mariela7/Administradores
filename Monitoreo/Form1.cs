using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocios;
using AccesoDatos;
using System.IO;

namespace Monitoreo
{
    public partial class frmMonitoreo : Form
    {
        public frmMonitoreo()
        {
            InitializeComponent();
        }

        Metodos metodo = new Metodos();

        private void frmMonitoreo_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            CargarEquiposSinAntivirus();
            rtxtResultado.Clear();
        }

        public void CargarGrilla()
        {
            this.dgvNovedades.Columns["dgEliminadoVeces"].Visible = false;

            List<EquiposNovedades> listaEquipos = new List<EquiposNovedades>();
            listaEquipos = metodo.EquiposNovedades_Select();

            List<AdministradoresNovedades> listaAdministradores = new List<AdministradoresNovedades>();
            listaAdministradores = metodo.AdministradoresNovedades_Select();
            listaAdministradores = listaAdministradores.OrderBy(x => x.IdMaquina).ToList();

            List<LineaBase> ListaLineaBase = new List<LineaBase>();
            ListaLineaBase = metodo.LineaBase_SelectAll();

            this.dgvNovedades.Rows.Clear();
            foreach (var admin in listaAdministradores)
            {
                EquiposNovedades equipo = new EquiposNovedades();
                foreach (EquiposNovedades eq in listaEquipos)
                {
                    if (eq.IdMaquina == admin.IdMaquina)
                    {
                        equipo = eq;
                    }
                }

                Agencias agencia = new Agencias();
                agencia = metodo.Agencias_SelectByIdAgencia(equipo.IdAgencia);

                this.dgvNovedades.Rows.Add();
                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgIdMaquina"].Value = admin.IdMaquina;
                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgIdAgencia"].Value = equipo.IdAgencia;
                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgIp"].Value = equipo.Ip;
                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgEquipo"].Value = equipo.Equipo;
                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgSistemaOperativo"].Value = equipo.SistemaOperativo;
                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgAntivirus"].Value = equipo.Antivirus;

                if (equipo.Antivirus <= 0)
                {
                    this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgAntivirus"].Style.BackColor = Color.Red;
                }

                string usr =admin.Administrador.Replace("WinNT://","");

                try
                {
                    this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgDominio"].Value = usr.Substring(0, usr.IndexOf("/"));
                    this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgNombreAdm"].Value = usr.Substring(usr.IndexOf("/") + 1, (usr.Length - usr.IndexOf("/") - 1));
                }
                catch (Exception)
                {
                    this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgDominio"].Value = "";
                    this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgNombreAdm"].Value = usr;
                }

                if (usr.Contains('/'))
                {
                    foreach (var item in ListaLineaBase)
                    {
                        string inicio = item.Usuario.Substring(0, 1);
                        if (inicio == "/")
                        {
                            //local
                            string usuario = usr.Substring(usr.IndexOf('/'), (usr.Length - usr.IndexOf('/')));
                            if (usuario == item.Usuario)
                            {
                                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgDominio"].Style.BackColor = Color.LightGreen;
                                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgNombreAdm"].Style.BackColor = Color.LightGreen;
                            }
                        }
                        else
                        {
                            //dominio
                            if (usr == item.Usuario)
                            {
                                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgDominio"].Style.BackColor = Color.LightGreen;
                                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgNombreAdm"].Style.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }

                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgAdministrador"].Value = admin.Administrador;
                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgFechaAdm"].Value = admin.Fecha;

                bool Excep = metodo.AdministradorEstaExcepcionado(equipo.Equipo, admin.Administrador);

                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgExcepcion"].Value = Excep;

                if (Excep)
                {
                    this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Visible = false;
                }

                int Incidente = metodo.AdministradorEliminadoAntes(equipo.Equipo, admin.Administrador);

                if (Incidente > 0)
                {
                    this.dgvNovedades.Columns["dgEliminadoVeces"].Visible = true;
                    this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgNombreAdm"].Style.ForeColor = Color.Red;
                    this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgNombreAdm"].Style.Font = new Font(Font, System.Drawing.FontStyle.Bold);
                    this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgNombreAdm"].ToolTipText = "Usuario borrado de este equipo " + Incidente.ToString() + " vez/veces.";
                    this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgEliminadoVeces"].Value = Incidente.ToString();
                }

                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgIdMaquina"].Value = equipo.IdMaquina;
                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgAccionEjecutada"].Value = admin.Accion;
                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgUltimoUsuario"].Value = equipo.UltimoUsuarioLogeado;

                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgProvincia"].Value = agencia.Provincia;
                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgCanton"].Value = agencia.Ciudad;
                this.dgvNovedades.Rows[this.dgvNovedades.Rows.Count - 1].Cells["dgNombreAgencia"].Value = agencia.NombreAgencia;
            }

            dgvNovedades.AutoResizeColumns();

            dgvNovedades.Sort(dgSistemaOperativo, ListSortDirection.Ascending);

        }

        public void CargarEquiposSinAntivirus()
        {
            List<EquiposNovedadesAntivirus> listaEquipos = new List<EquiposNovedadesAntivirus>();
            listaEquipos = metodo.EquiposNovedadesAntivirus_Select();

            foreach (EquiposNovedadesAntivirus equipo in listaEquipos)
            {
                Agencias agencia = new Agencias();
                agencia = metodo.Agencias_SelectByIdAgencia(equipo.IdAgencia);

                this.dgvAntivirus.Rows.Add();
                this.dgvAntivirus.Rows[this.dgvAntivirus.Rows.Count - 1].Cells["dgAv_IdAgencia"].Value = equipo.IdAgencia;
                this.dgvAntivirus.Rows[this.dgvAntivirus.Rows.Count - 1].Cells["dgAv_Ip"].Value = equipo.Ip;
                this.dgvAntivirus.Rows[this.dgvAntivirus.Rows.Count - 1].Cells["dgAv_Equipo"].Value = equipo.Equipo;
                this.dgvAntivirus.Rows[this.dgvAntivirus.Rows.Count - 1].Cells["dgAv_SistemaOperativo"].Value = equipo.SistemaOperativo;
                this.dgvAntivirus.Rows[this.dgvAntivirus.Rows.Count - 1].Cells["dgAv_AntivirusCodigo"].Value = equipo.Antivirus;
                this.dgvAntivirus.Rows[this.dgvAntivirus.Rows.Count - 1].Cells["dgAv_Provincia"].Value = agencia.Provincia;
                this.dgvAntivirus.Rows[this.dgvAntivirus.Rows.Count - 1].Cells["dgAv_Ciudad"].Value = agencia.Ciudad;
                this.dgvAntivirus.Rows[this.dgvAntivirus.Rows.Count - 1].Cells["dgAv_Agencia"].Value = agencia.NombreAgencia;

                if (equipo.Antivirus == 0)
                {
                    this.dgvAntivirus.Rows[this.dgvAntivirus.Rows.Count - 1].Cells["dgAv_Antivirus"].Value = "Servicio inactivo.";
                }
                else if (equipo.Antivirus == -1)
                {
                    this.dgvAntivirus.Rows[this.dgvAntivirus.Rows.Count - 1].Cells["dgAv_Antivirus"].Value = "No está el servicio. O tiene una versión diferente a la Sep12";
                }
                else if (equipo.Antivirus == -2)
                {
                    this.dgvAntivirus.Rows[this.dgvAntivirus.Rows.Count - 1].Cells["dgAv_Antivirus"].Value = "...";
                }
            }

            dgvAntivirus.AutoResizeColumns();
        }        

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dgvNovedades.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["dgAccionEjecutar"].Value) == true)
                {
                    int idMaquina = 0;
                    if (fila.Cells["dgAccionEjecutada"].Value.ToString() == "ADD")
                    {
                        //INSERTAR EN LA LINEA BASE (VALIDAR SI LA MAQUINA EXISTE O ES NUEVA)
                        Equipos equipoExiste = metodo.Equipos_SelectByEquipo(fila.Cells["dgEquipo"].Value.ToString());
                        if (equipoExiste.IdMaquina > 0)
                        {
                            //existe - actualizar
                            Equipos equipo = new Equipos();
                            equipo.Ip = fila.Cells["dgIp"].Value.ToString();
                            equipo.Equipo = fila.Cells["dgEquipo"].Value.ToString();
                            equipo.SistemaOperativo = fila.Cells["dgSistemaOperativo"].Value.ToString();
                            equipo.UltimoUsuarioLogeado = fila.Cells["dgUltimoUsuario"].Value.ToString();
                            equipo.Antivirus = Convert.ToInt32(fila.Cells["dgAntivirus"].Value.ToString());

                            idMaquina = metodo.EquiposModificar(equipo);
                        }
                        else
                        {
                            //no existe - crear
                            Equipos equipo = new Equipos();
                            equipo.Ip = fila.Cells["dgIp"].Value.ToString();
                            equipo.Equipo = fila.Cells["dgEquipo"].Value.ToString();
                            equipo.SistemaOperativo = fila.Cells["dgSistemaOperativo"].Value.ToString();
                            equipo.UltimoUsuarioLogeado = fila.Cells["dgUltimoUsuario"].Value.ToString();
                            equipo.Antivirus = Convert.ToInt32(fila.Cells["dgAntivirus"].Value.ToString());

                            idMaquina = metodo.EquiposInsertar(equipo);
                        }

                        if (idMaquina > 0)
                        {
                            Administradores adm = new Administradores();
                            adm.IdMaquina = idMaquina;
                            adm.Administrador = fila.Cells["dgAdministrador"].Value.ToString();

                            metodo.AdministradoresInsertar(adm);

                            adm.IdMaquina = Convert.ToInt32(fila.Cells["dgIdMaquina"].Value);
                            metodo.AdministradoresNovedadesEliminar(adm);
                        }
                    }
                    else if (fila.Cells["dgAccionEjecutada"].Value.ToString() == "DELETE")
                    {
                        /*NO HACER NADA*/
                        //ELIMINAR DE LA LINEA BASE (EXISTE SI O SI)
                        Equipos equipoExiste = metodo.Equipos_SelectByEquipo(fila.Cells["dgEquipo"].Value.ToString());
                        Administradores adm = new Administradores();
                        adm.IdMaquina = equipoExiste.IdMaquina;
                        adm.Administrador = fila.Cells["dgAdministrador"].Value.ToString();

                        metodo.AdministradoresEliminar(adm);

                        adm.IdMaquina = Convert.ToInt32(fila.Cells["dgIdMaquina"].Value);
                        metodo.AdministradoresNovedadesEliminar(adm);
                    }
                }
            }

            MessageBox.Show("Cambios Aplicados a la linea base.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvNovedades.Rows.Clear();
            CargarGrilla();
        }

        private void btnMarcarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dgvNovedades.Rows)
            {
                fila.Cells["dgAccionEjecutar"].Value = true;                
            }
        }

        private void btnDesmarcarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dgvNovedades.Rows)
            {
                fila.Cells["dgAccionEjecutar"].Value = false;
            }
        }

        private void btnGenerarArchivo_Click(object sender, EventArgs e)
        {
            string archivoMaquinasDepurar = @"C:\Scripting\ListadoAdmin.txt";
            StreamWriter logMaquinasDepurar;
            if (System.IO.File.Exists(archivoMaquinasDepurar))
            {
                File.Delete(archivoMaquinasDepurar);
                logMaquinasDepurar = File.CreateText(archivoMaquinasDepurar);
            }
            else
            {
                logMaquinasDepurar = File.CreateText(archivoMaquinasDepurar);
            }

            List<string> ListaIps = new List<string>();

            foreach (DataGridViewRow fila in dgvNovedades.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["dgAccionEjecutar"].Value) == false)
                {
                    //ARCHIVO PLANO
                    if (fila.Cells["dgAccionEjecutada"].Value.ToString() == "ADD")
                    {
                        //ARCHIVO DE BORRADO - DEPURACION
                        if (Convert.ToBoolean(fila.Cells["dgExcepcion"].Value) == false)
                        {
                            ListaIps.Add(fila.Cells["dgEquipo"].Value.ToString() + "|");

                            EquiposNovedades equipoHistorico = new EquiposNovedades();
                            equipoHistorico.IdMaquina = Convert.ToInt32(fila.Cells["dgIdMaquina"].Value.ToString());
                            equipoHistorico.Ip = fila.Cells["dgIp"].Value.ToString();
                            equipoHistorico.Equipo = fila.Cells["dgEquipo"].Value.ToString();
                            equipoHistorico.SistemaOperativo = fila.Cells["dgSistemaOperativo"].Value.ToString();
                            equipoHistorico.UltimoUsuarioLogeado = fila.Cells["dgUltimoUsuario"].Value.ToString();

                            AdministradoresNovedades administradorHistorico = new AdministradoresNovedades();
                            administradorHistorico.Administrador = fila.Cells["dgAdministrador"].Value.ToString();
                            administradorHistorico.Fecha = Convert.ToDateTime(fila.Cells["dgFechaAdm"].Value.ToString());
                            administradorHistorico.Accion = fila.Cells["dgAccionEjecutada"].Value.ToString();

                            metodo.HistoricosDepurados_Insertar(equipoHistorico, administradorHistorico);
                        }
                    }
                }
            }

            foreach (DataGridViewRow fila in dgvNovedades.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["dgAccionEjecutar"].Value) == false)
                {
                    //ARCHIVO PLANO
                    if (fila.Cells["dgAccionEjecutada"].Value.ToString() == "ADD")
                    {
                        //ARCHIVO DE BORRADO - DEPURACION
                        if (Convert.ToBoolean(fila.Cells["dgExcepcion"].Value))
                        {
                            ListaIps.Add(fila.Cells["dgEquipo"].Value.ToString() + "|" + fila.Cells["dgAdministrador"].Value.ToString());
                        }
                    }
                }
            }

            ListaIps = ListaIps.Distinct().ToList(); ;
            
            foreach (var item in ListaIps)
            {
                logMaquinasDepurar.WriteLine(item);
            }

            logMaquinasDepurar.Close();
            MessageBox.Show("El archivo fue generado exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMarcarFilasSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dgvNovedades.Rows)
            {
                if ((fila.Cells["dgNombreAdm"].Selected) || (fila.Cells["dgSistemaOperativo"].Selected) || (fila.Cells["dgDominio"].Selected))
                {
                    fila.Cells["dgAccionEjecutar"].Value = true;
                }
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            rtxtResultado.Clear();
            if (rbtEquiposPorAgencia.Checked)
            {
                List<Reporte_EquiposPorAgenciaTotal> reporte1 = new List<Reporte_EquiposPorAgenciaTotal>();
                reporte1 = metodo.Reporte_EquiposPorAgencia();

                this.dgvReportes.Columns.Clear();
                this.dgvReportes.Columns.Add("dgProvincia", "Provincia");
                this.dgvReportes.Columns.Add("dgCiudad", "Ciudad");
                this.dgvReportes.Columns.Add("dgAgencia", "Área");
                this.dgvReportes.Columns.Add("dgSubred", "Subred");
                this.dgvReportes.Columns.Add("dgEquipos", "Número de equipos");

                int TotalEquipos = 0;

                foreach (var item in reporte1)
                {
                    dgvReportes.Rows.Add();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgProvincia"].Value = item.Provincia.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgCiudad"].Value = item.Ciudad.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgAgencia"].Value = item.Agencia.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgSubred"].Value = item.Subred.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgEquipos"].Value = Convert.ToInt32(item.Equipos);

                    TotalEquipos = TotalEquipos + Convert.ToInt32(item.Equipos);
                }

                dgvReportes.AutoResizeColumns();

                EscribirDatos("Total de equipos: ", TotalEquipos.ToString());
            }
            else if (rbtAgenciasGrupos.Checked)
            {
                List<Agencias> reporte2 = new List<Agencias>();
                reporte2 = metodo.Agencias_SelectActivas();

                this.dgvReportes.Columns.Clear();
                this.dgvReportes.Columns.Add("dgProvincia", "Provincia");
                this.dgvReportes.Columns.Add("dgCiudad", "Ciudad");
                this.dgvReportes.Columns.Add("dgAgencia", "Área");
                this.dgvReportes.Columns.Add("dgSubred", "Subred");
                this.dgvReportes.Columns.Add("dgGrupo", "Grupo");

                int TotalEquipos = 0;

                foreach (Agencias agencia in reporte2)
                {
                    dgvReportes.Rows.Add();                    
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgProvincia"].Value = agencia.Provincia.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgCiudad"].Value = agencia.Ciudad.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgAgencia"].Value = agencia.NombreAgencia.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgSubred"].Value = agencia.Subred.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgGrupo"].ValueType = typeof(Int32);
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgGrupo"].Value = agencia.Grupo;

                    TotalEquipos++;
                }

                dgvReportes.AutoResizeColumns();                
                
                EscribirDatos("Total de Áreas: ", TotalEquipos.ToString());
            }
            else if ((rbtNovedadesAdministradores.Checked) || (rbtNovedadesAdministradoresMensual.Checked))
            {
                List<Reporte_AdministradoresNovedades_All> reporte3 = new List<Reporte_AdministradoresNovedades_All>();

                if (rbtNovedadesAdministradores.Checked)
                {
                    reporte3 = metodo.Reporte_AdministradoresNovedades();
                }
                else if (rbtNovedadesAdministradoresMensual.Checked)
                {
                    reporte3 = metodo.Reporte_AdministradoresNovedades_Mensual(Convert.ToInt32(ddlMes.SelectedValue), Convert.ToInt32(ddlAno.Text));
                }

                this.dgvReportes.Columns.Clear();
                this.dgvReportes.Columns.Add("dgProvincia", "Provincia");
                this.dgvReportes.Columns.Add("dgCiudad", "Ciudad");
                this.dgvReportes.Columns.Add("dgAgencia", "Área");
                this.dgvReportes.Columns.Add("dgSubred", "Subred");
                this.dgvReportes.Columns.Add("dgEquipo", "Equipo");
                this.dgvReportes.Columns.Add("dgSistemaOperativo", "Sistema Operativo");
                this.dgvReportes.Columns.Add("dgUltimoUsuarioLogeado", "Ultimo Usuario Logeado");
                this.dgvReportes.Columns.Add("dgAdministrador", "Administrador");
                this.dgvReportes.Columns.Add("dgNovedadesReportadas", "Novedades Reportadas");

                foreach (var dato in reporte3)
                {
                    dgvReportes.Rows.Add();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgProvincia"].Value = dato.Provincia.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgCiudad"].Value = dato.Ciudad.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgAgencia"].Value = dato.Agencia.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgSubred"].Value = dato.Subred.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgEquipo"].Value = dato.Equipo;
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgSistemaOperativo"].Value = dato.SistemaOperativo;
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgUltimoUsuarioLogeado"].Value = dato.UltimoUsuarioLogeado;
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgAdministrador"].Value = dato.Administrador;
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgNovedadesReportadas"].Value = dato.NovedadesReportadas;
                }

                dgvReportes.AutoResizeColumns();
                
                rtxtResultado.Clear();
            }
            else if (rbtAdminAdd.Checked)
            {
                List<Reporte_AdmisAdd_Mensual> reporte4 = new List<Reporte_AdmisAdd_Mensual>();
                reporte4 = metodo.Reporte_AdministradoresAnadidos(Convert.ToInt32(ddlMes.SelectedValue), Convert.ToInt32(ddlAno.Text));

                this.dgvReportes.Columns.Clear();
                this.dgvReportes.Columns.Add("dgProvincia", "Provincia");
                this.dgvReportes.Columns.Add("dgCiudad", "Ciudad");
                this.dgvReportes.Columns.Add("dgAgencia", "Área");
                this.dgvReportes.Columns.Add("dgEquipo", "Equipo");
                this.dgvReportes.Columns.Add("dgIp", "Ip");
                this.dgvReportes.Columns.Add("dgAdministrador", "Administrador");
                this.dgvReportes.Columns.Add("dgFechaDeteccion", "Fecha Detección");

                int TotalEquipos = 0;

                foreach (var item in reporte4)
                {
                    dgvReportes.Rows.Add();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgProvincia"].Value = item.Provincia.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgCiudad"].Value = item.Ciudad.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgAgencia"].Value = item.NombreAgencia.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgEquipo"].Value = item.Equipo;
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgIp"].Value = item.Ip;
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgAdministrador"].Value = item.Administrador;
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgFechaDeteccion"].Value = item.FechaDeteccion;

                    TotalEquipos++;
                }

                dgvReportes.AutoResizeColumns();

                EscribirDatos("Total de Usuarios añadidos: ", TotalEquipos.ToString());
            }
            else if (rbtEquiposDetalle.Checked)
            {
                List<ReporteDetalleEquipos> reporte5 = new List<ReporteDetalleEquipos>();
                reporte5 = metodo.Reporte_EquiposDetalle();

                this.dgvReportes.Columns.Clear();
                this.dgvReportes.Columns.Add("dgProvincia", "Provincia");
                this.dgvReportes.Columns.Add("dgCiudad", "Ciudad");
                this.dgvReportes.Columns.Add("dgNombreAgencia", "Nombre del Área");
                this.dgvReportes.Columns.Add("dgSubred", "Subred");
                this.dgvReportes.Columns.Add("dgEstadoAgencia", "Estado del Área");
                this.dgvReportes.Columns.Add("dgEquipo", "Equipo");
                this.dgvReportes.Columns.Add("dgIp", "Ip");
                this.dgvReportes.Columns.Add("dgSistemaOperativo", "Sistema Operativo");
                this.dgvReportes.Columns.Add("dgUsuarioLogeado", "Último usuario logeado");
                this.dgvReportes.Columns.Add("dgFechaRegistro", "Fecha de Registro");
                this.dgvReportes.Columns.Add("dgUltimaActividad", "Fecha último escaneo");
                this.dgvReportes.Columns.Add("dgEstadoAntivirus", "Estado del Antivirus");
                this.dgvReportes.Columns.Add("dgFechaActualizacionAntivirus", "Fecha última actualización del estado del Antivirus");

                int TotalEquipos = 0;

                foreach (var item in reporte5)
                {
                    dgvReportes.Rows.Add();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgProvincia"].Value = item.Provincia.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgCiudad"].Value = item.Ciudad.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgNombreAgencia"].Value = item.Agencia.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgSubred"].Value = item.Subred.ToString();
                    
                    //Deshabilitada                    
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgEstadoAgencia"].Value = item.EstadoAgencia.ToString();
                    if (item.EstadoAgencia.ToString() == "Deshabilitada")
                    {
                        this.dgvReportes.Rows[this.dgvReportes.Rows.Count - 1].Cells["dgEstadoAgencia"].Style.BackColor = Color.Red;
                    }

                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgEquipo"].Value = item.Equipo.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgIp"].Value = item.Ip.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgSistemaOperativo"].Value = item.SistemaOperativo.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgUsuarioLogeado"].Value = item.UltimoUsuarioLogeado.ToString();
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgFechaRegistro"].Value = item.FechaRegistro;
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgUltimaActividad"].Value = item.FechaUltimaActividad;
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgEstadoAntivirus"].Value = item.EstadoAntivirus;
                    dgvReportes.Rows[dgvReportes.Rows.Count - 1].Cells["dgFechaActualizacionAntivirus"].Value = item.FechaActualizaciónAntivirus;                    

                    TotalEquipos++;
                }

                dgvReportes.AutoResizeColumns();

                EscribirDatos("Total de equipos monitoreados: ", TotalEquipos.ToString());
            }
        }

        private void rbtAddAgencias_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAddAgencias.Checked)
            {
                panelContenedor.Controls.Clear();
                Control_AgenciaAgregar miControl = new Control_AgenciaAgregar();
                panelContenedor.Controls.Add(miControl);
            }
        }

        private void rbtAgenciasHabilitar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAgenciasHabilitar.Checked)
            {
                panelContenedor.Controls.Clear();
                Control_AgenciaHabilitarDeshabilitar miControl = new Control_AgenciaHabilitarDeshabilitar();
                //Habilitar
                miControl.estadoHD = false;
                panelContenedor.Controls.Add(miControl);
            }
        }

        private void rbtAgenciaDeshabilitar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAgenciaDeshabilitar.Checked)
            {
                panelContenedor.Controls.Clear();
                Control_AgenciaHabilitarDeshabilitar miControl = new Control_AgenciaHabilitarDeshabilitar();
                //Deshabilitar
                miControl.estadoHD = true;
                panelContenedor.Controls.Add(miControl);
            }
        }

        private void rbtAdminGrupos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAdminGrupos.Checked)
            {
                panelContenedor.Controls.Clear();
                Control_GruposAdministrar miControl = new Control_GruposAdministrar();
                panelContenedor.Controls.Add(miControl);
                miControl.Dock = DockStyle.Fill;
            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
            {
                string columnName = dGV.Columns[j].Name;
                if (columnName.ToUpper().Substring(0, 4) != "DGID")
                {
                    sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
                }
            }
            stOutput += sHeaders + "\r\n";

            // Export data.
            for (int i = 0; i < dGV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                {
                    string columnName = dGV.Columns[j].Name;
                    if (columnName.ToUpper().Substring(0, 4) != "DGID")
                    {
                        if (dGV.Rows[i].Cells[j].Value == null)
                        {
                            stLine = stLine.ToString() + "";
                        }
                        else
                        {
                            stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value.ToString().Replace(Environment.NewLine, "").Replace("\r\n", "")) + "\t";
                        }
                    }
                }
                stOutput += stLine + "\r\n";
            }


            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void btnExportarReporte_Click(object sender, EventArgs e)
        {
            DataGridView grd = new DataGridView();
            grd = dgvReportes;

            if (grd.Rows.Count > 0)
            {
                //GenExcell ge = new GenExcell();
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    string destino = string.Empty;

                    if (fichero.FileName != "")
                    {
                        destino = fichero.FileName;
                    }

                    //Especificar la ruta y nombre con el que se guardará el archivo
                    string filenam3 = destino;

                    //ge.DoExcell(dgvBitacora, filenam3);
                    ToCsV(dgvReportes, filenam3);

                    MessageBox.Show("El reporte fue exportado exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void rbtEquiposPorAgencia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEquiposPorAgencia.Checked)
            {
                dgvReportes.Columns.Clear();
                dgvReportes.Rows.Clear();
                rtxtResultado.Clear();
                lblAno.Visible = false;
                lblMes.Visible = false;
                ddlAno.Visible = false;
                ddlMes.Visible = false;
            }
        }

        private void rbtAgenciasGrupos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAgenciasGrupos.Checked)
            {
                dgvReportes.Columns.Clear();
                dgvReportes.Rows.Clear();
                rtxtResultado.Clear();
                lblAno.Visible = false;
                lblMes.Visible = false;
                ddlAno.Visible = false;
                ddlMes.Visible = false;
            }
        }

        private void rbtNovedadesAdministradores_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtNovedadesAdministradores.Checked)
            {
                dgvReportes.Columns.Clear();
                dgvReportes.Rows.Clear();
                rtxtResultado.Clear();
                lblAno.Visible = false;
                lblMes.Visible = false;
                ddlAno.Visible = false;
                ddlMes.Visible = false;
            }
        }

        private void dgvReportes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((rbtNovedadesAdministradores.Checked) || (rbtNovedadesAdministradoresMensual.Checked)) && (dgvReportes.Rows.Count > 0))
            {
                rtxtResultado.Clear();

                List<Reporte_AdministradoresNovedades_ByEquipoYAdmin> detalle = new List<Reporte_AdministradoresNovedades_ByEquipoYAdmin>();

                detalle = metodo.Reporte_AdministradoresNovedades_ByRegistro(dgvReportes.Rows[dgvReportes.CurrentRow.Index].Cells["dgEquipo"].Value.ToString(),
                                                                            dgvReportes.Rows[dgvReportes.CurrentRow.Index].Cells["dgAdministrador"].Value.ToString());


                EscribirDatos("Provincia: ", detalle[0].Provincia);
                EscribirDatos("Ciudad: ", detalle[0].Ciudad);
                EscribirDatos("Área: ", detalle[0].Agencia);
                EscribirDatos("Subred: ", detalle[0].Subred);
                EscribirDatos("Grupo: ", detalle[0].Grupo.ToString());
                EscribirDatos("Ip: ", detalle[0].Ip);
                EscribirDatos("Equipo: ", detalle[0].Equipo);
                EscribirDatos("Sistema Operativo: ", detalle[0].SistemaOperativo);
                EscribirDatos("Ultimo Usuario Logeado: ", detalle[0].UltimoUsuarioLogeado);
                EscribirDatos("Administrador: ", detalle[0].Administrador);

                EscribirDatos("Fechas: ", "");

                foreach (var item in detalle)
                {
                    EscribirDatos("", item.Fecha.ToShortDateString());                    
                }
            }
        }

        private void EscribirDatos(string negrita, string simple)
        {
            rtxtResultado.SelectionFont = new Font(rtxtResultado.SelectionFont, FontStyle.Bold);
            rtxtResultado.AppendText(negrita);
            rtxtResultado.SelectionFont = new Font(rtxtResultado.SelectionFont, FontStyle.Regular);
            rtxtResultado.AppendText(simple + Environment.NewLine);
        }

        private void rbtAdminAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAdminAdd.Checked)
            {
                dgvReportes.Columns.Clear();
                dgvReportes.Rows.Clear();
                rtxtResultado.Clear();
                lblAno.Visible = true;
                lblMes.Visible = true;
                ddlAno.Visible = true;
                ddlMes.Visible = true;
                LlenarMeses();
            }
        }

        private void LlenarMeses()
        {
            DataTable miTablaMeses = new DataTable("miTabla");
            miTablaMeses.Columns.Add("Id");
            miTablaMeses.Columns.Add("Nombre");
            for (int i = 1; i <= 12; i++)
            {
                miTablaMeses.Rows.Add(i, System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).ToUpper());
            }
            this.ddlMes.DataSource = miTablaMeses;
            this.ddlMes.ValueMember = "Id";
            this.ddlMes.DisplayMember = "Nombre";


            for (int i = 2015; i <= DateTime.Now.Year; i++)
            {
                this.ddlAno.Items.Add(i);
            }
            this.ddlMes.SelectedValue = DateTime.Now.Month;
            this.ddlAno.SelectedItem = DateTime.Now.Year;

        }

        private void rbtNovedadesAdministradoresMensual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtNovedadesAdministradoresMensual.Checked)
            {
                dgvReportes.Columns.Clear();
                dgvReportes.Rows.Clear();
                rtxtResultado.Clear();
                lblAno.Visible = true;
                lblMes.Visible = true;
                ddlAno.Visible = true;
                ddlMes.Visible = true;
                LlenarMeses();
            }
        }

        private void rbtLogEjecucion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtLogEjecucion.Checked)
            {
                panelContenedor.Controls.Clear();
                Control_LogEscaneo miControl = new Control_LogEscaneo();
                panelContenedor.Controls.Add(miControl);
                miControl.Dock = DockStyle.Fill;
            }
        }

        private void rbtEquiposDetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEquiposDetalle.Checked)
            {
                dgvReportes.Columns.Clear();
                dgvReportes.Rows.Clear();
                rtxtResultado.Clear();
                lblAno.Visible = false;
                lblMes.Visible = false;
                ddlAno.Visible = false;
                ddlMes.Visible = false;
            }
        }

        private void rbtAdmLineaBase_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAdmLineaBase.Checked)
            {
                panelContenedor.Controls.Clear();
                Control_AdministrarLineaBase miControl = new Control_AdministrarLineaBase();
                panelContenedor.Controls.Add(miControl);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
