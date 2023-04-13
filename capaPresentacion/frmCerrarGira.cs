using capaEntidades;
using capaLógica;
using capaLogica;
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
    public partial class frmCerrarGira : Form
    {
        public frmCerrarGira()
        {
            InitializeComponent();
        }

        //el siguiente evento permite al usuario seleccionar que tipo de información buscará la gira por cerrar. Solo aparecerán aquellas giras aprobadas.
        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == 0)
            {
                txtInfo.Text = "APROBADA";
                txtInfo.Enabled = false;
            }
            else
            {
                txtInfo.Text = string.Empty;
                txtInfo.Enabled = true;
            }
        }

        //la siguiente función busca la gira según el índice seleccionado en el combo box. Además, verifica que la gira a buscar ya haya pasado (osea, que la fecha final sea mayor o igual a la fecha actual) y ya esté aprobada. Ademas desactiva los controles de incidencias en caso de que el usuario haga una nueva búsuqeda y evitar errores.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion;
            string fechaActual = DateTime.Now.ToString("yyyy/MM/dd");
            try
            {

                if (!string.IsNullOrEmpty(txtInfo.Text))
                {

                    if (cboTipo.SelectedIndex == 0)
                    {

                        condicion = $"ESTADO = '{txtInfo.Text}' AND DIA_FINAL <= '{fechaActual}'";
                    }
                    else if (cboTipo.SelectedIndex == 1)
                    {
                        condicion = $"SOLICITANTE LIKE '%{txtInfo.Text}%' AND ESTADO = 'APROBADA' AND DIA_FINAL <= '{fechaActual}'";
                    }
                    else if (cboTipo.SelectedIndex == 2)
                    {
                        condicion = $"CHOFER LIKE '%{txtInfo.Text}%' AND ESTADO = 'APROBADA' AND DIA_FINAL <= '{fechaActual}'";
                    }
                    else
                    {
                        condicion = $"ID_GIRA = '{txtInfo.Text}' AND ESTADO = 'APROBADA' AND DIA_FINAL <= '{fechaActual}'";
                    }

                    txtIdGira.Text = string.Empty;
                    txtFuncionario.Text = string.Empty;
                    txtFuncionario.Tag = string.Empty;
                    btnBuscarFuncionario.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnLimpiar.Enabled = false;
                    CargarSolicitudes(condicion);
                }
                else
                {
                    MessageBox.Show("No se ha digitado la información requerida para buscar la solicitud de gira.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //función que carga las solicitudes con la condición y las carga en el datagrid.
        private void CargarSolicitudes(string condicion = "")
        {
            logicaSolicitudGira logica = new logicaSolicitudGira(Configuracion.getConnectiongString);
            List<entidadSolicitudGira> lista;

            try
            {
                lista = logica.ListarSolicitudes(condicion);
                dgvSolicitudes.DataSource = lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        //inicializa el combo box.
        private void frmCerrarGira_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;
        }

        //el siguiente evento verifica que el usuario haya seleccionado una gira y se ayuda de una función de la lógica para actualizarla y cambiar el estado a cerrada. Además, una vez se cerró activa los controles de incidencias para que el usuario pueda añadirlos, y guarda el id de la gira seleccionada en el txtIdGira, además de limpiar el datagrid.
        private void btnCierre_Click(object sender, EventArgs e)
        {
            logicaSolicitudGira logicaSolicitud = new logicaSolicitudGira(Configuracion.getConnectiongString);
            int idGira;
            List<entidadSolicitudGira> listaVacia = new List<entidadSolicitudGira>();
            try
            {
                if (dgvSolicitudes.SelectedRows.Count > 0)
                {

                    idGira = Convert.ToInt32(dgvSolicitudes.SelectedRows[0].Cells[7].Value);

                        if (logicaSolicitud.CerrarSolicitud($"ID_GIRA = {idGira}"))
                        {
                            MessageBox.Show("Gira cerrada satisfactoriamente.", "Solicitud aprobada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtIdGira.Text = idGira.ToString();
                            btnBuscarFuncionario.Enabled = true;
                            btnAgregar.Enabled = true;
                            btnLimpiar.Enabled = true;
                            dgvSolicitudes.DataSource = listaVacia;
                        }
                        else
                        {
                            MessageBox.Show("La gira no pudo ser rechazada.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                else
                {
                    MessageBox.Show("Para cerrar una gira debe seleccionarla primero.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //la siguiente función busca a un funcionario aprovechando el evento de aceptar solicitante pues sirve en este caso. Invoca al formulario de busqueda de funcionario.
        private void btnBuscarFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaFuncionario form = new frmBusquedaFuncionario();
                form.TipoBusqueda = 1;
                form.AceptarSolicitante += new EventHandler(AceptarSolicitante);
                form.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //la siguiente función busca al funcionario tráído desde el formulario de busqueda de funcionario en caso de que no exista y evitar errores.
        private void AceptarSolicitante(object idSolicitante, EventArgs e)
        {
            try
            {
                string id = idSolicitante.ToString();

                if (id != "-1")
                {
                    BuscarSolicitante(id);
                }
                else
                {
                    MessageBox.Show("No fue seleccionado ningún solicitante.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //la siguiente función verifica al solicitante seleccionado que exista para evitar errores y lo guarda en el texto de funcionario así como en el tag guarda la identificación.
        private void BuscarSolicitante(string idSolicitante)
        {
            entidadSolicitante solicitante;
            logicaFuncionario logica = new logicaFuncionario(Configuracion.getConnectiongString);
            logica.CadenaConexion = Configuracion.getConnectiongString;
            string condicion = $"IDENTIFICACION = '{idSolicitante}'";

            try
            {

                solicitante = logica.ObtenerSolicitante(condicion);

                if (solicitante.Identificacion == idSolicitante)
                {
                    txtFuncionario.Text = solicitante.NombreApellido;
                    txtFuncionario.Tag = solicitante.Identificacion;
                }
                else
                {
                    MessageBox.Show("No se ha podido cargar el funcionario. Debe haber un error al seleccionarlo.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //el siguiente botón permite agregar una incidencia. No permite hacerlo si no se ha seleccionado un funcionario responsable, e inserta la incidencia con una función invocada desde la logica de solicitud.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            logicaSolicitudGira logicaSolicitud = new logicaSolicitudGira(Configuracion.getConnectiongString);
            string incidencia, idFuncionario;
            int resultado = -1;
            try
            {
                if (!string.IsNullOrEmpty(txtFuncionario.Text))
                {

                    idFuncionario = txtFuncionario.Tag.ToString();

                    if (!string.IsNullOrEmpty(rtbDetalle.Text))
                    {
                        incidencia = rtbDetalle.Text;

                        resultado = logicaSolicitud.InsertarIncidencia(incidencia, idFuncionario, Convert.ToInt32(txtIdGira.Text));

                        if (resultado > -1)
                        {
                            MessageBox.Show($"La incidencia fue agregada satisfactoriamente. Puede consultarla con la identificación {resultado}.", "Incidencia insertada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No fue posible añadir la incidencia, debe haber un error.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor escriba la incidencia en el cuadro de texto antes de agregarla.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un funcionario antes de agregar la incidencia, esto pues, la incidencia irá a nombre del funcionario seleccionado.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        //el siguiente evento limpia la justificacion.
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
 
            rtbDetalle.Text = string.Empty;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
