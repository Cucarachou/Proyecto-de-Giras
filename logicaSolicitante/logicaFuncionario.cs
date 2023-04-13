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

        public entidadFuncionario ObtenerFuncionario(string condicion)
        {
            entidadFuncionario resultado;
            datosFuncionario accesoDatos = new datosFuncionario(CadenaConexion);

            try
            {
                resultado = accesoDatos.ObtenerFuncionario(condicion);
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

        public entidadFuncionario ObtenerAprobador(string condicion)
        {
            entidadFuncionario resultado;
            datosFuncionario accesoDatos = new datosFuncionario(CadenaConexion);

            try
            {
                resultado = accesoDatos.ObtenerAprobador(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public List<entidadFuncionario> ListarAcompaniantes(string condicion)
        {
            List<entidadFuncionario> resultado;
            datosFuncionario accesoDatos = new datosFuncionario(CadenaConexion);

            try
            {
                resultado = accesoDatos.ListarAcompaniantes(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }
        public bool VerificarDisponibilidadFuncionario(string condicion)
        {
            bool resultado = false;
            datosFuncionario accesoDatos = new datosFuncionario(CadenaConexion);

            try
            {
                resultado = accesoDatos.VerificarDisponibilidadFuncionario(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public List<entidadFuncionario> ListarFuncionarios(string condicion = "")
        {
            List<entidadFuncionario> resultado;
            datosFuncionario accesoDatos = new datosFuncionario(CadenaConexion);

            try
            {
                resultado = accesoDatos.ListarFuncionarios(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }


        public bool EliminarFuncionario(string identificacion)
        {
            bool resultado;
            datosFuncionario accesoDatos = new datosFuncionario(CadenaConexion);

            try
            {
                resultado = accesoDatos.EliminarFuncionario(identificacion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }


        public string InsertarFuncionario(entidadFuncionario funcionario)
        {
            string resultado = string.Empty;
            datosFuncionario AccesoDatos = new datosFuncionario(cadenaConexion);
            try
            {
                resultado = AccesoDatos.InsertarFuncionario(funcionario);
            }
            catch (Exception e)
            {
                throw e;
            }
            return resultado;
        }

        public bool ModificarFuncionario(entidadFuncionario funcionario)
        {
            bool resultado = false;
            datosFuncionario AccesoDatos = new datosFuncionario(cadenaConexion);
            try
            {
                resultado = AccesoDatos.ModificarFuncionario(funcionario);
            }
            catch (Exception e)
            {
                throw e;
            }
            return resultado;
        }
    }
}
