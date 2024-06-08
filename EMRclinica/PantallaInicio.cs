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
    public partial class PantallaInicio : Form
    {
        public PantallaInicio()
        {
            InitializeComponent();
        }

        private void BtnPacientesInicio_Click(object sender, EventArgs e)
        {
            Pacientes obj = new Pacientes();
            obj.Show();
            this.Hide();

        }

        private void BtnDoctoresInicio_Click(object sender, EventArgs e)
        {
            Doctores doc = new Doctores();
            doc.Show();
            this.Hide();
        }

        private void BtnLaboratorioInicio_Click(object sender, EventArgs e)
        {
            Laboratorio obj = new Laboratorio();
            obj.Show();
            this.Hide();
        }

        private void BtnRecepcionistaInicio_Click(object sender, EventArgs e)
        {
            Recepcionista obj = new Recepcionista();
            obj.Show();
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnSalirInicio_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj .Show();
            this.Hide();
        }

        private void PrescrBtn_Click(object sender, EventArgs e)
        {
            Prescripciones presc = new Prescripciones();
            presc.Show();
            this.Hide();
        }
    }
}
