using capaAccesoDatos;
using capaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaLogica
{
    public class logicaSolicitante
    {

        private string cadenaConexion;

        public string CadenaConexion { get => cadenaConexion; set => cadenaConexion = value; }

        public logicaSolicitante(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }


        //méotodo que pide a la capa de acceso a datos la lista de solicitantes según una condición
        public List<entidadSolicitante> ListarSolicitantes(string condicion = "")
        {
            List<entidadSolicitante> resultado;
            datosFuncionario accesoDatos = new datosFuncionario(CadenaConexion);

            try
            {
                resultado = accesoDatos.ListarSolicitantes(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        //método que obtiene un solo solicitante a partir de una condición, la pide a la capa de datos.
        public entidadSolicitante ObtenerSolicitante(string condicion)
        {
            entidadSolicitante resultado;
            datosFuncionario accesoDatos = new datosFuncionario(CadenaConexion);

            try
            {
                resultado = accesoDatos.ObtenerSolicitante(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }
    }
}
