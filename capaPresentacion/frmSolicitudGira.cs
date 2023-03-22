using capaLógica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class frmSolicitudGira : Form
    {
        //variables globales para todo el formulario que son importantes pues se usarán en distintas
        //funciones, así como arreglos globales con el objetivo de mostrar la información al usuario

        private DateTime giraFechaInicio = DateTime.MinValue, giraFechaFinal = DateTime.MinValue;
        private string horaInicio = string.Empty, horaFinal = string.Empty;

        //la siguiente variable booleana tiene como función ser bandera, e indicar que el botón de agregar un lugar ha sido accionado ya una vez. Esto para que un mensaje se le muestre al usuario solamente una vez cuando presiona este botón
        private bool eventoBotonAgregar = false;
        private DateTime fechaSolicitud = DateTime.Now;
        private List<claseLugares> lugares = new List<claseLugares>();

        //la siguiente bandera tiene como función verificar si se ha o no confirmado las fechas de la solicitud por parte del usuario
        //para usar dicha información en el disparo del clickear el botón de confirmar fechas.

        private int banderaConfirmarFecha;
        public frmSolicitudGira()
        {
            InitializeComponent();
        }

        /* control para salir del formulario */

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* la siguiente función recibe como parámetro la hora que eligió el usuario en las horas de inicio de un día, de manera que cambia las opciones del combo "Hora Final" cambian respecto a esa decisión, limitando las ocho horas de la regla de negocio */
        private void asignarHorasFin(string hora)
        {
            ComboBox comboFin = new ComboBox();
            cboFin.Items.Clear();

            if (hora == "08:00")
            {
                cboFin.Items.Add("09:00");
                cboFin.Items.Add("10:00");
                cboFin.Items.Add("11:00");
                cboFin.Items.Add("12:00");
                cboFin.Items.Add("13:00");
                cboFin.Items.Add("14:00");
                cboFin.Items.Add("15:00");
                cboFin.Items.Add("16:00");
            }
            else if (hora == "09:00")
            {
                cboFin.Items.Add("10:00");
                cboFin.Items.Add("11:00");
                cboFin.Items.Add("12:00");
                cboFin.Items.Add("13:00");
                cboFin.Items.Add("14:00");
                cboFin.Items.Add("15:00");
                cboFin.Items.Add("16:00");
            }
            else if (hora == "10:00")
            {
                cboFin.Items.Add("11:00");
                cboFin.Items.Add("12:00");
                cboFin.Items.Add("13:00");
                cboFin.Items.Add("14:00");
                cboFin.Items.Add("15:00");
                cboFin.Items.Add("16:00");
            }
            else if (hora == "11:00")
            {
                cboFin.Items.Add("12:00");
                cboFin.Items.Add("13:00");
                cboFin.Items.Add("14:00");
                cboFin.Items.Add("15:00");
                cboFin.Items.Add("16:00");
            }
            else if (hora == "12:00")
            {
                cboFin.Items.Add("13:00");
                cboFin.Items.Add("14:00");
                cboFin.Items.Add("15:00");
                cboFin.Items.Add("16:00");
            }
            else if (hora == "13:00")
            {
                cboFin.Items.Add("14:00");
                cboFin.Items.Add("15:00");
                cboFin.Items.Add("16:00");
            }
            else if (hora == "14:00")
            {
                cboFin.Items.Add("15:00");
                cboFin.Items.Add("16:00");
            }
            else
            {
                cboFin.Items.Add("16:00");
            }
        }

        /*el siguiente evento permite almacenar las fechas (de solicitud, y de inicio y fin de la gira) en 
         * una variable global para posteriormente usar dichas fechas en distintas funciones y eventos, así
         * como verificaciones. La primera vez guardará la información directamente, posteriormente
         mandará al usuario un mensaje de confirmación pues el cambio de confirmación de una fecha
        requiere limpiar todos los demás campos que ya han sido llenados del formulario*/
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (giraFechaInicio != DateTime.MinValue && giraFechaFinal != DateTime.MinValue &&
                banderaConfirmarFecha == 0 && cboInicio.SelectedIndex != -1 && cboFin.SelectedIndex != -1)
            {

                banderaConfirmarFecha = 1;

                if (dtpInicio.Value <= dtpFin.Value && dtpInicio.Value > dtpSolicitud.Value &&
                    dtpFin.Value > dtpSolicitud.Value)
                {
                    giraFechaInicio = dtpInicio.Value.Date;
                    giraFechaFinal = dtpFin.Value.Date;
                    horaInicio = cboInicio.Text;
                    horaFinal = cboFin.Text;
                    MessageBox.Show($"Nuevas fechas confirmadas. Fecha inicio: {giraFechaInicio.Date}- Fecha fin: {giraFechaFinal.Date}, Hora de Inicio: {horaInicio} / Hora de Fin: {horaFinal}", "Fechas confirmadas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Hay un problema con las fechas. Verifique que la fecha de inicio sea menor a la de fin y mayor a la de solicitud, o que la fecha final sea mayor a la de inicio y de solicitud.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    giraFechaInicio = DateTime.MinValue;
                    giraFechaFinal = DateTime.MinValue;
                    dtpInicio.Value = dtpSolicitud.Value;
                    dtpFin.Value = dtpSolicitud.Value;
                }


            }
            else
            {
                if (banderaConfirmarFecha == 0)
                {
                    MessageBox.Show("Es probable que los campos de fecha o de hora no hayan sido llenados, o no se haya confirmado una fecha.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult advertencia = MessageBox.Show("Ya han sido confirmadas unas fechas. ¿Seguro desea cambiar las fechas? Esto implica el limpiado de los demás campos de la solicitud.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (advertencia == DialogResult.Yes)
                    {
                        banderaConfirmarFecha = 0;
                        lugares.Clear();
                        limpiarLugares();
                        grdLugares.Rows.Clear();
                        btnConfirmar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Ningún campo modificado.");
                    }
                }

            }

        }

        /* control de inicio del formulario. Da algunos valores que están fijos en el formulario así como
         * la inicialización de distintas variables*/

        private void frmSolicitudGira_Load(object sender, EventArgs e)
        {
            banderaConfirmarFecha = 0;
            fechaSolicitud = DateTime.Now;
            giraFechaInicio = DateTime.MinValue;
            giraFechaFinal = DateTime.MinValue;

            dtpSolicitud.Value = fechaSolicitud;
            dtpInicio.Value = fechaSolicitud;
            dtpFin.Value = fechaSolicitud;
            dtpInicio.Enabled = true;
            dtpFin.Enabled = true;

        }

        /* el siguiente evento sucede cuando el datetimepicker de inicio de gira es cambiado, de modo que verifique si se ha insertado una fecha menor a la fecha de solicitud, además de asignar a la variable global de inicio el valor elegido por el usuario */

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {

            if (dtpInicio.Value > dtpSolicitud.Value)
            {
                giraFechaInicio = dtpInicio.Value;
            }

        }

        //igual que la función de abajo, verifica cuando el datetimepicker de hora final ha sido cambiado por el usuario.
        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {

            if (dtpFin.Value > dtpSolicitud.Value && dtpSolicitud.Value < dtpFin.Value)
            {
                giraFechaFinal = dtpFin.Value;
            }

        }


        //la siguiente función sin retorno simplemente añade la instancia al arreglo de lugares
        //y añade una fila con la información de la instancia al gridview
        private void aniadirLugar()
        {
            claseLugares claseLugares = new claseLugares();;;
            claseLugares.Id = lugares.Count;
            claseLugares.Origen = txtOrigen.Text;
            claseLugares.Destino = txtFinal.Text;

            lugares.Add(claseLugares);
            grdLugares.Rows.Add(claseLugares.Id, claseLugares.Origen, claseLugares.Destino);
        }


        //la siguiente sobrecarga simplemente repite el añadir una fila de la lista de lugares pero que ya es
        //existente, por lo tanto no se necesita crear una instancia, simplemente copiar la ya almacenada
        //mediante un número de índice como argumento

        private void aniadirLugar(int indice)
        {
            grdLugares.Rows.Add(lugares[indice].Id, lugares[indice].Origen, lugares[indice].Destino);
        }
        /*el evento de añadir lugar primero revisa que no haya alguno de los espacios vacíos y sin datos. Después,
         * verifica que ya hayan sido confirmadas las fechas según los valores por defecto de la fecha de inicio
         * y fin de la gira. Luego de ello, verifica que la fecha seleccionada esté en el rango de la fecha de fin
         * y de inicio de la solicitud de gira, y además, se ayuda de una función para verificar que dicha fecha
         * no haya sido insertada ya. Si pasa las verificaciones, crea una instancia de la clase de lugares
         * y lo añade al arreglo para posteriormente mediante una función añadir la fila al datagridview.*/

        private void btnAniadirLugar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtOrigen.Text)&& !string.IsNullOrEmpty(txtFinal.Text))
            {

                if (giraFechaInicio != DateTime.MinValue && giraFechaFinal != DateTime.MinValue)
                {
                        aniadirLugar();
                        ordenarListaLugares();
                        limpiarLugares();
                        if (eventoBotonAgregar == false)
                        {
                            MessageBox.Show("Ha sido agregada una de las fechas de la gira. Puede ver la información a la derecha.", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            eventoBotonAgregar = true;
                        }

                }
                else
                {
                    MessageBox.Show("No ha sido asignada una fecha de inicio ni de fin para la gira.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No ha sido seleccionada alguna hora, o algún campo de texto está vacío.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //la siguiente función llamará a la función "asignarHorasFin" cuando la hora de inicio sea cambiada, 3
        //asignándole al combo box de Hora Final un rango de horas de máximo 8 horas. 
        //Esto como un control de datos desde el
        //formulario, donde la hora que se pase cada día no sobrepase las 8 horas.
        private void cboInicio_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string horaSeleccionada = cboInicio.Text.ToString();

            asignarHorasFin(horaSeleccionada);

        }

        //funcion que limpia todos los campos de la interfaz de lugares mediante una función.
        private void txtLimpiar_Click(object sender, EventArgs e)
        {
            limpiarLugares();
        }

        //evento de evento de eliminar lugar, donde se verifica que el texto de id del lugar agregado
        //está lleno (esto quiere decir que fue seleccionado un lugar desde el dataviewgrid) y en caso de estarlo
        //ubica mediante el id la fila del dataview y la posicion en la lista para eliminarlos, después
        //limpia los lugares mediante una función
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = 0;

            if (!string.IsNullOrEmpty(txtIDLugar.Text))
            {
                indice = Convert.ToInt32(txtIDLugar.Text);
                indice = indice - 1;
                lugares.RemoveAt(indice);
                grdLugares.Rows.RemoveAt(indice);
                ordenarListaLugares();
                limpiarLugares();
            }
            else
            {
                MessageBox.Show("No hay ningún día seleccionado.", "Error de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //obtiene el indice adjudicado al lugar en la celda seleccionada, y da los valores
        //de la fila mediante el indice y el arreglo, mostrándolos en los campos de al lado.
        private void grdLugares_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice;

            DataGridViewCell celda = grdLugares.Rows[e.RowIndex].Cells[0];
            indice = Convert.ToInt32(celda.Value);

            txtIDLugar.Text = (lugares[indice].Id+1).ToString();
            txtOrigen.Text = lugares[indice].Origen.ToString();
            txtFinal.Text = lugares[indice].Destino.ToString();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Las solicitudes de las giras deben enviarse antes del miércoles de la semana y con al menos una semana de anticipación, por lo que si se manda después de dichos días de la semana o antes de una semana se debe marcar como extemporánea.", "Giras extemporáneas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        //funcion para reiniciar los ids de lugares despues de agregado o eliminado un día, de manera que también
        //ordena los lugares que se muestran en el datagridview así como lo almacenado en la lista de lugares
        //lo que ayudará a proteger la integridad de los datos a la hora de pasar a la capa lógica

        private void ordenarListaLugares()
        {
            grdLugares.Rows.Clear();

            //lugares.Sort((x, y) => x.Id.CompareTo(y));

            for (int i = 0; i < lugares.Count; i++)
            {
                lugares[i].Id = i;
                aniadirLugar(i);
            }
        }

        private void btnChofer_Click(object sender, EventArgs e)
        {
            frmBusquedaSolicitante form = new frmBusquedaSolicitante();
            form.Show();

        }

        private void limpiarLugares()
        {
            txtOrigen.Text = string.Empty;
            txtFinal.Text = string.Empty;
            txtIDLugar.Text = string.Empty;
        }
    }
}
