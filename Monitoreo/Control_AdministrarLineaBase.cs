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
    public partial class Control_AdministrarLineaBase : UserControl
    {
        public Control_AdministrarLineaBase()
        {
            InitializeComponent();
        }

        Metodos metodo = new Metodos();
        List<LineaBase> ListaLineaBaseORIGINAL = new List<LineaBase>();
            

        private void Control_AdministrarLineaBase_Load(object sender, EventArgs e)
        {
            ListaLineaBaseORIGINAL = metodo.LineaBase_SelectAll();
            LlenarLineaBase();
        }

        private void LlenarLineaBase()
        {
            dgvLineaBase.Rows.Clear();

            List<LineaBase> ListaLineaBase = new List<LineaBase>();
            ListaLineaBase = metodo.LineaBase_SelectAll();

            foreach (var item in ListaLineaBase)
            {
                dgvLineaBase.Rows.Add();
                dgvLineaBase.Rows[dgvLineaBase.Rows.Count - 1].Cells["dgIdUsuario"].Value = item.IdUsuario.ToString();
                dgvLineaBase.Rows[dgvLineaBase.Rows.Count - 1].Cells["dgUsuario"].Value = item.Usuario.ToString();
            }

            dgvLineaBase.AutoResizeColumns();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            dgvLineaBase.Rows.Add();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvLineaBase.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell item in dgvLineaBase.SelectedCells)
                {
                    try
                    {
                        dgvLineaBase.Rows.Remove(item.OwningRow);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            List<string> listLineaBase = new List<string>();
            
            if (dgvLineaBase.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvLineaBase.Rows)
                {
                    if (row.Cells["dgIdUsuario"].Value != null)
                    {
                        listLineaBase.Add(row.Cells["dgIdUsuario"].Value.ToString());
                    }
                }

                LineaBase objeto = new LineaBase();

                foreach (DataGridViewRow row in dgvLineaBase.Rows)
                {
                    if (row.Cells["dgIdUsuario"].Value == null)
                    {
                        //ADD
                        objeto.Usuario = row.Cells["dgUsuario"].Value.ToString();
                        int ret = metodo.LineaBaseInsertar(objeto);
                    }
                }

                foreach (var item in ListaLineaBaseORIGINAL)
                {
                    if (listLineaBase.Contains(item.IdUsuario.ToString()))
                    {
                        //UPDATE
                        foreach (DataGridViewRow row in dgvLineaBase.Rows)
                        {
                            if (row.Cells["dgIdUsuario"].Value != null)
                            {
                                if (row.Cells["dgIdUsuario"].Value.ToString() == item.IdUsuario.ToString())
                                {
                                    objeto.IdUsuario = Convert.ToInt32(row.Cells["dgIdUsuario"].Value);
                                    objeto.Usuario = row.Cells["dgUsuario"].Value.ToString();
                                    int ret = metodo.LineaBaseModificar(objeto);
                                }
                            }
                        }
                    }
                    else
                    {
                        //DELETE
                        objeto.IdUsuario = Convert.ToInt32(item.IdUsuario);
                        int ret = metodo.LineaBaseEliminar(objeto);
                    }
                }

                MessageBox.Show("Los datos fueron guardados.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaLineaBaseORIGINAL = metodo.LineaBase_SelectAll();
                LlenarLineaBase();
            }
            else
            {
                MessageBox.Show("No hay registros para guardar.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
