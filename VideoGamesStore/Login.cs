using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoGamesStore
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //validar(this);
            string sPass = Clases.Encrypt.GetSHA256(txtContraseña.Text.Trim());
            if (txtCorreo.Text == String.Empty || txtContraseña.Text == String.Empty)
            {
                MessageBox.Show("Por favor rellene todos los campos");
            }
            else
            {
                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    var lst = from d in db.Clients
                              where d.email == txtCorreo.Text
                              && d.Password == sPass
                              select d;

                    var lst2 = from a in db.Users
                               where a.Name == txtCorreo.Text
                               && a.Password == sPass
                               select a;
                    if (lst.Count() > 0)
                    {
                        this.Hide();
                        FormulariosVentas.frmMain frm = new FormulariosVentas.frmMain();
                        frm.FormClosed += (s, args) => this.Close();
                        frm.Show();

                    }
                    else if (lst2.Count() > 0)
                    {
                        this.Hide();
                        FormulariosAdmin.frmAdminPrincipal frmP = new FormulariosAdmin.frmAdminPrincipal();
                        frmP.FormClosed += (s, args) => this.Close();
                        frmP.Show();

                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecta.");
                    }



                }
            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegistro frmR = new frmRegistro();
            frmR.FormClosed += (s, args) => this.Close();
            frmR.Show();
        }
    }
}
