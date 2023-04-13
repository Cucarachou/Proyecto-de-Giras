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

        //la siguiente variable indica que tipo de busqueda está realizando el usuario, si por nombre o por identificacion del chofer.
        int banderaIdentificacion = 0;

        //variable global que guarda la identificacion del chofer seleccionado.
        string identificacionChofer;

        //variables globales que traen las fechas seleccionadas por el usuario desde la solicitud para poder verificar que el chofer está disponible.
        string fechaInicio, fechaFin;
        public EventHandler AceptarChofer;
        //variable global que guarda la licencia del vehiculo en caso de que haya sido seleccionado de primero que el chofer.
        private string licenciaVehiculo;

        //las siguientes propiedades son valores que se obtienen al abrir este formulario desde el principal de solicitud gira,
        //el de licencia de vehiculo es opcional, pues se da el valor solo si el usuario ha seleccionado un automovil antes
        public string FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public string FechaFin { get => fechaFin; set => fechaFin = value; }
        public string LicenciaVehiculo { get => licenciaVehiculo; set => licenciaVehiculo = value; }

        public frmBusquedaChofer()
        {
            InitializeComponent();
        }

        //asigna las fechas seleccionadas por el usuario desde la solicitud de gira e inicializa el combo box.
        private void frmBusquedaChofer_Load(object sender, EventArgs e)
        {
            txtInicio.Text = fechaInicio;
            txtFinal.Text = fechaFin;
            cboTipo.SelectedIndex = 0;
        }

        //limpia el datagrid asignando una lista vacia y los demas campos ademas de reiniciar el combo box.
        private void Limpiar()
        {
            List<entidadChofer> listaVacia = new List<entidadChofer>();
            cboTipo.SelectedIndex = 0;
            txtInfo.Text = string.Empty;
            grdLista.DataSource = listaVacia;

        }

        //el siguiente evento cambia la información que digitará el usuario para buscar chofer según el indice seleccionado en el combo box.
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

        //la siguiente funcion impide que el usuario escriba numeros o letras dependiendo si esta buscando por identificacion o por nombre y apellidos
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

        //funcion que carga la lista de choferes y las asigna al datagrid mediante una lista.
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

        //la siguiente verificación arma la condición para buscar al chofer según el indice seleccionado en el combo box. Nótese que la condición es compleja pues evita traer aquellos choferes que no están disponibles entre las fechas de la solicitud, así como los funcionarios que no son choferes o no están activos.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;

            try
            {

                if (!string.IsNullOrEmpty(txtInfo.Text))
                {
                    if (cboTipo.SelectedIndex == 1)
                    {
                        condicion = $"CONCAT(NOMBRE, ' ', APELLIDO_UNO, ' ', APELLIDO_DOS) LIKE '%{txtInfo.Text}%' AND ACTIVO = 1 AND CHOFER = 1 AND IDENTIFICACION NOT IN (SELECT CHOFER FROM SOLICITUDES_GIRAS WHERE  ESTADO='APROBADA' AND  (('{fechaInicio}' BETWEEN DIA_INICIO AND DIA_FINAL) OR ('{fechaFin}' BETWEEN DIA_INICIO AND DIA_FINAL) OR (DIA_INICIO BETWEEN '{fechaInicio}' AND '{fechaFin}') OR (DIA_FINAL BETWEEN '{fechaInicio}' AND '{fechaFin}'))) AND IDENTIFICACION NOT IN (SELECT IDENTIFICACION FROM ACOMPANIANTES INNER JOIN SOLICITUDES_GIRAS ON ACOMPANIANTES.ID_GIRA = SOLICITUDES_GIRAS.ID_GIRA WHERE ESTADO='APROBADA' AND  (('{fechaFin}' BETWEEN DIA_INICIO AND DIA_FINAL) OR ('{fechaFin}' BETWEEN DIA_INICIO AND DIA_FINAL) OR (DIA_INICIO BETWEEN '{fechaInicio}' AND '{fechaFin}') OR  (DIA_FINAL BETWEEN '{fechaInicio}' AND '{fechaFin}')))";
                    }
                    else
                    {
                        condicion = $"IDENTIFICACION LIKE '%{txtInfo.Text}%' AND ACTIVO = 1 AND CHOFER = 1 AND IDENTIFICACION NOT IN (SELECT CHOFER FROM SOLICITUDES_GIRAS WHERE ESTADO='APROBADA' AND (('{fechaInicio}' BETWEEN DIA_INICIO AND DIA_FINAL) OR ('{fechaFin}' BETWEEN DIA_INICIO AND DIA_FINAL) OR (DIA_INICIO BETWEEN '{fechaInicio}' AND '{fechaFin}') OR (DIA_FINAL BETWEEN '{fechaInicio}' AND '{fechaFin}'))) AND IDENTIFICACION NOT IN (SELECT IDENTIFICACION FROM ACOMPANIANTES INNER JOIN SOLICITUDES_GIRAS ON ACOMPANIANTES.ID_GIRA = SOLICITUDES_GIRAS.ID_GIRA WHERE ESTADO='APROBADA' AND (('{fechaFin}' BETWEEN DIA_INICIO AND DIA_FINAL) OR ('{fechaFin}' BETWEEN DIA_INICIO AND DIA_FINAL) OR (DIA_INICIO BETWEEN '{fechaInicio}' AND '{fechaFin}') OR  (DIA_FINAL BETWEEN '{fechaInicio}' AND '{fechaFin}')))";
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

        //la siguiente función asigna a la variable global de identificacion la identificacion del chofer según la fila seleccionada en el datagrid. Además, en caso de que el usuario haya seleccionado primero un vehículo utiliza una función para verificar que dicho chofer posee la licencia necesaria para manejar ese vehículo.
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

        //evento al dar doble click al datagrid, hace lo mismo que el botón aceptar.
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

        //envia -1 en caso de que el usuario seleccione salir.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            identificacionChofer = "-1";

            AceptarChofer(identificacionChofer, null);
            Close();
        }

        //el siguiente evento muestra al usuario las licencias que posee el chofer seleccionado mediante una función que crea un string con las licencias que posee el chofer.
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

    
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        private void btnInformacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En caso de que no encuentre el chofer deseado puede ser por: el funcionario no posee permisos para ser chofer, o el funcionario no se encuentra disponible entre las fechas elegidas para la gira o el funcionario no está activo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //evento que muestra la información del chofer seleccionado una vez en el datagrid. Esto lo muestra en la info, por lo que depende de la opción seleccionada en el combo box.
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
