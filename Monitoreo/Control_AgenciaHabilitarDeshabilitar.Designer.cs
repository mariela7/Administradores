namespace Monitoreo
{
    partial class Control_AgenciaHabilitarDeshabilitar
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
            this.ddlCiudad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlProvincia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlAgencia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAgencia = new System.Windows.Forms.TextBox();
            this.btnDeshabilitar = new System.Windows.Forms.Button();
            this.btnHabilitar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ddlCiudad
            // 
            this.ddlCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCiudad.FormattingEnabled = true;
            this.ddlCiudad.Location = new System.Drawing.Point(75, 66);
            this.ddlCiudad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddlCiudad.Name = "ddlCiudad";
            this.ddlCiudad.Size = new System.Drawing.Size(313, 23);
            this.ddlCiudad.TabIndex = 7;
            this.ddlCiudad.SelectedIndexChanged += new System.EventHandler(this.ddlCiudad_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ciudad";
            // 
            // ddlProvincia
            // 
            this.ddlProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProvincia.FormattingEnabled = true;
            this.ddlProvincia.Location = new System.Drawing.Point(75, 21);
            this.ddlProvincia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddlProvincia.Name = "ddlProvincia";
            this.ddlProvincia.Size = new System.Drawing.Size(313, 23);
            this.ddlProvincia.TabIndex = 5;
            this.ddlProvincia.SelectedIndexChanged += new System.EventHandler(this.ddlProvincia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Provincia";
            // 
            // ddlAgencia
            // 
            this.ddlAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAgencia.FormattingEnabled = true;
            this.ddlAgencia.Location = new System.Drawing.Point(75, 111);
            this.ddlAgencia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddlAgencia.Name = "ddlAgencia";
            this.ddlAgencia.Size = new System.Drawing.Size(313, 23);
            this.ddlAgencia.TabIndex = 9;
            this.ddlAgencia.SelectedIndexChanged += new System.EventHandler(this.ddlAgencia_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Área";
            // 
            // txtAgencia
            // 
            this.txtAgencia.BackColor = System.Drawing.Color.White;
            this.txtAgencia.Location = new System.Drawing.Point(395, 14);
            this.txtAgencia.Multiline = true;
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.ReadOnly = true;
            this.txtAgencia.Size = new System.Drawing.Size(217, 124);
            this.txtAgencia.TabIndex = 11;
            // 
            // btnDeshabilitar
            // 
            this.btnDeshabilitar.BackColor = System.Drawing.Color.White;
            this.btnDeshabilitar.Image = global::Monitoreo.Properties.Resources.cancel_32;
            this.btnDeshabilitar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeshabilitar.Location = new System.Drawing.Point(455, 153);
            this.btnDeshabilitar.Name = "btnDeshabilitar";
            this.btnDeshabilitar.Size = new System.Drawing.Size(157, 40);
            this.btnDeshabilitar.TabIndex = 13;
            this.btnDeshabilitar.Text = "Deshabilitar";
            this.btnDeshabilitar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeshabilitar.UseVisualStyleBackColor = false;
            this.btnDeshabilitar.Click += new System.EventHandler(this.btnDeshabilitar_Click);
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.BackColor = System.Drawing.Color.White;
            this.btnHabilitar.Image = global::Monitoreo.Properties.Resources.accept_32;
            this.btnHabilitar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHabilitar.Location = new System.Drawing.Point(13, 153);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(157, 40);
            this.btnHabilitar.TabIndex = 12;
            this.btnHabilitar.Text = "Habilitar";
            this.btnHabilitar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHabilitar.UseVisualStyleBackColor = false;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // Control_AgenciaHabilitarDeshabilitar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnDeshabilitar);
            this.Controls.Add(this.btnHabilitar);
            this.Controls.Add(this.txtAgencia);
            this.Controls.Add(this.ddlAgencia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddlCiudad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlProvincia);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Control_AgenciaHabilitarDeshabilitar";
            this.Size = new System.Drawing.Size(624, 205);
            this.Load += new System.EventHandler(this.Control_AgenciaHabilitarDeshabilitar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlCiudad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlProvincia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlAgencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAgencia;
        private System.Windows.Forms.Button btnHabilitar;
        private System.Windows.Forms.Button btnDeshabilitar;
    }
}
