namespace Monitoreo
{
    partial class frmMonitoreo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitoreo));
            this.tpReportes = new System.Windows.Forms.TabPage();
            this.lblMes = new System.Windows.Forms.Label();
            this.lblAno = new System.Windows.Forms.Label();
            this.ddlAno = new System.Windows.Forms.ComboBox();
            this.ddlMes = new System.Windows.Forms.ComboBox();
            this.rtxtResultado = new System.Windows.Forms.RichTextBox();
            this.gbxReportes = new System.Windows.Forms.GroupBox();
            this.rbtEquiposDetalle = new System.Windows.Forms.RadioButton();
            this.rbtNovedadesAdministradoresMensual = new System.Windows.Forms.RadioButton();
            this.rbtAdminAdd = new System.Windows.Forms.RadioButton();
            this.rbtNovedadesAdministradores = new System.Windows.Forms.RadioButton();
            this.rbtAgenciasGrupos = new System.Windows.Forms.RadioButton();
            this.rbtEquiposPorAgencia = new System.Windows.Forms.RadioButton();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.tpAntivirus = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAntivirus = new System.Windows.Forms.DataGridView();
            this.dgAv_IdMaquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAv_IdAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAv_Provincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAv_Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAv_Agencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAv_Ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAv_Equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAv_SistemaOperativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAv_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAv_Antivirus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAv_AntivirusCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpAdministradores = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNovedades = new System.Windows.Forms.DataGridView();
            this.dgIdMaquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIdAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProvincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCanton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNombreAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSistemaOperativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUltimoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAntivirus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDominio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAdministrador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNombreAdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEliminadoVeces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFechaAdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAccionEjecutada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAccionEjecutar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgExcepcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbAdministracion = new System.Windows.Forms.TabPage();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtAdmLineaBase = new System.Windows.Forms.RadioButton();
            this.rbtLogEjecucion = new System.Windows.Forms.RadioButton();
            this.rbtAdminGrupos = new System.Windows.Forms.RadioButton();
            this.rbtAgenciaDeshabilitar = new System.Windows.Forms.RadioButton();
            this.rbtAgenciasHabilitar = new System.Windows.Forms.RadioButton();
            this.rbtAddAgencias = new System.Windows.Forms.RadioButton();
            this.tcMonitoreo = new System.Windows.Forms.TabControl();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnGenerarArchivo = new System.Windows.Forms.Button();
            this.btnMarcarFilasSelect = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnMarcarTodos = new System.Windows.Forms.Button();
            this.btnDesmarcarTodos = new System.Windows.Forms.Button();
            this.btnExportarReporte = new System.Windows.Forms.Button();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.tpReportes.SuspendLayout();
            this.gbxReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.tpAntivirus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntivirus)).BeginInit();
            this.tpAdministradores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNovedades)).BeginInit();
            this.tbAdministracion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tcMonitoreo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpReportes
            // 
            this.tpReportes.Controls.Add(this.lblMes);
            this.tpReportes.Controls.Add(this.lblAno);
            this.tpReportes.Controls.Add(this.ddlAno);
            this.tpReportes.Controls.Add(this.ddlMes);
            this.tpReportes.Controls.Add(this.rtxtResultado);
            this.tpReportes.Controls.Add(this.gbxReportes);
            this.tpReportes.Controls.Add(this.dgvReportes);
            this.tpReportes.Controls.Add(this.btnExportarReporte);
            this.tpReportes.Controls.Add(this.btnGenerarReporte);
            this.tpReportes.Location = new System.Drawing.Point(4, 22);
            this.tpReportes.Name = "tpReportes";
            this.tpReportes.Padding = new System.Windows.Forms.Padding(3);
            this.tpReportes.Size = new System.Drawing.Size(1227, 435);
            this.tpReportes.TabIndex = 2;
            this.tpReportes.Text = "Reportes";
            this.tpReportes.UseVisualStyleBackColor = true;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Location = new System.Drawing.Point(472, 9);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(37, 16);
            this.lblMes.TabIndex = 33;
            this.lblMes.Text = "Mes:";
            this.lblMes.Visible = false;
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAno.Location = new System.Drawing.Point(289, 9);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(35, 16);
            this.lblAno.TabIndex = 32;
            this.lblAno.Text = "Año:";
            this.lblAno.Visible = false;
            // 
            // ddlAno
            // 
            this.ddlAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAno.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAno.FormattingEnabled = true;
            this.ddlAno.Location = new System.Drawing.Point(330, 6);
            this.ddlAno.Name = "ddlAno";
            this.ddlAno.Size = new System.Drawing.Size(85, 23);
            this.ddlAno.TabIndex = 31;
            this.ddlAno.Visible = false;
            // 
            // ddlMes
            // 
            this.ddlMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMes.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlMes.FormattingEnabled = true;
            this.ddlMes.Location = new System.Drawing.Point(515, 6);
            this.ddlMes.Name = "ddlMes";
            this.ddlMes.Size = new System.Drawing.Size(180, 23);
            this.ddlMes.TabIndex = 29;
            this.ddlMes.Visible = false;
            // 
            // rtxtResultado
            // 
            this.rtxtResultado.BackColor = System.Drawing.Color.White;
            this.rtxtResultado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtResultado.Dock = System.Windows.Forms.DockStyle.Right;
            this.rtxtResultado.Enabled = false;
            this.rtxtResultado.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtResultado.Location = new System.Drawing.Point(1052, 3);
            this.rtxtResultado.Name = "rtxtResultado";
            this.rtxtResultado.ReadOnly = true;
            this.rtxtResultado.Size = new System.Drawing.Size(172, 429);
            this.rtxtResultado.TabIndex = 6;
            this.rtxtResultado.Text = "";
            // 
            // gbxReportes
            // 
            this.gbxReportes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxReportes.Controls.Add(this.rbtEquiposDetalle);
            this.gbxReportes.Controls.Add(this.rbtNovedadesAdministradoresMensual);
            this.gbxReportes.Controls.Add(this.rbtAdminAdd);
            this.gbxReportes.Controls.Add(this.rbtNovedadesAdministradores);
            this.gbxReportes.Controls.Add(this.rbtAgenciasGrupos);
            this.gbxReportes.Controls.Add(this.rbtEquiposPorAgencia);
            this.gbxReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxReportes.Location = new System.Drawing.Point(6, 127);
            this.gbxReportes.Name = "gbxReportes";
            this.gbxReportes.Size = new System.Drawing.Size(252, 305);
            this.gbxReportes.TabIndex = 1;
            this.gbxReportes.TabStop = false;
            this.gbxReportes.Text = "Reportes";
            // 
            // rbtEquiposDetalle
            // 
            this.rbtEquiposDetalle.AutoSize = true;
            this.rbtEquiposDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtEquiposDetalle.Location = new System.Drawing.Point(6, 214);
            this.rbtEquiposDetalle.Name = "rbtEquiposDetalle";
            this.rbtEquiposDetalle.Size = new System.Drawing.Size(130, 20);
            this.rbtEquiposDetalle.TabIndex = 5;
            this.rbtEquiposDetalle.TabStop = true;
            this.rbtEquiposDetalle.Text = "Equipos (Detalle)";
            this.rbtEquiposDetalle.UseVisualStyleBackColor = true;
            this.rbtEquiposDetalle.CheckedChanged += new System.EventHandler(this.rbtEquiposDetalle_CheckedChanged);
            // 
            // rbtNovedadesAdministradoresMensual
            // 
            this.rbtNovedadesAdministradoresMensual.AutoSize = true;
            this.rbtNovedadesAdministradoresMensual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtNovedadesAdministradoresMensual.Location = new System.Drawing.Point(6, 136);
            this.rbtNovedadesAdministradoresMensual.Name = "rbtNovedadesAdministradoresMensual";
            this.rbtNovedadesAdministradoresMensual.Size = new System.Drawing.Size(229, 20);
            this.rbtNovedadesAdministradoresMensual.TabIndex = 4;
            this.rbtNovedadesAdministradoresMensual.TabStop = true;
            this.rbtNovedadesAdministradoresMensual.Text = "Novedades reportadas (Mensual)";
            this.rbtNovedadesAdministradoresMensual.UseVisualStyleBackColor = true;
            this.rbtNovedadesAdministradoresMensual.CheckedChanged += new System.EventHandler(this.rbtNovedadesAdministradoresMensual_CheckedChanged);
            // 
            // rbtAdminAdd
            // 
            this.rbtAdminAdd.AutoSize = true;
            this.rbtAdminAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtAdminAdd.Location = new System.Drawing.Point(6, 175);
            this.rbtAdminAdd.Name = "rbtAdminAdd";
            this.rbtAdminAdd.Size = new System.Drawing.Size(246, 20);
            this.rbtAdminAdd.TabIndex = 3;
            this.rbtAdminAdd.TabStop = true;
            this.rbtAdminAdd.Text = "Administradores añadidos (Mensual)";
            this.rbtAdminAdd.UseVisualStyleBackColor = true;
            this.rbtAdminAdd.CheckedChanged += new System.EventHandler(this.rbtAdminAdd_CheckedChanged);
            // 
            // rbtNovedadesAdministradores
            // 
            this.rbtNovedadesAdministradores.AutoSize = true;
            this.rbtNovedadesAdministradores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtNovedadesAdministradores.Location = new System.Drawing.Point(6, 97);
            this.rbtNovedadesAdministradores.Name = "rbtNovedadesAdministradores";
            this.rbtNovedadesAdministradores.Size = new System.Drawing.Size(218, 20);
            this.rbtNovedadesAdministradores.TabIndex = 2;
            this.rbtNovedadesAdministradores.TabStop = true;
            this.rbtNovedadesAdministradores.Text = "Novedades reportadas (Todas)";
            this.rbtNovedadesAdministradores.UseVisualStyleBackColor = true;
            this.rbtNovedadesAdministradores.CheckedChanged += new System.EventHandler(this.rbtNovedadesAdministradores_CheckedChanged);
            // 
            // rbtAgenciasGrupos
            // 
            this.rbtAgenciasGrupos.AutoSize = true;
            this.rbtAgenciasGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtAgenciasGrupos.Location = new System.Drawing.Point(6, 58);
            this.rbtAgenciasGrupos.Name = "rbtAgenciasGrupos";
            this.rbtAgenciasGrupos.Size = new System.Drawing.Size(125, 20);
            this.rbtAgenciasGrupos.TabIndex = 1;
            this.rbtAgenciasGrupos.TabStop = true;
            this.rbtAgenciasGrupos.Text = "Áreas por Grupo";
            this.rbtAgenciasGrupos.UseVisualStyleBackColor = true;
            this.rbtAgenciasGrupos.CheckedChanged += new System.EventHandler(this.rbtAgenciasGrupos_CheckedChanged);
            // 
            // rbtEquiposPorAgencia
            // 
            this.rbtEquiposPorAgencia.AutoSize = true;
            this.rbtEquiposPorAgencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtEquiposPorAgencia.Location = new System.Drawing.Point(6, 19);
            this.rbtEquiposPorAgencia.Name = "rbtEquiposPorAgencia";
            this.rbtEquiposPorAgencia.Size = new System.Drawing.Size(131, 20);
            this.rbtEquiposPorAgencia.TabIndex = 0;
            this.rbtEquiposPorAgencia.TabStop = true;
            this.rbtEquiposPorAgencia.Text = "Equipos por Área";
            this.rbtEquiposPorAgencia.UseVisualStyleBackColor = true;
            this.rbtEquiposPorAgencia.CheckedChanged += new System.EventHandler(this.rbtEquiposPorAgencia_CheckedChanged);
            // 
            // dgvReportes
            // 
            this.dgvReportes.AllowUserToAddRows = false;
            this.dgvReportes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgvReportes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReportes.BackgroundColor = System.Drawing.Color.White;
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(264, 35);
            this.dgvReportes.MultiSelect = false;
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.ReadOnly = true;
            this.dgvReportes.Size = new System.Drawing.Size(787, 391);
            this.dgvReportes.TabIndex = 0;
            this.dgvReportes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReportes_CellClick);
            // 
            // tpAntivirus
            // 
            this.tpAntivirus.Controls.Add(this.label2);
            this.tpAntivirus.Controls.Add(this.dgvAntivirus);
            this.tpAntivirus.Location = new System.Drawing.Point(4, 22);
            this.tpAntivirus.Name = "tpAntivirus";
            this.tpAntivirus.Padding = new System.Windows.Forms.Padding(3);
            this.tpAntivirus.Size = new System.Drawing.Size(1227, 435);
            this.tpAntivirus.TabIndex = 1;
            this.tpAntivirus.Text = "Antivirus SEP12";
            this.tpAntivirus.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(436, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Revisar el antivirus de los siguientes equipos:";
            // 
            // dgvAntivirus
            // 
            this.dgvAntivirus.AllowUserToAddRows = false;
            this.dgvAntivirus.AllowUserToDeleteRows = false;
            this.dgvAntivirus.AllowUserToResizeRows = false;
            this.dgvAntivirus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAntivirus.BackgroundColor = System.Drawing.Color.White;
            this.dgvAntivirus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAntivirus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgAv_IdMaquina,
            this.dgAv_IdAgencia,
            this.dgAv_Provincia,
            this.dgAv_Ciudad,
            this.dgAv_Agencia,
            this.dgAv_Ip,
            this.dgAv_Equipo,
            this.dgAv_SistemaOperativo,
            this.dgAv_Usuario,
            this.dgAv_Antivirus,
            this.dgAv_AntivirusCodigo});
            this.dgvAntivirus.Location = new System.Drawing.Point(10, 39);
            this.dgvAntivirus.Name = "dgvAntivirus";
            this.dgvAntivirus.RowHeadersVisible = false;
            this.dgvAntivirus.Size = new System.Drawing.Size(1116, 395);
            this.dgvAntivirus.TabIndex = 8;
            // 
            // dgAv_IdMaquina
            // 
            this.dgAv_IdMaquina.HeaderText = "IdMaquina";
            this.dgAv_IdMaquina.Name = "dgAv_IdMaquina";
            this.dgAv_IdMaquina.Visible = false;
            // 
            // dgAv_IdAgencia
            // 
            this.dgAv_IdAgencia.HeaderText = "IdAgencia";
            this.dgAv_IdAgencia.Name = "dgAv_IdAgencia";
            this.dgAv_IdAgencia.Visible = false;
            // 
            // dgAv_Provincia
            // 
            this.dgAv_Provincia.HeaderText = "Provincia";
            this.dgAv_Provincia.Name = "dgAv_Provincia";
            this.dgAv_Provincia.ReadOnly = true;
            // 
            // dgAv_Ciudad
            // 
            this.dgAv_Ciudad.HeaderText = "Ciudad";
            this.dgAv_Ciudad.Name = "dgAv_Ciudad";
            this.dgAv_Ciudad.ReadOnly = true;
            // 
            // dgAv_Agencia
            // 
            this.dgAv_Agencia.HeaderText = "Nombre Área";
            this.dgAv_Agencia.Name = "dgAv_Agencia";
            this.dgAv_Agencia.ReadOnly = true;
            // 
            // dgAv_Ip
            // 
            this.dgAv_Ip.HeaderText = "Ip";
            this.dgAv_Ip.Name = "dgAv_Ip";
            // 
            // dgAv_Equipo
            // 
            this.dgAv_Equipo.HeaderText = "Equipo";
            this.dgAv_Equipo.Name = "dgAv_Equipo";
            // 
            // dgAv_SistemaOperativo
            // 
            this.dgAv_SistemaOperativo.HeaderText = "Sistema Operativo";
            this.dgAv_SistemaOperativo.Name = "dgAv_SistemaOperativo";
            this.dgAv_SistemaOperativo.Width = 150;
            // 
            // dgAv_Usuario
            // 
            this.dgAv_Usuario.HeaderText = "UltimoUsuario";
            this.dgAv_Usuario.Name = "dgAv_Usuario";
            this.dgAv_Usuario.ReadOnly = true;
            this.dgAv_Usuario.Visible = false;
            // 
            // dgAv_Antivirus
            // 
            this.dgAv_Antivirus.HeaderText = "Antivirus";
            this.dgAv_Antivirus.Name = "dgAv_Antivirus";
            this.dgAv_Antivirus.ReadOnly = true;
            this.dgAv_Antivirus.Width = 200;
            // 
            // dgAv_AntivirusCodigo
            // 
            this.dgAv_AntivirusCodigo.HeaderText = "Antivirus codigo";
            this.dgAv_AntivirusCodigo.Name = "dgAv_AntivirusCodigo";
            this.dgAv_AntivirusCodigo.ReadOnly = true;
            this.dgAv_AntivirusCodigo.Visible = false;
            // 
            // tpAdministradores
            // 
            this.tpAdministradores.Controls.Add(this.btnActualizar);
            this.tpAdministradores.Controls.Add(this.label1);
            this.tpAdministradores.Controls.Add(this.dgvNovedades);
            this.tpAdministradores.Controls.Add(this.btnGenerarArchivo);
            this.tpAdministradores.Controls.Add(this.btnMarcarFilasSelect);
            this.tpAdministradores.Controls.Add(this.btnGrabar);
            this.tpAdministradores.Controls.Add(this.btnMarcarTodos);
            this.tpAdministradores.Controls.Add(this.btnDesmarcarTodos);
            this.tpAdministradores.Location = new System.Drawing.Point(4, 22);
            this.tpAdministradores.Name = "tpAdministradores";
            this.tpAdministradores.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdministradores.Size = new System.Drawing.Size(1227, 435);
            this.tpAdministradores.TabIndex = 0;
            this.tpAdministradores.Text = "Usuarios Administradores";
            this.tpAdministradores.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(540, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marcar todos los registros que pertenezcan a Línea Base";
            // 
            // dgvNovedades
            // 
            this.dgvNovedades.AllowUserToAddRows = false;
            this.dgvNovedades.AllowUserToDeleteRows = false;
            this.dgvNovedades.AllowUserToResizeRows = false;
            this.dgvNovedades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNovedades.BackgroundColor = System.Drawing.Color.White;
            this.dgvNovedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNovedades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgIdMaquina,
            this.dgIdAgencia,
            this.dgProvincia,
            this.dgCanton,
            this.dgNombreAgencia,
            this.dgIp,
            this.dgEquipo,
            this.dgSistemaOperativo,
            this.dgUltimoUsuario,
            this.dgAntivirus,
            this.dgDominio,
            this.dgAdministrador,
            this.dgNombreAdm,
            this.dgEliminadoVeces,
            this.dgFechaAdm,
            this.dgAccionEjecutada,
            this.dgAccionEjecutar,
            this.dgExcepcion});
            this.dgvNovedades.Location = new System.Drawing.Point(6, 56);
            this.dgvNovedades.Name = "dgvNovedades";
            this.dgvNovedades.RowHeadersVisible = false;
            this.dgvNovedades.Size = new System.Drawing.Size(1070, 378);
            this.dgvNovedades.TabIndex = 1;
            // 
            // dgIdMaquina
            // 
            this.dgIdMaquina.HeaderText = "IdMaquina";
            this.dgIdMaquina.Name = "dgIdMaquina";
            this.dgIdMaquina.Visible = false;
            // 
            // dgIdAgencia
            // 
            this.dgIdAgencia.HeaderText = "IdAgencia";
            this.dgIdAgencia.Name = "dgIdAgencia";
            this.dgIdAgencia.Visible = false;
            // 
            // dgProvincia
            // 
            this.dgProvincia.HeaderText = "Provincia";
            this.dgProvincia.Name = "dgProvincia";
            this.dgProvincia.ReadOnly = true;
            // 
            // dgCanton
            // 
            this.dgCanton.HeaderText = "Ciudad";
            this.dgCanton.Name = "dgCanton";
            this.dgCanton.ReadOnly = true;
            // 
            // dgNombreAgencia
            // 
            this.dgNombreAgencia.HeaderText = "Nombre Área";
            this.dgNombreAgencia.Name = "dgNombreAgencia";
            this.dgNombreAgencia.ReadOnly = true;
            // 
            // dgIp
            // 
            this.dgIp.HeaderText = "Ip";
            this.dgIp.Name = "dgIp";
            // 
            // dgEquipo
            // 
            this.dgEquipo.HeaderText = "Equipo";
            this.dgEquipo.Name = "dgEquipo";
            // 
            // dgSistemaOperativo
            // 
            this.dgSistemaOperativo.HeaderText = "Sistema Operativo";
            this.dgSistemaOperativo.Name = "dgSistemaOperativo";
            this.dgSistemaOperativo.Width = 150;
            // 
            // dgUltimoUsuario
            // 
            this.dgUltimoUsuario.HeaderText = "UltimoUsuario";
            this.dgUltimoUsuario.Name = "dgUltimoUsuario";
            this.dgUltimoUsuario.ReadOnly = true;
            this.dgUltimoUsuario.Visible = false;
            // 
            // dgAntivirus
            // 
            this.dgAntivirus.HeaderText = "Antivirus";
            this.dgAntivirus.Name = "dgAntivirus";
            this.dgAntivirus.ReadOnly = true;
            this.dgAntivirus.Visible = false;
            // 
            // dgDominio
            // 
            this.dgDominio.HeaderText = "Dominio";
            this.dgDominio.Name = "dgDominio";
            this.dgDominio.ReadOnly = true;
            // 
            // dgAdministrador
            // 
            this.dgAdministrador.HeaderText = "Administrador";
            this.dgAdministrador.Name = "dgAdministrador";
            this.dgAdministrador.Visible = false;
            this.dgAdministrador.Width = 150;
            // 
            // dgNombreAdm
            // 
            this.dgNombreAdm.HeaderText = "Administrador";
            this.dgNombreAdm.Name = "dgNombreAdm";
            this.dgNombreAdm.ReadOnly = true;
            // 
            // dgEliminadoVeces
            // 
            this.dgEliminadoVeces.HeaderText = "# de veces eliminado";
            this.dgEliminadoVeces.Name = "dgEliminadoVeces";
            this.dgEliminadoVeces.ReadOnly = true;
            this.dgEliminadoVeces.Visible = false;
            // 
            // dgFechaAdm
            // 
            this.dgFechaAdm.HeaderText = "FechaAdm";
            this.dgFechaAdm.Name = "dgFechaAdm";
            this.dgFechaAdm.ReadOnly = true;
            this.dgFechaAdm.Visible = false;
            // 
            // dgAccionEjecutada
            // 
            this.dgAccionEjecutada.HeaderText = "Accion ejecutada";
            this.dgAccionEjecutada.Name = "dgAccionEjecutada";
            // 
            // dgAccionEjecutar
            // 
            this.dgAccionEjecutar.HeaderText = "Aceptar / Denegar";
            this.dgAccionEjecutar.Name = "dgAccionEjecutar";
            this.dgAccionEjecutar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccionEjecutar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgExcepcion
            // 
            this.dgExcepcion.HeaderText = "Excepcion";
            this.dgExcepcion.Name = "dgExcepcion";
            this.dgExcepcion.ReadOnly = true;
            this.dgExcepcion.Visible = false;
            // 
            // tbAdministracion
            // 
            this.tbAdministracion.Controls.Add(this.panelContenedor);
            this.tbAdministracion.Controls.Add(this.groupBox1);
            this.tbAdministracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAdministracion.Location = new System.Drawing.Point(4, 22);
            this.tbAdministracion.Name = "tbAdministracion";
            this.tbAdministracion.Size = new System.Drawing.Size(1227, 435);
            this.tbAdministracion.TabIndex = 3;
            this.tbAdministracion.Text = "Administración";
            this.tbAdministracion.UseVisualStyleBackColor = true;
            // 
            // panelContenedor
            // 
            this.panelContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContenedor.Location = new System.Drawing.Point(230, 12);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(982, 420);
            this.panelContenedor.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.rbtAdmLineaBase);
            this.groupBox1.Controls.Add(this.rbtLogEjecucion);
            this.groupBox1.Controls.Add(this.rbtAdminGrupos);
            this.groupBox1.Controls.Add(this.rbtAgenciaDeshabilitar);
            this.groupBox1.Controls.Add(this.rbtAgenciasHabilitar);
            this.groupBox1.Controls.Add(this.rbtAddAgencias);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 429);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones:";
            // 
            // rbtAdmLineaBase
            // 
            this.rbtAdmLineaBase.AutoSize = true;
            this.rbtAdmLineaBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtAdmLineaBase.Location = new System.Drawing.Point(10, 242);
            this.rbtAdmLineaBase.Name = "rbtAdmLineaBase";
            this.rbtAdmLineaBase.Size = new System.Drawing.Size(164, 20);
            this.rbtAdmLineaBase.TabIndex = 5;
            this.rbtAdmLineaBase.TabStop = true;
            this.rbtAdmLineaBase.Text = "Administrar Línea Base";
            this.rbtAdmLineaBase.UseVisualStyleBackColor = true;
            this.rbtAdmLineaBase.CheckedChanged += new System.EventHandler(this.rbtAdmLineaBase_CheckedChanged);
            // 
            // rbtLogEjecucion
            // 
            this.rbtLogEjecucion.AutoSize = true;
            this.rbtLogEjecucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtLogEjecucion.ForeColor = System.Drawing.Color.Red;
            this.rbtLogEjecucion.Location = new System.Drawing.Point(10, 200);
            this.rbtLogEjecucion.Name = "rbtLogEjecucion";
            this.rbtLogEjecucion.Size = new System.Drawing.Size(187, 20);
            this.rbtLogEjecucion.TabIndex = 4;
            this.rbtLogEjecucion.TabStop = true;
            this.rbtLogEjecucion.Text = "Log ejecución escaneo";
            this.rbtLogEjecucion.UseVisualStyleBackColor = true;
            this.rbtLogEjecucion.CheckedChanged += new System.EventHandler(this.rbtLogEjecucion_CheckedChanged);
            // 
            // rbtAdminGrupos
            // 
            this.rbtAdminGrupos.AutoSize = true;
            this.rbtAdminGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtAdminGrupos.Location = new System.Drawing.Point(10, 158);
            this.rbtAdminGrupos.Name = "rbtAdminGrupos";
            this.rbtAdminGrupos.Size = new System.Drawing.Size(138, 20);
            this.rbtAdminGrupos.TabIndex = 3;
            this.rbtAdminGrupos.TabStop = true;
            this.rbtAdminGrupos.Text = "Administrar grupos";
            this.rbtAdminGrupos.UseVisualStyleBackColor = true;
            this.rbtAdminGrupos.CheckedChanged += new System.EventHandler(this.rbtAdminGrupos_CheckedChanged);
            // 
            // rbtAgenciaDeshabilitar
            // 
            this.rbtAgenciaDeshabilitar.AutoSize = true;
            this.rbtAgenciaDeshabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtAgenciaDeshabilitar.Location = new System.Drawing.Point(10, 116);
            this.rbtAgenciaDeshabilitar.Name = "rbtAgenciaDeshabilitar";
            this.rbtAgenciaDeshabilitar.Size = new System.Drawing.Size(130, 20);
            this.rbtAgenciaDeshabilitar.TabIndex = 2;
            this.rbtAgenciaDeshabilitar.TabStop = true;
            this.rbtAgenciaDeshabilitar.Text = "Deshabilitar Área";
            this.rbtAgenciaDeshabilitar.UseVisualStyleBackColor = true;
            this.rbtAgenciaDeshabilitar.CheckedChanged += new System.EventHandler(this.rbtAgenciaDeshabilitar_CheckedChanged);
            // 
            // rbtAgenciasHabilitar
            // 
            this.rbtAgenciasHabilitar.AutoSize = true;
            this.rbtAgenciasHabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtAgenciasHabilitar.Location = new System.Drawing.Point(10, 74);
            this.rbtAgenciasHabilitar.Name = "rbtAgenciasHabilitar";
            this.rbtAgenciasHabilitar.Size = new System.Drawing.Size(108, 20);
            this.rbtAgenciasHabilitar.TabIndex = 1;
            this.rbtAgenciasHabilitar.TabStop = true;
            this.rbtAgenciasHabilitar.Text = "Habilitar Área";
            this.rbtAgenciasHabilitar.UseVisualStyleBackColor = true;
            this.rbtAgenciasHabilitar.CheckedChanged += new System.EventHandler(this.rbtAgenciasHabilitar_CheckedChanged);
            // 
            // rbtAddAgencias
            // 
            this.rbtAddAgencias.AutoSize = true;
            this.rbtAddAgencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtAddAgencias.Location = new System.Drawing.Point(10, 32);
            this.rbtAddAgencias.Name = "rbtAddAgencias";
            this.rbtAddAgencias.Size = new System.Drawing.Size(107, 20);
            this.rbtAddAgencias.TabIndex = 0;
            this.rbtAddAgencias.TabStop = true;
            this.rbtAddAgencias.Text = "Agregar Área";
            this.rbtAddAgencias.UseVisualStyleBackColor = true;
            this.rbtAddAgencias.CheckedChanged += new System.EventHandler(this.rbtAddAgencias_CheckedChanged);
            // 
            // tcMonitoreo
            // 
            this.tcMonitoreo.Controls.Add(this.tbAdministracion);
            this.tcMonitoreo.Controls.Add(this.tpAdministradores);
            this.tcMonitoreo.Controls.Add(this.tpAntivirus);
            this.tcMonitoreo.Controls.Add(this.tpReportes);
            this.tcMonitoreo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMonitoreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tcMonitoreo.Location = new System.Drawing.Point(0, 0);
            this.tcMonitoreo.Name = "tcMonitoreo";
            this.tcMonitoreo.SelectedIndex = 0;
            this.tcMonitoreo.Size = new System.Drawing.Size(1235, 461);
            this.tcMonitoreo.TabIndex = 9;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Image = global::Monitoreo.Properties.Resources.Refresh_32;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(953, 10);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(123, 41);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar\r\nDatos";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnGenerarArchivo
            // 
            this.btnGenerarArchivo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGenerarArchivo.BackColor = System.Drawing.Color.White;
            this.btnGenerarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarArchivo.Image = global::Monitoreo.Properties.Resources.txt2_32;
            this.btnGenerarArchivo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerarArchivo.Location = new System.Drawing.Point(1082, 275);
            this.btnGenerarArchivo.Name = "btnGenerarArchivo";
            this.btnGenerarArchivo.Size = new System.Drawing.Size(123, 91);
            this.btnGenerarArchivo.TabIndex = 5;
            this.btnGenerarArchivo.Text = "Generar archivo de equipos a depurar";
            this.btnGenerarArchivo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGenerarArchivo.UseVisualStyleBackColor = false;
            this.btnGenerarArchivo.Click += new System.EventHandler(this.btnGenerarArchivo_Click);
            // 
            // btnMarcarFilasSelect
            // 
            this.btnMarcarFilasSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMarcarFilasSelect.BackColor = System.Drawing.Color.White;
            this.btnMarcarFilasSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcarFilasSelect.ForeColor = System.Drawing.Color.Blue;
            this.btnMarcarFilasSelect.Image = global::Monitoreo.Properties.Resources.check_row_32;
            this.btnMarcarFilasSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMarcarFilasSelect.Location = new System.Drawing.Point(1082, 103);
            this.btnMarcarFilasSelect.Name = "btnMarcarFilasSelect";
            this.btnMarcarFilasSelect.Size = new System.Drawing.Size(123, 43);
            this.btnMarcarFilasSelect.TabIndex = 6;
            this.btnMarcarFilasSelect.Text = "Marcar Filas Seleccionadas";
            this.btnMarcarFilasSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcarFilasSelect.UseVisualStyleBackColor = false;
            this.btnMarcarFilasSelect.Click += new System.EventHandler(this.btnMarcarFilasSelect_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.BackColor = System.Drawing.Color.White;
            this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::Monitoreo.Properties.Resources.save_32;
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.Location = new System.Drawing.Point(1082, 372);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(123, 65);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "Aplicar cambios";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnMarcarTodos
            // 
            this.btnMarcarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMarcarTodos.BackColor = System.Drawing.Color.White;
            this.btnMarcarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcarTodos.Image = global::Monitoreo.Properties.Resources.check_32;
            this.btnMarcarTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMarcarTodos.Location = new System.Drawing.Point(1082, 9);
            this.btnMarcarTodos.Name = "btnMarcarTodos";
            this.btnMarcarTodos.Size = new System.Drawing.Size(123, 41);
            this.btnMarcarTodos.TabIndex = 3;
            this.btnMarcarTodos.Text = "Marcar \r\nTodos";
            this.btnMarcarTodos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcarTodos.UseVisualStyleBackColor = false;
            this.btnMarcarTodos.Click += new System.EventHandler(this.btnMarcarTodos_Click);
            // 
            // btnDesmarcarTodos
            // 
            this.btnDesmarcarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesmarcarTodos.BackColor = System.Drawing.Color.White;
            this.btnDesmarcarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesmarcarTodos.Image = global::Monitoreo.Properties.Resources.uncheck_32;
            this.btnDesmarcarTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDesmarcarTodos.Location = new System.Drawing.Point(1082, 56);
            this.btnDesmarcarTodos.Name = "btnDesmarcarTodos";
            this.btnDesmarcarTodos.Size = new System.Drawing.Size(123, 41);
            this.btnDesmarcarTodos.TabIndex = 4;
            this.btnDesmarcarTodos.Text = "Desmarcar \r\nTodos";
            this.btnDesmarcarTodos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesmarcarTodos.UseVisualStyleBackColor = false;
            this.btnDesmarcarTodos.Click += new System.EventHandler(this.btnDesmarcarTodos_Click);
            // 
            // btnExportarReporte
            // 
            this.btnExportarReporte.BackColor = System.Drawing.Color.Transparent;
            this.btnExportarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarReporte.Image = global::Monitoreo.Properties.Resources.excel_32;
            this.btnExportarReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarReporte.Location = new System.Drawing.Point(31, 64);
            this.btnExportarReporte.Name = "btnExportarReporte";
            this.btnExportarReporte.Size = new System.Drawing.Size(148, 47);
            this.btnExportarReporte.TabIndex = 4;
            this.btnExportarReporte.Text = "Exportar Reporte";
            this.btnExportarReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarReporte.UseVisualStyleBackColor = false;
            this.btnExportarReporte.Click += new System.EventHandler(this.btnExportarReporte_Click);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarReporte.Image = global::Monitoreo.Properties.Resources.report_32;
            this.btnGenerarReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarReporte.Location = new System.Drawing.Point(31, 6);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(148, 47);
            this.btnGenerarReporte.TabIndex = 2;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarReporte.UseVisualStyleBackColor = false;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // frmMonitoreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1235, 461);
            this.Controls.Add(this.tcMonitoreo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMonitoreo";
            this.Text = "Monitoreo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMonitoreo_Load);
            this.tpReportes.ResumeLayout(false);
            this.tpReportes.PerformLayout();
            this.gbxReportes.ResumeLayout(false);
            this.gbxReportes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.tpAntivirus.ResumeLayout(false);
            this.tpAntivirus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntivirus)).EndInit();
            this.tpAdministradores.ResumeLayout(false);
            this.tpAdministradores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNovedades)).EndInit();
            this.tbAdministracion.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tcMonitoreo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpReportes;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.ComboBox ddlAno;
        private System.Windows.Forms.ComboBox ddlMes;
        private System.Windows.Forms.RichTextBox rtxtResultado;
        private System.Windows.Forms.GroupBox gbxReportes;
        private System.Windows.Forms.RadioButton rbtEquiposDetalle;
        private System.Windows.Forms.RadioButton rbtNovedadesAdministradoresMensual;
        private System.Windows.Forms.RadioButton rbtAdminAdd;
        private System.Windows.Forms.RadioButton rbtNovedadesAdministradores;
        private System.Windows.Forms.RadioButton rbtAgenciasGrupos;
        private System.Windows.Forms.RadioButton rbtEquiposPorAgencia;
        private System.Windows.Forms.DataGridView dgvReportes;
        private System.Windows.Forms.Button btnExportarReporte;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.TabPage tpAntivirus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAntivirus;
        private System.Windows.Forms.TabPage tpAdministradores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvNovedades;
        private System.Windows.Forms.Button btnGenerarArchivo;
        private System.Windows.Forms.Button btnMarcarFilasSelect;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnMarcarTodos;
        private System.Windows.Forms.Button btnDesmarcarTodos;
        private System.Windows.Forms.TabPage tbAdministracion;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtAdmLineaBase;
        private System.Windows.Forms.RadioButton rbtLogEjecucion;
        private System.Windows.Forms.RadioButton rbtAdminGrupos;
        private System.Windows.Forms.RadioButton rbtAgenciaDeshabilitar;
        private System.Windows.Forms.RadioButton rbtAgenciasHabilitar;
        private System.Windows.Forms.RadioButton rbtAddAgencias;
        private System.Windows.Forms.TabControl tcMonitoreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAv_IdMaquina;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAv_IdAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAv_Provincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAv_Ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAv_Agencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAv_Ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAv_Equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAv_SistemaOperativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAv_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAv_Antivirus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAv_AntivirusCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIdMaquina;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIdAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProvincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCanton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNombreAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSistemaOperativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUltimoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAntivirus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDominio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAdministrador;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNombreAdm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEliminadoVeces;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFechaAdm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAccionEjecutada;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgAccionEjecutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgExcepcion;
        private System.Windows.Forms.Button btnActualizar;

    }
}

