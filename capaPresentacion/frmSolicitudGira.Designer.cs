namespace capaPresentacion
{
    partial class frmSolicitudGira
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("hola");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudGira));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpSolicitud = new System.Windows.Forms.DateTimePicker();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIDLugar = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.grdLugares = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLimpiar = new System.Windows.Forms.Button();
            this.btnAniadirLugar = new System.Windows.Forms.Button();
            this.cboFin = new System.Windows.Forms.ComboBox();
            this.cboInicio = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAgregarFuncionario = new System.Windows.Forms.Button();
            this.btnEliminarFuncionario = new System.Windows.Forms.Button();
            this.lsvFuncionarios = new System.Windows.Forms.ListView();
            this.btnBuscarDos = new System.Windows.Forms.Button();
            this.txtSolicitante = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnChofer = new System.Windows.Forms.Button();
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtEstilo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtGasolina = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCapacidad = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnPlaca = new System.Windows.Forms.Button();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkExtemporanea = new System.Windows.Forms.CheckBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.columnaID = new System.Windows.Forms.DataGridViewButtonColumn();
            this.columnaOrigen = new System.Windows.Forms.DataGridViewButtonColumn();
            this.columnaDestino = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLugares)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpSolicitud);
            this.groupBox1.Controls.Add(this.btnConfirmar);
            this.groupBox1.Controls.Add(this.dtpFin);
            this.groupBox1.Controls.Add(this.dtpInicio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboInicio);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboFin);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fechas de Gira";
            // 
            // dtpSolicitud
            // 
            this.dtpSolicitud.Enabled = false;
            this.dtpSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSolicitud.Location = new System.Drawing.Point(123, 21);
            this.dtpSolicitud.Name = "dtpSolicitud";
            this.dtpSolicitud.Size = new System.Drawing.Size(88, 20);
            this.dtpSolicitud.TabIndex = 9;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(111, 136);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 24);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "Confimar fechas";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dtpFin
            // 
            this.dtpFin.Enabled = false;
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(123, 73);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(88, 20);
            this.dtpFin.TabIndex = 7;
            this.dtpFin.ValueChanged += new System.EventHandler(this.dtpFin_ValueChanged);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Enabled = false;
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(123, 47);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(88, 20);
            this.dtpInicio.TabIndex = 6;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtpInicio_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha de Fin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de Inicio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha de Solicitud:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.txtIDLugar);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.grdLugares);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtLimpiar);
            this.groupBox2.Controls.Add(this.btnAniadirLugar);
            this.groupBox2.Controls.Add(this.txtFinal);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtOrigen);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(238, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 161);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lugares de Gira";
            // 
            // txtIDLugar
            // 
            this.txtIDLugar.Enabled = false;
            this.txtIDLugar.Location = new System.Drawing.Point(40, 134);
            this.txtIDLugar.Name = "txtIDLugar";
            this.txtIDLugar.ReadOnly = true;
            this.txtIDLugar.Size = new System.Drawing.Size(49, 20);
            this.txtIDLugar.TabIndex = 16;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 137);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 13);
            this.label19.TabIndex = 15;
            this.label19.Text = "N°:";
            // 
            // grdLugares
            // 
            this.grdLugares.AllowUserToAddRows = false;
            this.grdLugares.AllowUserToDeleteRows = false;
            this.grdLugares.AllowUserToResizeColumns = false;
            this.grdLugares.AllowUserToResizeRows = false;
            this.grdLugares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLugares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnaID,
            this.columnaOrigen,
            this.columnaDestino});
            this.grdLugares.Location = new System.Drawing.Point(335, 13);
            this.grdLugares.Name = "grdLugares";
            this.grdLugares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLugares.Size = new System.Drawing.Size(360, 112);
            this.grdLugares.TabIndex = 14;
            this.grdLugares.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLugares_CellContentDoubleClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(615, 131);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar día";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(327, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(2, 137);
            this.label9.TabIndex = 2;
            this.label9.Text = " ";
            // 
            // txtLimpiar
            // 
            this.txtLimpiar.Location = new System.Drawing.Point(154, 132);
            this.txtLimpiar.Name = "txtLimpiar";
            this.txtLimpiar.Size = new System.Drawing.Size(75, 23);
            this.txtLimpiar.TabIndex = 11;
            this.txtLimpiar.Text = "Limpiar";
            this.txtLimpiar.UseVisualStyleBackColor = true;
            this.txtLimpiar.Click += new System.EventHandler(this.txtLimpiar_Click);
            // 
            // btnAniadirLugar
            // 
            this.btnAniadirLugar.Location = new System.Drawing.Point(235, 132);
            this.btnAniadirLugar.Name = "btnAniadirLugar";
            this.btnAniadirLugar.Size = new System.Drawing.Size(75, 23);
            this.btnAniadirLugar.TabIndex = 10;
            this.btnAniadirLugar.Text = "Añadir día";
            this.btnAniadirLugar.UseVisualStyleBackColor = true;
            this.btnAniadirLugar.Click += new System.EventHandler(this.btnAniadirLugar_Click);
            // 
            // cboFin
            // 
            this.cboFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFin.FormattingEnabled = true;
            this.cboFin.Location = new System.Drawing.Point(159, 102);
            this.cboFin.Name = "cboFin";
            this.cboFin.Size = new System.Drawing.Size(52, 21);
            this.cboFin.TabIndex = 7;
            // 
            // cboInicio
            // 
            this.cboInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInicio.FormattingEnabled = true;
            this.cboInicio.Items.AddRange(new object[] {
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00"});
            this.cboInicio.Location = new System.Drawing.Point(61, 102);
            this.cboInicio.Name = "cboInicio";
            this.cboInicio.Size = new System.Drawing.Size(52, 21);
            this.cboInicio.TabIndex = 6;
            this.cboInicio.SelectionChangeCommitted += new System.EventHandler(this.cboInicio_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "H. Fin:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "H. Inicio:";
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new System.Drawing.Point(104, 53);
            this.txtFinal.MaxLength = 200;
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(206, 20);
            this.txtFinal.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Lugar de Final:";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(104, 27);
            this.txtOrigen.MaxLength = 200;
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(206, 20);
            this.txtOrigen.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lugar de Origen:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAgregarFuncionario);
            this.groupBox3.Controls.Add(this.btnEliminarFuncionario);
            this.groupBox3.Controls.Add(this.lsvFuncionarios);
            this.groupBox3.Controls.Add(this.btnBuscarDos);
            this.groupBox3.Controls.Add(this.txtSolicitante);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.btnChofer);
            this.groupBox3.Controls.Add(this.txtChofer);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(12, 179);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 217);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Funcionarios de Gira";
            // 
            // btnAgregarFuncionario
            // 
            this.btnAgregarFuncionario.Location = new System.Drawing.Point(370, 108);
            this.btnAgregarFuncionario.Name = "btnAgregarFuncionario";
            this.btnAgregarFuncionario.Size = new System.Drawing.Size(61, 23);
            this.btnAgregarFuncionario.TabIndex = 8;
            this.btnAgregarFuncionario.Text = "Agregar";
            this.btnAgregarFuncionario.UseVisualStyleBackColor = true;
            // 
            // btnEliminarFuncionario
            // 
            this.btnEliminarFuncionario.Location = new System.Drawing.Point(370, 137);
            this.btnEliminarFuncionario.Name = "btnEliminarFuncionario";
            this.btnEliminarFuncionario.Size = new System.Drawing.Size(61, 23);
            this.btnEliminarFuncionario.TabIndex = 8;
            this.btnEliminarFuncionario.Text = "Eliminar";
            this.btnEliminarFuncionario.UseVisualStyleBackColor = true;
            // 
            // lsvFuncionarios
            // 
            this.lsvFuncionarios.GridLines = true;
            this.lsvFuncionarios.HideSelection = false;
            this.lsvFuncionarios.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lsvFuncionarios.Location = new System.Drawing.Point(24, 108);
            this.lsvFuncionarios.Name = "lsvFuncionarios";
            this.lsvFuncionarios.Size = new System.Drawing.Size(340, 97);
            this.lsvFuncionarios.TabIndex = 7;
            this.lsvFuncionarios.UseCompatibleStateImageBehavior = false;
            this.lsvFuncionarios.View = System.Windows.Forms.View.Details;
            // 
            // btnBuscarDos
            // 
            this.btnBuscarDos.Location = new System.Drawing.Point(370, 55);
            this.btnBuscarDos.Name = "btnBuscarDos";
            this.btnBuscarDos.Size = new System.Drawing.Size(61, 23);
            this.btnBuscarDos.TabIndex = 6;
            this.btnBuscarDos.Text = "Buscar";
            this.btnBuscarDos.UseVisualStyleBackColor = true;
            // 
            // txtSolicitante
            // 
            this.txtSolicitante.BackColor = System.Drawing.SystemColors.Info;
            this.txtSolicitante.Enabled = false;
            this.txtSolicitante.Location = new System.Drawing.Point(82, 25);
            this.txtSolicitante.Name = "txtSolicitante";
            this.txtSolicitante.ReadOnly = true;
            this.txtSolicitante.Size = new System.Drawing.Size(282, 20);
            this.txtSolicitante.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Solicitante:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Funcionarios que asisten:";
            // 
            // btnChofer
            // 
            this.btnChofer.Location = new System.Drawing.Point(370, 23);
            this.btnChofer.Name = "btnChofer";
            this.btnChofer.Size = new System.Drawing.Size(61, 23);
            this.btnChofer.TabIndex = 2;
            this.btnChofer.Text = "Buscar";
            this.btnChofer.UseVisualStyleBackColor = true;
            this.btnChofer.Click += new System.EventHandler(this.btnChofer_Click);
            // 
            // txtChofer
            // 
            this.txtChofer.BackColor = System.Drawing.SystemColors.Info;
            this.txtChofer.Enabled = false;
            this.txtChofer.Location = new System.Drawing.Point(82, 57);
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.ReadOnly = true;
            this.txtChofer.Size = new System.Drawing.Size(282, 20);
            this.txtChofer.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Chofer:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtEstilo);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtGasolina);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtCapacidad);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtModelo);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.btnPlaca);
            this.groupBox4.Controls.Add(this.txtPlaca);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(455, 179);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(485, 128);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Vehículo de Gira";
            // 
            // txtEstilo
            // 
            this.txtEstilo.Enabled = false;
            this.txtEstilo.Location = new System.Drawing.Point(373, 89);
            this.txtEstilo.Name = "txtEstilo";
            this.txtEstilo.ReadOnly = true;
            this.txtEstilo.Size = new System.Drawing.Size(100, 20);
            this.txtEstilo.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(330, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "Estilo:";
            // 
            // txtGasolina
            // 
            this.txtGasolina.Enabled = false;
            this.txtGasolina.Location = new System.Drawing.Point(126, 89);
            this.txtGasolina.Name = "txtGasolina";
            this.txtGasolina.ReadOnly = true;
            this.txtGasolina.Size = new System.Drawing.Size(100, 20);
            this.txtGasolina.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Tipo de Gasolina:";
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Enabled = false;
            this.txtCapacidad.Location = new System.Drawing.Point(373, 60);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.ReadOnly = true;
            this.txtCapacidad.Size = new System.Drawing.Size(100, 20);
            this.txtCapacidad.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(306, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Capacidad:";
            // 
            // txtModelo
            // 
            this.txtModelo.Enabled = false;
            this.txtModelo.Location = new System.Drawing.Point(126, 60);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.ReadOnly = true;
            this.txtModelo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtModelo.Size = new System.Drawing.Size(100, 20);
            this.txtModelo.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Modelo del vehículo:";
            // 
            // btnPlaca
            // 
            this.btnPlaca.Location = new System.Drawing.Point(369, 21);
            this.btnPlaca.Name = "btnPlaca";
            this.btnPlaca.Size = new System.Drawing.Size(104, 23);
            this.btnPlaca.TabIndex = 2;
            this.btnPlaca.Text = "Buscar vehículo";
            this.btnPlaca.UseVisualStyleBackColor = true;
            // 
            // txtPlaca
            // 
            this.txtPlaca.BackColor = System.Drawing.SystemColors.Info;
            this.txtPlaca.Enabled = false;
            this.txtPlaca.Location = new System.Drawing.Point(118, 24);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.ReadOnly = true;
            this.txtPlaca.Size = new System.Drawing.Size(100, 20);
            this.txtPlaca.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Placa del vehículo:";
            // 
            // chkExtemporanea
            // 
            this.chkExtemporanea.AutoSize = true;
            this.chkExtemporanea.Location = new System.Drawing.Point(485, 377);
            this.chkExtemporanea.Name = "chkExtemporanea";
            this.chkExtemporanea.Size = new System.Drawing.Size(196, 17);
            this.chkExtemporanea.TabIndex = 4;
            this.chkExtemporanea.Text = "Enviar como solicitud extemporánea";
            this.chkExtemporanea.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEnviar.Location = new System.Drawing.Point(687, 374);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(141, 23);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar Solicitud";
            this.btnEnviar.UseVisualStyleBackColor = false;
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(834, 316);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(106, 23);
            this.btnInfo.TabIndex = 6;
            this.btnInfo.Text = "Información Adicional";
            this.btnInfo.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(834, 345);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(106, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar Todo";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.LightGray;
            this.btnSalir.Location = new System.Drawing.Point(834, 374);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(106, 23);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Image = global::capaPresentacion.Properties.Resources.icons8_question_mark_windows_11_color_16;
            this.label18.Location = new System.Drawing.Point(460, 372);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 23);
            this.label18.TabIndex = 9;
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // columnaID
            // 
            this.columnaID.DataPropertyName = "Id";
            this.columnaID.HeaderText = "Número";
            this.columnaID.Name = "columnaID";
            this.columnaID.Visible = false;
            // 
            // columnaOrigen
            // 
            this.columnaOrigen.DataPropertyName = "Origen";
            this.columnaOrigen.HeaderText = "Origen";
            this.columnaOrigen.Name = "columnaOrigen";
            this.columnaOrigen.Width = 150;
            // 
            // columnaDestino
            // 
            this.columnaDestino.DataPropertyName = "Destino";
            this.columnaDestino.HeaderText = "Destino";
            this.columnaDestino.Name = "columnaDestino";
            this.columnaDestino.Width = 150;
            // 
            // frmSolicitudGira
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 402);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.chkExtemporanea);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSolicitudGira";
            this.Text = "Solicitud de Gira";
            this.Load += new System.EventHandler(this.frmSolicitudGira_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLugares)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button txtLimpiar;
        private System.Windows.Forms.Button btnAniadirLugar;
        private System.Windows.Forms.ComboBox cboFin;
        private System.Windows.Forms.ComboBox cboInicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lsvFuncionarios;
        private System.Windows.Forms.Button btnBuscarDos;
        private System.Windows.Forms.TextBox txtSolicitante;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnChofer;
        private System.Windows.Forms.TextBox txtChofer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnEliminarFuncionario;
        private System.Windows.Forms.Button btnAgregarFuncionario;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtEstilo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtGasolina;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCapacidad;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnPlaca;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkExtemporanea;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpSolicitud;
        private System.Windows.Forms.DataGridView grdLugares;
        private System.Windows.Forms.TextBox txtIDLugar;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridViewButtonColumn columnaID;
        private System.Windows.Forms.DataGridViewButtonColumn columnaOrigen;
        private System.Windows.Forms.DataGridViewButtonColumn columnaDestino;
    }
}