﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EMRclinica
{
    public partial class Laboratorio : Form
    {
        public int TestNum { get; private set; }
        public string NombreTest { get; private set; }
        public string CostoTest { get; private set; }

        public Laboratorio()
        {
            InitializeComponent();
        }

        private void habilitarCampos(bool readOnly)
        {

            txtNombreExamen.ReadOnly= readOnly;
            txtCostoExam.ReadOnly= readOnly;
            
             
        }

        private void listarTest()
        {
            LabDao labdao = new LabDao();
            LabDGV.DataSource = labdao.ObtenertodoslosTest();

        }

        private void ActualizarTest()
        {
            LabDao labdao = new LabDao();
            Laboratorio Test = new Laboratorio();

            DataGridViewRow Fila = LabDGV.SelectedRows[0];
            int TestNum = (int)Fila.Cells[0].Value;
            Test.TestNum = TestNum;
            Test.NombreTest = txtNombreExamen.Text;
            Test.CostoTest = txtCostoExam.Text;
           
            habilitarCampos(true);
            listarTest();
        }
        private void InsertarTest()
        {
            LabDao labdao = new LabDao();
            Laboratorio Test = new Laboratorio();
            Test.NombreTest = txtNombreExamen.Text;
            Test.CostoTest = txtCostoExam.Text;
            
            labdao.InsertarTest(Test);
            habilitarCampos(true);
            listarTest();

        }

        private void btnElimExam_Click(object sender, EventArgs e)
        {
            DataGridViewRow Fila = LabDGV.SelectedRows[0];
            int TestNum = (int)Fila.Cells[0].Value;
            LabDao labdao = new LabDao();
            labdao.EliminarTest(TestNum);
            listarTest();
        }

        private void btnEditExam_Click(object sender, EventArgs e)
        {
            DataGridViewRow Fila = LabDGV.SelectedRows[0];
            txtNombreExamen.Text = (String)Fila.Cells[1].Value;
            txtCostoExam.Text = (String)Fila.Cells[2].Value;
            ;
          
            habilitarCampos(false);
        }
    }


}