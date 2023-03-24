using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class entidadSolicitante
    {

        //atributos

        private string identificacion, nombre, apellidoUno, apellidoDos;
        int idCentro;

        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoUno { get => apellidoUno; set => apellidoUno = value; }
        public string ApellidoDos { get => apellidoDos; set => apellidoDos = value; }
        public int IdCentro { get => idCentro; set => idCentro = value; }
        public string NombreApellido { get { return $"{Nombre} {ApellidoUno} {ApellidoDos}"; } }

        //constructor

        public entidadSolicitante()
        {
            Identificacion = string.Empty;
            Nombre = string.Empty;
            ApellidoUno = string.Empty;
            ApellidoDos = string.Empty;
            IdCentro = -1;
        }


    }
}
