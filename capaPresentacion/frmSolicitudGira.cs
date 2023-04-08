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
using capaEntidades;
using capaLogica;
using capaLógica;
using logicaSolicitante;

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
        private List<entidadLugar> lugares = new List<entidadLugar>();
        private List<entidadFuncionario> funcionarios = new List<entidadFuncionario>();

        //la siguiente bandera tiene como función verificar si se ha o no confirmado las fechas de la solicitud por parte del usuario
        //para usar dicha información en el disparo del clickear el botón de confirmar fechas.

        private int banderaConfirmarFecha;

        //la siguiente lista almacena las licencias que posee el chofer elegido, esto por si el usuario primeramente elige el chofer, lo que permitirá pasar las licencias y filtrar la búsqueda la buscar un automóvil
        private List<entidadLicencia> licenciasChofer;
        private string placa, idChofer, idSolicitante, justificacionExtemporanea;
        private int idCentro;

        public string Placa { get => placa; set => placa = value; }
        public string IdChofer { get => idChofer; set => idChofer = value; }
        public string IdSolicitante { get => idSolicitante; set => idSolicitante = value; }
        public string JustificacionExtemporanea { get => justificacionExtemporanea; set => justificacionExtemporanea  = value; }
        public int IdCentro { get => idCentro; set => idCentro = value; }

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

                    if (CompararFechas(dtpSolicitud.Value, dtpInicio.Value))
                    {
                        giraFechaInicio = dtpInicio.Value.Date;
                        giraFechaFinal = dtpFin.Value.Date;
                        horaInicio = cboInicio.Text;
                        horaFinal = cboFin.Text;
                        MessageBox.Show($"Nuevas fechas confirmadas. Fecha inicio: {giraFechaInicio.Date.ToString("dd-MM-yyyy")} / Fecha fin: {giraFechaFinal.Date.ToString("dd-MM-yyyy")}. Hora de Inicio: {horaInicio} / Hora de Fin: {horaFinal}", "Fechas confirmadas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        giraFechaInicio = dtpInicio.Value.Date;
                        giraFechaFinal = dtpFin.Value.Date;
                        horaInicio = cboInicio.Text;
                        horaFinal = cboFin.Text;
                        MessageBox.Show($"Atención, la solicitud de gira debe mandarse como extemporánea pues está a menos de siete días del día de inicio. Por favor, digite la respectiva justificación a continuación", "Fecha extemporánea", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        justificacionExtemporanea = RecibirJustificacion();
                        chkExtemporanea.Checked = true;
                    }

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
                        limpiarLugares();
                        btnConfirmar_Click(sender, e);
                        ReiniciarTodo(true);
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
            licenciasChofer = null;
            banderaConfirmarFecha = 0;
            fechaSolicitud = DateTime.Now;
            giraFechaInicio = DateTime.MinValue;
            giraFechaFinal = DateTime.MinValue;
            txtCantidad.Text = "0";
            txtCantidad.Tag = string.Empty;
            dtpSolicitud.Value = fechaSolicitud;
            dtpInicio.Value = fechaSolicitud;
            dtpFin.Value = fechaSolicitud;
            dtpInicio.Enabled = true;
            dtpFin.Enabled = true;
            IdCentro = -1;
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
            entidadLugar claseLugares = new entidadLugar();
            claseLugares.Id = lugares.Count;
            claseLugares.Origen = txtOrigen.Text;
            claseLugares.Destino = txtFinal.Text;

            lugares.Add(claseLugares);
            grdLugares.Rows.Add(claseLugares.Id, claseLugares.Origen, claseLugares.Destino);
        }

        //la siguiente función sin retorno añade una entidad de funcionario devuelta desde el formulario de busqueda
        //a la lista global que guarda la asistentes de la gira, y de paso inserta los datos en el datagrid para permitir
        //que el usuario sea capaz de verlos
        private void aniadirFuncionario(entidadFuncionario funcionario)
        {
            if (verificarFuncionario(funcionario.Identificacion))
            {
                funcionarios.Add(funcionario);

                dgvFuncionarios.Rows.Add(funcionario.Identificacion, funcionario.NombreApellido);
                txtCantidad.Text = funcionarios.Count.ToString();
            }
            else
            {
                MessageBox.Show("Ese funcionario ya fue añadido.", "Error al añadir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool verificarFuncionario(string idFuncionario)
        {
            int i = 0;

            if (funcionarios.Count > 0)
            {
                while (i < funcionarios.Count)
                {

                    if (idFuncionario == funcionarios[i].Identificacion)
                    {
                        return false;
                    }
                    else
                    {
                        i++;
                    }
                }
            }


            return true;
        }
        //la siguiente sobrecarga simplemente repite el añadir una fila de la lista de lugares pero que ya es
        //existente, por lo tanto no se necesita crear una instancia, simplemente copiar la ya almacenada
        //mediante un número de índice como argumento

        private void aniadirLugar(int indice)
        {
            grdLugares.Rows.Add(lugares[indice].Id, lugares[indice].Origen, lugares[indice].Destino);
        }

        private void aniadirFuncionario(int indice)
        {
            dgvFuncionarios.Rows.Add(funcionarios[indice].Identificacion, funcionarios[indice].NombreApellido);
        }
        /*el evento de añadir lugar primero revisa que no haya alguno de los espacios vacíos y sin datos. Después,
         * verifica que ya hayan sido confirmadas las fechas según los valores por defecto de la fecha de inicio
         * y fin de la gira. Luego de ello, verifica que la fecha seleccionada esté en el rango de la fecha de fin
         * y de inicio de la solicitud de gira, y además, se ayuda de una función para verificar que dicha fecha
         * no haya sido insertada ya. Si pasa las verificaciones, crea una instancia de la clase de lugares
         * y lo añade al arreglo para posteriormente mediante una función añadir la fila al datagridview.*/

        private void btnAniadirLugar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtOrigen.Text) && !string.IsNullOrEmpty(txtFinal.Text))
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

            txtIDLugar.Text = (lugares[indice].Id + 1).ToString();
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

        private void ordenarListaFuncionarios()
        {
            dgvFuncionarios.Rows.Clear();

            for (int i = 0; i < funcionarios.Count; i++)
            {
                aniadirFuncionario(i);
            }
        }

        private void btnChofer_Click(object sender, EventArgs e)
        {
            frmBusquedaFuncionario form = new frmBusquedaFuncionario();
            form.TipoBusqueda = 1;
            form.AceptarSolicitante += new EventHandler(AceptarSolicitante);

            form.Show();

        }

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

        private void AceptarFuncionario(object idFuncionario, EventArgs e)
        {
            try
            {
                string id = idFuncionario.ToString();

                if (id != "-1")
                {
                    BuscarFuncionario(id);
                }
                else
                {
                    MessageBox.Show("No fue seleccionado ningún funcionario.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AceptarChofer(object idSolicitante, EventArgs e)
        {
            try
            {
                string id = idSolicitante.ToString();

                if (id != "-1")
                {
                    BuscarChofer(id);
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



        private void btnBuscarDos_Click(object sender, EventArgs e)
        {

            if (giraFechaInicio != DateTime.MinValue && giraFechaFinal != DateTime.MinValue)
            {

                frmBusquedaChofer form = new frmBusquedaChofer();
                form.FechaInicio = giraFechaInicio.ToString("yyyy-MM-dd");
                form.AceptarChofer += new EventHandler(AceptarChofer);
                form.FechaFin = giraFechaFinal.ToString("yyyy-MM-dd");
                if (!string.IsNullOrEmpty(txtPlaca.Text))
                {
                    form.LicenciaVehiculo = txtEstilo.Text;
                }
                form.Show();


            }
            else
            {
                MessageBox.Show("Para registrar un chofer en la solicitud debe primero confirmar unas fechas válidas para la gira", "Error de fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

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
                    txtSolicitante.Text = solicitante.NombreApellido;
                    txtSolicitante.Tag = solicitante.Identificacion;
                    IdSolicitante = solicitante.Identificacion;
                }
                else
                {
                    MessageBox.Show("No se ha podido cargar el solicitante. Debe haber un error al seleccionarlo.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BuscarFuncionario(string idFuncionario)
        {
            entidadFuncionario funcionario;
            logicaFuncionario logica = new logicaFuncionario(Configuracion.getConnectiongString);
            logica.CadenaConexion = Configuracion.getConnectiongString;
            string condicion = $"IDENTIFICACION = '{idFuncionario}'";

            try
            {

                funcionario = logica.ObtenerSolicitante(condicion);

                if (funcionario.Identificacion == idFuncionario)
                {
                    aniadirFuncionario(funcionario);
                }
                else
                {
                    MessageBox.Show("No se ha podido cargar el solicitante. Debe haber un error al seleccionarlo.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnAgregarFuncionario_Click(object sender, EventArgs e)
        {
            if (giraFechaInicio != DateTime.MinValue || giraFechaFinal != DateTime.MinValue)
            {
                if (string.IsNullOrEmpty(txtCapacidad.Text))
                {
                    frmBusquedaFuncionario form = new frmBusquedaFuncionario();
                    form.TipoBusqueda = 2;
                    form.FechaInicio = giraFechaInicio;
                    form.FechaFinal = giraFechaFinal;
                    form.AceptarFuncionario += new EventHandler(AceptarFuncionario);

                    form.Show();
                }
                else
                {
                    if (Convert.ToInt32(txtCantidad.Text) + 2 <= Convert.ToInt32(txtCapacidad.Text))
                    {
                        frmBusquedaFuncionario form = new frmBusquedaFuncionario();
                        form.TipoBusqueda = 2;
                        form.FechaInicio = giraFechaInicio;
                        form.FechaFinal = giraFechaFinal;
                        form.AceptarFuncionario += new EventHandler(AceptarFuncionario);

                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("La cantidad de funciones seleccionados no puede superar la capacidad del vehículo seleccionado. Tome en cuenta que el chofer se toma en cuenta respecto a la cantidad de funcionarios que asisten a la gira. Por favor, asegúrese de elegir un vehículo con más capacidad.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                }
            }
            else
            {
                MessageBox.Show("Para seleccionar una funcionario primero debe asignar a la gira una fecha de inicio y final, esto pues se debe verificar la disponibilidad de los funcionarios en dichas fechas", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void btnEliminarFuncionario_Click(object sender, EventArgs e)
        {
            int indice = 0;

            if (!string.IsNullOrEmpty(txtCantidad.Tag.ToString()))
            {

                indice = Convert.ToInt32(txtCantidad.Tag);
                funcionarios.RemoveAt(indice);
                txtCantidad.Tag = string.Empty;
                txtCantidad.Text = funcionarios.Count.ToString();
                ordenarListaFuncionarios();
            }
            else
            {
                MessageBox.Show("No hay ningún funcionario seleccionado.", "Error de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = -1;

            if (dgvFuncionarios.SelectedRows.Count > 0)
            {
                indice = dgvFuncionarios.SelectedRows[0].Index;
                txtCantidad.Tag = indice;
            }
            else
            {
                MessageBox.Show("No hay ningún funcionario seleccionado. Debe hacer doble click en el que desea eliminar.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void btnPlaca_Click(object sender, EventArgs e)
        {


            if (giraFechaInicio != DateTime.MinValue && giraFechaFinal != DateTime.MinValue)
            {
                frmBusquedaVehiculo form;


                if (funcionarios.Count > 0)
                {
                    form = new frmBusquedaVehiculo(funcionarios.Count);
                }
                else
                {
                    form = new frmBusquedaVehiculo(-1);
                }

                if (licenciasChofer != null)
                {
                    form.LicenciaLista = licenciasChofer;
                }

                form.GiraFechaFinal = giraFechaFinal;
                form.GiraFechaInicio = giraFechaInicio;
                form.AceptarVehiculo += new EventHandler(AceptarVehiculo);
                form.Show();

            }
            else
            {
                MessageBox.Show("Para registrar un vehículo en la solicitud debe primero confirmar unas fechas válidas para la gira", "Error de fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void chkExtemporanea_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            entidadSolicitudGira solicitud;
            int retorno;
            int resultado;
            logicaSolicitudGira logica = new logicaSolicitudGira(Configuracion.getConnectiongString);

            try
            {

                if (giraFechaInicio != DateTime.MinValue || giraFechaFinal != DateTime.MinValue)
                {
                    if (lugares.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(placa) && !string.IsNullOrEmpty(idSolicitante) && !string.IsNullOrEmpty(idChofer))
                        {

                            if (idCentro > -1)
                            {
                                if (funcionarios.Count > 0)
                                {
                                    solicitud = GenerarSolicitud();
                                    retorno = logica.InsertarSolicitudGira(solicitud);

                                    if (retorno > 0)
                                    {

                                        foreach (entidadFuncionario item in funcionarios)
                                        {
                                            resultado = logica.InsertarAcompaniante(item.Identificacion, retorno);
                                        }

                                        foreach (entidadLugar item in lugares)
                                        {
                                            resultado = logica.InsertarLugares(item.Origen, item.Destino, retorno);
                                        }
                                        MessageBox.Show($"La solicitud fue enviada satisfactoriamente, puede consultarla con la id: {retorno}", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ReiniciarTodo();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Hubo un error al insertar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Debe añadir por lo menos un (1) asistente para enviar una gira.", "Error de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Asegúrese añadir el centro de formación desde donde se envía la solicitud de la gira.", "Error de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                        }
                        else
                        {
                            MessageBox.Show("Hace falta buscar un vehículo, un solicitante, un chofer o agregar el centro de formación para enviar la gira.", "Error de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Debe añadir por lo menos un (1) lugar para enviar una gira.", "Error de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Para enviar una solicitud debe haber declarado la fecha de inicio y final para la gira, así como la hora.", "Error de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //la siguiente función genera la solicitud con la respectiva información y la devuelve para su posterior inserción en la base de datos

        private entidadSolicitudGira GenerarSolicitud()
        {
            entidadSolicitudGira solicitud = new entidadSolicitudGira();


            solicitud.DiaSolicitud = fechaSolicitud;
            solicitud.DiaInicio = giraFechaInicio;
            solicitud.DiaFinal = giraFechaFinal;
            solicitud.HoraInicio = horaInicio;
            solicitud.HoraFin = horaFinal;
            solicitud.Placa = Placa;
            solicitud.Solicitante = IdSolicitante;
            solicitud.Chofer = IdChofer;
            solicitud.CantidadFuncionarios = Convert.ToInt32(txtCantidad.Text);
            solicitud.IdCentro = IdCentro;
            solicitud.Extemporanea = (string.IsNullOrEmpty(justificacionExtemporanea)) ? 0 : 1;

            if (solicitud.Extemporanea == 1)
            {
                solicitud.Justificacion = justificacionExtemporanea;
            }
            else
            {
                solicitud.Justificacion = string.Empty;

            }
            return solicitud;
        }
        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para enviar una solicitud de gira requiere: una fecha de inicio y final para la gira, así como los respectivos horarios de inicio y final (8 horas máximo por dia). Puede agregar los lugares que desee. Debe agregar un solicitante, quien responderá a nombre de la gira y no necesariamente debe asistir. También, debe agregar un chofer a cargo que coincida con la licencia requerida para manejar el vehículo que seleccione. Puede agregar los funcionarios que asistirán a la gira. Importante: solamente se mostrarán los choferes, funcionarios y vehículos que estén disponibles de acuerdo a las fechas que asignó a la gira, por lo que si no aparece un resultado determinado, intente cambiando las fechas.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ReiniciarTodo();
        }

        private string RecibirJustificacion()
        {
            frmExtemporanea form = new frmExtemporanea();
            string justificacion;
            DialogResult resultado = form.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                justificacion = form.Justificacion;
            }
            else
            {
                MessageBox.Show("Para proceder debe digitar una justificación pues la solicitud es extemporánea.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                justificacion = string.Empty;
            }

            return justificacion;
        }

        private void AceptarVehiculo(object placa, EventArgs e)
        {
            try
            {
                string id = placa.ToString();

                if (id != "-1")
                {
                    BuscarVehiculo(id);
                }
                else
                {
                    MessageBox.Show("No fue seleccionado ningún vehículo.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarCentro_Click(object sender, EventArgs e)
        {

            frmBusquedaCentro form = new frmBusquedaCentro();
            form.AceptarCentro += new EventHandler(AceptarCentro);
            form.Show();

        }



        private void BuscarChofer(string idChofer)
        {
            entidadChofer chofer;
            logicaFuncionario logica = new logicaFuncionario(Configuracion.getConnectiongString);
            logicaLicencia logicaLicencia = new logicaLicencia(Configuracion.getConnectiongString);
            logica.CadenaConexion = Configuracion.getConnectiongString;
            string condicion = $"IDENTIFICACION = '{idChofer}'";

            try
            {

                chofer = logica.ObtenerChofer(condicion);

                if (chofer.Identificacion == idChofer)
                {
                    txtChofer.Text = chofer.NombreApellido;
                    txtChofer.Tag = chofer.Identificacion;
                    licenciasChofer = logicaLicencia.ListarLicencias($"IDENTIFICACION = '{chofer.Identificacion}'");
                    IdChofer = chofer.Identificacion;
                }
                else
                {
                    MessageBox.Show("No se ha podido cargar el solicitante. Debe haber un error al seleccionarlo.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BuscarVehiculo(string placa)
        {
            entidadVehiculo vehiculo;
            entidadCentroFormacion centro;
            logicaVehiculo logica = new logicaVehiculo(Configuracion.getConnectiongString);
            logicaCentroFormacion logicaCentro = new logicaCentroFormacion(Configuracion.getConnectiongString);
            logica.CadenaConexion = Configuracion.getConnectiongString;
            string condicion = $"PLACA = '{placa}'";

            try
            {

                vehiculo = logica.ObtenerVehiculo(condicion);
                centro = logicaCentro.ObtenerCentroFormacion($"ID_CENTRO = '{vehiculo.Id_Centro}'");
                if (vehiculo.Placa == placa)
                {
                    txtPlaca.Text = vehiculo.Placa;
                    txtModelo.Text = vehiculo.Modelo;
                    txtGasolina.Text = vehiculo.Combustible;
                    txtCapacidad.Text = vehiculo.Capacidad.ToString();
                    txtCentro.Text = centro.Nombre;
                    txtMarca.Text = vehiculo.Marca;
                    txtEstilo.Text = vehiculo.LicenciaRequerida;
                    Placa = vehiculo.Placa;
                }
                else
                {
                    MessageBox.Show("No se ha podido cargar el vehículo. Debe haber un error al seleccionarlo.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

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
                    txtCentroDeForm.Text = centro.Nombre;
                    txtCentroDeForm.Tag = centro.IdCentro;
                    IdCentro = centro.IdCentro;
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

        private void limpiarLugares()
        {
            txtOrigen.Text = string.Empty;
            txtFinal.Text = string.Empty;
            txtIDLugar.Text = string.Empty;
        }

        private void limpiarVehiculo()
        {
            txtPlaca.Text = string.Empty;
            txtGasolina.Text = string.Empty;
            txtEstilo.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtCapacidad.Text = string.Empty;
            txtCentro.Text = string.Empty;
            txtMarca.Text = string.Empty;
        }

        private void ReiniciarPorFechas()
        {

        }
        private void ReiniciarTodo(bool reinicioFechas = false)
        {
            if (!reinicioFechas)
            {
                dtpInicio.Value = dtpSolicitud.Value;
                dtpFin.Value = dtpSolicitud.Value;
                giraFechaInicio = DateTime.MinValue;
                horaFinal = string.Empty;
                horaInicio = string.Empty;
                giraFechaFinal = DateTime.MinValue;
                cboInicio.SelectedIndex = 0;
                asignarHorasFin("08:00");
                chkExtemporanea.Checked = false;
                JustificacionExtemporanea = string.Empty;
            }



            limpiarLugares();
            grdLugares.Rows.Clear();
            txtSolicitante.Text = string.Empty;
            txtSolicitante.Tag = string.Empty;
            Placa = string.Empty;
            IdChofer = string.Empty;
            IdSolicitante = string.Empty;

            txtChofer.Text = string.Empty;
            txtChofer.Tag = string.Empty;
            dgvFuncionarios.Rows.Clear();
            txtCantidad.Text = "0";
            licenciasChofer = null;
            eventoBotonAgregar = false;
            lugares.Clear();
            funcionarios.Clear();
            banderaConfirmarFecha = 0;
            limpiarVehiculo();
            idCentro = -1;
            txtCentroDeForm.Text = string.Empty;

        }

        //la siguiente función verifica si la día de solicitud y la fecha de inicio tienen siete días menos de diferencia
        //y si es lunes o martes, para de esta manera declarar la solicitud como extemporánea

        public bool CompararFechas(DateTime fechaSolicitud, DateTime fechaInicio)
        {
            TimeSpan diferencia = fechaInicio - fechaSolicitud;

            if (diferencia.TotalDays <= 7)
            {
                if (fechaSolicitud.DayOfWeek == DayOfWeek.Monday || fechaSolicitud.DayOfWeek == DayOfWeek.Tuesday)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
