using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
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
            string consulta = "select password,usuario from login where password '" + textBox2 + "' and usuario '" + textBox1 + "';";
            OleDbCommand comando = new OleDbCommand(consulta, conexion);
            OleDbDataReader leedb;
            leedb = comando.ExecuteReader();
            Boolean existereg = leedb.HasRows;
            if (existereg)
            {
                MessageBox.Show("bienvenido al sistema " + textBox1.Text);
                Form3 f3 = new Form3();
                f3.Show();


            }
            else
            {
                MessageBox.Show(" usuario o contraseña incorreto");
                return;
            }
            conexion.Close();
        }
    }
}
