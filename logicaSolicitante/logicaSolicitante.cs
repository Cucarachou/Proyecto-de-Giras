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

        public logicaSolicitante(string _cadenaConexion)
        {
            cadenaConexion = _cadenaConexion;
        }

        public List<entidadSolicitante> ListarSolicitantes(string condicion = "")
        {
            List<entidadSolicitante> resultado;
            datosFuncionario accesoDatos = new datosFuncionario(cadenaConexion);

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
    }
}
