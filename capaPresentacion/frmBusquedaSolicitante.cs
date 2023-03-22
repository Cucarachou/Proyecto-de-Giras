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
    public partial class frmBusquedaSolicitante : Form
    {
        public frmBusquedaSolicitante()
        {
            InitializeComponent();
        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmBusquedaSolicitante_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == 0)
            {
                lblTipo.Text = "Identificación:";
            }
            else
            {
                lblTipo.Text = "Nombre / Apellidos:";
            }
        }
    }
}
