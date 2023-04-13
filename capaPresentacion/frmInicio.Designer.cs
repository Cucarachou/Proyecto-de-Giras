namespace capaPresentacion
{
    partial class frmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuGiras = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSolicitar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAprobar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistroSoli = new System.Windows.Forms.ToolStripMenuItem();
            this.finalizarGira = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMantFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.centrosDeFormaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirCentroDeFormaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarCentroDeFormaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeCentrosDeFormaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGiras,
            this.mnuFuncionarios,
            this.centrosDeFormaciónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuGiras
            // 
            this.mnuGiras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSolicitar,
            this.mnuAprobar,
            this.mnuRegistroSoli,
            this.finalizarGira});
            this.mnuGiras.Name = "mnuGiras";
            this.mnuGiras.Size = new System.Drawing.Size(45, 20);
            this.mnuGiras.Text = "Giras";
            // 
            // mnuSolicitar
            // 
            this.mnuSolicitar.Name = "mnuSolicitar";
            this.mnuSolicitar.Size = new System.Drawing.Size(194, 22);
            this.mnuSolicitar.Text = "Solicitar gira..";
            this.mnuSolicitar.Click += new System.EventHandler(this.mnuSolicitar_Click);
            // 
            // mnuAprobar
            // 
            this.mnuAprobar.Name = "mnuAprobar";
            this.mnuAprobar.Size = new System.Drawing.Size(194, 22);
            this.mnuAprobar.Text = "Aprobar/denegar gira..";
            this.mnuAprobar.Click += new System.EventHandler(this.mnuAprobar_Click);
            // 
            // mnuRegistroSoli
            // 
            this.mnuRegistroSoli.Name = "mnuRegistroSoli";
            this.mnuRegistroSoli.Size = new System.Drawing.Size(194, 22);
            this.mnuRegistroSoli.Text = "Registro de solicitudes";
            // 
            // finalizarGira
            // 
            this.finalizarGira.Name = "finalizarGira";
            this.finalizarGira.Size = new System.Drawing.Size(194, 22);
            this.finalizarGira.Text = "Finalizar gira..";
            this.finalizarGira.Click += new System.EventHandler(this.finalizarGira_Click);
            // 
            // mnuFuncionarios
            // 
            this.mnuFuncionarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMantFuncionarios});
            this.mnuFuncionarios.Name = "mnuFuncionarios";
            this.mnuFuncionarios.Size = new System.Drawing.Size(87, 20);
            this.mnuFuncionarios.Text = "Funcionarios";
            // 
            // mnuMantFuncionarios
            // 
            this.mnuMantFuncionarios.Name = "mnuMantFuncionarios";
            this.mnuMantFuncionarios.Size = new System.Drawing.Size(243, 22);
            this.mnuMantFuncionarios.Text = "Mantenimiento de Funcionarios";
            this.mnuMantFuncionarios.Click += new System.EventHandler(this.mnuMantFuncionarios_Click);
            // 
            // centrosDeFormaciónToolStripMenuItem
            // 
            this.centrosDeFormaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirCentroDeFormaciónToolStripMenuItem,
            this.modificarCentroDeFormaciónToolStripMenuItem,
            this.registroDeCentrosDeFormaciónToolStripMenuItem});
            this.centrosDeFormaciónToolStripMenuItem.Name = "centrosDeFormaciónToolStripMenuItem";
            this.centrosDeFormaciónToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.centrosDeFormaciónToolStripMenuItem.Text = "Centros de Formación";
            // 
            // añadirCentroDeFormaciónToolStripMenuItem
            // 
            this.añadirCentroDeFormaciónToolStripMenuItem.Name = "añadirCentroDeFormaciónToolStripMenuItem";
            this.añadirCentroDeFormaciónToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.añadirCentroDeFormaciónToolStripMenuItem.Text = "Añadir centro de formación..";
            // 
            // modificarCentroDeFormaciónToolStripMenuItem
            // 
            this.modificarCentroDeFormaciónToolStripMenuItem.Name = "modificarCentroDeFormaciónToolStripMenuItem";
            this.modificarCentroDeFormaciónToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.modificarCentroDeFormaciónToolStripMenuItem.Text = "Modificar centro de formación..";
            // 
            // registroDeCentrosDeFormaciónToolStripMenuItem
            // 
            this.registroDeCentrosDeFormaciónToolStripMenuItem.Name = "registroDeCentrosDeFormaciónToolStripMenuItem";
            this.registroDeCentrosDeFormaciónToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.registroDeCentrosDeFormaciónToolStripMenuItem.Text = "Registro de centros de formación";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.frmInicio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuGiras;
        private System.Windows.Forms.ToolStripMenuItem mnuSolicitar;
        private System.Windows.Forms.ToolStripMenuItem mnuAprobar;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistroSoli;
        private System.Windows.Forms.ToolStripMenuItem finalizarGira;
        private System.Windows.Forms.ToolStripMenuItem mnuFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem mnuMantFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem centrosDeFormaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirCentroDeFormaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarCentroDeFormaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeCentrosDeFormaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}

