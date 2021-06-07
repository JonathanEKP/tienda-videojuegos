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
using VideoGamesStore.Clases;

namespace VideoGamesStore.FormulariosVentas
{
    public partial class frmMain : Form
    {
        FormulariosAdmin.frmAdminCategorias frm1 = new FormulariosAdmin.frmAdminCategorias();
        int cant = 0;
        public frmMain()
        {
            InitializeComponent();
            cargar();
            txtNombre.Enabled = false;
        }

        private void cargar()
        {
            try
            {
                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    var cargar = (from p in db.Products
                                  join c in db.Categorie on p.CategoryId equals c.CategoryId
                                  select new
                                  {
                                      Nombre = p.Description,
                                      Precio = p.SalePrice,
                                      //c.CategoryId,
                                      Categoria = c.CategoryId + " ." + c.Description,
                                      Imagen = p.Image,
                                      p.ProductId,
                                      Key = p.ProductKey
                                  }).ToList();
                    dgvProductos.DataSource = cargar;
                    dgvProductos.Columns["ProductId"].Visible = false;
                    dgvProductos.Columns["Key"].Visible = false;
                    

                    if (dgvProductos.RowCount > 0)
                    {
                        dgvProductos.Rows[0].Selected = false;
                    }

                   
                }

                
                txtCant.Text = cant.ToString();


            }catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

        private void llenar()
        {
            if (dgvProductos.RowCount > 0)
            {
                txtNombre.Text = dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Nombre"].Value.ToString();
                txtPrecio.Text = dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Precio"].Value.ToString();
                int id = int.Parse(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["ProductId"].Value.ToString());
                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    var oImg = db.Products.Find(id);
                    MemoryStream ms = new MemoryStream(oImg.Image);
                    Bitmap bmp = new Bitmap(ms);
                    pictureBox1.Image = bmp;
                }

                double precio;
                precio = double.Parse(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Precio"].Value.ToString());
                //cant = cant + 1;
                txtCant.Text = cant.ToString();
                precio = precio * cant;
                txtSubTotal.Text = precio.ToString();
                
            }
        }



        private void btnCarro_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCarrito frm = new frmCarrito();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            llenar();
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            cant++;
            //cargar();
            llenar();
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            cant--;
            //cargar();
            llenar();
        }

        private void limpiar()
        {
            txtCant.Text = "";
            txtlogin.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtSubTotal.Text = "";
            Image Nothing = null;
            pictureBox1.Image = Nothing;
            cant = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
