﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMRclinica
{
    internal class ConexionMysql 
    {
       private MySqlConnection connection;
       private string cadenaConexion;
       
       public ConexionMysql()
        {
           /* cadenaConexion = "Database=" + database + 
            ";DataSource = " + server +
            ";User Id = " + user +
            "; Password ="+password;
            */connection = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection getConnection() 
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return connection; 
            
           
        }

    }
}
