using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EMRclinica
{
    internal class PacienteDao
    {
        private string connectionString = "server=localhost;" +
          "user=root;" +
          "password=;" +
          "database=clinicadb;";

        // Método para obtener todos los Pacientes de la base de datos
        public List<Pacientes> ObtenerTodosLosPacientes()
        {
            List<Pacientes> listaPacientes = new List<Pacientes>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //aperturar conexion
                conn.Open();
                //diseñar la consulta
                string query = "SELECT IdPaciente, NombrePaciente, GeneroPaciente, FNPaciente, DireccionPaciente, TelefonoPaciente, VIHPaciente, AlPaciente FROM paciente";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pacientes Paciente = new Pacientes();
                            Paciente.IdPaciente = Convert.ToInt32(reader["IdPaciente"]);
                            Paciente.NombrePaciente = reader["NombrePaciente"].ToString();
                            Paciente.GeneroPaciente = reader["GeneroPaciente"].ToString();
                            Paciente.FNPaciente = (DateTime)reader["FNPaciente"];
                            Paciente.DireccionPaciente = reader["DireccionPaciente"].ToString();
                            Paciente.TelefonoPaciente = reader["TelefonoPaciente"].ToString();
                            Paciente.VIHPaciente = reader["VIHPaciente"].ToString();
                            Paciente.AlPaciente = reader["AlPaciente"].ToString();
                            listaPacientes.Add(Paciente);
                        }
                    }
                }
            }

            return listaPacientes;
        }

        // Método para obtener un Doctor por su ID
        public Pacientes ObtenerPacientePorId(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT IdPaciente, NombrePaciente, GeneroPaciente,FNPaciente, DireccionPaciente, TelefonoPaciente, VIHPaciente, AlPaciente WHERE IdPaciente = @IdPaciente";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPaciente", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Pacientes Paciente = new Pacientes();
                            Paciente.IdPaciente = Convert.ToInt32(reader["IdPaciente"]);
                            Paciente.NombrePaciente = reader["NombrePaciente"].ToString();
                            Paciente.FNPaciente = (DateTime)reader["FNPaciente"];
                            Paciente.GeneroPaciente = reader["GeneroPaciente"].ToString();
                            Paciente.DireccionPaciente = reader["DireccionPaciente"].ToString();
                            Paciente.TelefonoPaciente = Convert.ToInt32(reader["TelefonoPaciente"]).ToString();
                            Paciente.VIHPaciente = reader["VIHPaciente"].ToString();
                            Paciente.AlPaciente = reader["AlPaciente"].ToString() ;
                            

                            return Paciente;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        // Método para insertar un nuevo paciente en la base de datos
        public void InsertarPaciente(Pacientes Paciente)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO paciente (IdPaciente, NombrePaciente, GeneroPaciente,FNPaciente, DireccionPaciente, TelefonoPaciente, VIHPaciente, AlPaciente) VALUES " +
                    "(@IdPaciente, @NombrePaciente, @GeneroPaciente,@FNPaciente, @DireccionPaciente, @TelefonoPaciente, @VIHPaciente, @AlPaciente)";


                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPaciente", Paciente.IdPaciente);
                    cmd.Parameters.AddWithValue("@NombrePaciente", Paciente.NombrePaciente);
                    cmd.Parameters.AddWithValue("@GeneroPaciente", Paciente.GeneroPaciente);
                    cmd.Parameters.AddWithValue("@FNPaciente", Paciente.FNPaciente);
                    cmd.Parameters.AddWithValue("@DireccionPaciente", Paciente.DireccionPaciente);
                    cmd.Parameters.AddWithValue("@TelefonoPaciente", Paciente.TelefonoPaciente);
                    cmd.Parameters.AddWithValue("@VIHPaciente", Paciente.VIHPaciente);
                    cmd.Parameters.AddWithValue("@AlPaciente", Paciente.AlPaciente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para actualizar un paciente en la base de datos
        public void ActualizarPaciente(Pacientes Paciente)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE paciente SET NombrePaciente = @NombrePaciente, DireccionPaciente = @DireccionPaciente, " +
                    "TelefonoPaciente = @TelefonoPaciente WHERE IdPaciente = @IdPaciente";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombrePaciente", Paciente.NombrePaciente);
                    cmd.Parameters.AddWithValue("@GeneroPaciente", Paciente.GeneroPaciente);
                    cmd.Parameters.AddWithValue("@FNPaciente", Paciente.FNPaciente);
                    cmd.Parameters.AddWithValue("@DireccionPaciente", Paciente.DireccionPaciente);
                    cmd.Parameters.AddWithValue("@DireccionPaciente", Paciente.DireccionPaciente);
                    cmd.Parameters.AddWithValue("@TelefonoPaciente", Paciente.TelefonoPaciente);
                    cmd.Parameters.AddWithValue("@VIHPaciente", Paciente.VIHPaciente);
                    cmd.Parameters.AddWithValue("@AlPaciente", Paciente.AlPaciente);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para eliminar un paciente de la base de datos por su ID
        public void EliminarPaciente(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM paciente WHERE IdPaciente = @IdPaciente";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPaciente", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

    

