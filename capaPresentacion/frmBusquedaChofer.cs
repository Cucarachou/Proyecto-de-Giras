using capaEntidades;
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
    public partial class frmBusquedaChofer : Form
    {

        int banderaIdentificacion = 0;
        string identificacionChofer;
        string fechaInicio, fechaFin;
        public EventHandler AceptarChofer;
        private string licenciaVehiculo;
        private string justificacionExtemporanea;
        //las siguientes propiedades son valores que se obtienen al abrir este formulario desde el principal de solicitud gira,
        //el de licencia de vehiculo es opcional, pues se da el valor solo si el usuario ha seleccionado un automovil antes
        public string FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public string FechaFin { get => fechaFin; set => fechaFin = value; }
        public string LicenciaVehiculo { get => licenciaVehiculo; set => licenciaVehiculo = value; }

        public frmBusquedaChofer()
        {
            InitializeComponent();
        }

        private void frmBusquedaChofer_Load(object sender, EventArgs e)
        {
            txtInicio.Text = fechaInicio;
            txtFinal.Text = fechaFin;
            cboTipo.SelectedIndex = 0;
            justificacionExtemporanea = string.Empty;
        }

        private void Limpiar()
        {
            cboTipo.SelectedIndex = 0;
            txtInfo.Text = string.Empty;
            grdLista.ClearSelection();

        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtInfo.Text = string.Empty;

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

        private void CargarChoferes(string condicion = "")
        {
            logicaFuncionario logica = new logicaFuncionario(Configuracion.getConnectiongString);
            List<entidadChofer> lista;

            try
            {
                lista = logica.ListarChoferes(condicion);
                grdLista.DataSource = lista;

            }
            catch (Exception ex)
            {

                throw ex;
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
                        condicion = $"CONCAT(NOMBRE, ' ', APELLIDO_UNO, ' ', APELLIDO_DOS) LIKE '%{txtInfo.Text}%' AND ACTIVO = 0 AND CHOFER = 1";
                    }
                    else
                    {
                        condicion = $"IDENTIFICACION LIKE '%{txtInfo.Text}%' AND ACTIVO = 0 AND CHOFER = 1";
                    }
                    CargarChoferes(condicion);
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

        private void SeleccionarChofer()
        {
            try
            {
                if (grdLista.SelectedRows.Count > 0 || !string.IsNullOrEmpty(identificacionChofer))
                {
                    identificacionChofer = grdLista.SelectedRows[0].Cells[1].Value.ToString();

                    if (!string.IsNullOrEmpty(licenciaVehiculo))
                    {
                        if (VerificarLicencia(identificacionChofer))
                        {
                            AceptarChofer(identificacionChofer, null);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Ha seleccionado un vehículo para la gira antes de seleccionar el chofer, por lo que el chofer no posee la licencia necesaria para manejar ese vehículo.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {

                        AceptarChofer(identificacionChofer, null);
                        Close();
                    }

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

        //la siguiente función se usará en caso de que el usuario haya seleccionado un vehículo antes que al chofer, y verifica que
        //el chofer elegido tenga la licencia correspondiente para manejar el vehículo elegido.

        private bool VerificarLicencia(string identificacion)
        {
            logicaLicencia logica = new logicaLicencia(Configuracion.getConnectiongString);
            List<entidadLicencia> licencias;

            licencias = logica.ListarLicencias($"IDENTIFICACION = '{identificacion}'");

            for (int i = 0; i < licencias.Count; i++)
            {
                if (licenciaVehiculo == "A2")
                {
                    if (licencias[i].TipoLicencia == "A2" || licencias[i].TipoLicencia == "A3" || licencias[i].TipoLicencia == "E1" || licencias[i].TipoLicencia == "E1=2")
                    {
                        return true;
                    }
                }
                else if (licenciaVehiculo == "A3")
                {
                    if (licencias[i].TipoLicencia == "A3" || licencias[i].TipoLicencia == "E1" || licencias[i].TipoLicencia == "E2")
                    {
                        return true;
                    }
                }
                else if (licenciaVehiculo == "B1")
                {
                    if (licencias[i].TipoLicencia == "B1" || licencias[i].TipoLicencia == "B2" || licencias[i].TipoLicencia == "B3" || licencias[i].TipoLicencia == "B4" || licencias[i].TipoLicencia == "E1" || licencias[i].TipoLicencia == "E2")
                    {
                        return true;
                    }
                }
                else if (licenciaVehiculo == "B2")
                {
                    if (licencias[i].TipoLicencia == "B2" || licencias[i].TipoLicencia == "B3" || licencias[i].TipoLicencia == "B4" || licencias[i].TipoLicencia == "E1" || licencias[i].TipoLicencia == "E2")
                    {
                        return true;
                    }
                }
                else if (licenciaVehiculo == "B3")
                {
                    if (licencias[i].TipoLicencia == "B3" || licencias[i].TipoLicencia == "B4" || licencias[i].TipoLicencia == "E1" || licencias[i].TipoLicencia == "E2")
                    {
                        return true;
                    }
                }
                else if (licenciaVehiculo == "B4")
                {
                    if (licencias[i].TipoLicencia == "B4" || licencias[i].TipoLicencia == "E1" || licencias[i].TipoLicencia == "E2")
                    {
                        return true;
                    }
                }
                else if (licenciaVehiculo == "C1")
                {
                    if (licencias[i].TipoLicencia == "C1")
                    {
                        return true;
                    }
                }
                else if (licenciaVehiculo == "C2")
                {
                    if (licencias[i].TipoLicencia == "C2")
                    {
                        return true;
                    }
                }
                else if (licenciaVehiculo == "D1")
                {
                    if (licencias[i].TipoLicencia == "D1" || licencias[i].TipoLicencia == "E2")
                    {
                        return true;
                    }
                }
                else if (licenciaVehiculo == "D2")
                {
                    if (licencias[i].TipoLicencia == "D2" || licencias[i].TipoLicencia == "E2")
                    {
                        return true;
                    }
                }
                else if (licenciaVehiculo == "D3")
                {
                    if (licencias[i].TipoLicencia == "D3" || licencias[i].TipoLicencia == "E2")
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void grdLista_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SeleccionarChofer();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                SeleccionarChofer();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            identificacionChofer = "-1";

            AceptarChofer(identificacionChofer, null);
            Close();
        }

        private void btnLicencias_Click(object sender, EventArgs e)
        {
            string mensaje;
            try
            {

                if (grdLista.SelectedRows.Count > 0)
                {
                    mensaje = MensajeLicencias(grdLista.SelectedRows[0].Cells[1].Value.ToString());

                    MessageBox.Show(mensaje, "Consulta de Licencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("No hay ningún chófer seleccionado.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        //la siguiente función crea un mensaje concatenado con todas las licencias que posee un chofer, esto para que el usuario
        //pueda consultarlo al seleccionarlo.
        private string MensajeLicencias(string id)
        {
            List<entidadLicencia> licencias = new List<entidadLicencia>();
            logicaLicencia logica = new logicaLicencia(Configuracion.getConnectiongString);
            string mensaje = "El chófer seleccionado posee las siguientes licencias: ";

            licencias = logica.ListarLicencias($"IDENTIFICACION = '{id}'");

            for (int i = 0; i < licencias.Count; i++)
            {
               mensaje = $"{mensaje} {licencias[i].TipoLicencia}";

                if (i + 1 < licencias.Count)
                {
                    mensaje = mensaje + ", ";
                }
                else
                {
                    mensaje = mensaje + ". ";
                }
            }

            return mensaje;
        }

        private void grdLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cboTipo.SelectedIndex == 0)
            {
                txtInfo.Text = grdLista.SelectedRows[0].Cells[1].Value.ToString();
            }
            else
            {
                txtInfo.Text = grdLista.SelectedRows[0].Cells[9].Value.ToString();
            }

            identificacionChofer = grdLista.SelectedRows[0].Cells[1].Value.ToString();
        }
    }
}
