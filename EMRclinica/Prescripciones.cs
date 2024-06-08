using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMRclinica
{
    public partial class Prescripciones : Form
    {

        public Prescripciones()
        {
            InitializeComponent();

        }
        private string connectionString = "server=localhost;" +
               "user=root;" +
               "password=;" +
               "database=clinicadb;";

        public int IdPrescripcion { get; internal set; }
        public string IdDoctor { get; internal set; }
        public string NombreDoctor { get; internal set; }
        public string NombrePaciente { get; internal set; }
        public string IdPaciente { get; internal set; }
        public string TestNum { get; internal set; }
        public string NombreTest { get; internal set; }
        public string Medicamentos { get; internal set; }
        public string Costo { get; internal set; }

        private void listarPrescripciones()
        {
            PrecripcionesDao Precripcionesdao = new PrecripcionesDao();
            PrescripcionesDGV.DataSource = Precripcionesdao.ObtenerTodosLasPrescripciones();

        }


        private void habilitarCampos(bool readOnly)
        {

            DocIdCb.SelectedItem = readOnly;
            PacienteIdCb.SelectedItem = readOnly;
            TestIdCb.SelectedItem = readOnly;
            TxtCostoMed.ReadOnly = readOnly;
            TxtMedicamentos.ReadOnly = readOnly;
            TxtNombreDoc.ReadOnly = readOnly;
            TxtNombrePaciente.ReadOnly = readOnly;
            TxtNombrePrueba.ReadOnly = readOnly;


        }

        private void Prescripciones_Load(object sender, EventArgs e)
        {
            listarPrescripciones();
        }

        private void InsertarPrescripcion()
        {
            PrecripcionesDao precripcionesDao = new PrecripcionesDao();
            Prescripciones prescripciones = new Prescripciones();
            prescripciones.IdDoctor = DocIdCb.Text;
            prescripciones.NombreDoctor = TxtNombreDoc.Text;
            prescripciones.IdPaciente = PacienteIdCb.Text;
            prescripciones.NombrePaciente = TxtNombrePaciente.Text;
            prescripciones.TestNum = TestIdCb.Text;
            prescripciones.NombreTest = TxtNombrePrueba.Text;
            prescripciones.Medicamentos = TxtMedicamentos.Text;
            prescripciones.Costo = TxtCostoMed.Text;

            precripcionesDao.InsertarPrescripcion(prescripciones);
            habilitarCampos(true);
            listarPrescripciones();

        }

        private void BtnEliminarPresc_Click(object sender, EventArgs e)
        {
            DataGridViewRow Fila = PrescripcionesDGV.SelectedRows[0];
            int id = (int)Fila.Cells[0].Value;
            PrecripcionesDao Precripcionesdao = new PrecripcionesDao();
            Precripcionesdao.EliminarPrescripcion(id);
            listarPrescripciones();
        }

        private void BtnAgregarPresc_Click(object sender, EventArgs e)
        {
            InsertarPrescripcion();
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
                            doctor.IdDoctor = Convert.ToInt32(reader["Id"]);

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
                    cmd.Parameters.AddWithValue("@idPaciente", IdPaciente);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Pacientes Paciente = new Pacientes();
                            Paciente.IdPaciente = Convert.ToInt32(reader["Id"]);

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
                            Doctor.NombreDoctor = reader["Nombre"].ToString();

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
                            Paciente.NombrePaciente = reader["Nombre"].ToString();

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
                            //Test.NombreTest = Convert.ToInt32(reader["Nombre"]);

                        }
                        else
                        {
                            Console.WriteLine("objeto no encontrado");
                        }
                    }
                }
            }
        }

        private void DocIdCb_SelectedIndexChanged(object sender, EventArgs e)
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
                            doctor.IdDoctor = Convert.ToInt32(reader["Id"]);

                        }
                        else
                        {
                            Console.WriteLine("objeto no encontrado");
                        }
                    }

                }
            }
        }

        private void PacienteIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT IdPaciente WHERE IdPaciente = @IdPaciente";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPaciente", IdPaciente);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Pacientes Paciente = new Pacientes();
                            Paciente.IdPaciente = Convert.ToInt32(reader["Id"]);

                        }
                        else
                        {
                            Console.WriteLine("objeto no encontrado");
                        }
                    }
                }
            }

        }

        private void TestIdCb_SelectedIndexChanged(object sender, EventArgs e)
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

        private void PrescripcionPd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(PreTxt.Text + "\n", new Font("Averia", 18, FontStyle.Regular), Brushes.Black, new Point(95, 80));
            e.Graphics.DrawString("\n\t " + "Gracias", new Font("Averia", 15, FontStyle.Bold), Brushes.Red, new Point(200, 300));
        }

        private void BtnPacientesDoc_Click(object sender, EventArgs e)
        {
            Pacientes obj = new Pacientes();
            obj.Show();
            this.Hide();
        }

        private void BtnDoctoresDoc_Click(object sender, EventArgs e)
        {
            Doctores doc = new Doctores();
            doc.Show();
            this.Hide();
        }

        private void BtnLaboratorioDoc_Click(object sender, EventArgs e)
        {
            Laboratorio obj = new Laboratorio();
            obj.Show();
            this.Hide();

        }

        private void BtnRecepcionistaDoc_Click(object sender, EventArgs e)
        {
            Recepcionista obj = new Recepcionista ();
            obj.Show();
            this.Hide();
        }

        private void BtnSalirPrescripciones_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
