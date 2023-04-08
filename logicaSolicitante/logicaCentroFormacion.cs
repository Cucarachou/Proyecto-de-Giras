using capaAccesoDatos;
using capaEntidades;
using capaLógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicaSolicitante
{
    public class logicaCentroFormacion
    {

        //atributos
        private string cadenaConexion;

        //propiedades
        public string CadenaConexion { get => cadenaConexion; set => cadenaConexion = value; }

        //constructor
        public logicaCentroFormacion(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        //metodos

        public entidadCentroFormacion ObtenerCentroFormacion(string condicion)
        {
            entidadCentroFormacion resultado;
            datosCentroFormacion accesoDatos = new datosCentroFormacion(CadenaConexion);

            try
            {
                resultado = accesoDatos.ObtenerCentroFormacion(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public List<entidadCentroFormacion> ListarCentros(string condicion = "")
        {
            List<entidadCentroFormacion> resultado;
            datosCentroFormacion accesoDatos = new datosCentroFormacion(CadenaConexion);

            try
            {
                resultado = accesoDatos.ListarCentros(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }


    }
}
