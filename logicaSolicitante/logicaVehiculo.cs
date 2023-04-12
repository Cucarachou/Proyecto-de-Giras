using capaAccesoDatos;
using capaLógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicaSolicitante
{
    public class logicaVehiculo
    {

        //atributos

        private string cadenaConexion;

        //propiedades
        public string CadenaConexion { get => cadenaConexion; set => cadenaConexion = value; }

        //constructor

        public logicaVehiculo(string _CadenaConexion) 
        {
            cadenaConexion += _CadenaConexion;
        }

        public List<entidadVehiculo> ListarVehiculos(string condicion = "")
        {
            List<entidadVehiculo> resultado;
            datosVehiculo accesoDatos = new datosVehiculo(CadenaConexion);

            try
            {
                resultado = accesoDatos.ListarVehiculos(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }


        public entidadVehiculo ObtenerVehiculo(string condicion)
        {
            entidadVehiculo resultado;
            datosVehiculo accesoDatos = new datosVehiculo(CadenaConexion);

            try
            {
                resultado = accesoDatos.ObtenerVehiculo(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public bool VerificarDisponibilidadVehiculo(string condicion)
        {
            bool resultado = false;
            datosVehiculo accesoDatos = new datosVehiculo(CadenaConexion);

            try
            {
                resultado = accesoDatos.VerificarDisponibilidadVehiculo(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }
    }
}
