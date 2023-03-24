using capaEntidades;
using capaLogica;
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

        //la siguiente variable global funciona de bandera para evitar que el usuario escriba números o letras según la opción
        //que eligió en el combo para buscar funcionario

        int banderaIdentificacion;
        public frmBusquedaSolicitante()
        {
            InitializeComponent();
            banderaIdentificacion = 0;
        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmBusquedaSolicitante_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;

            try
            {
                CargarSolicitantes("");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == 0)
            {
                lblTipo.Text = "Identificación:";

                banderaIdentificacion = 0;
            }
            else
            {
                lblTipo.Text = "Nombre / Apellidos:";

                banderaIdentificacion = 1;
            }
        }

        private void txtInfo_KeyPress(object sender, KeyPressEventArgs e)
       {

            if (Char.IsLetter(e.KeyChar) && banderaIdentificacion == 0) 
            {
                e.Handled = true;
            }
            else if (Char.IsDigit(e.KeyChar) && banderaIdentificacion == 1)
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string condicion = string.Empty;

            try
            {

                if (!string.IsNullOrEmpty(txtInfo.Text))
                {
                    if (cboTipo.SelectedIndex == 1)
                    {
                        condicion = $"CONCAT(NOMBRE, ' ', APELLIDO_UNO, ' ', APELLIDO_DOS) LIKE '%{txtInfo.Text}%' AND ACTIVO = 0 AND APROBADOR = 1";
                    }
                    else
                    {
                        condicion = $"IDENTIFICACION LIKE '%{txtInfo.Text}%' AND ACTIVO = 0 AND APROBADOR = 1";
                    }
                    CargarSolicitantes(condicion);
                }
                else
                {
                    MessageBox.Show("No se ha digitado la información requerida para buscar al funcionario.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarSolicitantes(string condicion = "")
        {
            logicaSolicitante logica = new logicaSolicitante(Configuracion.getConnectiongString);
            List<entidadSolicitante> lista;

            try
            {
                lista = logica.ListarSolicitantes(condicion);
                grdSolicitante.DataSource = lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
