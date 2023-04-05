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
    public partial class frmBusquedaFuncionario : Form
    {

        //la siguiente variable global funciona de bandera para evitar que el usuario escriba números o letras según la opción
        //que eligió en el combo para buscar funcionario

        private int banderaIdentificacion;

        //la siguiente variable global indica que tipo de busqueda se está haciendo: si (1) de solicitante o (2) de funcionario.

        private int tipoBusqueda;

        //la siguiente variable global tipo string guarda la identificacion del solicitante para enviarla posteriormente
        //al formulario de solicitid de gura.
        private string identificacionSolicitante;

        //fechas de inicio y final de la gira, se utilizan para verificar que un funcionario sí está disponible 
        //en caso de búsqueda de funcionario (no solicitante)

        private DateTime fechaInicio, fechaFinal;
        //evento para pasar la información de un formulario a otro, en este caso de solicitante a la solicitud.
        public EventHandler AceptarSolicitante;
        public EventHandler AceptarFuncionario;

        public int TipoBusqueda { get => tipoBusqueda; set => tipoBusqueda = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFinal { get => fechaFinal; set => fechaFinal = value; }

        public frmBusquedaFuncionario()
        {
            InitializeComponent();
            banderaIdentificacion = 0;
        }

        //evento del formulario al cargar, donde se selecciona el índice por defecto del combo y se carga la lista
        //de solicitantes
        private void frmBusquedaSolicitante_Load(object sender, EventArgs e)
        {

            try
            {
                Limpiar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //el siguiente evento cambia un label de información por identificación o nombre según la opción del combo
        //seleccionada por el usuario, también limpia el texto de información y cambia la variable global de bandera
        //segun el indice seleccionado del combo.
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

        //el siguiente evento prohibe escribir letras o números en el texto de busqueda según lo elegido en el combobox.
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

        //el siguiente botón buscar genera la condición conforme a la opción seleccionada en el combo, ya sea buscar por
        //identificación o buscar por nombre y apellido, para posteriormente hacer la solicitud de búsqueda.
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string condicion = string.Empty;

            try
            {

                if (!string.IsNullOrEmpty(txtInfo.Text))
                {
                    if (cboTipo.SelectedIndex == 1)
                    {

                        condicion = $"CONCAT(NOMBRE, ' ', APELLIDO_UNO, ' ', APELLIDO_DOS) LIKE '%{txtInfo.Text}%' AND ACTIVO = 0";
       
                    }
                    else
                    {
                        
                        if (tipoBusqueda == 1)
                        {
                            condicion = $"IDENTIFICACION LIKE '%{txtInfo.Text}%' AND ACTIVO = 0";
                        }
                        else
                        {

                        condicion = $"IDENTIFICACION NOT IN (SELECT IDENTIFICACION FROM ACOMPANIANTES A INNER JOIN SOLICITUDES_GIRAS SG ON SG.ID_GIRA = A.ID_GIRA WHERE DIA_INICIO BETWEEN '{fechaInicio.ToString("yyyy/MM/dd")}' and '{fechaFinal.ToString("yyyy/MM/dd")}' OR DIA_FINAL BETWEEN '{fechaInicio.ToString("yyyy/MM/dd")}' and '{fechaFinal.ToString("yyyy/MM/dd")}') AND ACTIVO = 0";

                        }

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

        //la siguiente función cargar los solicitantes conforme a una condición y le pasa los datos al data grid view de solicitantes.
        private void CargarSolicitantes(string condicion = "")
        {
            logicaFuncionario logica = new logicaFuncionario(Configuracion.getConnectiongString);
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

        //el siguiente evento muestra la información del solicitante al dar un simple click al data grid view
        //si el combo box tiene un indice 0 seleccionado pues muestra la identificación y si tiene 1 muestra nombre y apellidos.
        private void grdSolicitante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (cboTipo.SelectedIndex == 0)
            {
                txtInfo.Text = grdSolicitante.SelectedRows[0].Cells[1].Value.ToString();
            }
            else
            {
                txtInfo.Text = grdSolicitante.SelectedRows[0].Cells[9].Value.ToString();
            }

            identificacionSolicitante = grdSolicitante.SelectedRows[0].Cells[1].Value.ToString();
        }


        //la siguiente función envía los datos de un formulario a otro.
        private void SeleccionarSolicitante()
        {
            try
            {
                if (grdSolicitante.SelectedRows.Count > 0 || !string.IsNullOrEmpty(identificacionSolicitante))
                {
                    identificacionSolicitante = grdSolicitante.SelectedRows[0].Cells[1].Value.ToString();
                    AceptarSolicitante(identificacionSolicitante, null);
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

        private void SeleccionarFuncionario() 
        {
            try
            {
                if (grdSolicitante.SelectedRows.Count > 0 || !string.IsNullOrEmpty(identificacionSolicitante))
                {
                    identificacionSolicitante = grdSolicitante.SelectedRows[0].Cells[1].Value.ToString();
                    AceptarFuncionario(identificacionSolicitante, null);
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
                throw;
            }
        }

        //la siguiente función ejecuta la función para mandar info de un método a otro al dar doble click al datagrid
        private void grdSolicitante_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tipoBusqueda == 1)
                {
                    SeleccionarSolicitante();
                }
                else
                {
                    SeleccionarFuncionario();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //la siguiente función ejecuta la función para mandar info de un método a otro al dar doble click al datagrid.
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tipoBusqueda == 1)
                {
                    SeleccionarSolicitante();
                }
                else
                {
                    SeleccionarFuncionario();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //evento de cancelación, no envía ningún dato al formulario
        private void btnSalir_Click(object sender, EventArgs e)
        {
            identificacionSolicitante = "-1";

            AceptarFuncionario(identificacionSolicitante, null);
            Close();

        }

        //la siguiente función limpia todos los campos y reinicia el combo. Se reutiliza tanto en la carga como en un evento click del botón limpiuar

        private void Limpiar()
        {
            cboTipo.SelectedIndex = 0;
            txtInfo.Text = string.Empty;
            grdSolicitante.ClearSelection();
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}

