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
    public class logicaSolicitudGira
    {

        //atributos

        private string cadenaConexion;

        //propiedades
        public string CadenaConexion { get => cadenaConexion; set => cadenaConexion = value; }

        //constructor

        public logicaSolicitudGira(string _CadenaConexion)
        {
            cadenaConexion += _CadenaConexion;
        }

        //metodos

        public int InsertarSolicitudGira(entidadSolicitudGira solicitud)
        {
            int resultado = -1;
            datosSolicitudGira AccesoDatos = new datosSolicitudGira(cadenaConexion);
            try
            {
                resultado = AccesoDatos.InsertarSolicitudGira(solicitud);
            }
            catch (Exception e)
            {
                throw e;
            }
            return resultado;
        }

        public int InsertarAcompaniante(string idAcompaniante, int idGira)
        {
            int resultado;

            datosSolicitudGira datos = new datosSolicitudGira(cadenaConexion);
            try
            {
                resultado = datos.InsertarAcompaniantes(idAcompaniante, idGira);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public int InsertarLugares(string origen, string destino, int idGira)
        {
            int resultado;

            datosSolicitudGira datos = new datosSolicitudGira(cadenaConexion);
            try
            {
                resultado = datos.InsertarLugares(origen, destino, idGira);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public List<entidadSolicitudGira> ListarSolicitudes(string condicion = "")
        {
            List<entidadSolicitudGira> resultado;
            datosSolicitudGira accesoDatos = new datosSolicitudGira(CadenaConexion);

            try
            {
                resultado = accesoDatos.ListarSolicitudes(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public entidadSolicitudGira ObtenerSolicitud(string condicion)
        {
            entidadSolicitudGira resultado;
            datosSolicitudGira accesoDatos = new datosSolicitudGira(CadenaConexion);

            try
            {
                resultado = accesoDatos.ObtenerSolicitud(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }
    }
}
