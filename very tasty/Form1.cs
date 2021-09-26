using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Windows.Forms;

namespace very_tasty
{
    public partial class Form1 : Form
    {

        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|login.accdb");

        
        
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conex = new SqlConnection("server = LAPTOP-SCCOV70O; database = codigos+ ; integrated security=true");

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                MessageBox.Show("conectado");

            }
            catch(Exception a)
            {

                MessageBox.Show("Error por; " + a.ToString());
            }
        }
               

        private void button1_Click(object sender, EventArgs e)
        {
            string consulta = "select password,usuario from login where password = '" + textBox2.Text + "' and usuario = '" + textBox1.Text + "';";
            OleDbCommand comando = new OleDbCommand(consulta,conexion);
            OleDbDataReader leedb;
            leedb = comando.ExecuteReader();
            Boolean existereg = leedb.HasRows;
            if (existereg)
            {
                MessageBox.Show("bienvenido al sistema" + textBox1.Text);
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("usuario o contraseña incorrecto trate de nuevo");
                return;
            }
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conex.Open();
            string consul = "select * from usuarios where usuario='"+ textBox1.Text + "' and pass='"+ textBox2.Text +" ' ";
            SqlCommand coman = new SqlCommand(consul,conex);
            SqlDataReader lector;
            lector = coman.ExecuteReader();

            if (lector.HasRows == true) 
            {
                MessageBox.Show("bienvenido al sistema" + textBox1.Text);
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();

            }
            else 
            {

                MessageBox.Show(" Usuario o Contraseña invalido");
            
            }
            conex.Close();
        }    
    }
}
