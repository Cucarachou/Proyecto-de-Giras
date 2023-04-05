using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaLógica
{
    public class entidadVehiculo
    {

        //atributos

        private string placa, marca, modelo, combustible, estilo, licenciaRequerida;
        private int disponibilidad, id_Centro, capacidad;

        //propiedades
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Combustible { get => combustible; set => combustible = value; }
        public string Estilo { get => estilo; set => estilo = value; }
        public string LicenciaRequerida { get => licenciaRequerida; set => licenciaRequerida = value; }
        public int Disponibilidad { get => disponibilidad; set => disponibilidad = value; }
        public int Id_Centro { get => id_Centro; set => id_Centro = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }

        //constructor

        public entidadVehiculo()
        {
            placa = string.Empty;
            marca = string.Empty;
            modelo = string.Empty;
            combustible = string.Empty;
            estilo = string.Empty;
            licenciaRequerida = string.Empty;
            disponibilidad = 1;
            id_Centro = 0;
            capacidad = 0;
        }

    }
}
