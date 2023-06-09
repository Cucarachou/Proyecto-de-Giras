﻿using capaEntidades;
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
    public partial class frmAprobarGira : Form
    {
        public frmAprobarGira()
        {
            InitializeComponent();
        }

        //al cargar el formulario, se asigna al combo box de tipo la primera opción.
        private void frmAprobarGira_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;

        }

        //el siguiente evento busca un funcionario que pueda aprobar o rechazar giras. Esto lo hace asignándole al constructor del formulario un tipo de busqueda (numero 3 = busqueda de aprobador) y posteriormente lo recibe con la función aceptar aprobador.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusquedaFuncionario form = new frmBusquedaFuncionario();
                form.TipoBusqueda = 3;
                form.AceptarAprobador = new EventHandler(AceptarAprobador);
                form.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        //la siguiente función recibe el aprobador desde el anterior evento y verifica que sí se haya seleccionado uno, para posteriormente llamar a la función de buscar aprobador.
        private void AceptarAprobador(object idSolicitante, EventArgs e)
        {
            try
            {
                string id = idSolicitante.ToString();

                if (id != "-1")
                {
                    BuscarAprobador(id);
                }
                else
                {
                    MessageBox.Show("No fue seleccionado ningún aprobador.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //la siguiente función verifica que el aprobador traído desde el formulario de BuscarFuncionario con el tipo de busqueda numero 3 exista en caso de cualquier fallo, para posteriormente asignar el nombre completo al texto y la identificacion al tag.
        private void BuscarAprobador(string idAprobador)
        {
            entidadFuncionario aprobador;
            logicaFuncionario logica = new logicaFuncionario(Configuracion.getConnectiongString);
            logica.CadenaConexion = Configuracion.getConnectiongString;
            string condicion = $"IDENTIFICACION = '{idAprobador}'";

            try
            {

                aprobador = logica.ObtenerAprobador(condicion);

                if (aprobador.Identificacion == idAprobador)
                {
                    txtFuncionario.Text = aprobador.NombreApellido;
                    txtFuncionario.Tag = aprobador.Identificacion;
                }
                else
                {
                    MessageBox.Show("No se ha podido cargar el aprobador. Debe haber un error al seleccionarlo.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //el siguiente evento se dispara en caso de que el usuario cambie el valor del combo box, haciendo que el texto de informacion cambie a pendiente o que permita escribir informacion según la opcion del combo box seleccionada.
        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == 0)
            {
                txtInfo.Text = "PENDIENTE";
                txtInfo.Enabled = false;
            }
            else
            {
                txtInfo.Text = string.Empty;
                txtInfo.Enabled = true;
            }
        }

        //el siguiente evento se encarga de crear la condicion para buscar la gira según la opción que el usuario haya seleccionado en el combo box. Posteriormente carga todas las solicitudes con ayuda de la función CargarSolicitudes.

        private void btnBuscarGira_Click(object sender, EventArgs e)
        {
            string condicion;

            try
            {

                if (!string.IsNullOrEmpty(txtInfo.Text))
                {

                    if (cboTipo.SelectedIndex == 0)
                    {

                        condicion = $"ESTADO = '{txtInfo.Text}'";
                    }
                    else if (cboTipo.SelectedIndex == 1)
                    {
                        condicion = $"ID_GIRA = '{txtInfo.Text}' AND ESTADO = 'PENDIENTE'";
                    }
                    else if (cboTipo.SelectedIndex == 2)
                    {
                        condicion = $"SOLICITANTE LIKE '%{txtInfo.Text}%' AND ESTADO = 'PENDIENTE'";
                    }
                    else
                    {
                        condicion = $"CHOFER LIKE '%{txtInfo.Text}%' AND ESTADO = 'PENDIENTE'";
                    }

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

        //la siguiente función llama a la lógica de solicitud y crea una lista de solicitudes para posteriormente cargarla en el datagrid.
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

        //el siguiente evento se dispara al presioanr el boton de consultar y abre el formulario para poder consultar una gria, mandándole la entidad que se obtiene mediante la logica de la solicitud con la id de la gira de la fila seleccionada en el datagrid.
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            entidadSolicitudGira solicitudConsultada;
            logicaSolicitudGira logicaSolicitud = new logicaSolicitudGira(Configuracion.getConnectiongString);
            try
            {
                if (dgvSolicitudes.SelectedRows.Count > 0)
                {
                    solicitudConsultada = logicaSolicitud.ObtenerSolicitud($"ID_GIRA = {dgvSolicitudes.SelectedRows[0].Cells[7].Value}");

                    frmConsultaSolicitud form = new frmConsultaSolicitud(solicitudConsultada);
                    form.SolicitudConsultada = solicitudConsultada;
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione la solicitud que desea consultar.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        //el siguiente evento permite al funcionario aprobar una gira. Para esto, primeramente asigna las variables de fehca inicio, fecha final, placa e id de chofer e id de gira las cuales provienen de la fila seleccionada en el datagridview. Después hace varias verificaciones con ayuda de varias funciones; esto se hace para verificar que un funcionario o un chofer no estén en una gira aprobada dentro de las fechas de fin y final de la gira que se va a aceptar. Al igual que con la placa del vehículo, se verifica que el vehículo tenga seguro, marchamo al día, y que no tenga próximas revisiones pendientes, así como que no esté en ninguna gira aprobada durante las dos fechas de la gira a aprobar. Posteriormente actualiza la solicitud con una función desde la lógica y limpia la lista una vez aprobada.
        private void btnAprobar_Click(object sender, EventArgs e)
        {
            List<entidadFuncionario> asistentes = new List<entidadFuncionario>();
            logicaFuncionario logicaFuncionario = new logicaFuncionario(Configuracion.getConnectiongString);
            logicaVehiculo logicaVehiculo = new logicaVehiculo(Configuracion.getConnectiongString);
            logicaSolicitudGira logicaSolicitud = new logicaSolicitudGira(Configuracion.getConnectiongString);
            string fechaInicio, fechaFinal, placaVehiculo, idChofer;
            int idGira;
            bool disponibilidadAsistentes = true;
            int i = 0;

            try
            {
                if (!string.IsNullOrEmpty(txtFuncionario.Text))
                {
                    if (dgvSolicitudes.SelectedRows.Count > 0)
                    {

                        fechaInicio = Convert.ToDateTime(dgvSolicitudes.SelectedRows[0].Cells[12].Value).Date.ToString("yyyy-MM-dd");
                        fechaFinal = Convert.ToDateTime(dgvSolicitudes.SelectedRows[0].Cells[13].Value).Date.ToString("yyyy-MM-dd");
                        idGira = Convert.ToInt32(dgvSolicitudes.SelectedRows[0].Cells[7].Value);
                        placaVehiculo = (dgvSolicitudes.SelectedRows[0].Cells[1].Value).ToString();
                        idChofer = dgvSolicitudes.SelectedRows[0].Cells[3].Value.ToString();

                        if (Convert.ToDateTime(fechaInicio) > (DateTime.Now.Date))
                        {

                            asistentes = logicaFuncionario.ListarAcompaniantes($"ID_GIRA = {dgvSolicitudes.SelectedRows[0].Cells[7].Value}");

                            while (disponibilidadAsistentes == true && i < asistentes.Count)
                            {
                                if (logicaFuncionario.VerificarDisponibilidadFuncionario($"F INNER JOIN SOLICITUDES_GIRAS SG ON F.IDENTIFICACION = SG.CHOFER WHERE SG.CHOFER = '{asistentes[i].Identificacion}' AND SG.ESTADO = 'APROBADA' AND ((SG.DIA_INICIO BETWEEN '{fechaInicio}' AND '{fechaFinal}') OR (SG.DIA_FINAL BETWEEN '{fechaInicio}' AND '{fechaFinal}') OR ('{fechaInicio}' BETWEEN DIA_INICIO AND DIA_FINAL) OR ('{fechaFinal}' BETWEEN DIA_INICIO AND DIA_FINAL)) UNION SELECT IDENTIFICACION FROM ACOMPANIANTES A INNER JOIN SOLICITUDES_GIRAS SG ON A.ID_GIRA = SG.ID_GIRA WHERE A.IDENTIFICACION = '{asistentes[i].Identificacion}' AND SG.ESTADO = 'APROBADA' AND ((SG.DIA_INICIO BETWEEN '{fechaInicio}' AND '{fechaFinal}') OR (SG.DIA_FINAL BETWEEN '{fechaInicio}' AND '{fechaFinal}') OR ('{fechaInicio}' BETWEEN DIA_INICIO AND DIA_FINAL) OR ('{fechaFinal}' BETWEEN DIA_INICIO AND DIA_FINAL))"))


                                {
                                    disponibilidadAsistentes = false;
                                }

                                i++;
                            }


                            if (disponibilidadAsistentes)
                            {

                                if (!logicaFuncionario.VerificarDisponibilidadFuncionario($"F INNER JOIN SOLICITUDES_GIRAS SG ON F.IDENTIFICACION = SG.CHOFER WHERE SG.CHOFER = '{idChofer}' AND SG.ESTADO = 'APROBADA' AND ((SG.DIA_INICIO BETWEEN '{fechaInicio}' AND '{fechaFinal}') OR (SG.DIA_FINAL BETWEEN '{fechaInicio}' AND '{fechaFinal}') OR ('{fechaInicio}' BETWEEN DIA_INICIO AND DIA_FINAL) OR ('{fechaFinal}' BETWEEN DIA_INICIO AND DIA_FINAL)) UNION SELECT IDENTIFICACION FROM ACOMPANIANTES A INNER JOIN SOLICITUDES_GIRAS SG ON A.ID_GIRA = SG.ID_GIRA WHERE A.IDENTIFICACION = '{idChofer}' AND SG.ESTADO = 'APROBADA' AND ((SG.DIA_INICIO BETWEEN '{fechaInicio}' AND '{fechaFinal}') OR (SG.DIA_FINAL BETWEEN '{fechaInicio}' AND '{fechaFinal}') OR ('{fechaInicio}' BETWEEN DIA_INICIO AND DIA_FINAL) OR ('{fechaFinal}' BETWEEN DIA_INICIO AND DIA_FINAL))"))
                                {


                                    if (!logicaVehiculo.VerificarDisponibilidadVehiculo($"V JOIN REVISIONES_TALLER RT ON V.PLACA = RT.PLACA WHERE V.PLACA = '{placaVehiculo}' AND (NOT EXISTS (SELECT PLACA FROM MARCHAMOS WHERE PLACA = '{placaVehiculo}' AND YEAR(FECHA) = YEAR('{fechaInicio}') OR YEAR (FECHA) = YEAR('{fechaFinal}')) OR EXISTS (SELECT 1 FROM REVISIONES_TALLER WHERE PLACA = '{placaVehiculo}' AND PROXIMA_REVISION BETWEEN '{fechaInicio}' AND '{fechaFinal}') OR EXISTS (SELECT 1 FROM REVISIONES_TECNICAS WHERE PLACA = '{placaVehiculo}' AND PROXIMA_FECHA BETWEEN '{fechaInicio}' AND '{fechaFinal}') OR EXISTS (SELECT 1 FROM SEGUROS_VEHICULOS WHERE PLACA = '{placaVehiculo}' AND VENCIMIENTO < '{fechaInicio}' OR VENCIMIENTO < '{fechaFinal}'))"))
                                    {

                                        if (logicaSolicitud.ActualizarSolicitud($"ID_GIRA = {idGira}", txtFuncionario.Tag.ToString         ()))
                                        {
                                            MessageBox.Show("Gira aprobada correctamente.", "Solicitud aprobada",                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            LimpiarLista();
                                        }
                                        else
                                        {
                                            MessageBox.Show("La gira no pudo ser aprobada.", "Error de datos", MessageBoxButtons.OK,            MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El vehículo de la solicitud se encuentra en una gira dentro de las fechas de       la solicitud que quiere aprobar, o no tiene marchamo o seguro al día, o asistirá a una               revisión, por lo que no fue posible aprobarla.", "Error de datos", MessageBoxButtons.OK,             MessageBoxIcon.Error);
                                    }


                                }
                                else
                                {
                                    MessageBox.Show("El chofer de la solicitud se encuentra en una gira dentro de las fechas de la solicitud que quiere aprobar, por lo que no fue posible aprobarla.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Hay un al menos un funcionario que se encuentra en una gira dentro de las fechas de la gira que quiere aprobar, por lo que no fue posible aprobarla.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            logicaSolicitud.ActualizarSolicitud($"ID_GIRA = {idGira}", txtFuncionario.Tag.ToString(), 2);
                            LimpiarLista();
                            MessageBox.Show("La gira que desea aprobar ya se encuentra vencida pues el día de inicio es menor o igual a la fecha actual. Se ha actualizado el estado de la gira a vencida.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para aprobar una gira debe seleccionarla primero.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Para aprobar una gira asegúrese de elegir un funcionario que tenga la capacidad de aprobar giras.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //el siguiente evento de rechazar hace lo mismo que el anterior evento pero con menos verificaciones. Este verifica que la fecha de inicio de la gira a aprobar no sea menor a la fecha de aprobacion (hoy) y en ese caso la actuatilizará como vencida. Si esto no pasa, simplemente actualiza la gira mediante una función sobrecargada y pone el estado en rechazada.
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            logicaSolicitudGira logicaSolicitud = new logicaSolicitudGira(Configuracion.getConnectiongString);
            string fechaInicio, fechaFinal;
            int idGira;

            try
            {
                if (!string.IsNullOrEmpty(txtFuncionario.Text))
                {
                    if (dgvSolicitudes.SelectedRows.Count > 0)
                    {

                        fechaInicio = Convert.ToDateTime(dgvSolicitudes.SelectedRows[0].Cells[12].Value).Date.ToString("yyyy-MM-dd");
                        fechaFinal = Convert.ToDateTime(dgvSolicitudes.SelectedRows[0].Cells[13].Value).Date.ToString("yyyy-MM-dd");
                        idGira = Convert.ToInt32(dgvSolicitudes.SelectedRows[0].Cells[7].Value);

                        if (Convert.ToDateTime(fechaInicio) > (DateTime.Now.Date))
                        {
                            if (logicaSolicitud.ActualizarSolicitud($"ID_GIRA = {idGira}", txtFuncionario.Tag.ToString(), 1))
                            {
                                LimpiarLista();
                                MessageBox.Show("Gira rechazada correctamente.", "Solicitud rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("La gira no pudo ser rechazada.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            logicaSolicitud.ActualizarSolicitud($"ID_GIRA = {idGira}", txtFuncionario.Tag.ToString(), 2 );
                            LimpiarLista();
                            MessageBox.Show("La gira que desea rechazar ya se encuentra vencida pues el día de inicio es menor o igual a la fecha actual. El estado de la gira se ha actualizado a vencida.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para rechazar una gira debe seleccionarla primero.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Para rechazar una gira asegúrese de elegir un funcionario que tenga la capacidad de aprobar o rechazar giras.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LimpiarLista()
        {
            List<entidadSolicitudGira> lista = null;

            dgvSolicitudes.DataSource = lista;
        }
    }
}
