using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoGamesStore.FormulariosVentas
{
    public partial class frmAdd : Form
    {
        ProyectopooEntities db = new ProyectopooEntities();
        public frmAdd()
        {
            InitializeComponent();
            bloquear();
        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bloquear()
        {
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtSubTotal.Enabled = false;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain main = new frmMain();
            main.Show();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmFactura fac = new frmFactura();
            fac.Show();
            
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        { 
            var a = from c in db.Clients
                    where c.email == txtIdLogin.Text
                    select c;
            if(a.Count() > 0)
            {
                
            }

            Cart añadir = new Cart();
            añadir.Quantity = int.Parse(txtCant.Text);
            añadir.ProductId = int.Parse(txtNombre.Text);
            añadir.Login_id = int.Parse(txtIdLogin.Text);
        }
    }
}
