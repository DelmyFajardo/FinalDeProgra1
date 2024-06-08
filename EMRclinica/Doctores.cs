using Microsoft.OData.Edm;
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
    public partial class Doctores : Form
    {
        
        public Doctores()
        {
            InitializeComponent();
        }

        private void habilitarCampos (bool readOnly)
        {
           
            txtNombreDoc.ReadOnly = readOnly;
            DocGenCb.SelectedItem = readOnly;
            DocEspecCb.SelectedItem = readOnly;
            txtExpDoc.ReadOnly = readOnly;
            txtDireccionDoc.ReadOnly = readOnly;
            //DOcDOB.MaxDate = readOnly;
            txtTelDoc.ReadOnly = readOnly;
            txtContrasenaDoc.ReadOnly = readOnly;        

        }

        private void listarDoctores()
        {
            Dao dao = new Dao();
            DoctoresDGV.DataSource= dao.ObtenerTodosLosDoctores();

        }

        
        public int IdDoctor { get; internal set; }
        public string NombreDoctor { get; internal set; }
        public string FNDoctor { get; internal set; }
        public string GeneroDoctor { get; internal set; }
        public string EspecialidadDoctor { get; internal set; }
        public string ExperienciaDoctor { get; internal set; }
        public string TelefonoDoctor { get; internal set; }
        public string DireccionDoctor { get; internal set; }
        public string ContrasenaDoctor { get; internal set; }
        public object Id { get; internal set; }

        private void Doctores_Load(object sender, EventArgs e)
        {
            listarDoctores();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
             
        }

        private void ActualizarDoctor()
        {
            Dao dao = new Dao();
            Doctores Doctor = new Doctores();

            DataGridViewRow Fila = DoctoresDGV.SelectedRows[0];
            int id = (int)Fila.Cells[0].Value;
            Doctor.IdDoctor = id;
            Doctor.NombreDoctor = txtNombreDoc.Text;
            Doctor.GeneroDoctor = DocGenCb.Text;
            Doctor.EspecialidadDoctor = DocEspecCb.Text;
            Doctor.ExperienciaDoctor =txtExpDoc.Text;
            Doctor.DireccionDoctor = txtDireccionDoc.Text;
            Doctor.FNDoctor = DOcDOB.Text;
            Doctor.TelefonoDoctor = txtTelDoc.Text;
            Doctor.ContrasenaDoctor= txtContrasenaDoc.Text;
            dao.ActualizarDoctor(Doctor);
            habilitarCampos(true);
            listarDoctores();
        }
        private void InsertarDoctores()
        {
            Dao dao = new Dao();
            Doctores Doctor = new Doctores();
            Doctor.NombreDoctor = txtNombreDoc.Text;
            Doctor.GeneroDoctor = DocGenCb.Text;
            Doctor.EspecialidadDoctor = DocEspecCb.Text;
            Doctor.ExperienciaDoctor = txtExpDoc.Text;
            Doctor.DireccionDoctor = txtDireccionDoc.Text;
            Doctor.FNDoctor = DOcDOB.Text;
            Doctor.TelefonoDoctor = txtTelDoc.Text;
            Doctor.ContrasenaDoctor = txtContrasenaDoc.Text;

            dao.InsertarDoctor(Doctor);
            habilitarCampos(true);
            listarDoctores();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow Fila = DoctoresDGV.SelectedRows[0];
            int id = (int)Fila.Cells[0].Value;
            Dao dao = new Dao();
            dao.EliminarDoctor(id);
            listarDoctores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow Fila = DoctoresDGV.SelectedRows[0];
            txtNombreDoc.Text = (String)Fila.Cells[1].Value;
            DocGenCb.Text = (String)Fila.Cells[2].Value;
            DocEspecCb.Text = ((String)Fila.Cells[3].Value).ToString();
            txtExpDoc.Text = ((int)Fila.Cells[4].Value).ToString();
            txtDireccionDoc.Text = (String)Fila.Cells[5].Value;
            //DOcDOB.Text = (SistemDateTime)Fila.Cells[6].Value;
            txtTelDoc.Text = ((int)Fila.Cells[7].Value).ToString();
            txtContrasenaDoc.Text =((String)Fila.Cells[8].Value);
            habilitarCampos(false);
            
        }

        private void BtnPacientesDoc_Click(object sender, EventArgs e)
        {
            Pacientes obj = new Pacientes();
            obj.Show();
            this.Hide();
        }

        private void BtnDoctoresDoc_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnLaboratorioDoc_Click(object sender, EventArgs e)
        {
            Laboratorio obj = new Laboratorio();
            obj.Show();
            this.Hide();
        }

        private void BtnRecepcionistaDoc_Click(object sender, EventArgs e)
        {
            Recepcionista obj = new Recepcionista();
            obj.Show();
            this.Hide();
        }

        private void BtnSalirDoctores_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void prescripBtn_Click(object sender, EventArgs e)
        {
           
        }
    }

}
