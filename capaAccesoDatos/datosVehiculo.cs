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
    public class datosVehiculo
    {

        private string cadenaConexion;

        public datosVehiculo(string _cadenaConexion)
        {
            cadenaConexion = _cadenaConexion;
        }

        public List<entidadVehiculo> ListarVehiculos(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlDataAdapter adapter = null;

            List<entidadVehiculo> vehiculos = new List<entidadVehiculo>();
            string sentencia = "SELECT PLACA, MARCA, MODELO, COMBUSTIBLE, ESTILO, ID_CENTRO, CAPACIDAD, LICENCIA_REQUERIDA FROM VEHICULOS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} WHERE {condicion}";
            }

            try
            {
                adapter = new SqlDataAdapter(sentencia, connection);
                adapter.Fill(datos, "Vehiculos");

                vehiculos = (from DataRow registro in datos.Tables[0].Rows
                                select new entidadVehiculo()
                                {
                                    Placa = Convert.ToString(registro[0]),
                                    Marca = Convert.ToString(registro[1]),
                                    Modelo = Convert.ToString(registro[2]),
                                    Combustible = Convert.ToString(registro[3]),
                                    Estilo = Convert.ToString(registro[4]),
                                    Id_Centro = Convert.ToInt32(registro[5]),
                                    Capacidad = Convert.ToInt32(registro[6]),
                                    LicenciaRequerida = Convert.ToString(registro[7])
                                }).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return vehiculos;
        }

        public entidadVehiculo ObtenerVehiculo(string condicion)
        {
            entidadVehiculo vehiculo = new entidadVehiculo();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            SqlDataReader datos;
            string sentencia = "SELECT PLACA, MARCA, MODELO, COMBUSTIBLE, ESTILO, ID_CENTRO, CAPACIDAD, LICENCIA_REQUERIDA FROM VEHICULOS";

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
                    vehiculo.Placa = datos.GetString(0);
                    vehiculo.Marca = datos.GetString(1);
                    vehiculo.Modelo = datos.GetString(2);
                    vehiculo.Combustible = datos.GetString(3);
                    vehiculo.Estilo = datos.GetString(4);
                    vehiculo.Id_Centro = datos.GetInt32(5);
                    vehiculo.Capacidad = datos.GetInt32(6);
                    vehiculo.LicenciaRequerida = datos.GetString(7);

                }

                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return vehiculo;
        }
    }
}
