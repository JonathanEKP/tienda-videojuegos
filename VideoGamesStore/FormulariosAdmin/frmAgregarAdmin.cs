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
    public partial class frmAgregarAdmin : Form
    {
        public frmAgregarAdmin()
        {
            InitializeComponent();
            cargardatos();
            deshabilitar();
        }

        private void cargardatos()
        {
            try
            {
                using (ProyectopooEntities model = new ProyectopooEntities())
                {
                    dgvAdmin.DataSource = model.Users.ToList();
                    dgvAdmin.Columns["UserId"].Visible = false;
                    dgvAdmin.ClearSelection();
                    if (dgvAdmin.RowCount > 0)
                    {
                        dgvAdmin.Rows[0].Selected = false;

                    }
                }

                

            }catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void llenar()
        {
            if (dgvAdmin.RowCount > 0)
            {
                txtName.Text = dgvAdmin.Rows[dgvAdmin.CurrentRow.Index].Cells[2].Value.ToString();
                txtApellido.Text = dgvAdmin.Rows[dgvAdmin.CurrentRow.Index].Cells[3].Value.ToString();
                txtPass.Text = dgvAdmin.Rows[dgvAdmin.CurrentRow.Index].Cells[1].Value.ToString();
            }
        }

        private void dgvAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAdmin_Click(object sender, EventArgs e)
        {
            //llenar();
        }

       
        private void habilitar()
        {
            txtPass.Enabled = true;
            txtName.Enabled = true;
            txtConfirmar.Enabled = true;
            txtApellido.Enabled = true;
        }
        private void deshabilitar()
        {
            txtName.Enabled = false;
            txtApellido.Enabled = false;
            txtConfirmar.Enabled = false;
            txtPass.Enabled = false;

        }

        private void limpiar()
        {
            txtApellido.Clear();
            txtConfirmar.Clear();
            txtName.Clear();
            txtPass.Clear();
        }
        
       

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminPrincipal frm = new frmAdminPrincipal();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            limpiar();
            habilitar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtApellido.Text==String.Empty || txtConfirmar.Text==String.Empty || txtName.Text==String.Empty || txtPass.Text==String.Empty)
            {
                MessageBox.Show("Debe rellenear todos los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    Users oUsers = new Users();
                    oUsers.Name = txtName.Text;
                    oUsers.LastName = txtApellido.Text;
                    if (txtPass.Text == txtConfirmar.Text)
                    {
                        string sPass = Clases.Encrypt.GetSHA256(txtPass.Text.Trim());
                        oUsers.Password = sPass;
                        MessageBox.Show("Administrado agregado con exito!", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.Users.Add(oUsers);
                        db.SaveChanges();
                        limpiar();
                        

                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas deben coincidir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
