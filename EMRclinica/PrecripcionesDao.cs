using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace EMRclinica
{
   
    internal class PrecripcionesDao
    {
        private string connectionString = "server=localhost;" +
                "user=root;" +
                "password=;" +
                "database=clinicadb;";

        public object DocIdCb { get; private set; }
        public object PacienteIdCb { get; private set; }
 
        public object TestIdCb { get; private set; }
        public object TxtCostoMed { get; private set; }
        public object TxtMedicamentos { get; private set; }
        public object TxtNombreDoc { get; private set; }
        public object TxtNombrePaciente { get; private set; }
        public object TxtNombrePrueba { get; private set; }
        public object IdDoctor { get; private set; }
        public object TestNum { get; private set; }

        public List<Prescripciones> ObtenerTodosLasPrescripciones()
        {
            List<Prescripciones> listaPrescripciones = new List<Prescripciones>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //aperturar conexion
                conn.Open();
                //diseñar la consulta
                string query = "SELECT IdPrescripcion,IdDoctor ,NombreDoctor,IdPaciente,NombrePaciente,TestNum,NombreTest , Medicamentos, Costo FROM prescripcion";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Prescripciones prescripciones = new Prescripciones();
                            prescripciones.IdPrescripcion = Convert.ToInt32(reader["IdPrescripcion"]);
                            prescripciones.IdDoctor = reader["IdDoctor"].ToString();
                            prescripciones.NombreDoctor = reader["NombreDoctor"].ToString();
                            prescripciones.IdPaciente = reader["IdPaciente"].ToString();
                            prescripciones.NombrePaciente = reader["NOmbrePaciente"].ToString();
                            prescripciones.TestNum = reader["TestNum"].ToString();
                            prescripciones.NombreTest = reader["NombreTest"].ToString();
                            prescripciones.Medicamentos = reader["Medicamentos"].ToString();
                            prescripciones.Costo = reader["Costo"].ToString();
                            listaPrescripciones.Add(prescripciones);
                        }
                    }
                }
            }

            return listaPrescripciones;
        }

        public Prescripciones prescricionPorId(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT prescripcion,  WHERE IdPrescripcion = @IdPrescripcion";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPrescripcion", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Prescripciones prescripciones = new Prescripciones();
                            prescripciones.IdPrescripcion = Convert.ToInt32(reader["IdPrescripcion"]);
                            return prescripciones;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        private void GetDoctorId(int IdDoctor)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT IdDoctor WHERE IdDoctor = @IdDoctor";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdDoctor", IdDoctor);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Doctores doctor = new Doctores();
                            doctor.IdDoctor = Convert.ToInt32(reader["IdDoctor"]);

                        }
                        else
                        {
                            Console.WriteLine("objeto no encontrado");
                        }  
                    }
                }
            }
        }
        private void GetPacienteId(int IdPaciente)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT IdPaciente WHERE IdPaciente = @IdPaciente";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPaciente", IdPaciente);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Pacientes Paciente = new Pacientes();
                            Paciente.IdPaciente = Convert.ToInt32(reader["IdPaciente"]);

                        }
                        else
                        {
                            Console.WriteLine("objeto no encontrado");
                        }
                    }
                }
            }
        }    
        private void GetTest(int TestNum)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT TestNum WHERE TestNum = @TestNum";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestNum", TestNum);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Laboratorio Test = new Laboratorio();
                           // Test.TestNum = Convert.ToInt32(reader["TestNum"]);

                        }
                        else
                        {
                            Console.WriteLine("objeto no encontrado");
                        }
                    }
                }
            }
        }

        private void GetDoctorNombre(string NombreDoctor)
        {

        
        
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT NombreDoctor WHERE NombreDoctor = @NombreDoctor";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreDoctor", NombreDoctor);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Doctores Doctor = new Doctores();
                            Doctor.NombreDoctor = reader["NombreDoctor"].ToString();

                        }
                        else
                        {
                            Console.WriteLine("objeto no encontrado");
                        }
                    }
                }
            }
        }

        private void GetPacienteNombre(string NombrePaciente)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT NombrePaciente WHERE NombrePaciente = @NombrePaciente";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombrePaciente", NombrePaciente);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Pacientes Paciente = new Pacientes();
                            Paciente.NombrePaciente = reader["NombrePaciente"].ToString();

                        }
                        else
                        {
                            Console.WriteLine("objeto no encontrado");
                        }
                    }
                }
            }
        }
        private void GetNombreTest(string NombreTest)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT NombreTest WHERE NombreTest = @NombreTest";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreTest", NombreTest);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Laboratorio Test = new Laboratorio();
                            //Test.NombreTest = string(reader["NombreTest"]); esto da error

                        }
                        else
                        {
                            Console.WriteLine("objeto no encontrado");
                        }
                    }
                }
            }
        }

        public void InsertarPrescripcion(Prescripciones prescripciones)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO prescripcion (IdDoctor ,NombreDoctor,IdPaciente,NombrePaciente,TestNum,NombreTest , Medicamentos, Costo) VALUES " +
                    "(@IdDoctor, @NombreDoctor, @IdPaciente, @NombrePaciente, @TestNum, @NombreTest , @Medicamentos, @Costo)";


                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdDoctor", prescripciones.IdDoctor);
                    cmd.Parameters.AddWithValue("@NombreDoctor", prescripciones.NombreDoctor);
                    cmd.Parameters.AddWithValue("@IdPaciente", prescripciones.IdPaciente);
                    cmd.Parameters.AddWithValue("@NombrePaciente", prescripciones.NombrePaciente);
                    cmd.Parameters.AddWithValue("@TestNum", prescripciones.TestNum);
                    cmd.Parameters.AddWithValue("@NombreTest", prescripciones.NombreTest);
                    cmd.Parameters.AddWithValue("@Medicamentos", prescripciones.Medicamentos);
                    cmd.Parameters.AddWithValue("@Costo", prescripciones.Costo);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void EliminarPrescripcion(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM prescripciones WHERE TestNum = @TestNum";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestNum", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
