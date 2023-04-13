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
            string sentencia = "SELECT IDENTIFICACION, NOMBRE, APELLIDO_UNO, APELLIDO_DOS, TELEFONO, CORREO, ACTIVO, ID_CENTRO FROM FUNCIONARIOS";

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
                    solicitante.Telefono = datos.GetString(4);
                    solicitante.Correo = datos.GetString(5);
                    solicitante.Activo = datos.GetBoolean(6);
                    solicitante.IdCentro = datos.GetInt32(7);


                }

                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return solicitante;
        }

        public entidadFuncionario ObtenerFuncionario(string condicion)
        {
            entidadFuncionario funcionario = new entidadFuncionario();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            SqlDataReader datos;
            string sentencia = "SELECT IDENTIFICACION, NOMBRE, APELLIDO_UNO, APELLIDO_DOS, TELEFONO, CORREO, ACTIVO, ID_CENTRO, APROBADOR, CHOFER FROM FUNCIONARIOS";

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
                    funcionario.Identificacion = datos.GetString(0);
                    funcionario.Nombre = datos.GetString(1);
                    funcionario.ApellidoUno = datos.GetString(2);
                    funcionario.ApellidoDos = datos.GetString(3);
                    funcionario.Telefono = datos.GetString(4);
                    funcionario.Correo = datos.GetString(5);
                    funcionario.Activo = datos.GetBoolean(6);
                    funcionario.IdCentro = datos.GetInt32(7);
                    funcionario.Aprobador = datos.GetBoolean(8);
                    funcionario.Chofer = datos.GetBoolean(9);

                }

                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return funcionario;
        }

        public List<entidadSolicitante> ListarSolicitantes(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlDataAdapter adapter = null;

            List<entidadSolicitante> solicitantes = new List<entidadSolicitante>();
            string sentencia = "SELECT IDENTIFICACION, NOMBRE, APELLIDO_UNO, APELLIDO_DOS, TELEFONO, CORREO, ACTIVO, APROBADOR, ID_CENTRO FROM FUNCIONARIOS";

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
                                    Telefono = Convert.ToString(registro[4]),
                                    Correo = Convert.ToString(registro[5]),
                                    Activo = Convert.ToBoolean(registro[6]),
                                    Aprobador = Convert.ToBoolean(registro[7]),
                                    IdCentro = Convert.ToInt32(registro[8])

                }).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return solicitantes;
        }

        public List<entidadChofer> ListarChoferes(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlDataAdapter adapter = null;

            List<entidadChofer> choferes = new List<entidadChofer>();
            string sentencia = "SELECT IDENTIFICACION, NOMBRE, APELLIDO_UNO, APELLIDO_DOS, TELEFONO, CORREO, ACTIVO, CHOFER, ID_CENTRO FROM FUNCIONARIOS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} WHERE {condicion}";
            }

            try
            {
                adapter = new SqlDataAdapter(sentencia, connection);
                adapter.Fill(datos, "Choferes");

                choferes = (from DataRow registro in datos.Tables[0].Rows
                                select new entidadChofer()
                                {
                                    Identificacion = Convert.ToString(registro[0]),
                                    Nombre = Convert.ToString(registro[1]),
                                    ApellidoUno = Convert.ToString(registro[2]),
                                    ApellidoDos = Convert.ToString(registro[3]),
                                    Telefono = Convert.ToString(registro[4]),
                                    Correo = Convert.ToString(registro[5]),
                                    Activo = Convert.ToBoolean(registro[6]),
                                    Chofer = Convert.ToBoolean(registro[7]),
                                    IdCentro = Convert.ToInt32(registro[8])
                                }).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return choferes;
        }

        public entidadChofer ObtenerChofer(string condicion)
        {
            entidadChofer chofer = new entidadChofer();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            SqlDataReader datos;
            string sentencia = "SELECT IDENTIFICACION, NOMBRE, APELLIDO_UNO, APELLIDO_DOS, TELEFONO, CORREO, ACTIVO, CHOFER, ID_CENTRO FROM FUNCIONARIOS";

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
                    chofer.Identificacion = datos.GetString(0);
                    chofer.Nombre = datos.GetString(1);
                    chofer.ApellidoUno = datos.GetString(2);
                    chofer.ApellidoDos = datos.GetString(3);
                    chofer.Telefono = datos.GetString(4);
                    chofer.Correo = datos.GetString(5);
                    chofer.Activo = datos.GetBoolean(6);
                    chofer.Chofer = datos.GetBoolean(7);
                    chofer.IdCentro = datos.GetInt32(8);

                }

                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return chofer;
        }
        public entidadFuncionario ObtenerAprobador(string condicion)
        {
            entidadFuncionario aprobador = new entidadChofer();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            SqlDataReader datos;
            string sentencia = "SELECT IDENTIFICACION, NOMBRE, APELLIDO_UNO, APELLIDO_DOS, TELEFONO, CORREO, ACTIVO, ID_CENTRO FROM FUNCIONARIOS";

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
                    aprobador.Identificacion = datos.GetString(0);
                    aprobador.Nombre = datos.GetString(1);
                    aprobador.ApellidoUno = datos.GetString(2);
                    aprobador.ApellidoDos = datos.GetString(3);
                    aprobador.Telefono = datos.GetString(4);
                    aprobador.Correo = datos.GetString(5);
                    aprobador.Activo = datos.GetBoolean(6);
                    aprobador.IdCentro = datos.GetInt32(7);

                }

                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return aprobador;
        }


        public List<entidadFuncionario> ListarAcompaniantes(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlDataAdapter adapter = null;

            List<entidadFuncionario> acompaniantes = new List<entidadFuncionario>();
            string sentencia = "SELECT IDENTIFICACION FROM ACOMPANIANTES";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} WHERE {condicion}";
            }

            try
            {
                adapter = new SqlDataAdapter(sentencia, connection);
                adapter.Fill(datos, "Solicitantes");

                acompaniantes = (from DataRow registro in datos.Tables[0].Rows
                                select new entidadFuncionario()
                                {
                                    Identificacion = Convert.ToString(registro[0]),
                                }).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return acompaniantes;
        }

        public bool VerificarDisponibilidadFuncionario(string condicion)
        {
            bool resultado = false;

            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            SqlDataReader datos;
            string sentencia = "SELECT IDENTIFICACION FROM FUNCIONARIOS";

            sentencia = $"{sentencia} {condicion}";

            command.CommandText = sentencia;

            try
            {
                connection.Open();
                datos = command.ExecuteReader();

                if (datos.HasRows)
                {
                    resultado = true;
                }

                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }


        public List<entidadFuncionario> ListarFuncionarios(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            SqlDataAdapter adapter = null;
            List<entidadFuncionario> funcionarios = new List<entidadFuncionario>();
            string sentencia = "SELECT IDENTIFICACION, NOMBRE, APELLIDO_UNO, APELLIDO_DOS, TELEFONO, CORREO, ACTIVO, APROBADOR, CHOFER, ID_CENTRO FROM FUNCIONARIOS";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} WHERE {condicion}";
            }

            try
            {
                adapter = new SqlDataAdapter(sentencia, connection);
                adapter.Fill(datos, "Funcionarios");

                funcionarios = (from DataRow registro in datos.Tables[0].Rows
                                select new entidadFuncionario()
                                {
                                    Identificacion = Convert.ToString(registro[0]),
                                    Nombre = Convert.ToString(registro[1]),
                                    ApellidoUno = Convert.ToString(registro[2]),
                                    ApellidoDos = Convert.ToString(registro[3]),
                                    Telefono = Convert.ToString(registro[4]),
                                    Correo = Convert.ToString(registro[5]),
                                    Activo = Convert.ToBoolean(registro[6]),
                                    Aprobador = Convert.ToBoolean(registro[7]),
                                    Chofer = Convert.ToBoolean(registro[8]),
                                    IdCentro = Convert.ToInt32(registro[9])

                                }).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return funcionarios;
        }

        public bool EliminarFuncionario(string identificacion)
        {
            int resultado = -1;
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            string sentencia;
            try
            {
                sentencia = $"DELETE FROM FUNCIONARIOS WHERE IDENTIFICACION='{identificacion}'";
                comando.CommandText = sentencia;
                comando.CommandType = CommandType.Text;

                cnn.Open();

                resultado = (int)comando.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (resultado > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public string InsertarFuncionario(entidadFuncionario funcionario)
        {
            string resultado = string.Empty;
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            string sentencia;
            try
            {
                sentencia = "INSERT INTO FUNCIONARIOS(IDENTIFICACION, NOMBRE, APELLIDO_UNO, APELLIDO_DOS, TELEFONO, CORREO, ACTIVO, APROBADOR, CHOFER, ID_CENTRO) OUTPUT INSERTED.IDENTIFICACION VALUES (@IDENTIFICACION, @NOMBRE, @APELLIDO_UNO, @APELLIDO_DOS, @TELEFONO, @CORREO, @ACTIVO, @APROBADOR, @CHOFER, @ID_CENTRO)";

                comando.CommandText = sentencia;
                comando.CommandType = CommandType.Text;
                //parametros de entrada
                comando.Parameters.AddWithValue("@IDENTIFICACION", funcionario.Identificacion);
                comando.Parameters.AddWithValue("@NOMBRE", funcionario.Nombre);
                comando.Parameters.AddWithValue("@APELLIDO_UNO", funcionario.ApellidoUno);
                comando.Parameters.AddWithValue("@APELLIDO_DOS", funcionario.ApellidoDos);
                comando.Parameters.AddWithValue("@TELEFONO", funcionario.Telefono);
                comando.Parameters.AddWithValue("@CORREO", funcionario.Correo);
                comando.Parameters.AddWithValue("@ACTIVO", funcionario.Activo);
                comando.Parameters.AddWithValue("@APROBADOR", funcionario.Activo);
                comando.Parameters.AddWithValue("@CHOFER", funcionario.Chofer);
                comando.Parameters.AddWithValue("@ID_CENTRO", funcionario.IdCentro);

                //parametros de salida
                cnn.Open();
                resultado = (string)comando.ExecuteScalar();

                cnn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }


        public bool ModificarFuncionario(entidadFuncionario funcionario)
        {
            int resultado = -1;
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            string sentencia;
            try
            {
                sentencia = "UPDATE FUNCIONARIOS SET NOMBRE = @NOMBRE, APELLIDO_UNO = @APELLIDO_UNO, APELLIDO_DOS = @APELLIDO_DOS, TELEFONO = @TELEFONO, CORREO = @CORREO, APROBADOR = @APROBADOR, CHOFER = @CHOFER, ID_CENTRO = @ID_CENTRO WHERE IDENTIFICACION = @IDENTIFICACION";

                comando.CommandText = sentencia;
                comando.CommandType = CommandType.Text;
                //parametros de entrada
                comando.Parameters.AddWithValue("@IDENTIFICACION", funcionario.Identificacion);
                comando.Parameters.AddWithValue("@NOMBRE", funcionario.Nombre);
                comando.Parameters.AddWithValue("@APELLIDO_UNO", funcionario.ApellidoUno);
                comando.Parameters.AddWithValue("@APELLIDO_DOS", funcionario.ApellidoDos);
                comando.Parameters.AddWithValue("@TELEFONO", funcionario.Telefono);
                comando.Parameters.AddWithValue("@CORREO", funcionario.Correo);
                comando.Parameters.AddWithValue("@APROBADOR", funcionario.Aprobador);
                comando.Parameters.AddWithValue("@CHOFER", funcionario.Chofer);
                comando.Parameters.AddWithValue("@ID_CENTRO", funcionario.IdCentro);

                //parametros de salida
                cnn.Open();
                resultado = (int)comando.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (resultado > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }




}

