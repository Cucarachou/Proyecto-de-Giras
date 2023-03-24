using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class entidadLugar
    {

        //atributos.
        //estos atributos son para almacenar la información de los diferentes días de una gira
        //y luego poder hacer su respectiva verificación, así como poder mostrar mediante un arreglo
        //la información que el usuario vaya agregando con una herramienta

        private int id;
        private string origen, destino;

        //propiedades
        public string Origen { get => origen; set => origen = value; }
        public string Destino { get => destino; set => destino = value; }
        public int Id { get => id; set => id = value; }


        //constructor

        //constructor inicializador
        public entidadLugar()
        {
            id = 0;
            origen = string.Empty;
            destino = string.Empty;
        }

        //constructor para almacenar la información que vienen desde la capa de presentación

        public entidadLugar(int id, DateTime horaInicio, DateTime horaFinal, DateTime fecha, string origen, string destino)
        {
            this.id = id;
            this.origen = origen;
            this.destino = destino;
        }
    }
}
