using capaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaAccesoDatos
{
    public class datosFuncionario
    {

        private string cadenaConexion;

        public datosFuncionario(string _cadenaConexion)
        {
            cadenaConexion = _cadenaConexion;
        }

        public entidadSolicitante ObtenerSolicitante(string condicion)
        {
            entidadSolicitante solicitante = new entidadSolicitante();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            SqlDataReader datos;
            string sentencia = "SELECT IDENTIFICACION, NOMBRE, APELLIDO_UNO, APELLIDO_DOS, ID_CENTRO FROM FUNCIONARIOS";

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
                    solicitante.Identificacion = datos.GetString(0);
                    solicitante.Nombre = datos.GetString(1);
                    solicitante.ApellidoUno = datos.GetString(2);
                    solicitante.ApellidoDos = datos.GetString(3);
                    solicitante.IdCentro = datos.GetInt32(4);
                }

                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return solicitante;
        }

        public List<entidadSolicitante> ListarSolicitantes(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlDataAdapter adapter = null;

            List<entidadSolicitante> solicitantes = new List<entidadSolicitante>();
            string sentencia = "SELECT IDENTIFICACION, NOMBRE, APELLIDO_UNO, APELLIDO_DOS, ID_CENTRO FROM FUNCIONARIOS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} WHERE {condicion}";
            }

            try
            {
                adapter = new SqlDataAdapter(sentencia, connection);
                adapter.Fill(datos, "Solicitantes");

                solicitantes = (from DataRow registro in datos.Tables[0].Rows select new entidadSolicitante()
                                {
                                    Identificacion = Convert.ToString(registro[0]),
                                    Nombre = Convert.ToString(registro[1]),
                                    ApellidoUno = Convert.ToString(registro[2]),
                                    ApellidoDos = Convert.ToString(registro[3]),
                                    IdCentro = Convert.ToInt32(registro[4])
                                }).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return solicitantes;
        }
    }
}

