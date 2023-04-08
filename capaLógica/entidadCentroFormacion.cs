using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaLógica
{
    public class entidadCentroFormacion
    {

        //atributos
        private int idCentro;
        private string nombre, ubicacion, regional;

        //propiedades
        public int IdCentro { get => idCentro; set => idCentro = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string Regional { get => regional; set => regional = value; }

        //constructor

        public entidadCentroFormacion()
        {
            IdCentro = -1;
            Nombre = string.Empty;
            Ubicacion = string.Empty;
            Regional = string.Empty;
        }
        //metodos

    }
}
