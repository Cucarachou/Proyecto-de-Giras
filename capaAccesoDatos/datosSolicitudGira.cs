using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaLógica;
using System.Xml;
using capaEntidades;

namespace capaAccesoDatos
{
    public class datosSolicitudGira
    {

        private string cadenaConexion;
        private int idGira;
        public datosSolicitudGira(string _cadenaConexion)
        {
            cadenaConexion = _cadenaConexion;
        }

        public int IdGira { get => idGira; }

        public int InsertarSolicitudGira(entidadSolicitudGira solicitud)
        {
            int resultado = -1;
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            string sentencia;
            try
            {
                sentencia = "SP_INSERTARSOLICITUDGIRA";
                comando.CommandText = sentencia;
                comando.CommandType = CommandType.StoredProcedure;
                //parametros de entrada
                comando.Parameters.AddWithValue("@FECHA_SOLICITUD", solicitud.DiaSolicitud);
                comando.Parameters.AddWithValue("@FECHA_INICIO", solicitud.DiaInicio);
                comando.Parameters.AddWithValue("@FECHA_FINAL", solicitud.DiaFinal);
                comando.Parameters.AddWithValue("@HORA_INICIO", solicitud.HoraInicio);
                comando.Parameters.AddWithValue("@HORA_FINAL", solicitud.HoraFin);
                comando.Parameters.AddWithValue("@EXTEMPORANEA", solicitud.Extemporanea);
                comando.Parameters.AddWithValue("@JUSTIFICACION", solicitud.Justificacion);
                comando.Parameters.AddWithValue("@CHOFER", solicitud.Chofer);
                comando.Parameters.AddWithValue("@SOLICITANTE", solicitud.Solicitante);
                comando.Parameters.AddWithValue("@PLACA", solicitud.Placa);
                comando.Parameters.AddWithValue("@ID_CENTRO", solicitud.IdCentro);


                //parametros de salida
                comando.Parameters.Add("@ID_GIRA", SqlDbType.Int).Direction = ParameterDirection.Output;
                cnn.Open();
                comando.ExecuteNonQuery();

                resultado = Convert.ToInt32(comando.Parameters["@ID_GIRA"].Value);
                cnn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public int InsertarAcompaniantes(string idFuncionario, int idGira)
        {
            int resultado = -1;
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            SqlCommand cmn = new SqlCommand();
            cmn.Connection = cnn;
            string sentencia;

            try
            {
                cnn.Open();

                sentencia = $"INSERT INTO ACOMPANIANTES(IDENTIFICACION, ID_GIRA) VALUES (@IDFUNCIONARIO, @IDGIRA)";
                cmn.CommandText = sentencia;
                cmn.Parameters.AddWithValue("@IDFUNCIONARIO", idFuncionario);
                cmn.Parameters.AddWithValue("@IDGIRA", idGira);
                cmn.ExecuteNonQuery();

                resultado = 0;
                cnn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public int InsertarLugares(string origen, string destino, int idGira)
        {
            int resultado = -1;
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            SqlCommand cmn = new SqlCommand();
            cmn.Connection = cnn;
            string sentencia;

            try
            {
                cnn.Open();

                sentencia = $"INSERT INTO LUGARES_VISITA(ORIGEN, DESTINO, ID_GIRA) VALUES (@ORIGEN, @DESTINO, @ID_GIRA)";
                cmn.CommandText = sentencia;
                cmn.Parameters.AddWithValue("@ORIGEN", origen);
                cmn.Parameters.AddWithValue("@DESTINO", destino);

                cmn.Parameters.AddWithValue("@ID_GIRA", idGira);
                cmn.ExecuteNonQuery();

                resultado = 0;
                cnn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public List<entidadSolicitudGira> ListarSolicitudes(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlDataAdapter adapter = null;

            datosCentroFormacion centroFormacion = new datosCentroFormacion(cadenaConexion);
            List<entidadSolicitudGira> solicitudes = new List<entidadSolicitudGira>();
            string sentencia = "SELECT ID_GIRA, DIA_SOLICITUD, DIA_INICIO, DIA_FINAL, HORA_INICIO, HORA_FINAL, ESTADO, EXTEMPORANEA, JUSTIFICACION, APROBADOR, CHOFER, SOLICITANTE, PLACA, ID_CENTRO FROM SOLICITUDES_GIRAS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} WHERE {condicion}";
            }

            try
            {
                adapter = new SqlDataAdapter(sentencia, connection);
                adapter.Fill(datos, "Solicitantes");

                solicitudes = (from DataRow registro in datos.Tables[0].Rows
                                select new entidadSolicitudGira()
                                {
                                    IdGira = Convert.ToInt32(registro[0]),
                                    DiaSolicitud = Convert.ToDateTime(registro[1]),
                                    DiaInicio = Convert.ToDateTime(registro[2]),
                                    DiaFinal = Convert.ToDateTime(registro[3]),
                                    HoraInicio = Convert.ToString(registro[4]),
                                    HoraFin = Convert.ToString(registro[5]),
                                    Estado = Convert.ToString(registro[6]),
                                    Extemporanea = Convert.ToBoolean(registro[7]),
                                    Justificacion = Convert.ToString(registro[8]),
                                    Aprobador = Convert.ToString(registro[9]),
                                    Chofer = Convert.ToString(registro[10]),
                                    Solicitante = Convert.ToString(registro[11]),
                                    Placa = Convert.ToString(registro[12]),
                                    IdCentro = Convert.ToInt32(registro[13]),
                                    NombreCentro = centroFormacion.ObtenerNombreCentro($"ID_CENTRO = {Convert.ToString(registro[13])}"),

                                }).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return solicitudes;
        }

        public entidadSolicitudGira ObtenerSolicitud(string condicion)
        {
            entidadSolicitudGira solicitud = new entidadSolicitudGira();
            datosCentroFormacion centroFormacion = new datosCentroFormacion(cadenaConexion);
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            SqlDataReader datos;
            string sentencia = "SELECT ID_GIRA, DIA_SOLICITUD, DIA_INICIO, DIA_FINAL, HORA_INICIO, HORA_FINAL, ESTADO, EXTEMPORANEA, JUSTIFICACION, APROBADOR, CHOFER, SOLICITANTE, PLACA, ID_CENTRO FROM SOLICITUDES_GIRAS";

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
                    solicitud.IdGira = datos.GetInt32(0);
                    solicitud.DiaSolicitud = datos.GetDateTime(1);
                    solicitud.DiaInicio = datos.GetDateTime(2);
                    solicitud.DiaFinal = datos.GetDateTime(3);
                    solicitud.HoraInicio = datos.GetTimeSpan(4).ToString();
                    solicitud.HoraFin = datos.GetTimeSpan(5).ToString();
                    solicitud.Estado = datos.GetString(6);
                    solicitud.Extemporanea = datos.GetBoolean(7);
                    solicitud.Justificacion = datos.GetString(8);
                    solicitud.Aprobador = datos.GetString(9);
                    solicitud.Chofer = datos.GetString(10);
                    solicitud.Solicitante = datos.GetString(11);
                    solicitud.Placa = datos.GetString(12);
                    solicitud.IdCentro = datos.GetInt32(13);
                    solicitud.NombreCentro = centroFormacion.ObtenerNombreCentro($"ID_CENTRO = {datos.GetInt32(13)}");

                }

                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return solicitud;
        }
    }
}
