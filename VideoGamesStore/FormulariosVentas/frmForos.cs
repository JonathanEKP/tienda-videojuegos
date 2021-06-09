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
    public partial class frmForos : Form
    {
        ProyectopooEntities db = new ProyectopooEntities();
        public frmForos()
        {
            InitializeComponent();
            cargarDatos();
            combo1();
            txtComentario.Enabled = false;
            txtNombre.Enabled = false;
            btnComentar.Enabled = false;
            dgvForo.Visible = false;
        }
        private void cargarDatos()
        {
            try
            {
                using (ProyectopooEntities model = new ProyectopooEntities())
                {
                    dgvForo.DataSource = model.Forum.ToList();
                    dgvForo.Columns["ForumId"].Visible = false;
                    dgvForo.Columns["CategoryId"].Visible = false;
                    dgvForo.Columns["Categorie"].Visible = false;
                    dgvForo.ClearSelection();
                    if (dgvForo.RowCount > 0)
                    {
                        dgvForo.Rows[0].Selected = false;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            //txtID.Visible = false;
            //dgvCategorias.DataSource = db.Categorie.Where(x => x.CategoryId == 1).ToList();
            dgvForo.Columns[0].HeaderText = "Nombre";
            dgvForo.Columns[1].HeaderText = "Comentario";
            txtComentario.Text = "";
            dgvForo.Enabled = false;
            txtNombre.Text = "";
            txtComentario.Enabled = false;
            txtNombre.Enabled = false;
        }

        private void combo1()
        {
            var lista = db.Categorie.ToList();

            if (lista.Count > 0)
            {
                cmbCategoria.DataSource = lista;
                cmbCategoria.DisplayMember = "Description";
                cmbCategoria.ValueMember = "CategoryId";
                if (cmbCategoria.Items.Count >= 1)
                {
                    cmbCategoria.SelectedIndex = -1;
                }
            }

        }

        private void btnComentar_Click(object sender, EventArgs e)
        {
            if (txtComentario.Text.Equals("") || cmbCategoria.Text.Equals(""))
            {
                MessageBox.Show("Debe rellenar todos los campos!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Forum f = new Forum();
            f.Comments = txtComentario.Text;
            f.CategoryId = int.Parse(cmbCategoria.SelectedValue.ToString());
            f.Description = txtNombre.Text;

            db.Forum.Add(f);
            db.SaveChanges();
            //cargarDatos();
            filtrar(cmbCategoria.SelectedValue.ToString());
            combo1();
            txtComentario.Text = "";
            txtNombre.Text = "";
        }
        private void filtrar(string categoria, string criterio = "CategoryId")
        {
            if (!cmbCategoria.Text.Equals(""))
            {
                dgvForo.DataSource = db.Forum.SqlQuery("select * from Forum where " + criterio + " like '" + categoria + "%'").ToList();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtrar(cmbCategoria.SelectedValue.ToString());
            txtComentario.Enabled = true;
            txtNombre.Enabled = true;
            btnComentar.Enabled = true;
            dgvForo.Visible = true;
        }
    }
}
