namespace capaPresentacion
{
    partial class frmBusquedaSolicitante
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.grdSolicitante = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.columnaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaNombreApe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaCentro = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.columnaCentro});
            this.grdSolicitante.Location = new System.Drawing.Point(15, 32);
            this.grdSolicitante.Name = "grdSolicitante";
            this.grdSolicitante.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSolicitante.Size = new System.Drawing.Size(519, 164);
            this.grdSolicitante.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(459, 202);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(15, 202);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(363, 202);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
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
            this.columnaNombreApe.HeaderText = "Nombre y Apellidos";
            this.columnaNombreApe.Name = "columnaNombreApe";
            this.columnaNombreApe.Width = 200;
            // 
            // columnaCentro
            // 
            this.columnaCentro.DataPropertyName = "IdCentro";
            this.columnaCentro.HeaderText = "Centro de Formación";
            this.columnaCentro.Name = "columnaCentro";
            this.columnaCentro.Visible = false;
            this.columnaCentro.Width = 150;
            // 
            // frmBusquedaSolicitante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 229);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grdSolicitante);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "frmBusquedaSolicitante";
            this.Text = "Búsqueda de Solicitante";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaCentro;
    }
}