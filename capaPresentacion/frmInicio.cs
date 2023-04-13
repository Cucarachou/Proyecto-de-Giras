using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuSolicitar_Click(object sender, EventArgs e)
        {
            frmSolicitudGira frmSolicitudGira = new frmSolicitudGira();
            frmSolicitudGira.Show();
        }

        private void mnuAprobar_Click(object sender, EventArgs e)
        {
            frmAprobarGira frmAprobarGira = new frmAprobarGira();
            frmAprobarGira.Show();
        }

        private void finalizarGira_Click(object sender, EventArgs e)
        {
            frmCerrarGira frmCerrarGira = new frmCerrarGira();
            frmCerrarGira.Show();
        }

        private void mnuMantFuncionarios_Click(object sender, EventArgs e)
        {
            frmMantenimientoFuncionarios frmMantenimiento = new frmMantenimientoFuncionarios();
            frmMantenimiento.Show();
        }
    }
}
