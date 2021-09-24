namespace Monitoreo
{
    partial class Control_GruposAdministrar
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAgencias = new System.Windows.Forms.DataGridView();
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblTotalAgencias = new System.Windows.Forms.Label();
            this.dgIdAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProvincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNombreAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgencias)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvAgencias);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 471);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Áreas";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvAgencias
            // 
            this.dgvAgencias.AllowUserToAddRows = false;
            this.dgvAgencias.AllowUserToDeleteRows = false;
            this.dgvAgencias.AllowUserToResizeRows = false;
            this.dgvAgencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAgencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgIdAgencia,
            this.dgProvincia,
            this.dgCiudad,
            this.dgNombreAgencia,
            this.dgGrupo});
            this.dgvAgencias.Location = new System.Drawing.Point(6, 20);
            this.dgvAgencias.Name = "dgvAgencias";
            this.dgvAgencias.RowHeadersWidth = 22;
            this.dgvAgencias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAgencias.Size = new System.Drawing.Size(694, 445);
            this.dgvAgencias.TabIndex = 0;
            this.dgvAgencias.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAgencias_CellEndEdit);
            // 
            // lstGrupos
            // 
            this.lstGrupos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGrupos.FormattingEnabled = true;
            this.lstGrupos.ItemHeight = 15;
            this.lstGrupos.Location = new System.Drawing.Point(3, 17);
            this.lstGrupos.Name = "lstGrupos";
            this.lstGrupos.Size = new System.Drawing.Size(208, 369);
            this.lstGrupos.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lstGrupos);
            this.groupBox2.Location = new System.Drawing.Point(714, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 389);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Grupos";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::Monitoreo.Properties.Resources.save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(714, 434);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(218, 40);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Aplicar cambios";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTotalAgencias
            // 
            this.lblTotalAgencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAgencias.AutoSize = true;
            this.lblTotalAgencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAgencias.Location = new System.Drawing.Point(723, 404);
            this.lblTotalAgencias.Name = "lblTotalAgencias";
            this.lblTotalAgencias.Size = new System.Drawing.Size(0, 16);
            this.lblTotalAgencias.TabIndex = 4;
            // 
            // dgIdAgencia
            // 
            this.dgIdAgencia.Frozen = true;
            this.dgIdAgencia.HeaderText = "Id Agencia";
            this.dgIdAgencia.Name = "dgIdAgencia";
            this.dgIdAgencia.ReadOnly = true;
            this.dgIdAgencia.Visible = false;
            // 
            // dgProvincia
            // 
            this.dgProvincia.Frozen = true;
            this.dgProvincia.HeaderText = "Provincia";
            this.dgProvincia.Name = "dgProvincia";
            this.dgProvincia.ReadOnly = true;
            // 
            // dgCiudad
            // 
            this.dgCiudad.Frozen = true;
            this.dgCiudad.HeaderText = "Ciudad";
            this.dgCiudad.Name = "dgCiudad";
            this.dgCiudad.ReadOnly = true;
            // 
            // dgNombreAgencia
            // 
            this.dgNombreAgencia.Frozen = true;
            this.dgNombreAgencia.HeaderText = "Nombre Área";
            this.dgNombreAgencia.Name = "dgNombreAgencia";
            this.dgNombreAgencia.ReadOnly = true;
            // 
            // dgGrupo
            // 
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "1";
            this.dgGrupo.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgGrupo.Frozen = true;
            this.dgGrupo.HeaderText = "Grupo";
            this.dgGrupo.MaxInputLength = 2;
            this.dgGrupo.Name = "dgGrupo";
            // 
            // Control_GruposAdministrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTotalAgencias);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Control_GruposAdministrar";
            this.Size = new System.Drawing.Size(935, 477);
            this.Load += new System.EventHandler(this.Control_GruposAdministrar_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgencias)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAgencias;
        private System.Windows.Forms.ListBox lstGrupos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTotalAgencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIdAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProvincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNombreAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGrupo;

    }
}
