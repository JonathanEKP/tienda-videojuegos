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
    public partial class frmAdminClientes : Form
    {
        Clients op;
        ProyectopooEntities db = new ProyectopooEntities();
        public frmAdminClientes()
        {
            InitializeComponent();
            cargarDB();
            bloquear();
            
        }
        private void cargarDB()
        {
            try
            {
                using (ProyectopooEntities model = new ProyectopooEntities())
                {
                    dgvClientes.DataSource = model.Clients.ToList();

                    dgvClientes.Columns["Cart"].Visible = false;
                    dgvClientes.ClearSelection();
                    if (dgvClientes.RowCount > 0)
                    {
                        dgvClientes.Rows[0].Selected = false;

                    }
                }

                txtID.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
        private void bloquear()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtContraseña.Enabled = false;
            txtEmail.Enabled = false;
            txtDireccion.Enabled = false;
        }
        private void des()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtContraseña.Enabled = true;
            txtEmail.Enabled = true;
            txtDireccion.Enabled = true;
        }
        private void filtrar( string nombre, string criterio = "Name")
        {
            if (!txtNombre.Text.Equals(""))
            {
                dgvClientes.DataSource = db.Clients.SqlQuery("select * from Clients where " + criterio + " like '" + nombre + "%'").ToList();
            }
        }
        private void limpiar()
        {
            txtNombre.Text = " ";
            txtApellido.Text = " ";
            txtContraseña.Text = " ";
            txtEmail.Text = " ";
            txtDireccion.Text = " ";
        }
        private void llenar()
        {
            this.txtID.Text = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();
            this.txtNombre.Text = dgvClientes.SelectedRows[0].Cells[1].Value.ToString();
            this.txtApellido.Text = dgvClientes.SelectedRows[0].Cells[2].Value.ToString();
            this.txtContraseña.Text = dgvClientes.SelectedRows[0].Cells[3].Value.ToString();
            this.txtEmail.Text = dgvClientes.SelectedRows[0].Cells[4].Value.ToString();
            this.txtDireccion.Text = dgvClientes.SelectedRows[0].Cells[5].Value.ToString();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminPrincipal frm = new frmAdminPrincipal();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();
        }

        private void dgvClientes_Click(object sender, EventArgs e)
        {
            llenar();
            des();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            op = new Clients();

            op.Name = txtNombre.Text;
            op.LastName = txtApellido.Text;
            op.Password = txtContraseña.Text;
            op.email = txtEmail.Text;
            op.ShippAdress = txtDireccion.Text;

            db.Clients.Add(op);
            db.SaveChanges();
            cargarDB();
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            des();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btmAceptar_Click(object sender, EventArgs e)
        {
            filtrar(txtNombre.Text);
            bloquear();
        }
    }
}
