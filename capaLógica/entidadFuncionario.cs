
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
        private string identificacion, nombre, apellidoUno, apellidoDos, telefono, correo, nombreCentro;
        int idCentro;
        bool activo, aprobador, chofer;

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

        public bool Aprobador { get => aprobador; set => aprobador = value; }
        public bool Chofer { get => chofer; set => chofer = value; }
        
        public string NombreCentro { get => nombreCentro; set => nombreCentro = value; }
        // constructor

        public entidadFuncionario()
        {
            Identificacion = string.Empty;
            Nombre = string.Empty;
            ApellidoUno = string.Empty;
            ApellidoDos = string.Empty;
            Telefono = string.Empty;
            Correo = string.Empty;
            IdCentro = -1;
            Activo = true;
            Aprobador = false;
            Chofer = false;
            NombreCentro= string.Empty;
        }

        public entidadFuncionario(string _identificacion, string _nombre, string _apellidoUno, string _apellidoDos, string _telefono, string _correo, int _idCentro, bool _activo, bool _aprobador, bool _chofer)
        {
            Identificacion = _identificacion;
            Nombre = _nombre;
            ApellidoUno = _apellidoUno;
            ApellidoDos = _apellidoDos;
            Telefono = _telefono;
            Correo = _correo;
            IdCentro = _idCentro;
            Activo = _activo;
            Aprobador = _aprobador;
            Chofer = _chofer;
            NombreCentro = string.Empty;
        }
    }
}
