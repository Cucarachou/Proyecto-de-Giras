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
    public partial class frmAniadirFuncionario : Form
    {
        //la siguiente variable tipo string almacena el id del funcionario en caso de que se haya accedidod a modificar. Esta variable se verifica en el constructor del formulario, y si no es null se entra al modo modififcar.
        string idFuncionario;

        //la siguiente entidad no instanciada de momento guarda de forma global la variable del funcionario a modificar.
        entidadFuncionario funcionario;
        public frmAniadirFuncionario(string idFuncionario)
        {
            InitializeComponent();
            this.idFuncionario = idFuncionario;
            if (idFuncionario != null)
            {
                ModoModificar();
            }
        }

        //la siguiente funcion ModoModificar cambia el formulario para que se pueda modificar el funcionario seleccionado y desactiva el botón de agregar funcionario. Además, trae la entidad de funcionario y la asigna a la variable global y le da los valores a los campos de información.
        private void ModoModificar()
        {
            try
            {
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                entidadCentroFormacion centro;
                logicaFuncionario logicaFuncionario = new logicaFuncionario(Configuracion.getConnectiongString);
                logicaCentroFormacion logicaCentro = new logicaCentroFormacion(Configuracion.getConnectiongString);

                funcionario = logicaFuncionario.ObtenerFuncionario($"IDENTIFICACION = '{idFuncionario}'");

                txtIdentificacion.Text = funcionario.Identificacion;
                txtIdentificacion.Enabled = false;
                txtNombre.Text = funcionario.Nombre;
                txtApellidoUno.Text = funcionario.ApellidoUno;
                txtApellidoDos.Text = funcionario.ApellidoDos;
                txtCorreo.Text = funcionario.Correo;
                txtTelefono.Text = funcionario.Telefono;
                centro = logicaCentro.ObtenerCentroFormacion($"ID_CENTRO = {funcionario.IdCentro}");
                txtCentro.Text = centro.Nombre;
                txtCentro.Tag = centro.IdCentro;
                chkAprobador.Checked = funcionario.Aprobador;
                chkChofer.Checked = funcionario.Chofer;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //el siguiente evento verifica que todos los campos hayan sido llenados para posteriormente agregar el funcionario a la base de datos llamando a la lógica de funcionario. Crea una entidad de funcionario y le añade todos los datos requeridos. Utiliza una sobrecarga del constructor de la entidad funcionario.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string identificacion, nombre, apellidoUno, apellidoDos, correo, telefono, resultado;
            int idCentro;
            bool aprobador = false, chofer = false;

            try
            {
                logicaFuncionario logica = new logicaFuncionario(Configuracion.getConnectiongString);
                if (!string.IsNullOrEmpty(txtIdentificacion.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellidoUno.Text) && !string.IsNullOrEmpty(txtApellidoDos.Text))
                {

                    if (!string.IsNullOrEmpty(txtCorreo.Text) && !string.IsNullOrEmpty(txtTelefono.Text) && !string.IsNullOrEmpty(txtCentro.Text))
                    {
                        identificacion = txtIdentificacion.Text;
                        nombre = txtNombre.Text;
                        apellidoUno = txtApellidoUno.Text;
                        apellidoDos = txtApellidoDos.Text;
                        correo = txtCorreo.Text;
                        telefono = txtTelefono.Text;
                        idCentro = Convert.ToInt32(txtCentro.Tag);

                        if (chkAprobador.Checked)
                        {
                            aprobador = true;
                        }

                        if (chkChofer.Checked)
                        {
                            chofer = true;
                        }

                        funcionario = new entidadFuncionario(identificacion, nombre, apellidoUno, apellidoDos, telefono, correo, idCentro, true, aprobador, chofer);

                        resultado = logica.InsertarFuncionario(funcionario);

                        if (!string.IsNullOrEmpty(resultado))
                        {
                            MessageBox.Show($"Ha ingresado satisfactoriamente un funcionario con la identificacion {resultado}", "Funcionario agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No fue posible añadir el funcionario ingresado.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Para añadir un funcionario asegúrese de llenar todos los campos requeridos.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Para añadir un funcionario asegúrese de llenar todos los campos requeridos.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //la siguiente funcion abre el formulario para proceder a buscar un centro de formación en específico y luego lo recibe.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaCentro form = new frmBusquedaCentro();
                form.AceptarCentro += new EventHandler(AceptarCentro);
                form.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //la siguiente funcion recibe el centro desde el formulario BuscarCentro y verifica que haya encontrado uno para posteriormente llamar a la función buscar centro.
        private void AceptarCentro(object idCentro, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(idCentro);

                if (id != -1)
                {
                    BuscarCentro(id);
                }
                else
                {
                    MessageBox.Show("No fue seleccionado ningún centro de formación.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //la siguiente función buscarcentro verifica que el centro de formación traído desde el formulario de BuscarCentro exista para evitar errores, posteriormente asignar los valores de nombre al texto y el id del centro al tag.
        private void BuscarCentro(int idCentro)
        {
            entidadCentroFormacion centro;
            logicaCentroFormacion logica = new logicaCentroFormacion(Configuracion.getConnectiongString);
            logica.CadenaConexion = Configuracion.getConnectiongString;
            string condicion = $"ID_CENTRO = '{idCentro}'";

            try
            {

                centro = logica.ObtenerCentroFormacion(condicion);

                if (centro.IdCentro == idCentro)
                {
                    txtCentro.Text = centro.Nombre;
                    txtCentro.Tag = centro.IdCentro;
                }
                else
                {
                    MessageBox.Show("No se ha podido cargar el centro de formación. Debe haber un error al seleccionarlo.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        
        //el siguiente evento verifica que al menos un campo haya sido cambiado en el formulario para proceder con la modificación. Posteriormente le asigna los valores a la entidad global de funcionario y llama a una función para modificar el funcionario que se encuentra en la lógica del funcionario.
        private void btnModificar_Click(object sender, EventArgs e)
        {
            logicaFuncionario logica = new logicaFuncionario(Configuracion.getConnectiongString);
            bool resultado = false;
            try
            {
                if (txtNombre.Text != funcionario.Nombre || txtApellidoUno.Text != funcionario.ApellidoUno || txtApellidoDos.Text != funcionario.ApellidoDos || txtCorreo.Text != funcionario.Correo || txtTelefono.Text != funcionario.Telefono || Convert.ToInt32(txtCentro.Tag) != funcionario.IdCentro || chkAprobador.Checked != funcionario.Aprobador || chkChofer.Checked != funcionario.Chofer)
                {
                    funcionario.Nombre = txtNombre.Text;
                    funcionario.ApellidoUno = txtApellidoUno.Text;
                    funcionario.ApellidoDos = txtApellidoDos.Text;
                    funcionario.Telefono = txtTelefono.Text;
                    funcionario.Correo = txtCorreo.Text;
                    funcionario.IdCentro = Convert.ToInt32(txtCentro.Tag);
                    funcionario.Aprobador = chkAprobador.Checked;
                    funcionario.Chofer = chkChofer.Checked;

                    resultado = logica.ModificarFuncionario(funcionario);

                    if (resultado)
                    {
                        MessageBox.Show("Funcionario modificado satisfactoriamente.", "Funcionario Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al cambiar al funcionario.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    Close();
                }
                else
                {
                    MessageBox.Show("Asegúrese de cambiar al menos un campo para poder modificar al funcionario.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
    }
}
