using capaLogica;
using capaLógica;
using logicaSolicitante;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class frmBusquedaVehiculo : Form
    {

        //la siguiente variable global del formulario se obtendrá al abrirse solamente en caso de que el usuario haya añadido 
        //ya asistentes a la gira, esto para incluir el número de personas que irán a la gira como parámetro de búsqueda
        //del vehículo por su capacidad. En caso de que el usuario no haya añadido funcionarios de antemano, no se pasará
        //y se mantendrá en -1.

        private int cantidadAsistentes;

        //la siguiente variable global indica el tipo de búsqueda que va a realizar el usuario para encontrar el vehículo
        private int tipoBusqueda;
        //la siguiente variable global guarda la placa del vehículo
        private string placa;
        //
        private DateTime giraFechaInicio, giraFechaFinal;
        //
        public EventHandler AceptarVehiculo;
        public int CantidadAsistentes { get => cantidadAsistentes; set => cantidadAsistentes = value; }
        public DateTime GiraFechaInicio { get => giraFechaInicio; set => giraFechaInicio = value; }
        public DateTime GiraFechaFinal { get => giraFechaFinal; set => giraFechaFinal = value; }

        public frmBusquedaVehiculo(int _cantidadAsistentes)
        {
            InitializeComponent();
            nudCantidadF.Enabled = false;
            cantidadAsistentes = _cantidadAsistentes;
            if (cantidadAsistentes != -1)
            {
                cboTipo.SelectedIndex = 0;
                nudCantidadF.Value = cantidadAsistentes;
            }
            else
            {
                cboTipo.SelectedIndex = 1;
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == 0)
            {
                nudCantidadF.Enabled = true;
                txtInfo.Text = string.Empty;
                txtInfo.Enabled = false;
                tipoBusqueda = 0;
            }
            else if (cboTipo.SelectedIndex == 1)
            {
                nudCantidadF.Enabled = false;
                txtInfo.Text = string.Empty;
                txtInfo.Enabled = true;
                tipoBusqueda = 1;
            }
            else
            {
                tipoBusqueda = 2;
                nudCantidadF.Enabled = false;
                txtInfo.Enabled = true;
                txtInfo.Text = string.Empty;
            }
        }

        private void nudCantidadF_ValueChanged(object sender, EventArgs e)
        {
            if (cantidadAsistentes != -1)
            {
                if (nudCantidadF.Value < cantidadAsistentes)
                {
                    nudCantidadF.Value = cantidadAsistentes;
                    MessageBox.Show("Han sido agregados funcionarios antes de buscar un vehículo, por lo que no se puede seleccionar un número menor a la cantidad de funcionarios digitados.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;

            try
            {

                if (!string.IsNullOrEmpty(txtInfo.Text) || (cboTipo.SelectedIndex == 0))
                {
                    if (cboTipo.SelectedIndex == 0)
                    {
                        condicion = $"CAPACIDAD >= {nudCantidadF.Value} AND DISPONIBILIDAD = 1";
                    }
                    else if (cboTipo.SelectedIndex == 1)
                    {
                        condicion = $"ID_CENTRO = (SELECT 1 FROM CENTROS_DE_FORMACION WHERE NOMBRE LIKE '%{txtInfo.Text}%') AND DISPONIBILIDAD = 1";
                    }
                    else if (cboTipo.SelectedIndex == 2)
                    {
                        condicion = $"PLACA LIKE '%{txtInfo.Text}%' AND DISPONIBILIDAD = 1";
                    }
                    else
                    {
                        condicion = $"LICENCIA_REQUERIDA LIKE '%{txtInfo.Text}%' AND DISPONIBILIDAD = 1";
                    }
                    CargarVehiculos(condicion);
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

        private void CargarVehiculos(string condicion = "")
        {
            logicaVehiculo logica = new logicaVehiculo(Configuracion.getConnectiongString);
            List<entidadVehiculo> lista;

            try
            {
                lista = logica.ListarVehiculos(condicion);
                dgvVehiculos.DataSource = lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                SeleccionarVehiculo();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarVehiculo()
        {
            try
            {
                if (dgvVehiculos.SelectedRows.Count > 0 || !string.IsNullOrEmpty(placa))
                {
                    placa = dgvVehiculos.SelectedRows[0].Cells[0].Value.ToString();
                    AceptarVehiculo(placa, null);
                    Close();
                }
                else
                {
                    MessageBox.Show("No hay ningún solicitante seleccionado.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dgvVehiculos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SeleccionarVehiculo();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            placa = "-1";

            AceptarVehiculo(placa, null);
            Close();
        }
    }
}
