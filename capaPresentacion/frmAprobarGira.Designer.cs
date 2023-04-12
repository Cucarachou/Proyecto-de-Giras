namespace capaPresentacion
{
    partial class frmAprobarGira
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
            this.txtFuncionario = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscarGira = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFuncionario
            // 
            this.txtFuncionario.BackColor = System.Drawing.SystemColors.Info;
            this.txtFuncionario.Enabled = false;
            this.txtFuncionario.Location = new System.Drawing.Point(15, 19);
            this.txtFuncionario.Name = "txtFuncionario";
            this.txtFuncionario.ReadOnly = true;
            this.txtFuncionario.Size = new System.Drawing.Size(357, 20);
            this.txtFuncionario.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(378, 17);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(66, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFuncionario);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Location = new System.Drawing.Point(10, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 53);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionario que aprueba o deniega:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConsultar);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.btnAprobar);
            this.groupBox2.Controls.Add(this.btnSalir);
            this.groupBox2.Controls.Add(this.btnBuscarGira);
            this.groupBox2.Controls.Add(this.txtInfo);
            this.groupBox2.Controls.Add(this.cboTipo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dgvSolicitudes);
            this.groupBox2.Location = new System.Drawing.Point(12, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 260);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Búsqueda de Giras";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(213, 231);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(67, 23);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "&Consultar Extemporaneidad";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(286, 231);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "&Rechazar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnAprobar
            // 
            this.btnAprobar.Location = new System.Drawing.Point(367, 231);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(75, 23);
            this.btnAprobar.TabIndex = 7;
            this.btnAprobar.Text = "&Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(13, 231);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBuscarGira
            // 
            this.btnBuscarGira.Location = new System.Drawing.Point(376, 22);
            this.btnBuscarGira.Name = "btnBuscarGira";
            this.btnBuscarGira.Size = new System.Drawing.Size(66, 23);
            this.btnBuscarGira.TabIndex = 4;
            this.btnBuscarGira.Text = "B&uscar";
            this.btnBuscarGira.UseVisualStyleBackColor = true;
            this.btnBuscarGira.Click += new System.EventHandler(this.btnBuscarGira_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Enabled = false;
            this.txtInfo.Location = new System.Drawing.Point(182, 24);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(188, 20);
            this.txtInfo.TabIndex = 3;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Estado",
            "Número de Gira",
            "Identificación de Solicitante",
            "Identificación de Chofer"});
            this.cboTipo.Location = new System.Drawing.Point(77, 24);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(99, 21);
            this.cboTipo.TabIndex = 2;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar por:";
            // 
            // dgvSolicitudes
            // 
            this.dgvSolicitudes.AllowUserToAddRows = false;
            this.dgvSolicitudes.AllowUserToDeleteRows = false;
            this.dgvSolicitudes.AllowUserToResizeColumns = false;
            this.dgvSolicitudes.AllowUserToResizeRows = false;
            this.dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column4,
            this.Column5,
            this.Column11,
            this.Column7,
            this.Column9,
            this.Column8,
            this.Column10,
            this.Column2,
            this.Column3,
            this.Column12,
            this.Column13});
            this.dgvSolicitudes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSolicitudes.Location = new System.Drawing.Point(13, 50);
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolicitudes.Size = new System.Drawing.Size(429, 175);
            this.dgvSolicitudes.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdGira";
            this.Column1.HeaderText = "Número";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "DiaSolicitud";
            this.Column6.HeaderText = "Fecha Solicitud";
            this.Column6.Name = "Column6";
            this.Column6.Width = 70;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DiaInicio";
            this.Column4.HeaderText = "Fecha Inicio";
            this.Column4.Name = "Column4";
            this.Column4.Width = 70;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DiaFinal";
            this.Column5.HeaderText = "Fecha Final";
            this.Column5.Name = "Column5";
            this.Column5.Width = 70;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "NombreCentro";
            this.Column11.HeaderText = "Centro de Formación";
            this.Column11.Name = "Column11";
            this.Column11.Width = 150;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "IdCentro";
            this.Column7.HeaderText = "IdCentro";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Solicitante";
            this.Column9.HeaderText = "Solicitante";
            this.Column9.Name = "Column9";
            this.Column9.Width = 70;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Chofer";
            this.Column8.HeaderText = "Chofer";
            this.Column8.Name = "Column8";
            this.Column8.Width = 70;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Placa";
            this.Column10.HeaderText = "Placa";
            this.Column10.Name = "Column10";
            this.Column10.Width = 70;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "HoraInicio";
            this.Column2.HeaderText = "Hora Inicio";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "HoraFin";
            this.Column3.HeaderText = "Hora Final";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "Extemporanea";
            this.Column12.HeaderText = "Extemporanea";
            this.Column12.Name = "Column12";
            this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column12.Width = 80;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Justificacion";
            this.Column13.HeaderText = "Justificación";
            this.Column13.Name = "Column13";
            this.Column13.Visible = false;
            // 
            // frmAprobarGira
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 330);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAprobarGira";
            this.Text = "Aprobar o denegar gira";
            this.Load += new System.EventHandler(this.frmAprobarGira_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFuncionario;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBuscarGira;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
    }
}