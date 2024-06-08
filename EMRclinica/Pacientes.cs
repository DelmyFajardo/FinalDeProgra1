using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMRclinica
{
    public partial class Pacientes : Form
    {
        public Pacientes()
        {
            InitializeComponent();
        }

        private void habilitarCampos(bool readOnly)
        {

            txtNombrePaciente.ReadOnly = readOnly;
            GeneroPacienteCb.SelectedItem = readOnly;
            //PacDOB.MaxDate = readOnly;
            txtDireccionPaciente.ReadOnly = readOnly;
            txtTelPaciente.ReadOnly = readOnly;
            VIHPacienteCb.SelectedItem = readOnly;
            txtAlergiasPaciente.ReadOnly = readOnly;


        }

        private void listarPacientes()
        {
            PacienteDao pacientedao = new PacienteDao();
            PacientesDGV.DataSource = pacientedao.ObtenerTodosLosPacientes();

        }


        public int IdPaciente { get; internal set; }
        public string NombrePaciente { get; internal set; }
        public string GeneroPaciente { get; internal set; }
        public string FNPaciente { get; internal set; }
        public string DireccionPaciente { get; internal set; }
        public object TelefonoPaciente { get; internal set; }
        public string VIHPaciente { get; internal set; }
        public string AlPaciente { get; internal set; }

        private void ActualizarPaciente()

        {
            PacienteDao pacientedao = new PacienteDao();
            Pacientes Paciente = new Pacientes();

            DataGridViewRow Fila = PacientesDGV.SelectedRows[0];
            int id = (int)Fila.Cells[0].Value;
            Paciente.IdPaciente = id;
            Paciente.NombrePaciente = txtNombrePaciente.Text;
            Paciente.GeneroPaciente = GeneroPacienteCb.Text;
            Paciente.FNPaciente = PacDOB.Text;
            Paciente.DireccionPaciente = txtDireccionPaciente.Text;
            Paciente.TelefonoPaciente = txtTelPaciente.Text;
            Paciente.VIHPaciente = PacDOB.Text;
            Paciente.AlPaciente = txtAlergiasPaciente.Text;

            habilitarCampos(true);
            listarPacientes();
        }
        private void InsertarPacientes()
        {
            PacienteDao pacientedao = new PacienteDao();
            Pacientes Paciente = new Pacientes();
            Paciente.NombrePaciente = txtNombrePaciente.Text;
            Paciente.GeneroPaciente = GeneroPacienteCb.Text;
            Paciente.FNPaciente = PacDOB.Text;
            Paciente.DireccionPaciente = txtDireccionPaciente.Text;
            Paciente.TelefonoPaciente = txtTelPaciente.Text;
            Paciente.VIHPaciente = PacDOB.Text;
            Paciente.AlPaciente = txtAlergiasPaciente.Text;

            pacientedao.InsertarPaciente(Paciente);
            habilitarCampos(true);
            listarPacientes();

        }

        private void btnEliminarPaciente_Click(object sender, EventArgs e)
        {
            DataGridViewRow Fila = PacientesDGV.SelectedRows[0];
            int id = (int)Fila.Cells[0].Value;
            PacienteDao pacientedao = new PacienteDao();
            pacientedao.EliminarPaciente(id);
            listarPacientes();
        }

        private void btnEditarPaciente_Click(object sender, EventArgs e)
        {

            DataGridViewRow Fila = PacientesDGV.SelectedRows[0];
            txtNombrePaciente.Text = (String)Fila.Cells[1].Value;
            GeneroPacienteCb.Text = (String)Fila.Cells[2].Value;
            //PacDOB.Text = (SistemDateTime)Fila.Cells[3].Value;
            txtDireccionPaciente.Text = (String)Fila.Cells[4].Value;
            txtTelPaciente.Text = ((string)Fila.Cells[5].Value);
            VIHPacienteCb.Text = ((String)Fila.Cells[6].Value);
            txtAlergiasPaciente.Text = ((String)Fila.Cells[7].Value);
            habilitarCampos(false);
        }

        private void BtnPacientes_Click(object sender, EventArgs e)
        {
            Pacientes obj = new Pacientes();
            obj.Show();
            this.Hide();
        }

        private void BtnDoctores_Click(object sender, EventArgs e)
        {
            Doctores doc = new Doctores();
            doc.Show();
            this.Hide();
        }

        private void BtnLab_Click(object sender, EventArgs e)
        {
            Laboratorio laboratorio = new Laboratorio();
            laboratorio.Show();
            this.Hide();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            InsertarPacientes();
        }

        private void BtnSalirPacientes_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PrescripcionBtn_Click(object sender, EventArgs e)
        {
            Prescripciones presc = new Prescripciones();
            presc.Show();
            this.Hide();
        }
    }
 
}

