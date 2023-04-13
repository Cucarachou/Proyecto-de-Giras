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

        //la siguiente variable almacena la id del centro seleccionado para posteriormente pasarla al formulario que mandó a llamar a BusquedaCentro.
        public int idCentro;

        //el siguiente evento pasa el id del centro seleccionado al formulario que abrió este.
        public EventHandler AceptarCentro;
        public frmBusquedaCentro()
        {
            InitializeComponent();
        }

        //función que asigna el valor inicial al combo box de tipo.
        private void frmBusquedaCentro_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;
        }

        //función que según el índice del combo box seleccionado cambia un label para que le indique al usuario que información digitar para buscar el centro.
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

        //la siguiente función arma una condición según el indice seleccionado en el combo box y manda a llamar a la función de cargar centros para que se encargue del resto.
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

        //la siguiente función llama a la lógica de centro de formación para obtener una lista coincidente con la condición y asignarla al datagrid.
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

        //la siguiente función da valor a la variable global de idcentro según la fila seleccionada en el datagrid y la manda al formulario que abrió este.
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

        //la siguiente función se encarga de mostrar la información del centro de formación seleccionado según el valor del combo box. Esto se realiza posterior a una búsqueda, además, asigna a la variable idcentro la id de la fila seleccionada.
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

        //evento que se dispara al dar doble click al datagrid y hace lo mismo que el botón aceptar.
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

        //asigna una lista vacia al datagrid para limpiarlo.
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            List<entidadCentroFormacion> listaVacia = new List<entidadCentroFormacion>();
            dgvLista.DataSource = listaVacia;
            txtInfo.Text = string.Empty;
        }

        //en caso de no seleccionar nada, manda -1 como resultado al formulario que abrió este.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            idCentro = -1;

            AceptarCentro(idCentro, null);
            Close();
        }

        //boton aceptar, llama a la función seleccionarcentro
        private void btnAceptar_Click(object sender, EventArgs e)
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
    }
}
