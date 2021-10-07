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


       
       
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conex = new SqlConnection("server = LAPTOP-SCCOV70O; database = codigos+ ; integrated security=true");
       
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conex.Open();
                MessageBox.Show("conectado");

            }
            catch(Exception a)
            {

                MessageBox.Show("Error por; " + a.ToString());
            }
        }
               

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {
                OleDbConnection conexion_access = new OleDbConnection();
                conexion_access.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\SISTEMA\\sistema.accdb ";
                conexion_access.Open();
                OleDbDataAdapter consulta = new OleDbDataAdapter("SELECT * FROM usuario", conexion_access);
                DataSet resultado = new DataSet(); consulta.Fill(resultado);
                foreach (DataRow registro in resultado.Tables[0].Rows)
                {
                    if ((textBox1.Text == registro["nombre"].ToString()) && (textBox2.Text == registro["clave"].ToString()))
                    {

                        Form3 f3 = new Form3();
                        f3.Show();
                        this.Hide();
                    }
                    conexion_access.Close();
                }

            }

            catch (Exception err)
            {

                MessageBox.Show(err.Message); MessageBox.Show("Error de usuario o clave de acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                
            }
           


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
