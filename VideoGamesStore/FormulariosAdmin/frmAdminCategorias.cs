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
    public partial class frmAdminCategorias : Form
    {
        ProyectopooEntities db = new ProyectopooEntities();
        public int? id;
        public frmAdminCategorias()
        {
            InitializeComponent();
            cargardatos();
            bloquear();
            
        }

        private void cargardatos()
        {
            try
            {
                using (ProyectopooEntities model = new ProyectopooEntities())
                {
                    dgvCategorias.DataSource = model.Categorie.ToList();
                    dgvCategorias.Columns["Forum"].Visible = false;
                    dgvCategorias.Columns["Products"].Visible = false;
                    dgvCategorias.ClearSelection();
                    if (dgvCategorias.RowCount > 0)
                    {
                        dgvCategorias.Rows[0].Selected = false;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            txtID.Visible = false;
            //dgvCategorias.DataSource = db.Categorie.Where(x => x.CategoryId == 1).ToList();
            dgvCategorias.Columns[0].HeaderText = "ID";
            dgvCategorias.Columns[1].HeaderText = "Categoria";
            txtNombreCat.Text = "";
        }
        private void llenar()
        {
            this.txtID.Text = dgvCategorias.SelectedRows[0].Cells[0].Value.ToString();
            this.txtNombreCat.Text = dgvCategorias.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreCat.Text == String.Empty)
            {
                MessageBox.Show("Debe agregar un nombre a la categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    Categorie op = new Categorie();
                    op.Description = txtNombreCat.Text;

                    db.Categorie.Add(op);
                    db.SaveChanges();
                    cargardatos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty)
            {
                MessageBox.Show("Seleccione un registro para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt16(this.txtID.Text);


                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    Categorie c = db.Categorie.FirstOrDefault(x => x.CategoryId == id);
                    db.Categorie.Remove(c);
                    db.SaveChanges();
                    cargardatos();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtID.Text==String.Empty)
            {
                MessageBox.Show("Debe seleccionar un registro para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id1 = Convert.ToInt16(this.txtID.Text);
                string categoria = txtNombreCat.Text;

                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    Categorie c = db.Categorie.FirstOrDefault(x => x.CategoryId == id1);
                    c.Description = categoria;
                    db.SaveChanges();
                    cargardatos();
                }
                
            }
        }

        private void bloquear()
        {
            txtNombreCat.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
            button1.Enabled = false;
        }

        private void dgvCategorias_Click(object sender, EventArgs e)
        {
            llenar();
            bloquear();
            txtNombreCat.Enabled = true;
            btnEliminar.Enabled = true;
            button1.Enabled = true;
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
            cargardatos();
            bloquear();
            txtNombreCat.Enabled = true;
            btnGuardar.Enabled = true;
        }
    }
}
