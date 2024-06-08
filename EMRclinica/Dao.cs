using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRclinica
{
    public class Dao
    {

             private string connectionString = "server=localhost;" +
                "user=root;" +
                "password=;" +
                "database=clinicadb;";

            // Método para obtener todos los Doctores de la base de datos
            public List<Doctores> ObtenerTodosLosDoctores()
            {
                List<Doctores> listaDoctores = new List<Doctores>();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    //aperturar conexion
                    
                    //diseñar la consulta
                    string query = "SELECT IdDoctor, NombreDoctor, FNDoctor, GeneroDoctor, EspecialidadDoctor, ExperienciaDoctor, TelefonoDoctor, DireccionDoctor, ContrasenaDoctor FROM doctor";
                    
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                        while (reader.Read())
                            {
                                Doctores Doctor = new Doctores();
                                Doctor.IdDoctor = Convert.ToInt32(reader["Id"]);
                                Doctor.NombreDoctor = reader["Nombre"].ToString();
                                Doctor.FNDoctor = reader["Fecha de nacimiento"].ToString();
                                Doctor.GeneroDoctor = reader["Genero"].ToString();
                                Doctor.EspecialidadDoctor = reader["Especialidad"].ToString();
                                Doctor.ExperienciaDoctor =Convert.ToInt32(reader["codigo_producto"]).ToString();

                                listaDoctores.Add(Doctor);
                            }
                        }
                    }
                }
                
                return listaDoctores;
            }

            // Método para obtener un Doctor por su ID
            public Doctores ObtenerDoctoroPorId(int id)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT IdDoctor, NombreDoctor, FNDoctor, GeneroDoctor, EspecialidadDoctor, ExperienciaDoctor, TelefonoDoctor, DireccionDoctor, ContrasenaDoctor WHERE IdDoctor = @IdDoctor";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                        if (reader.Read())
                        {
                            Doctores Doctor = new Doctores();
                            Doctor.IdDoctor = Convert.ToInt32(reader["Id"]);
                            Doctor.NombreDoctor = reader["Nombre"].ToString();
                            Doctor.FNDoctor = reader["Fecha de nacimiento"].ToString();
                            Doctor.GeneroDoctor = reader["Genero"].ToString();
                            Doctor.EspecialidadDoctor = reader["Especialidad"].ToString();
                            Doctor.ExperienciaDoctor = Convert.ToInt32(reader["Experiencia"]).ToString();
                            Doctor.TelefonoDoctor = reader["Telefono"].ToString();
                            Doctor.DireccionDoctor = reader["Direccion"].ToString();
                            Doctor.ContrasenaDoctor = reader["Contrasena"].ToString();

                            return Doctor;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }

            // Método para insertar un nuevo producto en la base de datos
            public void InsertarDoctor(Doctores Doctor)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO doctor (NombreDoctor, FNDoctor, GeneroDoctor, EspecialidadDoctor, ExperienciaDoctor, TelefonoDoctor, DireccionDoctor, ContrasenaDoctor) VALUES " +
                        "(@NombreDoctor, @FNDoctor, @GeneroDoctor, @EspecialidadDoctor, @ExperienciaDoctor, @TelefonoDoctor, @DireccionDoctor, @ContrasenaDoctor)";


                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NombreDoctor", Doctor.NombreDoctor);
                        cmd.Parameters.AddWithValue("@FNDoctor", Doctor.FNDoctor);
                        cmd.Parameters.AddWithValue("@GeneroDoctor", Doctor.GeneroDoctor);
                        cmd.Parameters.AddWithValue("@EspecialidadDoctor", Doctor.EspecialidadDoctor);
                        cmd.Parameters.AddWithValue("@ExperienciaDoctor", Doctor.ExperienciaDoctor);
                        cmd.Parameters.AddWithValue("@TelefonoDoctor", Doctor.TelefonoDoctor);
                        cmd.Parameters.AddWithValue("@DireccionDoctor", Doctor.DireccionDoctor);
                        cmd.Parameters.AddWithValue("@ContrasenaDoctor", Doctor.ContrasenaDoctor);

                    cmd.ExecuteNonQuery();
                    }
                }
            }

            // Método para actualizar un producto en la base de datos
            public void ActualizarDoctor(Doctores Doctor)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE productos SET nombre = @nombre, descripcion = @descripcion, " +
                        "precio = @precio, cantidad_disponible = @cantidad_disponible, codigo_producto = @codigo_producto WHERE IdDoctor = @IdDoctor";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                    cmd.Parameters.AddWithValue("@NombreDoctor", Doctor.NombreDoctor);
                    cmd.Parameters.AddWithValue("@FNDoctor", Doctor.FNDoctor);
                    cmd.Parameters.AddWithValue("@GeneroDoctor", Doctor.GeneroDoctor);
                    cmd.Parameters.AddWithValue("@EspecialidadDoctor", Doctor.EspecialidadDoctor);
                    cmd.Parameters.AddWithValue("@ExperienciaDoctor", Doctor.ExperienciaDoctor);
                    cmd.Parameters.AddWithValue("@TelefonoDoctor", Doctor.TelefonoDoctor);
                    cmd.Parameters.AddWithValue("@DireccionDoctor", Doctor.DireccionDoctor);
                    cmd.Parameters.AddWithValue("@ContrasenaDoctor", Doctor.ContrasenaDoctor);
                    cmd.Parameters.AddWithValue("@id", Doctor.Id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // Método para eliminar un producto de la base de datos por su ID
            public void EliminarDoctor(int id)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM productos WHERE IdDoctor = @IdDoctor";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdDoctor", id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }


