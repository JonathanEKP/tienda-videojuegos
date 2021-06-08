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
    public partial class frmCarrito : Form
    {
        int cant = 1;
        public frmCarrito()
        {
            InitializeComponent();
            cargar();
            deshabilitaredit();
        }

        private void cargar()
        {
            txtid.Visible = false;
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
                                   Precio=p.SalePrice,
                                   Cantidad = d.Quantity,
                                   Usuario = l.email,
                                   Imagen=p.Image,
                                   ProductId=p.ProductId,
                                   Id=d.CartId
                               }).ToList();
                    var precio=(from d in db.Cart
                                join p in db.Products on d.ProductId equals p.ProductId
                                join l in db.Clients on d.Login_id equals l.Login_id

                                select new
                                {
                                   
                                    Precio=p.SalePrice
                                    
                                }).ToList();
                    dgvprecio.DataSource = precio;
                    dgvProductos.DataSource = lst;
                    dgvProductos.Columns["Imagen"].Visible = false;
                    dgvProductos.Columns["ProductId"].Visible = false;
                    dgvProductos.Columns["Precio"].Visible = false;
                    dgvProductos.Columns["Id"].Visible = false;
                }
                if (dgvProductos.RowCount > 0)
                {
                    dgvProductos.Rows[0].Selected = false;
                }
                txtSubtotal.Text = Operaciones.subTotal.ToString();
                //txtCantidad.Text = cant.ToString();
            }catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error" + ex.Message);
            }


        }
        private void deshabilitaredit()
        {
            btnMas.Enabled = false;
            btnMenos.Enabled = false;
        }
        private void habilitarEdit()
        {
            btnMas.Enabled = true;
            btnMenos.Enabled = true;

        }
        private void llenar()
        {
           

        
            if (dgvProductos.RowCount > 0)
            {
                txtCantidad.Text = dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Cantidad"].Value.ToString();
                cant= int.Parse(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Cantidad"].Value.ToString());
                int id = int.Parse(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["ProductId"].Value.ToString());
                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    var oImg = db.Products.Find(id);
                    MemoryStream ms = new MemoryStream(oImg.Image);
                    Bitmap bmp = new Bitmap(ms);
                    pictureBox1.Image = bmp;
                }
                txtid.Text = dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Id"].Value.ToString();
               

            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            llenar();
            habilitarEdit();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double total = 0;
            foreach(DataGridViewRow row in dgvprecio.Rows)
            {
                total += Convert.ToDouble(row.Cells["Precio"].Value);
                 
            }
            txtSubtotal.Text = Convert.ToString(total);
            //Clases.Operaciones op = new Clases.Operaciones();
            Operaciones.subTotal = total;
        }

        private void frmCarrito_Load(object sender, EventArgs e)
        {

        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            cant++;
            if(txtCantidad.Text==String.Empty)
            {
                MessageBox.Show("Debe ingresar una cantidad a comprar");
            }
            else
            {

            }

            llenar();
            
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            cant--;

            llenar();
        }
    }
}
