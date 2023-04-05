using capaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaLógica;

namespace capaAccesoDatos
{
    public class datosLicencia
    {

        //atributos
        private string cadenaConexion;

        //constructor
        public datosLicencia(string _cadenaConexion)
        {
            cadenaConexion = _cadenaConexion;
        }

        //métodos

        public List<entidadLicencia> ListarLicencias(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlDataAdapter adapter = null;

            List<entidadLicencia> licencias = new List<entidadLicencia>();
            string sentencia = "SELECT TIPO_LICENCIA, IDENTIFICACION FROM LICENCIAS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} WHERE {condicion}";
            }

            try
            {
                adapter = new SqlDataAdapter(sentencia, connection);
                adapter.Fill(datos, "Licencias");

                licencias = (from DataRow registro in datos.Tables[0].Rows
                                select new entidadLicencia()
                                {
                                    TipoLicencia = Convert.ToString(registro[0]),
                                    Identificacion = Convert.ToString(registro[1]),
                                }).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return licencias;
        }
    }
}
