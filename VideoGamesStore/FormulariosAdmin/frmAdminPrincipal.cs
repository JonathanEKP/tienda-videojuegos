using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoGamesStore.FormulariosAdmin
{
    public partial class frmAdminPrincipal : Form
    {
        public frmAdminPrincipal()
        {
            InitializeComponent();
        }

        private void frmAdminPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnVideojuegos_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminVideojuegos frm = new frmAdminVideojuegos();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminClientes frm = new frmAdminClientes();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();
        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOrdenes frm = new frmOrdenes();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminCategorias frm = new frmAdminCategorias();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();
        }

        private void btnOtherSites_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOtherSites frm = new frmOtherSites();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAgregarAdmin frm = new frmAgregarAdmin();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();
        }
    }
}
