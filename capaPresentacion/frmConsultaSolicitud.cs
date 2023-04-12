using capaLógica;
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
    public partial class frmConsultaSolicitud : Form
    {

        //entidad de la gira que consulta el usuario, la cual se recibe desde un formulario principal

        entidadSolicitudGira solicitudConsultada;
        public entidadSolicitudGira SolicitudConsultada { get => solicitudConsultada; set => solicitudConsultada = value; }

        public frmConsultaSolicitud(entidadSolicitudGira solicitud)
        {
            solicitudConsultada = solicitud;
            InitializeComponent();
            txtIdSolicitud.Text = solicitudConsultada.IdGira.ToString();
            txtEstado.Text = solicitudConsultada.Estado;
            txtHoraInicio.Text = solicitudConsultada.HoraInicio;
            txtHoraFin.Text = solicitudConsultada.HoraFin;
            txtDiaInicio.Text = solicitudConsultada.DiaInicio.ToString("dd, MM, YYYY");
            txtDiaFin.Text = solicitudConsultada.DiaFinal.ToString("dd, MM, YYYY");

            if (solicitudConsultada.Extemporanea == false)
            {
                chkExtemporanea.Checked = false;
            }
            else
            {
                chkExtemporanea.Checked = true;
                rtbJustificacion.Text = solicitudConsultada.Justificacion;
            }

            txtPlaca.Text = solicitudConsultada.Placa;

        }

       
    }
}
