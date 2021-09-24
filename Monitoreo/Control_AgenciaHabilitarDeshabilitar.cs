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

namespace Monitoreo
{
    public partial class Control_AgenciaHabilitarDeshabilitar : UserControl
    {
        public Control_AgenciaHabilitarDeshabilitar()
        {
            InitializeComponent();
        }

        public bool estadoHD;

        Metodos metodo = new Metodos();

        List<ProvinciasEcuador> ListaProvincias = new List<ProvinciasEcuador>();
        List<CiudadesEcuador> ListaCiudades = new List<CiudadesEcuador>();
        List<Agencias> ListaAgencias = new List<Agencias>();

        private void Control_AgenciaHabilitarDeshabilitar_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
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
            else
            {
                ddlCiudad.DataSource = ListaCiudades;
                ddlCiudad.ValueMember = "IdCiudad";
                ddlCiudad.DisplayMember = "Ciudad";
            }

            ListaAgencias = new List<Agencias>();
            if (ListaCiudades.Count > 0)
            {
                CargarAgencias(ListaProvincias[ddlProvincia.SelectedIndex].Provincia, ListaCiudades[ddlCiudad.SelectedIndex].Ciudad);
            }
            else
            {
                ddlAgencia.DataSource = ListaAgencias;
                ddlAgencia.ValueMember = "IdAgencia";
                ddlAgencia.DisplayMember = "NombreAgencia";
                txtAgencia.Text = string.Empty;
            }

            if (estadoHD)
            {
                btnHabilitar.Visible = false;
                btnDeshabilitar.Visible = true;
            }
            else
            {
                btnHabilitar.Visible = true;
                btnDeshabilitar.Visible = false;
            }

            if ((ListaProvincias.Count > 0) && (ListaCiudades.Count > 0) && (ListaAgencias.Count > 0))
            {
                btnHabilitar.Enabled = true;
                btnDeshabilitar.Enabled = true;
            }
            else
            {
                btnHabilitar.Enabled = false;
                btnDeshabilitar.Enabled = false;
            }

        }

        public void CargarCiudades(int idProvincia)
        {
            ListaCiudades = metodo.Ciudades_HabilitadasDeshabilitadas(estadoHD, idProvincia);
            ListaCiudades = ListaCiudades.OrderBy(x => x.Ciudad).ToList();
            ddlCiudad.DataSource = ListaCiudades;
            ddlCiudad.ValueMember = "IdCiudad";
            ddlCiudad.DisplayMember = "Ciudad";
        }

        private void CargarProvincias()
        {
            ListaProvincias = metodo.Provincias_HabilitadasDeshabilitadas(estadoHD);
            ListaProvincias = ListaProvincias.OrderBy(x => x.Provincia).ToList();
            ddlProvincia.DataSource = ListaProvincias;
            ddlProvincia.ValueMember = "IdProvincia";
            ddlProvincia.DisplayMember = "Provincia";
        }

        private void CargarAgencias(string provincia, string ciudad)
        {
            ListaAgencias = metodo.Agencias_HabilitadasDeshabilitadas(estadoHD, provincia, ciudad);
            ListaAgencias = ListaAgencias.OrderBy(x => x.NombreAgencia).ToList();
            ddlAgencia.DataSource = ListaAgencias;
            ddlAgencia.ValueMember = "IdAgencia";
            ddlAgencia.DisplayMember = "NombreAgencia";
        }

        private void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListaProvincias.Count > 0)
            {
                CargarCiudades(ListaProvincias[ddlProvincia.SelectedIndex].IdProvincia);
            }
        }

        private void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string provincia = string.Empty;
            string ciudad = string.Empty;

            if (ListaCiudades.Count > 0)
            {
                if (ddlProvincia.SelectedIndex > 0)
                {
                    provincia = ListaProvincias[ddlProvincia.SelectedIndex].Provincia;
                }
                else
                {
                    provincia = ListaProvincias[0].Provincia;
                }

                if (ddlCiudad.SelectedIndex > 0)
                {
                    ciudad = ListaCiudades[ddlCiudad.SelectedIndex].Ciudad;
                }
                else
                {
                    ciudad = ListaCiudades[0].Ciudad;
                }

                CargarAgencias(provincia, ciudad);
            }
        }

        private void ddlAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Agencias agencia = new Agencias();

            agencia = metodo.Agencias_SelectByIdAgencia(ListaAgencias[ddlAgencia.SelectedIndex].IdAgencia);
            
            txtAgencia.Text = string.Empty;
            txtAgencia.Text = txtAgencia.Text + "PROVINCIA: " + agencia.Provincia + System.Environment.NewLine; ;
            txtAgencia.Text = txtAgencia.Text + "CIUDAD: " + agencia.Ciudad + System.Environment.NewLine; ;
            txtAgencia.Text = txtAgencia.Text + "ÁREA: " + agencia.NombreAgencia + System.Environment.NewLine; ;
            txtAgencia.Text = txtAgencia.Text + "SUBRED: " + agencia.Subred + System.Environment.NewLine; ;
            txtAgencia.Text = txtAgencia.Text + "GRUPO: " + agencia.Grupo + System.Environment.NewLine; ;
            
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            metodo.Agencias_HabilitarDeshabilitar(ListaAgencias[ddlAgencia.SelectedIndex].IdAgencia, true);

            MessageBox.Show("El área fue habilitada.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            metodo.Agencias_HabilitarDeshabilitar(ListaAgencias[ddlAgencia.SelectedIndex].IdAgencia, false);

            MessageBox.Show("El área fue deshabilitada.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
        }
    }
}
