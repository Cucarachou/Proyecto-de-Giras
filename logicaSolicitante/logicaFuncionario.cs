  using capaAccesoDatos;
using capaEntidades;
using capaLógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaLogica
{
    public class logicaFuncionario
    {

        private string cadenaConexion;

        public string CadenaConexion { get => cadenaConexion; set => cadenaConexion = value; }

        public logicaFuncionario(string _cadenaConexion)
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

        //método que obtiene una lista de funcionarios que son chóferes y cumplen una condición

        public List<entidadChofer> ListarChoferes(string condicion = "")
        {
            List<entidadChofer> resultado;
            datosFuncionario accesoDatos = new datosFuncionario(CadenaConexion);

            try
            {
                resultado = accesoDatos.ListarChoferes(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public entidadChofer ObtenerChofer(string condicion)
        {
            entidadChofer resultado;
            datosFuncionario accesoDatos = new datosFuncionario(CadenaConexion);

            try
            {
                resultado = accesoDatos.ObtenerChofer(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }
    }
}
