using capaLogica;
using capaLógica;
using logicaSolicitante;
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
    public partial class frmBusquedaCentro : Form
    {

        public int idCentro;
        public EventHandler AceptarCentro;
        public frmBusquedaCentro()
        {
            InitializeComponent();
        }

        private void frmBusquedaCentro_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == 0)
            {
                lblInfo.Text = "Nombre:";
            }
            else
            {
                lblInfo.Text = "Regional:";
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
                        condicion = $"REGIONAL LIKE '%{txtInfo.Text}%'";
                    }
                    else
                    {
                        condicion = $"NOMBRE LIKE '%{txtInfo.Text}%'";
                    }
                    CargarCentros(condicion);
                }
                else
                {
                    MessageBox.Show("No se ha digitado la información requerida para buscar el centro de formación.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCentros(string condicion = "")
        {
            logicaCentroFormacion logica = new logicaCentroFormacion(Configuracion.getConnectiongString);
            List<entidadCentroFormacion> lista;

            try
            {
                lista = logica.ListarCentros(condicion);
                dgvLista.DataSource = lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        //boton aceptar:
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SeleccionarCentro();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarCentro()
        {
            try
            {
                if (dgvLista.SelectedRows.Count > 0)
                {
                    idCentro = Convert.ToInt32(dgvLista.SelectedRows[0].Cells[0].Value);


                    AceptarCentro(idCentro, null);
                    Close();

                }
                else
                {
                    MessageBox.Show("No hay ningún centro de formación seleccionado.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cboTipo.SelectedIndex == 0)
            {
                txtInfo.Text = dgvLista.SelectedRows[0].Cells[1].Value.ToString();
            }
            else
            {
                txtInfo.Text = dgvLista.SelectedRows[0].Cells[2].Value.ToString();
            }

            idCentro = Convert.ToInt32(dgvLista.SelectedRows[0].Cells[0].Value);
        }

        private void dgvLista_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SeleccionarCentro();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            List<entidadCentroFormacion> listaVacia = new List<entidadCentroFormacion>();
            dgvLista.DataSource = listaVacia;
            txtInfo.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            idCentro = -1;

            AceptarCentro(idCentro, null);
            Close();
        }
    }
}
