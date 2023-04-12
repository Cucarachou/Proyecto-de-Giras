using capaEntidades;
using capaLógica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaAccesoDatos
{
    public class datosCentroFormacion
    {

        //atributos
        private string cadenaConexion;

        //constructor
        public datosCentroFormacion(string _cadenaConexion)
        {
            cadenaConexion = _cadenaConexion;
        }

        //métodos

        public entidadCentroFormacion ObtenerCentroFormacion(string condicion)
        {
            entidadCentroFormacion centro = new entidadCentroFormacion();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            SqlDataReader datos;
            string sentencia = "SELECT ID_CENTRO, NOMBRE, UBICACION, REGIONAL FROM CENTROS_DE_FORMACION";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} WHERE {condicion}";
            }

            command.CommandText = sentencia;

            try
            {
                connection.Open();
                datos = command.ExecuteReader();

                if (datos.HasRows)
                {
                    datos.Read();
                    centro.IdCentro = datos.GetInt32(0);
                    centro.Nombre = datos.GetString(1);
                    centro.Ubicacion = datos.GetString(2);
                    centro.Regional = datos.GetString(3);

                }

                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return centro;
        }

        public string ObtenerNombreCentro(string condicion)
        {
            entidadCentroFormacion centro = new entidadCentroFormacion();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            SqlDataReader datos;
            string sentencia = "SELECT ID_CENTRO, NOMBRE, UBICACION, REGIONAL FROM CENTROS_DE_FORMACION";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} WHERE {condicion}";
            }

            command.CommandText = sentencia;

            try
            {
                connection.Open();
                datos = command.ExecuteReader();

                if (datos.HasRows)
                {
                    datos.Read();
                    centro.IdCentro = datos.GetInt32(0);
                    centro.Nombre = datos.GetString(1);
                    centro.Ubicacion = datos.GetString(2);
                    centro.Regional = datos.GetString(3);

                }

                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return centro.Nombre;
        }

        public List<entidadCentroFormacion> ListarCentros(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlDataAdapter adapter = null;

            List<entidadCentroFormacion> centros = new List<entidadCentroFormacion>();
            string sentencia = "SELECT ID_CENTRO, NOMBRE, UBICACION, REGIONAL FROM CENTROS_DE_FORMACION";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} WHERE {condicion}";
            }

            try
            {
                adapter = new SqlDataAdapter(sentencia, connection);
                adapter.Fill(datos, "Centros");

                centros = (from DataRow registro in datos.Tables[0].Rows
                            select new entidadCentroFormacion()
                            {
                                IdCentro = Convert.ToInt32(registro[0]),
                                Nombre = registro[1].ToString(),
                                Ubicacion = registro[2].ToString(),
                                Regional = registro[3].ToString()   
                            }).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return centros;
        }
    }
}
