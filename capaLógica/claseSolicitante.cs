using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaLógica
{
    public class claseSolicitante
    {

        //atributos

        private string nombreApellidos;
        private string identificacion;

        //constructor
        public string NombreApellidos { get => nombreApellidos; set => nombreApellidos = value; }
        public string Identificacion { get => identificacion; set => identificacion = value; }

        //constructor

        public claseSolicitante()
        {
            nombreApellidos = string.Empty;
            identificacion = string.Empty;
        }

        public claseSolicitante(string nombreApellidos, string identificacion)
        {
            this.nombreApellidos = nombreApellidos;
            this.identificacion = identificacion;
        }

    }
}
