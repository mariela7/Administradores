using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocios;
using AccesoDatos;
using System.Net;

namespace Monitoreo
{
    public partial class Control_AgenciaAgregar : UserControl
    {
        public Control_AgenciaAgregar()
        {
            InitializeComponent();
        }

        Metodos metodo = new Metodos();

        public bool estado;

        List<ProvinciasEcuador> ListaProvincias = new List<ProvinciasEcuador>();
        List<CiudadesEcuador> ListaCiudades = new List<CiudadesEcuador>();

        private void Control_GrupoAdd_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        public void CargarCiudades(int idProvincia)
        {
            ListaCiudades = metodo.CiudadesEcuador_SelectByIdProvincia(idProvincia);
            ListaCiudades = ListaCiudades.OrderBy(x => x.Ciudad).ToList();
            ddlCiudad.DataSource = ListaCiudades;
            ddlCiudad.ValueMember = "IdCiudad";
            ddlCiudad.DisplayMember = "Ciudad";
            ddlCiudad.SelectedIndex = 5;
        }

        private void CargarProvincias()
        {
            ListaProvincias = metodo.ProvinciasEcuador_SelectAll();
            ListaProvincias = ListaProvincias.OrderBy(x => x.Provincia).ToList();
            ddlProvincia.DataSource = ListaProvincias;
            ddlProvincia.ValueMember = "IdProvincia";
            ddlProvincia.DisplayMember = "Provincia";
            ddlProvincia.SelectedIndex  = 18;
        }

        private void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCiudades(ListaProvincias[ddlProvincia.SelectedIndex].IdProvincia);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(ddlProvincia.Text.Trim()) == false)
                && (String.IsNullOrEmpty(ddlCiudad.Text.Trim()) == false)
                && (String.IsNullOrEmpty(txtNombreAgencia.Text.Trim()) == false)
                && (String.IsNullOrEmpty(txtSubred.Text.Trim()) == false)
                && (String.IsNullOrEmpty(nudGrupo.Text.Trim()) == false))
            {
                //string SegmentoReal = LimpiarIP(mtxtSubred.Text.Trim());
                string SegmentoReal = LimpiarIP(txtSubred.Text.Trim());

                if (ValidarIP(SegmentoReal))
                {
                    bool existeSubred = metodo.Agencias_SubredExiste(SegmentoReal);

                    if (existeSubred)
                    {
                        MessageBox.Show("El segemento de red ya está asignado a una área diferente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //valid ip
                        Agencias agencia = new Agencias();
                        agencia.Ciudad = ddlCiudad.Text.Trim();
                        agencia.Grupo = Convert.ToInt32(nudGrupo.Value);
                        agencia.NombreAgencia = txtNombreAgencia.Text.Trim().ToUpper();
                        agencia.Provincia = ddlProvincia.Text.Trim();
                        agencia.Subred = SegmentoReal;

                        int retorno = 0;

                        retorno = metodo.Agencias_Insertar(agencia);

                        if (retorno > 0)
                        {
                            LimpiarCampos();
                            MessageBox.Show("Los datos fueron grabados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al tratar de grabar la información.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    //is not valid ip
                    MessageBox.Show("El segemento de red es incorrecto.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Ingrese todos los campos del formulario.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidarIP(string ip)
        {
            int cont_poi = 0;
            int posUltimoPunto = 0;

            for (int i = 0; i < ip.Length; i++)
            {
                if (ip[i].ToString().Trim() == ".")
                {
                    cont_poi++;
                    if (posUltimoPunto == 0)
                    {
                        if (Convert.ToInt32(ip.Substring(posUltimoPunto, i - posUltimoPunto).Trim()) > 255)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(ip.Substring(posUltimoPunto + 1, i - (posUltimoPunto + 1)).Trim()) > 255)
                        {
                            return false;
                        }
                    }

                    posUltimoPunto = i;

                    cont_poi++;

                    if (cont_poi == 3)
                    {
                        break;
                    } 
                }                
            }

            return true;
        }

        private string LimpiarIP(string ipInicial)
        {
            string ipFinal = string.Empty;
            int cont_poi = 0;
            int posUltimoPunto = 0;

            for (int i = 0; i < ipInicial.Length; i++)
            {
                if (ipInicial[i].ToString().Trim() == ".")
                {
                    if (posUltimoPunto == 0)
                    {
                        //if (Convert.ToInt32(ipInicial.Substring(posUltimoPunto, i - posUltimoPunto).Trim()) <= 255)
                        //{
                            if (string.IsNullOrEmpty(ipFinal) == false)
                            {
                                ipFinal = ipFinal + "." + ipInicial.Substring(posUltimoPunto, i - posUltimoPunto).Trim();
                            }
                            else
                            {
                                ipFinal = ipFinal + ipInicial.Substring(posUltimoPunto, i - posUltimoPunto).Trim();
                            }
                        //}
                    }
                    else
                    {
                        //if (Convert.ToInt32(ipInicial.Substring(posUltimoPunto + 1, i - (posUltimoPunto + 1)).Trim()) <= 255)
                        //{
                            if (string.IsNullOrEmpty(ipFinal) == false)
                            {
                                ipFinal = ipFinal + "." + ipInicial.Substring(posUltimoPunto + 1, i - (posUltimoPunto + 1)).Trim();
                            }
                            else
                            {
                                ipFinal = ipFinal + ipInicial.Substring(posUltimoPunto + 1, i - (posUltimoPunto + 1)).Trim();
                            }
                        //}
                    }

                    posUltimoPunto = i;

                    cont_poi++;

                    if (cont_poi == 3)
                    {
                        ipFinal = ipFinal + ".X";
                        break;
                    } 
                }
            }

            return ipFinal.Trim();
        }

        private void LimpiarCampos()
        {
            ListaProvincias = new List<ProvinciasEcuador>();
            CargarProvincias();

            ListaCiudades = new List<CiudadesEcuador>();
            if (ListaProvincias.Count > 0)
            {
                CargarCiudades(ListaProvincias[ddlProvincia.SelectedIndex].IdProvincia);
            }            

            txtNombreAgencia.Text = string.Empty;
            txtSubred.Text = string.Empty;
            nudGrupo.Value = 1;
        }
    }
}
