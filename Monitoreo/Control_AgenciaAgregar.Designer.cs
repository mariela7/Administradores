namespace Monitoreo
{
    partial class Control_AgenciaAgregar
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
            this.label1 = new System.Windows.Forms.Label();
            this.ddlProvincia = new System.Windows.Forms.ComboBox();
            this.ddlCiudad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreAgencia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudGrupo = new System.Windows.Forms.NumericUpDown();
            this.txtSubred = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Provincia";
            // 
            // ddlProvincia
            // 
            this.ddlProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProvincia.FormattingEnabled = true;
            this.ddlProvincia.Location = new System.Drawing.Point(130, 20);
            this.ddlProvincia.Margin = new System.Windows.Forms.Padding(4);
            this.ddlProvincia.Name = "ddlProvincia";
            this.ddlProvincia.Size = new System.Drawing.Size(303, 23);
            this.ddlProvincia.TabIndex = 1;
            this.ddlProvincia.SelectedIndexChanged += new System.EventHandler(this.ddlProvincia_SelectedIndexChanged);
            // 
            // ddlCiudad
            // 
            this.ddlCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCiudad.FormattingEnabled = true;
            this.ddlCiudad.Location = new System.Drawing.Point(130, 67);
            this.ddlCiudad.Margin = new System.Windows.Forms.Padding(4);
            this.ddlCiudad.Name = "ddlCiudad";
            this.ddlCiudad.Size = new System.Drawing.Size(303, 23);
            this.ddlCiudad.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ciudad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre Área";
            // 
            // txtNombreAgencia
            // 
            this.txtNombreAgencia.Location = new System.Drawing.Point(130, 113);
            this.txtNombreAgencia.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreAgencia.Name = "txtNombreAgencia";
            this.txtNombreAgencia.Size = new System.Drawing.Size(303, 21);
            this.txtNombreAgencia.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Subred";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 206);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Grupo";
            // 
            // nudGrupo
            // 
            this.nudGrupo.Location = new System.Drawing.Point(130, 203);
            this.nudGrupo.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudGrupo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGrupo.Name = "nudGrupo";
            this.nudGrupo.Size = new System.Drawing.Size(59, 21);
            this.nudGrupo.TabIndex = 9;
            this.nudGrupo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtSubred
            // 
            this.txtSubred.Location = new System.Drawing.Point(130, 158);
            this.txtSubred.MaxLength = 11;
            this.txtSubred.Name = "txtSubred";
            this.txtSubred.Size = new System.Drawing.Size(135, 21);
            this.txtSubred.TabIndex = 12;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = global::Monitoreo.Properties.Resources.save_32;
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.Location = new System.Drawing.Point(343, 181);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(89, 43);
            this.btnGrabar.TabIndex = 10;
            this.btnGrabar.Text = "Guardar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // Control_AgenciaAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtSubred);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.nudGrupo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombreAgencia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddlCiudad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlProvincia);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Control_AgenciaAgregar";
            this.Size = new System.Drawing.Size(455, 244);
            this.Load += new System.EventHandler(this.Control_GrupoAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudGrupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlProvincia;
        private System.Windows.Forms.ComboBox ddlCiudad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreAgencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudGrupo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtSubred;
    }
}
