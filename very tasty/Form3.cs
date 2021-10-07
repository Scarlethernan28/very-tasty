using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace very_tasty
{
    public partial class Form3 : Form
    {
        public OleDbConnection miconexion;
        public string usuario_modificar;
        public Form3()
        {
            miconexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Sistema\sistema.accdb ");
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sistemaDataSet.usuario' Puede moverla o quitarla según sea necesario.
            this.usuarioTableAdapter.Fill(this.sistemaDataSet.usuario);

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.usuarioBindingSource.MoveFirst();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.usuarioBindingSource.MovePrevious();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.usuarioBindingSource.MoveNext();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.usuarioBindingSource.MoveLast();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            comboBox1.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "selecione nivel";
            textBox1.Focus();
            button2.Visible = false;
            button3.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand guardar = new OleDbCommand();
                miconexion.Open();
                guardar.Connection = miconexion;
                guardar.CommandType = CommandType.Text;
                guardar.CommandText = "INSERT INTO usuario ([nombre], [clave],[nivel]) Values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox1.Text.ToString() + "')";
                guardar.ExecuteNonQuery();
                miconexion.Close();
                button2.Visible = true;
                button3.Visible = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                comboBox1.Enabled = false;
                button2.Focus();
                MessageBox.Show("Usuario agregado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.usuarioTableAdapter.Fill(this.sistemaDataSet.usuario);
                this.usuarioBindingSource.MoveLast();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            comboBox1.Enabled = true;
            textBox1.Focus();
            button7.Visible = false;
            button8.Visible = true;
            usuario_modificar = textBox1.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try 
            {
                OleDbCommand actualizar = new OleDbCommand();
                miconexion.Open(); 
                actualizar.Connection = miconexion; 
                actualizar.CommandType = CommandType.Text;
                string nom = textBox1.Text.ToString();
                string cla = textBox2.Text.ToString();
                string niv = comboBox1.Text;

                actualizar.CommandText = "UPDATE usuario SET nombre = '" + nom + "', clave = '" + cla + "',nivel = '" + niv + "' WHERE nombre = '" + usuario_modificar + "'";
                actualizar.ExecuteNonQuery(); miconexion.Close();

                textBox1.Enabled = true;
                textBox2.Enabled = true;
                comboBox1.Enabled = true;
                button7.Visible = true;
                button8.Visible = false;
                MessageBox.Show("Usuario actualizado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand eliminar = new OleDbCommand();
                miconexion.Open();
                eliminar.Connection = miconexion;
                eliminar.CommandType = CommandType.Text;
                eliminar.CommandText = "DELETE FROM usuario WHERE nombre = '" + textBox1.Text.ToString() + "'";
                eliminar.ExecuteNonQuery();
                this.usuarioBindingSource.MoveNext();
                miconexion.Close();
                MessageBox.Show("Usuario eliminado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.usuarioBindingSource.MovePrevious();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
