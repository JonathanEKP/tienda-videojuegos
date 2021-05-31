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
        public int? id;
        public frmAdminCategorias()
        {
            InitializeComponent();
            cargardatos();
            
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
        }
        private void llenar()
        {
            this.txtID.Text = dgvCategorias.SelectedRows[0].Cells[0].Value.ToString();
            this.txtNombreCat.Text = dgvCategorias.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

        private void btnEliminar_Click(object sender, EventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            int id1 = Convert.ToInt16(this.txtID.Text);
            string categoria = txtNombreCat.Text;

            using(ProyectopooEntities db = new ProyectopooEntities())
            {
                Categorie c = db.Categorie.FirstOrDefault(x => x.CategoryId == id1);
                c.Description = categoria;
                db.SaveChanges();
                cargardatos();
            }
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCategorias_Click(object sender, EventArgs e)
        {
            llenar();
        }
    }
}
