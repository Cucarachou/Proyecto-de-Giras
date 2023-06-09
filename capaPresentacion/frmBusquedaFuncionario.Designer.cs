﻿namespace capaPresentacion
{
    partial class frmBusquedaFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaFuncionario));
            this.label1 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.grdSolicitante = new System.Windows.Forms.DataGridView();
            this.columnaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaNombreApe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.btnInformacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdSolicitante)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar por:";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(306, 7);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(132, 20);
            this.txtInfo.TabIndex = 1;
            this.txtInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInfo_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(444, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // grdSolicitante
            // 
            this.grdSolicitante.AllowUserToAddRows = false;
            this.grdSolicitante.AllowUserToDeleteRows = false;
            this.grdSolicitante.AllowUserToResizeColumns = false;
            this.grdSolicitante.AllowUserToResizeRows = false;
            this.grdSolicitante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSolicitante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnaId,
            this.Column2,
            this.A,
            this.Column3,
            this.columnaNombreApe,
            this.Activo,
            this.Column1,
            this.Correo,
            this.Column4,
            this.Column5});
            this.grdSolicitante.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdSolicitante.Location = new System.Drawing.Point(15, 32);
            this.grdSolicitante.MultiSelect = false;
            this.grdSolicitante.Name = "grdSolicitante";
            this.grdSolicitante.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSolicitante.Size = new System.Drawing.Size(519, 164);
            this.grdSolicitante.TabIndex = 3;
            this.grdSolicitante.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSolicitante_CellContentClick);
            this.grdSolicitante.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSolicitante_CellContentDoubleClick);
            // 
            // columnaId
            // 
            this.columnaId.DataPropertyName = "Identificacion";
            this.columnaId.HeaderText = "Identificación";
            this.columnaId.Name = "columnaId";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Nombre";
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // A
            // 
            this.A.DataPropertyName = "ApellidoUno";
            this.A.HeaderText = "ApellidoUno";
            this.A.Name = "A";
            this.A.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ApellidoDos";
            this.Column3.HeaderText = "ApellidoDos";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // columnaNombreApe
            // 
            this.columnaNombreApe.DataPropertyName = "NombreApellido";
            this.columnaNombreApe.HeaderText = "Nombre Completo";
            this.columnaNombreApe.Name = "columnaNombreApe";
            this.columnaNombreApe.Width = 200;
            // 
            // Activo
            // 
            this.Activo.DataPropertyName = "Activo";
            this.Activo.HeaderText = "Activo";
            this.Activo.Name = "Activo";
            this.Activo.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Telefono";
            this.Column1.HeaderText = "Telefono";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Correo
            // 
            this.Correo.DataPropertyName = "Correo";
            this.Correo.HeaderText = "Correo";
            this.Correo.Name = "Correo";
            this.Correo.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Aprobador";
            this.Column4.HeaderText = "Aprobador";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "IdCentro";
            this.Column5.HeaderText = "IdCentro";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(459, 201);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(15, 201);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(378, 201);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Identificación",
            "Nombre o Apellidos"});
            this.cboTipo.Location = new System.Drawing.Point(79, 5);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(121, 21);
            this.cboTipo.TabIndex = 7;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(206, 9);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(73, 13);
            this.lblTipo.TabIndex = 8;
            this.lblTipo.Text = "Identificación:";
            // 
            // btnInformacion
            // 
            this.btnInformacion.Location = new System.Drawing.Point(97, 201);
            this.btnInformacion.Name = "btnInformacion";
            this.btnInformacion.Size = new System.Drawing.Size(75, 23);
            this.btnInformacion.TabIndex = 9;
            this.btnInformacion.Text = "Información";
            this.btnInformacion.UseVisualStyleBackColor = true;
            this.btnInformacion.Click += new System.EventHandler(this.btnInformacion_Click);
            // 
            // frmBusquedaFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(546, 229);
            this.Controls.Add(this.btnInformacion);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grdSolicitante);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusquedaFuncionario";
            this.Text = "Búsqueda de Funcionarios";
            this.Load += new System.EventHandler(this.frmBusquedaSolicitante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSolicitante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView grdSolicitante;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn A;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaNombreApe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnInformacion;
    }
}