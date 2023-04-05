using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaLógica
{
    public class entidadLicencia
    {
        //atributos
        private string tipoLicencia, identificacion;

        //propiedades
        public string TipoLicencia { get => tipoLicencia; set => tipoLicencia = value; }
        public string Identificacion { get => identificacion; set => identificacion = value; }

        //constructor

        public entidadLicencia()
        {
            tipoLicencia = string.Empty;
            identificacion = string.Empty;
        }
    }
}
