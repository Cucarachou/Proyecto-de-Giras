using capaAccesoDatos;
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

    }
}
