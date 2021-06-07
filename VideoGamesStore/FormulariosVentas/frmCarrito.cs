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

namespace VideoGamesStore.FormulariosVentas
{
    public partial class frmCarrito : Form
    {
        public frmCarrito()
        {
            InitializeComponent();
            cargar();
        }

        private void cargar()
        {
            try
            {
                using(ProyectopooEntities db = new ProyectopooEntities())
                {
                    var lst = (from d in db.Cart
                               join p in db.Products on d.ProductId equals p.ProductId
                               join l in db.Clients on d.Login_id equals l.Login_id
                               
                               select new
                               {
                                   Producto = p.Description,
                                   Cantidad = d.Quantity,
                                   Usuario = l.email,
                                   Imagen=p.Image,
                                   ProductId=p.ProductId
                               }).ToList();
                    
                    dgvProductos.DataSource = lst;
                    dgvProductos.Columns["Imagen"].Visible = false;
                    dgvProductos.Columns["ProductId"].Visible = false;
                }
                if (dgvProductos.RowCount > 0)
                {
                    dgvProductos.Rows[0].Selected = false;
                }

                
            }catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error" + ex.Message);
            }


        }
        private void llenar()
        {
            if (dgvProductos.RowCount > 0)
            {
                txtCantidad.Text = dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Cantidad"].Value.ToString();
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

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            llenar();
        }
    }
}
