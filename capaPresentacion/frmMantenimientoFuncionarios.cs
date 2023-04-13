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
    public partial class frmMantenimientoFuncionarios : Form
    {
        public frmMantenimientoFuncionarios()
        {
            InitializeComponent();

        }

        private void frmMantenimientoFuncionarios_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInfo.Text = string.Empty;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion;

            try
            {
                if (!string.IsNullOrEmpty(txtInfo.Text))
                {
                    
                    if (cboTipo.SelectedIndex == 0)
                    {
                        condicion = $"IDENTIFICACION LIKE '%{txtInfo.Text}%'";
                    }
                    else if (cboTipo.SelectedIndex == 1)
                    {
                        condicion = $"CONCAT(NOMBRE, ' ', APELLIDO_UNO, ' ', APELLIDO_DOS) LIKE '%{txtInfo.Text}%'";
                    }
                    else
                    {
                        condicion = $"INNER JOIN CENTROS_DE_FORMACION ON FUNCIONARIOS.ID_CENTRO = CENTROS_DE_FORMACION.ID_CENTRO WHERE CENTROS_DE_FORMACION.NOMBRE LIKE '%{txtInfo.Text}%''";
                    }

                    CargarFuncionarios(condicion);
                }
                else
                {
                    MessageBox.Show("Por favor inserte la información requerida para la búsqueda de funcionarios.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFuncionarios(string condicion = "")
        {
            logicaFuncionario logica = new logicaFuncionario(Configuracion.getConnectiongString);
            List<entidadFuncionario> lista;

            try
            {

                lista = logica.ListarFuncionarios(condicion);
                lista = ObtenerNombresCentro(lista);

                dgvFuncionarios.DataSource = lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        private List<entidadFuncionario> ObtenerNombresCentro(List<entidadFuncionario> lista)
        {
            logicaCentroFormacion logicaCentro = new logicaCentroFormacion(Configuracion.getConnectiongString);
            entidadCentroFormacion centro = new entidadCentroFormacion();

            for (int i = 0; i < lista.Count; i++)
            {
                centro = logicaCentro.ObtenerCentroFormacion($"ID_CENTRO = {lista[i].IdCentro}");
                lista[i].NombreCentro = centro.Nombre;
            }

            return lista;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string identificacion;
            logicaFuncionario logicaFuncionario = new logicaFuncionario(Configuracion.getConnectiongString);
            bool resultado;

            try
            {
                if (dgvFuncionarios.SelectedRows.Count > 0)
                {
                    identificacion = dgvFuncionarios.SelectedRows[0].Cells[0].Value.ToString();
                    resultado = logicaFuncionario.VerificarDisponibilidadFuncionario($"F WHERE F.IDENTIFICACION = '{identificacion}' AND (EXISTS (SELECT 1 FROM SOLICITUDES_GIRAS SG WHERE SG.CHOFER = F.IDENTIFICACION AND SG.DIA_INICIO <= GETDATE() AND SG.DIA_FINAL >= GETDATE() AND SG.ESTADO IN ('PENDIENTE', 'APROBADA')) OR EXISTS (SELECT 1 FROM ACOMPANIANTES A INNER JOIN SOLICITUDES_GIRAS SG ON A.ID_GIRA = SG.ID_GIRA WHERE A.IDENTIFICACION = F.IDENTIFICACION AND SG.DIA_INICIO <= GETDATE() AND SG.DIA_FINAL >= GETDATE() AND SG.ESTADO IN ('PENDIENTE', 'APROBADA')))");

                    if (!resultado)
                    {
                        resultado = logicaFuncionario.EliminarFuncionario(identificacion);

                        if (resultado)
                        {
                            MessageBox.Show("Funcionario eliminado satisfactoriamente.", "Funcionario eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarTodo();
                        }
                        else
                        {
                            MessageBox.Show("Ha habido un error al eliminar al funcionario.", "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El funcionaro seleccionado no se ha podido eliminar pues tiene una gira aprobada o pendiente en la fecha actual.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione el funcionario que desea eliminar.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAniadirFuncionario frmAniadirFuncionario = new frmAniadirFuncionario(null);
            frmAniadirFuncionario.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvFuncionarios.SelectedRows.Count > 0)
            {
                frmAniadirFuncionario frmAniadirFuncionario = new frmAniadirFuncionario(dgvFuncionarios.SelectedRows[0].Cells[0].Value.ToString());
                LimpiarTodo();
                frmAniadirFuncionario.Show();

            }
            else
            {
                MessageBox.Show("Por favor seleccione el funcionario que desea modificar.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarTodo()
        {
            List<entidadFuncionario> lista = new List<entidadFuncionario>();

            dgvFuncionarios.DataSource = lista;
            txtInfo.Clear();
            cboTipo.SelectedIndex = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }
    }
}
