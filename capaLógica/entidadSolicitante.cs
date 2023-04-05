using capaLógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class entidadSolicitante:entidadFuncionario
    {

        //atributos

        bool aprobador;


        //propiedades

        public bool Aprobador { get => aprobador; set => aprobador = value; }

        //constructor

        public entidadSolicitante()
        {
            Aprobador = true;
        }


    }
}
