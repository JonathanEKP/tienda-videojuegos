using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoGamesStore.FormulariosAdmin
{
    public partial class frmAdminVideojuegos : Form
    {

        Clases.CategoryViewModel cat = new Clases.CategoryViewModel();
        public frmAdminVideojuegos()
        {
            InitializeComponent();
            cargarcmb();
            cargar();
            txtFile.Enabled = false;
            refrescar();
            deshabilitar();
        }


        private void cargar()
        {
            try
            {

                using (ProyectopooEntities db = new ProyectopooEntities()) {

                    var cargar = (from p in db.Products
                                  join c in db.Categorie on p.CategoryId equals c.CategoryId
                                  select new
                                  {
                                      Nombre=p.Description,
                                      Precio=p.SalePrice,
                                      //c.CategoryId,
                                      Categoria=c.CategoryId+" ."+c.Description,
                                      Imagen=p.Image,
                                      p.ProductId,
                                      Key=p.ProductKey
                                  }).ToList();
                    dgvProductos.DataSource = cargar;
                    dgvProductos.Columns["ProductId"].Visible = false;

                    if (dgvProductos.RowCount > 0)
                    {
                        dgvProductos.Rows[0].Selected = false;
                    }

                }

            }catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            txtId.Visible = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminPrincipal frm = new frmAdminPrincipal();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Archivos jpg(*.jpg)|*.jpg|Archivos png(*.png)|*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtFile.Text.Trim().Equals("") || cmbCat.Text.Trim().Equals("") || txtKey.Text.Trim().Equals("")
                || txtNombre.Text.Trim().Equals("") || txtPrecio.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe rellenar todos los campos!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            byte[] file = null;
            Stream myS = openFileDialog1.OpenFile();
            using (MemoryStream mem = new MemoryStream())
            {
                myS.CopyTo(mem);
                file = mem.ToArray();
            }
            using (ProyectopooEntities db = new ProyectopooEntities())
            {
                Products oPd = new Products();
                oPd.Description = txtNombre.Text.Trim();
                oPd.ProductKey = txtKey.Text.Trim();
                oPd.SalePrice = double.Parse(txtPrecio.Text.Trim());
                oPd.Image = file;
                oPd.CategoryId = int.Parse(cmbCat.SelectedValue.ToString());
                db.Products.Add(oPd);
                db.SaveChanges();
                
            }
            cargar();
            refrescar();
            deshabilitar();
        }
        private void refrescar()
        {
            txtFile.Text = "";
            txtKey.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            cmbCat.SelectedIndex = -1;
            //pictureBox1.Image.Dispose();
            Image Nothing = null;
            pictureBox1.Image = Nothing;
            txtId.Text = "";
        }

        private void cargarcmb()
        {
            try
            {
                //List<Clases.ProductViewModel> lstProduct = new List<Clases.ProductViewModel>();
                List<Clases.CategoryViewModel> lstCat = new List<Clases.CategoryViewModel>();
                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    lstCat = (from d in db.Categorie
                              select new Clases.CategoryViewModel
                              {
                                  CategoryId = d.CategoryId,
                                  Description = d.Description
                              }).ToList();

                }

                cmbCat.DataSource = lstCat;
                cmbCat.ValueMember = "CategoryId";
                cmbCat.DisplayMember = "Description";
            }catch(Exception ex)
            {
                MessageBox.Show("Ocurrio lo siguiente: " + ex.Message);
            }

        }

        private void habilitar()
        {
            txtKey.Enabled = true;
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            cmbCat.Enabled = true;
        }

        private void deshabilitar()
        {
            txtPrecio.Enabled = false;
            txtNombre.Enabled = false;
            txtKey.Enabled = false;
            cmbCat.Enabled = false;
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            refrescar();
            habilitar();
            
        }

        private void llenar()
        {
            if (dgvProductos.RowCount > 0)
            {
                txtNombre.Text = dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Nombre"].Value.ToString();
                txtPrecio.Text = dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Precio"].Value.ToString();
                cmbCat.SelectedIndex = cmbCat.FindStringExact(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Categoria"].Value.ToString());
                txtKey.Text = dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Key"].Value.ToString();
                txtId.Text = dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["ProductId"].Value.ToString();
                int id = int.Parse(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["ProductId"].Value.ToString());
                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    var oImg = db.Products.Find(id);
                    MemoryStream ms = new MemoryStream(oImg.Image);
                    Bitmap bmp = new Bitmap(ms);
                    pictureBox1.Image = bmp;
                }
            }
        }

        private void dgvProductos_Click(object sender, EventArgs e)
        {
            llenar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            
            if (txtId.Text == String.Empty)
            {
                MessageBox.Show("Debe seleccionar un registro para editar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (cmbCat.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe seleccionar una categoria", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtKey.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe rellenar el Key", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtNombre.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe rellenar el nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPrecio.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe fijar un nuevo precio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int id = int.Parse(txtId.Text);
                string nombre = txtNombre.Text;
                string key = txtKey.Text;
                int idC = int.Parse(cmbCat.SelectedValue.ToString());
                double precio = double.Parse(txtPrecio.Text);
                
                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    Products p = db.Products.FirstOrDefault(x => x.ProductId == id);
                    p.Description = nombre;
                    p.SalePrice = precio;
                    p.ProductKey = key;
                    p.CategoryId = idC;                  
                    db.SaveChanges();
                    cargar();
                    refrescar();
                    MessageBox.Show("Las imagenes no se pueden editar","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == String.Empty)
                {
                    MessageBox.Show("Debe seleccionar un juego para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    int id = int.Parse(txtId.Text);
                    using (ProyectopooEntities db = new ProyectopooEntities())
                    {
                        Products po = db.Products.FirstOrDefault(x => x.ProductId == id);
                        db.Products.Remove(po);
                        db.SaveChanges();
                        cargar();
                        refrescar();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al eliminar" + ex.Message);
            }
        }
    }
}
