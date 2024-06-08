using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EMRclinica
{
    public partial class Form1 : Form
    {
        public string usuario = "Cris";
        public string contraseña = "123";
        public Form1()
        {
            InitializeComponent();
        }
        private string connectionString = "server=localhost;" +
          "user=root;" +
          "password=;" +
          "database=clinicadb;";

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void RolCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            RolCB.SelectedIndex = 0;
            UsuarioTB.Text = "";
            ContrasenaTB.Text = " ";
        }
        public static string Role;

        private void button1_Click(object sender, EventArgs e)
        {
            string usuarioText = UsuarioTB.Text;
            string contraseñaText = ContrasenaTB.Text;

            if (usuario == usuarioText && contraseña == contraseñaText)
            {
                MessageBox.Show("Sesion iniciada correctamente");
                PantallaInicio obj = new PantallaInicio();
                this.Hide();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Valores incorrectos, intenta de nuevo.");
            }
        }

        private void BtnReiniciar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is System.Windows.Forms.TextBox)
                    ctr.Text = string.Empty;
            }
        }
    }

}
