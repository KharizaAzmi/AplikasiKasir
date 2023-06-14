using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AplikasiKasir
{
    public partial class FormLogin : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rd;

        Koneksi konn = new Koneksi();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataReader reader = null;
            SqlConnection conn = konn.GetConn();
            {
                conn.Open();
                cmd = new SqlCommand("select * from Tabel_Kasir where KodeKasir='"+ textBox1.Text + "' and PasswordKasir='"+ textBox2.Text + "'", conn);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    FormMenuUtama.menu.loginToolStripMenuItem.Enabled = false;
                    FormMenuUtama.menu.logoutToolStripMenuItem.Enabled = true;
                    FormMenuUtama.menu.masterToolStripMenuItem.Enabled = true;
                    FormMenuUtama.menu.transaksiToolStripMenuItem.Enabled = true;
                    FormMenuUtama.menu.laporanToolStripMenuItem.Enabled = true;
                    FormMenuUtama.menu.toolsToolStripMenuItem.Enabled = true;
                    //FormMenuUtama formUtama = new FormMenuUtama();
                    //formUtama.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Salah!");
                }
            }
            /*if(textBox1.Text == "ADM001" && textBox2.Text == "admin123")
            {
                FormMenuUtama formMenu = new FormMenuUtama();
                formMenu.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("username/password salah");
            }*/
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
