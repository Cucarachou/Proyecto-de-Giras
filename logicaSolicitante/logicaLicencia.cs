using capaAccesoDatos;
using capaLógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicaSolicitante
{
    public class logicaLicencia
    {

        //atributos

        private string cadenaConexion;

        //propiedades
        public string CadenaConexion { get => cadenaConexion; set => cadenaConexion = value; }

        //constructor

        public logicaLicencia(string _CadenaConexion)
        {
            cadenaConexion += _CadenaConexion;
        }

        //metodos

        public List<entidadLicencia> ListarLicencias(string condicion = "")
        {
            List<entidadLicencia> resultado;
            datosLicencia accesoDatos = new datosLicencia(CadenaConexion);

            try
            {
                resultado = accesoDatos.ListarLicencias(condicion);
            }
            catch (Exception ex)
            { 

                throw ex;
            }

            return resultado;
        }

    }
}
