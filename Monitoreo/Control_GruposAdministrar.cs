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
    public partial class Control_GruposAdministrar : UserControl
    {
        public Control_GruposAdministrar()
        {
            InitializeComponent();
            LlenarColores();
        }

        Metodos metodo = new Metodos();
        List<Grupos_SelectAll> ListaGrupos = new List<Grupos_SelectAll>();
        List<Agencias> ListaAgencias = new List<Agencias>();

        Parametros parametro = new Parametros();


        private void Control_GruposAdministrar_Load(object sender, EventArgs e)
        {
            dgvAgencias.Rows.Clear();
            LlenarGrilla();
            parametro = metodo.ObtenerParametroPorCodigo("MXG");
        }

        private void LlenarGrilla()
        {
            ListaAgencias = metodo.Agencias_SelectActivas();

            this.dgvAgencias.Columns["dgGrupo"].ValueType = typeof(Int32);

            foreach (Agencias agencia in ListaAgencias)
            {
                dgvAgencias.Rows.Add();
                dgvAgencias.Rows[dgvAgencias.Rows.Count - 1].Cells["dgIdAgencia"].Value = agencia.IdAgencia.ToString();
                dgvAgencias.Rows[dgvAgencias.Rows.Count - 1].Cells["dgProvincia"].Value = agencia.Provincia.ToString();
                dgvAgencias.Rows[dgvAgencias.Rows.Count - 1].Cells["dgCiudad"].Value = agencia.Ciudad.ToString();
                dgvAgencias.Rows[dgvAgencias.Rows.Count - 1].Cells["dgNombreAgencia"].Value = agencia.NombreAgencia.ToString();
                dgvAgencias.Rows[dgvAgencias.Rows.Count - 1].Cells["dgGrupo"].ValueType = typeof(Int32);
                dgvAgencias.Rows[dgvAgencias.Rows.Count - 1].Cells["dgGrupo"].Value = agencia.Grupo;
            }
            dgvAgencias.AutoResizeColumns();
            SumarGrupos();
            ColorearGrupos();
            lblTotalAgencias.Text = "Total de Agencias: " + dgvAgencias.Rows.Count.ToString();
        }

        private void SumarGrupos()
        {
            lstGrupos.Items.Clear();

            List<int> miListaGrupos = new List<int>();
            foreach (DataGridViewRow item in this.dgvAgencias.Rows)
            {
                int valorFinal = 0;
                int.TryParse(item.Cells["dgGrupo"].Value.ToString(), out valorFinal);
                miListaGrupos.Add(valorFinal);
            }

            List<int> miListaString = new List<int>();
            miListaGrupos.Sort();
            miListaString = miListaGrupos.Distinct().ToList();

            foreach (int Grupos in miListaString)
            {
                int Contar = 0;
                foreach (int Contador in miListaGrupos)
                {
                    
                    if (Grupos == Contador)
                    {
                        Contar++;
                    }
                }

                this.lstGrupos.Items.Add("Grupo " + Grupos.ToString() + ": " + Contar.ToString());
            }

        }

        private void ColorearGrupos()
        {
            List<int> miListaGrupos = new List<int>();
            foreach (DataGridViewRow item in this.dgvAgencias.Rows)
            {
                int valorFinal = 0;
                int.TryParse(item.Cells["dgGrupo"].Value.ToString(), out valorFinal);
                miListaGrupos.Add(valorFinal);
            }

            List<int> miListaString = new List<int>();
            miListaGrupos.Sort();
            miListaString = miListaGrupos.Distinct().ToList();



            foreach (int Grupos in miListaString)
            {
                foreach (DataGridViewRow item in this.dgvAgencias.Rows)
                {
                    if (Grupos.ToString() == item.Cells["dgGrupo"].Value.ToString())
                    {
                        foreach (DataGridViewCell Celdas in item.Cells)
                        {
                            Celdas.Style.BackColor = ListaColores[Grupos - 1];   
                        }
                        
                    }
                }

            }
        }

        List<Color> ListaColores = new List<Color>();

        private void LlenarColores()
        {
            ListaColores.Clear();

            ListaColores.Add(Color.AliceBlue);
            ListaColores.Add(Color.Beige);
            ListaColores.Add(Color.LightCyan);
            ListaColores.Add(Color.Gainsboro);
            ListaColores.Add(Color.LightGreen);
            ListaColores.Add(Color.LightSalmon);
            ListaColores.Add(Color.LightSkyBlue);
            ListaColores.Add(Color.LightYellow);
            ListaColores.Add(Color.LightPink);
            ListaColores.Add(Color.PeachPuff);
            ListaColores.Add(Color.MediumPurple);
            ListaColores.Add(Color.MintCream);
            ListaColores.Add(Color.FromArgb(246, 191, 211));
            ListaColores.Add(Color.FromArgb(247, 214, 243));
            ListaColores.Add(Color.FromArgb(218, 214, 247));
            ListaColores.Add(Color.FromArgb(214, 229, 247));
            ListaColores.Add(Color.FromArgb(214, 242, 247));
            ListaColores.Add(Color.FromArgb(214, 250, 216));
            ListaColores.Add(Color.FromArgb(246, 245, 200));
            ListaColores.Add(Color.FromArgb(244, 196, 151));
            ListaColores.Add(Color.FromArgb(210, 184, 179));
            ListaColores.Add(Color.FromArgb(206, 205, 247));
            ListaColores.Add(Color.FromArgb(243, 205, 247));
            ListaColores.Add(Color.FromArgb(227, 247, 205));
        }

        private void dgvAgencias_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (this.dgvAgencias[e.ColumnIndex, e.RowIndex].Value != null)
            {
                int valorFinal = parametro.Valor;
                int.TryParse(this.dgvAgencias[e.ColumnIndex, e.RowIndex].Value.ToString(), out valorFinal);
                if (valorFinal == 0)
                {
                    //MessageBox.Show("Favor ingrese solo números del 1 al " + parametro.Valor.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dgvAgencias[e.ColumnIndex, e.RowIndex].Value = parametro.Valor;
                }
                else if (valorFinal > parametro.Valor)
                {
                    MessageBox.Show("Solo puede ingresar hasta " + parametro.Valor.ToString() + " grupos.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dgvAgencias[e.ColumnIndex, e.RowIndex].Value = parametro.Valor;
                }
            }
            else
            {
                this.dgvAgencias[e.ColumnIndex, e.RowIndex].Value = parametro.Valor;
            }

                SumarGrupos();
                ColorearGrupos();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvAgencias.Rows)
            {
                if (item.Cells["dgGrupo"].Value.ToString() != string.Empty)
                {
                    metodo.Agencias_UpdateGrupo(Convert.ToInt16(item.Cells["dgIdAgencia"].Value), Convert.ToInt16(item.Cells["dgGrupo"].Value));
                }
            }

            dgvAgencias.Rows.Clear();
            LlenarGrilla();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
