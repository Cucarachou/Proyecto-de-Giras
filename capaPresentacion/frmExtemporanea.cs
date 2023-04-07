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
    public partial class frmExtemporanea : Form
    {
        public EventHandler AceptarJustificación;
        private string justificacion;

        public string Justificacion { get => justificacion; set => justificacion = value; }

        public frmExtemporanea()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rtbJustificacion.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtbJustificacion.Text))
            {

                frmExtemporanea frm = (frmExtemporanea)this.FindForm();

                frm.Justificacion = rtbJustificacion.Text;
                frm.DialogResult = DialogResult.OK;
                frm.Close();
            }
            else
            {
                MessageBox.Show("Por favor digite la justificación antes de pulsar el bóton de aceptar.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmExtemporanea frm = (frmExtemporanea)this.FindForm();

            frm.Justificacion = rtbJustificacion.Text;
            frm.DialogResult = DialogResult.Cancel;
            frm.Close();
        }
    }
}
