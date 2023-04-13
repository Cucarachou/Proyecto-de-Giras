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

        //la siguiente variable global guarda la justificacion escrita.
        private string justificacion;

        public string Justificacion { get => justificacion; set => justificacion = value; }

        public frmExtemporanea()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            rtbJustificacion.Clear();
        }

        //envia la justificacion de extemporanea al formulario de solicitudes que lo abrió.
        private void btnAceptar_Click(object sender, EventArgs e)
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

        //en caso de cancelar la solicitud en el otro formulario se procede a limpiar las fechas pues el usuario no digitó una justificación para la fecha extemporanea.
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmExtemporanea frm = (frmExtemporanea)this.FindForm();

            frm.Justificacion = rtbJustificacion.Text;
            frm.DialogResult = DialogResult.Cancel;
            frm.Close();
        }
    }
}
