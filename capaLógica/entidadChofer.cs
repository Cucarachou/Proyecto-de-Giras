using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaLógica
{
    public class entidadChofer:entidadFuncionario
    {

        //atributos

        private bool chofer = true;

        //propiedades
        public bool Chofer { get => chofer; set => chofer = value; }

        //constructor

        public entidadChofer() 
        {
            chofer = false;
        }

    }
}
