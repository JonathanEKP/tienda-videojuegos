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
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }


        


        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text == String.Empty || txtConfirmar.Text == String.Empty
                   || txtContraseña.Text == String.Empty || txtCorreo.Text == String.Empty
                   || txtDireccion.Text == String.Empty || txtNombre.Text == String.Empty)
            {
                MessageBox.Show("Debe rellenear todos los campos","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                using (ProyectopooEntities db = new ProyectopooEntities())
                {


                    Clients Oclients = new Clients();
                    Oclients.Name = txtNombre.Text;
                    Oclients.LastName = txtApellido.Text;
                    Oclients.email = txtCorreo.Text;
                    Oclients.ShippAdress = txtDireccion.Text;
                    if (txtContraseña.Text == txtConfirmar.Text)
                    {
                        string sPass = Clases.Encrypt.GetSHA256(txtContraseña.Text.Trim());
                        Oclients.Password = sPass;
                        MessageBox.Show("Cuenta creada con exito!");
                        db.Clients.Add(Oclients);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas deben coincidir");
                    }




                }
            }

            
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.FormClosed += (s, args) => this.Close();
            lg.Show();
        }
    }
}
