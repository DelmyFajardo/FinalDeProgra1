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
    public partial class Recepcionista : Form
    {
        public Recepcionista()
        {
            InitializeComponent();
        }

        private void habilitarCampos(bool readOnly)
        {

            txtRecepcionista.ReadOnly = readOnly;
            txtTelefono.ReadOnly = readOnly;
            txtDireccion.ReadOnly = readOnly;
            txtContrasena.ReadOnly = readOnly;
            

        }

        private void listRecepcionista()
        {
            RecepcionistaDao recepcionistadao = new RecepcionistaDao();
            RecepcionistaDGV.DataSource = recepcionistadao.ObtenerTodosLosDatosRecepcionista();

        }

        public int IdRecepcionista { get; internal set; }
        public string NombreRecepcionista { get; internal set; }
        public string TelefonoRecepcionista { get; internal set; }
        public string DireccionRecepcionista { get; internal set; }
        public string ContrasenaRecepcionista { get; internal set; }

        private void Recepcionista_Load(object sender, EventArgs e)
        {
            listRecepcionista();
        }

        private void ActualizarRecepcionista()
        {
            RecepcionistaDao recepcionistadao = new RecepcionistaDao();
            Recepcionista recepcionista = new Recepcionista();

            DataGridViewRow Fila = RecepcionistaDGV.SelectedRows[0];
            int id = (int)Fila.Cells[0].Value;
            recepcionista.IdRecepcionista = id;
            recepcionista.NombreRecepcionista = txtRecepcionista.Text;
            recepcionista.DireccionRecepcionista = txtDireccion.Text;
            recepcionista.TelefonoRecepcionista = txtTelefono.Text;
            recepcionista.ContrasenaRecepcionista = txtContrasena.Text;
            recepcionistadao.ActualizarRecepcionista(recepcionista);
            habilitarCampos(true);
            listRecepcionista();
        }
        private void InsertarRecepcionista()
        {
            RecepcionistaDao recepcionistadao = new RecepcionistaDao();
            Recepcionista recepcionista = new Recepcionista();
            recepcionista.NombreRecepcionista = txtRecepcionista.Text;
            recepcionista.DireccionRecepcionista = txtDireccion.Text;
            recepcionista.TelefonoRecepcionista = txtTelefono.Text;
            recepcionista.ContrasenaRecepcionista = txtContrasena.Text;

            recepcionistadao.InsertarRecepcionista(recepcionista);
            habilitarCampos(true);
            listRecepcionista();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            InsertarRecepcionista();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActualizarRecepcionista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow Fila = RecepcionistaDGV.SelectedRows[0];
            txtRecepcionista.Text = (String)Fila.Cells[1].Value;
            txtTelefono.Text = ((string)Fila.Cells[2].Value).ToString();
            txtDireccion.Text = (String)Fila.Cells[3].Value;
    
            txtContrasena.Text = ((String)Fila.Cells[4].Value);
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
            
        }

        private void BtnSalirRecepcionista_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PresBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
