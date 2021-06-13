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
            dgvClientes.DataSource = db.Clients.Where(x => x.Login_id == 1).ToList();
            dgvClientes.Columns[0].HeaderText = "ID Login";
            dgvClientes.Columns[1].HeaderText = "Nombre";
            dgvClientes.Columns[2].HeaderText = "Apellido";
            dgvClientes.Columns[3].HeaderText = "Contraseña";
            dgvClientes.Columns[4].HeaderText = "Email";
            dgvClientes.Columns[5].HeaderText = "Direccion";
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
            btmAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEditar.Enabled = false;
        }
        private void des()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtContraseña.Enabled = true;
            txtEmail.Enabled = true;
            txtDireccion.Enabled = true;
            btmAceptar.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
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
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtContraseña.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
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
            btmAceptar.Enabled = false;
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(txtID.Text.Equals("")|| txtNombre.Text.Equals("") || txtApellido.Text.Equals("") || txtContraseña.Text.Equals("") || txtEmail.Text.Equals("")||txtDireccion.Text.Equals("")){
                MessageBox.Show("Debe rellenar todos los campos!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int id = int.Parse(txtID.Text);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string pass = txtContraseña.Text;
                string email = txtEmail.Text;
                string dir = txtDireccion.Text;

                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    Clients p = db.Clients.FirstOrDefault(x => x.Login_id == id);
                    p.Name = nombre;
                    p.LastName = apellido;
                    p.Password = pass;
                    p.email = email;
                    p.ShippAdress = dir;
                    db.SaveChanges();
                }
            }
            cargarDB();
            bloquear();
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            des();
            ocultar();
            limpiar();
            btnEditar.Enabled = false;
            btnBuscar.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btmAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals(""))
            {
                MessageBox.Show("Debe rellenar todos los campos!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            filtrar(txtNombre.Text);
            bloquear();
            btnCancelar.Enabled = true;
        }
        private void ocultar()
        {
            txtApellido.Visible = false;
            txtContraseña.Visible = false;
            txtDireccion.Visible = false;
            txtEmail.Visible = false;
            txtID.Visible = false;
            lblApellido.Visible = false;
            lblContraseña.Visible = false;
            lblDir.Visible = false;
            lblEmail.Visible = false;
        }
        private void desOcultar()
        {
            txtApellido.Visible = true;
            txtContraseña.Visible = true;
            txtDireccion.Visible = true;
            txtEmail.Visible = true;
            txtID.Visible = true;
            lblApellido.Visible = true;
            lblContraseña.Visible = true;
            lblDir.Visible = true;
            lblEmail.Visible = true;
            txtID.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cargarDB();
            limpiar();
            bloquear();
            desOcultar();
            btnBuscar.Enabled = true;
        }
    }
}
