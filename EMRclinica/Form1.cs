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
    public partial class Form1 : Form
    {
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

        }

       

        private void BtnReiniciar_Click(object sender, EventArgs e)
        {

        }
    }
}
