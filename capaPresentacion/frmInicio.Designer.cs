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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuGiras = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSolicitar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAprobar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistroSoli = new System.Windows.Forms.ToolStripMenuItem();
            this.finalizarGiraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVehiculos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgVehiculo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgMante = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgMarch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgPoli = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModVeh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModMant = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModMarch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModPoli = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuRegVeh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegMant = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegMarch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegPoli = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.talleresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirTallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirMantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirRevisiónTécnicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarRevisiónTécnicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarTallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarMantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeTalleresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeMantenimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeRevisionesTécnicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnuVehiculos,
            this.mnuFuncionarios,
            this.talleresToolStripMenuItem,
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
            this.finalizarGiraToolStripMenuItem});
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
            // finalizarGiraToolStripMenuItem
            // 
            this.finalizarGiraToolStripMenuItem.Name = "finalizarGiraToolStripMenuItem";
            this.finalizarGiraToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.finalizarGiraToolStripMenuItem.Text = "Finalizar gira..";
            // 
            // mnuVehiculos
            // 
            this.mnuVehiculos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAgVehiculo,
            this.mnuAgMante,
            this.mnuAgMarch,
            this.mnuAgPoli,
            this.mnuModVeh,
            this.mnuModMant,
            this.mnuModMarch,
            this.mnuModPoli,
            this.MnuRegVeh,
            this.mnuRegMant,
            this.mnuRegMarch,
            this.mnuRegPoli});
            this.mnuVehiculos.Name = "mnuVehiculos";
            this.mnuVehiculos.Size = new System.Drawing.Size(69, 20);
            this.mnuVehiculos.Text = "Vehículos";
            // 
            // mnuAgVehiculo
            // 
            this.mnuAgVehiculo.Name = "mnuAgVehiculo";
            this.mnuAgVehiculo.Size = new System.Drawing.Size(223, 22);
            this.mnuAgVehiculo.Text = "Agregar nuevo vehículo..";
            // 
            // mnuAgMante
            // 
            this.mnuAgMante.Name = "mnuAgMante";
            this.mnuAgMante.Size = new System.Drawing.Size(223, 22);
            this.mnuAgMante.Text = "Añadir mantenimiento..";
            // 
            // mnuAgMarch
            // 
            this.mnuAgMarch.Name = "mnuAgMarch";
            this.mnuAgMarch.Size = new System.Drawing.Size(223, 22);
            this.mnuAgMarch.Text = "Añadir marchamo..";
            // 
            // mnuAgPoli
            // 
            this.mnuAgPoli.Name = "mnuAgPoli";
            this.mnuAgPoli.Size = new System.Drawing.Size(223, 22);
            this.mnuAgPoli.Text = "Añadir póliza..";
            // 
            // mnuModVeh
            // 
            this.mnuModVeh.Name = "mnuModVeh";
            this.mnuModVeh.Size = new System.Drawing.Size(223, 22);
            this.mnuModVeh.Text = "Modificar vehículo..";
            // 
            // mnuModMant
            // 
            this.mnuModMant.Name = "mnuModMant";
            this.mnuModMant.Size = new System.Drawing.Size(223, 22);
            this.mnuModMant.Text = "Modificar mantenimiento..";
            // 
            // mnuModMarch
            // 
            this.mnuModMarch.Name = "mnuModMarch";
            this.mnuModMarch.Size = new System.Drawing.Size(223, 22);
            this.mnuModMarch.Text = "Modificar marchamo..";
            // 
            // mnuModPoli
            // 
            this.mnuModPoli.Name = "mnuModPoli";
            this.mnuModPoli.Size = new System.Drawing.Size(223, 22);
            this.mnuModPoli.Text = "Modificar póliza..";
            // 
            // MnuRegVeh
            // 
            this.MnuRegVeh.Name = "MnuRegVeh";
            this.MnuRegVeh.Size = new System.Drawing.Size(223, 22);
            this.MnuRegVeh.Text = "Registro de vehículos";
            // 
            // mnuRegMant
            // 
            this.mnuRegMant.Name = "mnuRegMant";
            this.mnuRegMant.Size = new System.Drawing.Size(223, 22);
            this.mnuRegMant.Text = "Registro de mantenimientos";
            // 
            // mnuRegMarch
            // 
            this.mnuRegMarch.Name = "mnuRegMarch";
            this.mnuRegMarch.Size = new System.Drawing.Size(223, 22);
            this.mnuRegMarch.Text = "Registro de marchamos";
            // 
            // mnuRegPoli
            // 
            this.mnuRegPoli.Name = "mnuRegPoli";
            this.mnuRegPoli.Size = new System.Drawing.Size(223, 22);
            this.mnuRegPoli.Text = "Registro de pólizas";
            // 
            // mnuFuncionarios
            // 
            this.mnuFuncionarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAgFuncionario,
            this.mnuModFuncionario,
            this.mnuRegFuncionarios});
            this.mnuFuncionarios.Name = "mnuFuncionarios";
            this.mnuFuncionarios.Size = new System.Drawing.Size(87, 20);
            this.mnuFuncionarios.Text = "Funcionarios";
            // 
            // mnuAgFuncionario
            // 
            this.mnuAgFuncionario.Name = "mnuAgFuncionario";
            this.mnuAgFuncionario.Size = new System.Drawing.Size(202, 22);
            this.mnuAgFuncionario.Text = "Añadir funcionario..";
            // 
            // mnuModFuncionario
            // 
            this.mnuModFuncionario.Name = "mnuModFuncionario";
            this.mnuModFuncionario.Size = new System.Drawing.Size(202, 22);
            this.mnuModFuncionario.Text = "Modificar funcionario..";
            // 
            // mnuRegFuncionarios
            // 
            this.mnuRegFuncionarios.Name = "mnuRegFuncionarios";
            this.mnuRegFuncionarios.Size = new System.Drawing.Size(202, 22);
            this.mnuRegFuncionarios.Text = "Registro de funcionarios";
            // 
            // talleresToolStripMenuItem
            // 
            this.talleresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirTallerToolStripMenuItem,
            this.añadirMantenimientoToolStripMenuItem,
            this.añadirRevisiónTécnicaToolStripMenuItem,
            this.modificarRevisiónTécnicaToolStripMenuItem,
            this.modificarTallerToolStripMenuItem,
            this.modificarMantenimientoToolStripMenuItem,
            this.registroDeTalleresToolStripMenuItem,
            this.registroDeMantenimientosToolStripMenuItem,
            this.registroDeRevisionesTécnicasToolStripMenuItem});
            this.talleresToolStripMenuItem.Name = "talleresToolStripMenuItem";
            this.talleresToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.talleresToolStripMenuItem.Text = "Talleres";
            // 
            // añadirTallerToolStripMenuItem
            // 
            this.añadirTallerToolStripMenuItem.Name = "añadirTallerToolStripMenuItem";
            this.añadirTallerToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.añadirTallerToolStripMenuItem.Text = "Añadir taller..";
            // 
            // añadirMantenimientoToolStripMenuItem
            // 
            this.añadirMantenimientoToolStripMenuItem.Name = "añadirMantenimientoToolStripMenuItem";
            this.añadirMantenimientoToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.añadirMantenimientoToolStripMenuItem.Text = "Añadir mantenimiento..";
            // 
            // añadirRevisiónTécnicaToolStripMenuItem
            // 
            this.añadirRevisiónTécnicaToolStripMenuItem.Name = "añadirRevisiónTécnicaToolStripMenuItem";
            this.añadirRevisiónTécnicaToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.añadirRevisiónTécnicaToolStripMenuItem.Text = "Añadir revisión técnica..";
            // 
            // modificarRevisiónTécnicaToolStripMenuItem
            // 
            this.modificarRevisiónTécnicaToolStripMenuItem.Name = "modificarRevisiónTécnicaToolStripMenuItem";
            this.modificarRevisiónTécnicaToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.modificarRevisiónTécnicaToolStripMenuItem.Text = "Modificar revisión técnica..";
            // 
            // modificarTallerToolStripMenuItem
            // 
            this.modificarTallerToolStripMenuItem.Name = "modificarTallerToolStripMenuItem";
            this.modificarTallerToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.modificarTallerToolStripMenuItem.Text = "Modificar taller..";
            // 
            // modificarMantenimientoToolStripMenuItem
            // 
            this.modificarMantenimientoToolStripMenuItem.Name = "modificarMantenimientoToolStripMenuItem";
            this.modificarMantenimientoToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.modificarMantenimientoToolStripMenuItem.Text = "Modificar mantenimiento..";
            // 
            // registroDeTalleresToolStripMenuItem
            // 
            this.registroDeTalleresToolStripMenuItem.Name = "registroDeTalleresToolStripMenuItem";
            this.registroDeTalleresToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.registroDeTalleresToolStripMenuItem.Text = "Registro de talleres";
            // 
            // registroDeMantenimientosToolStripMenuItem
            // 
            this.registroDeMantenimientosToolStripMenuItem.Name = "registroDeMantenimientosToolStripMenuItem";
            this.registroDeMantenimientosToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.registroDeMantenimientosToolStripMenuItem.Text = "Registro de mantenimientos";
            // 
            // registroDeRevisionesTécnicasToolStripMenuItem
            // 
            this.registroDeRevisionesTécnicasToolStripMenuItem.Name = "registroDeRevisionesTécnicasToolStripMenuItem";
            this.registroDeRevisionesTécnicasToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.registroDeRevisionesTécnicasToolStripMenuItem.Text = "Registro de revisiones técnicas";
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
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
        private System.Windows.Forms.ToolStripMenuItem mnuVehiculos;
        private System.Windows.Forms.ToolStripMenuItem mnuAgVehiculo;
        private System.Windows.Forms.ToolStripMenuItem mnuModVeh;
        private System.Windows.Forms.ToolStripMenuItem MnuRegVeh;
        private System.Windows.Forms.ToolStripMenuItem mnuAgMante;
        private System.Windows.Forms.ToolStripMenuItem mnuRegMant;
        private System.Windows.Forms.ToolStripMenuItem mnuModMant;
        private System.Windows.Forms.ToolStripMenuItem mnuAgMarch;
        private System.Windows.Forms.ToolStripMenuItem mnuAgPoli;
        private System.Windows.Forms.ToolStripMenuItem mnuModMarch;
        private System.Windows.Forms.ToolStripMenuItem mnuModPoli;
        private System.Windows.Forms.ToolStripMenuItem mnuRegMarch;
        private System.Windows.Forms.ToolStripMenuItem mnuRegPoli;
        private System.Windows.Forms.ToolStripMenuItem finalizarGiraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem mnuAgFuncionario;
        private System.Windows.Forms.ToolStripMenuItem mnuModFuncionario;
        private System.Windows.Forms.ToolStripMenuItem mnuRegFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem talleresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirTallerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirMantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirRevisiónTécnicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarRevisiónTécnicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarTallerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarMantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeTalleresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeMantenimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeRevisionesTécnicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centrosDeFormaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirCentroDeFormaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarCentroDeFormaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeCentrosDeFormaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}

