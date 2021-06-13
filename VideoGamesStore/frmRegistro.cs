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

        private void limpiar()
        {
            txtApellido.Text = "";
            txtConfirmar.Text = "";
            txtContraseña.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
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
                    var lst = from d in db.Clients
                              where d.email == txtCorreo.Text
                              select d;
                    if (lst.Count() > 0)
                    {
                        MessageBox.Show("Error, este correo electronico ya está en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
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
                            MessageBox.Show("Cuenta creada con exito!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            db.Clients.Add(Oclients);
                            db.SaveChanges();
                            limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas deben coincidir","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }




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
