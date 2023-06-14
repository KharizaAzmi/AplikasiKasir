using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiKasir
{
    public partial class FormMenuUtama : Form
    {
        public static FormMenuUtama menu;
        MenuStrip mnstrip;
        FormLogin formLogin;
        FormMasterKasir formKasir;
        FormMasterBarang formBarang;

        void formLogin_formClosed(object sender, FormClosedEventArgs e)
        {
            formLogin = null;
        }

        void formKasir_formClosed(object sender, FormClosedEventArgs e)
        {
            formKasir = null;
        }

        void formBarang_formClosed(object sender, FormClosedEventArgs e)
        {
            formBarang = null;
        }

        void MenuLocked()
        {
            loginToolStripMenuItem.Enabled = true;
            logoutToolStripMenuItem.Enabled = false;
            masterToolStripMenuItem.Enabled = false;
            laporanToolStripMenuItem.Enabled = false;
            transaksiToolStripMenuItem.Enabled = false;
            toolsToolStripMenuItem.Enabled = false;
            menu = this;
        }

        public FormMenuUtama()
        {
            InitializeComponent();
        }

        private void FormMenuUtama_Load(object sender, EventArgs e)
        {
            MenuLocked();
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(formLogin == null)
            {
                formLogin = new FormLogin();
                formLogin.FormClosed += new FormClosedEventHandler(formLogin_formClosed);
                formLogin.ShowDialog();
            }
            else
            {
                formLogin.Activate();
            }
            //formLogin = new FormLogin();
            //formLogin.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuLocked();
        }

        private void kasirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formKasir == null)
            {
                formKasir = new FormMasterKasir();
                formKasir.FormClosed += new FormClosedEventHandler(formKasir_formClosed);
                formKasir.ShowDialog();
            }
            else
            {
                formKasir.Activate();
            }
        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formBarang == null)
            {
                formBarang = new FormMasterBarang();
                formBarang.FormClosed += new FormClosedEventHandler(formBarang_formClosed);
                formBarang.ShowDialog();
            }
            else
            {
                formBarang.Activate();
            }
        }
    }
}
