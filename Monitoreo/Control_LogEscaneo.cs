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
    public partial class Control_LogEscaneo : UserControl
    {
        public Control_LogEscaneo()
        {
            InitializeComponent();
        }

        Metodos metodo = new Metodos();
        List<Log_RevisionEjecucion> Lista = new List<Log_RevisionEjecucion>();

        private void Control_LogEscaneo_Load(object sender, EventArgs e)
        {
            LlenarGrilla();
        }

        private void LlenarGrilla()
        {
            Lista = metodo.Log_RevisionEjecucionByFecha(this.dtpFecha.Value);

            dgvLogs.Rows.Clear();

            foreach (Log_RevisionEjecucion dato in Lista)
            {
                dgvLogs.Rows.Add();
                dgvLogs.Rows[dgvLogs.Rows.Count - 1].Cells["dgGrupo"].Value = dato.NGroup.ToString();
                if (dato.SegmentoEscaneado.Substring(0, 4) == "GI -")
                {
                    //inicio
                    dgvLogs.Rows[dgvLogs.Rows.Count - 1].Cells["dgEstado"].Value = "INICIO";
                }
                else if (dato.SegmentoEscaneado.Substring(0, 4) == "GF -")
                {
                    dgvLogs.Rows[dgvLogs.Rows.Count - 1].Cells["dgEstado"].Value = "FIN";
                }
                else
                {
                    dgvLogs.Rows[dgvLogs.Rows.Count - 1].Cells["dgEstado"].Value = "N/A";
                }
                
                dgvLogs.Rows[dgvLogs.Rows.Count - 1].Cells["dgFechaHora"].Value = dato.Fecha.ToString();                
            }
            dgvLogs.AutoResizeColumns();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            LlenarGrilla();
        }
    }
}
