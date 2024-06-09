using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMRclinica
{
    internal class LabDao

    {
        private string connectionString = "server=localhost;" +
              "user=root;" +
              "password=;" +
              "database=clinicadb;";

        // Método para obtener todos los Test de la base de datos
        public List<Laboratorio> ObtenertodoslosTest()
        {
            List<Laboratorio> listaTest = new List<Laboratorio>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //aperturar conexion
                conn.Open();
                //diseñar la consulta
                string query = "SELECT TestNum, NombreTest, CostoTest FROM laboratorio";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Laboratorio Test= new Laboratorio();
                            Test.TestNum = Convert.ToInt32(reader["TestNum"]);
                            Test.NombreTest = reader["NombreTest"].ToString();
                            Test.CostoTest = reader["CostoTest"].ToString();
                           
                            
                            listaTest.Add(Test);
                        }
                    }
                }
            }

            return listaTest;
        }

       

        // Método para insertar un nuevo producto en la base de datos
        public void InsertarTest(Laboratorio Test)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO laboratorio (TestNum, NombreTest, CostoTest) VALUES " +
                    "(@TestNum, @NombreTest, @CostoTest)";


                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestNum", Test.TestNum);
                    cmd.Parameters.AddWithValue("@NombreTest", Test.NombreTest);
                    cmd.Parameters.AddWithValue("@CostoTest", Test.CostoTest);
               

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para actualizar un Test en la base de datos
        public void ActualizarTest(Laboratorio Test)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE  SET TestNum = @TestNum, NombreTest = @NombreTest, " +
                    " WHERE TestNum = @TestNum";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestNum", Test.TestNum);
                    cmd.Parameters.AddWithValue("@NombreTest", Test.NombreTest);
                    cmd.Parameters.AddWithValue("@CostoTest", Test.CostoTest);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para eliminar un Test de la base de datos por su ID
        public void EliminarTest(int TestNum)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM laboratorio WHERE TestNum = @TestNum";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestNum", TestNum);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


    

