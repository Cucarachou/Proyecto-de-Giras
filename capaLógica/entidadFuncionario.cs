
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaLógica
{
    public class entidadFuncionario
    {

        //atributos
        private string identificacion, nombre, apellidoUno, apellidoDos, telefono, correo;
        int idCentro;
        bool activo;

        //propiedades

        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoUno { get => apellidoUno; set => apellidoUno = value; }
        public string ApellidoDos { get => apellidoDos; set => apellidoDos = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public int IdCentro { get => idCentro; set => idCentro = value; }
        public bool Activo { get => activo; set => activo = value; }

        //propiedad que devuelve el nombre completo
        public string NombreApellido { get { return $"{Nombre} {ApellidoUno} {ApellidoDos}"; } }

        // constructor

        public entidadFuncionario()
        {
            identificacion = string.Empty;
            nombre = string.Empty;
            apellidoUno= string.Empty;
            apellidoDos= string.Empty;
            telefono = string.Empty;
            correo = string.Empty;
            idCentro = -1;
            activo = true;
        }
    }
}
