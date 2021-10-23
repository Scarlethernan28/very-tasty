using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace very_tasty
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        static string co = "server =127.0.0.1; port =3306; database =dias, uid =root; password =;";
        MySqlConnection cn = new MySqlConnection(co);
        
        public DataTable llenar_grid()  
        {
            cn.Open();
            DataTable dt = new DataTable();
            string llenar = "select * from inventario";
            MySqlCommand cmd = new MySqlCommand(llenar,cn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            cn.Close();
            return dt;
        
        
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenar_grid();
        }
    }
}
