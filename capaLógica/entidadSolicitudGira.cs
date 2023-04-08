using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaLógica
{
    public class entidadSolicitudGira
    {

        //atributos
        private string estado, horaInicio, horaFin, solicitante, chofer, aprobador, placa, justificacion;
        private int idGira, idCentro, extemporanea, cantidadFuncionarios;
        private DateTime diaInicio, diaFinal, diaSolicitud;


        //propiedades
        public string Estado { get => estado; set => estado = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Aprobador { get => aprobador; set => aprobador = value; }
        public string Chofer { get => chofer; set => chofer = value; }
        public string Solicitante { get => solicitante; set => solicitante = value; }
        public string HoraInicio { get => horaInicio; set => horaInicio = value; }
        public string HoraFin { get => horaFin; set => horaFin = value; }
        public int IdGira { get => idGira; set => idGira = value; }
        public int IdCentro { get => idCentro; set => idCentro = value; }
        public int Extemporanea { get => extemporanea; set => extemporanea = value; }
        public string Justificacion { get => justificacion; set => justificacion = value; }
        public DateTime DiaSolicitud { get => diaSolicitud; set => diaSolicitud = value; }
        public DateTime DiaInicio { get => diaInicio; set => diaInicio = value; }
        public DateTime DiaFinal { get => diaFinal; set => diaFinal = value; }
        public int CantidadFuncionarios { get => cantidadFuncionarios; set => cantidadFuncionarios = value; }

        public entidadSolicitudGira()
        {
            Estado = string.Empty;
            Placa = string.Empty;
            Aprobador = string.Empty;
            Chofer = string.Empty;
            Solicitante = string.Empty;
            HoraInicio = string.Empty;
            HoraFin = string.Empty;
            IdGira = -1;
            IdCentro = -1;
            Extemporanea = 0;
            DiaSolicitud = DateTime.MinValue;
            DiaInicio = DateTime.MinValue;
            DiaFinal = DateTime.MinValue;   
            CantidadFuncionarios = -1;
        }
    }
}
