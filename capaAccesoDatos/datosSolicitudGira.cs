﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaLógica;
using System.Xml;

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
                comando.Parameters.AddWithValue("@CANTIDAD_FUNCIONARIOS", solicitud.CantidadFuncionarios);
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
    }
}
