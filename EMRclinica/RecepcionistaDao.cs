using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRclinica
{
    internal class RecepcionistaDao 
    {
        private string connectionString = "server=localhost;" +
                "user=root;" +
                "password=;" +
                "database=clinicadb;";

        // Método para obtener todos las Recepcionistas de la base de datos
        public List<Recepcionista> ObtenerTodosLosDatosRecepcionista()
        {
            List<Recepcionista> listaRecepcionista = new List<Recepcionista>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //aperturar conexion
                conn.Open();
                //diseñar la consulta
                string query = "SELECT IdRecepcionista, NombreRecepcionista, TelefonoRecepcionista, DireccionRecepcionista, ContrasenaRecepcionista FROM recepcionista";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recepcionista recepcionista = new Recepcionista();
                            recepcionista.IdRecepcionista = Convert.ToInt32(reader["IdRecepcionista"]);
                            recepcionista.NombreRecepcionista = reader["NombreRecepcionista"].ToString();
                            recepcionista.TelefonoRecepcionista = reader["TelefonoRecepcionista"].ToString();
                            recepcionista.DireccionRecepcionista = reader["DireccionRecepcionista"].ToString();
                            recepcionista.ContrasenaRecepcionista = reader["ContrasenaRecepcionista"].ToString();
                          

                            listaRecepcionista.Add(recepcionista);
                        }
                    }
                }
            }

            return listaRecepcionista;
        }

        // Método para obtener un Recepcionista por su ID
        public Recepcionista ObtenerRecepcionistaPorId(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT IdRecepcionista, NombreRecepcionista, TelefonoRecepcionista, DireccionRecepcionista , ContrasenaRecepcionista WHERE IdRecepcionista = @IdRecepcionista";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Recepcionista recepcionista = new Recepcionista();
                            recepcionista.IdRecepcionista = Convert.ToInt32(reader["IdRecepcionista"]);
                            recepcionista.NombreRecepcionista = reader["NombreRecepcionista"].ToString();
                            recepcionista.TelefonoRecepcionista = reader["TelefonoRecepcionista"].ToString();
                            recepcionista.DireccionRecepcionista = reader["DireccionRecepcionista"].ToString();
                            recepcionista.ContrasenaRecepcionista = reader["ContrasenaRecepcionista"].ToString();

                            return recepcionista;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        // Método para insertar una nueva recepcionista  en la base de datos
        public void InsertarRecepcionista(Recepcionista recepcionista)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO recepcionista (NombreRecepcionista,  TelefonoRecepcionista, DireccionRecepcionista, ContrasenaRecepcionista) VALUES " +
                    "(@NombreRecepcionista, @TelefonoRecepcionista, @DireccionRecepcionista, @ContrasenaRecepcionista)";


                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreRecepcionista", recepcionista.NombreRecepcionista);
                    cmd.Parameters.AddWithValue("@TelefonoRecepcionista", recepcionista.TelefonoRecepcionista);
                    cmd.Parameters.AddWithValue("@DireccionRecepcionista", recepcionista.DireccionRecepcionista);
                    cmd.Parameters.AddWithValue("@ContrasenaRecepcionista", recepcionista.ContrasenaRecepcionista);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para actualizar un producto en la base de datos
        public void ActualizarRecepcionista(Recepcionista recepcionista)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE recepcionista SET NombreRecepcionista = @NombreRecepcionista, " +
                    "TelefonoRecepcionista =@TelefonoRecepcionista,DireccionRecepcionista  = @DireccionRecepcionista, ContrasenaRecepcionista = @ContrasenaRecepcionista WHERE IdRecepcionista = @IdRecepcionista";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreRecepcionista", recepcionista.NombreRecepcionista);
                    cmd.Parameters.AddWithValue("@TelefonoRecepcionista", recepcionista.TelefonoRecepcionista);
                    cmd.Parameters.AddWithValue("@DireccionRecepcionista", recepcionista.DireccionRecepcionista);
                    cmd.Parameters.AddWithValue("@ContrasenaRecepcionista", recepcionista.ContrasenaRecepcionista);
                    cmd.Parameters.AddWithValue("@IdRecepcionista", recepcionista.IdRecepcionista);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para eliminar un producto de la base de datos por su ID
        public void EliminarRecepcionista(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM recepcionista WHERE IdRecepcionista = @IdRecepcionista";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdRecepcionista", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
