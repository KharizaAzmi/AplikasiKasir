using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace AplikasiKasir
{
    public partial class FormMasterBarang : Form
    {
        Koneksi konn = new Koneksi();
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rd;

        void pilihSatuan()
        {
            comboBox1.Items.Add("Box");
            comboBox1.Items.Add("Pcs");
            comboBox1.Items.Add("Kilo");
            comboBox1.Items.Add("Pax");
            comboBox1.Items.Add("Botol");
            comboBox1.Items.Add("Karung");
        }

        void kondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";

            pilihSatuan();
            munculDataBarang();
        }

        void munculDataBarang()
        {
            SqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from Tabel_Barang", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Tabel_Barang");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tabel_Barang";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();
        }


        public FormMasterBarang()
        {
            InitializeComponent();
        }

        private void FormMasterBarang_Load(object sender, EventArgs e)
        {
            kondisiAwal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan perubahan data terisi");
            }
            else
            {
                SqlConnection conn = konn.GetConn();
                cmd = new SqlCommand("Update Tabel_Barang set NamaBarang='" + textBox2.Text + "',HargaBeli='" + textBox3.Text + "',HargaJual='" + textBox4.Text + "',JumlahBarang='" + textBox5.Text + "',levelBarang='" + comboBox1.Text + "'where KodeBarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diubah");
                kondisiAwal();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan perubahan data terisi");
            }
            else
            {
                SqlConnection conn = konn.GetConn();
                cmd = new SqlCommand("delete Tabel_Barang where KodeBarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus");
                kondisiAwal();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi");
            }
            else
            {
                SqlConnection conn = konn.GetConn();
                cmd = new SqlCommand("insert into Tabel_Barang values('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + textBox5.Text + "' ,'" + comboBox1.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diinput");
                kondisiAwal();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Laporan Barang";
            printer.SubTitle = string.Format("Tanggal {0}", DateTime.Now.Date.ToString("dddd-MMMM-yyyy"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns= true;
            printer.HeaderCellAlignment= StringAlignment.Near;
            printer.FooterSpacing= 15;
            printer.Footer = "Toko Indah";
            printer.PrintPreviewDataGridView(dataGridView1);
        }
    }
}
