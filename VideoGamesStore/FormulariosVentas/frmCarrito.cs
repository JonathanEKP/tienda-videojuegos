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
        double precio;
        Sesion se = new Sesion();
        int cant = 0;
        private int log_id;

        private string nombre, apellido, email;
        public int Login
        {
            get { return log_id; }
            set { log_id = value; }
        }
        public frmCarrito(int login)
        {
            Login = login;
            InitializeComponent();
            cargar();
            deshabilitaredit();
            txtLog.Text = Login.ToString();
            dgvprecio.Enabled = false;
            
            
        }

        public frmCarrito()
        {
            InitializeComponent();
            cargar();
            deshabilitaredit();
            txtLog.Text = Login.ToString();
            dgvprecio.Enabled = false;
        }

        private void cargar()
        {
            dgvProductos.ClearSelection();
            dgvprecio.ClearSelection();
            txtLog.Visible = false;
            txtid.Visible = false;
            try
            {
                using(ProyectopooEntities db = new ProyectopooEntities())
                {
                    var lst = (from d in db.Cart
                               join p in db.Products on d.ProductId equals p.ProductId
                               join l in db.Clients on d.Login_id equals l.Login_id
                               where d.Login_id==Login && d.Status=="open"
                               
                               select new
                               {
                                   Producto = p.Description,
                                   Precio=p.SalePrice,
                                   Cantidad=d.Quantity,
                                   Usuario = l.email,
                                   Imagen=p.Image,
                                   ProductId=p.ProductId,
                                   Id=d.CartId
                               }).ToList();
                    var precio=(from d in db.Cart
                                join p in db.Products on d.ProductId equals p.ProductId
                                join l in db.Clients on d.Login_id equals l.Login_id
                                where d.Login_id==Login && d.Status == "open"


                                select new
                                {
                                    Cantidad=d.Quantity,
                                    Precio=p.SalePrice
                                    
                                    
                                }).ToList();
                    dgvprecio.DataSource = precio;
                    dgvProductos.DataSource = lst;
                    dgvProductos.Columns["Cantidad"].Visible = false;
                    dgvProductos.Columns["Imagen"].Visible = false;
                    dgvProductos.Columns["ProductId"].Visible = false;
                    dgvProductos.Columns["Precio"].Visible = false;
                    dgvProductos.Columns["Id"].Visible = false;
                }
                if (dgvProductos.RowCount > 0 && dgvprecio.RowCount>0)
                {
                    dgvProductos.Rows[0].Selected = false;
                    dgvprecio.Rows[0].Selected = false;
                }
                txtSubtotal.Text = Operaciones.subTotal.ToString();
                txtCantidad.Text = cant.ToString();
            }catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error" + ex.Message);
            }

            double total = 0;
            foreach (DataGridViewRow row in dgvprecio.Rows)
            {
                total += Convert.ToDouble(row.Cells["Cantidad"].Value) * Convert.ToDouble(row.Cells["Precio"].Value);

            }
            txtSubtotal.Text = Convert.ToString(total);
            //Clases.Operaciones op = new Clases.Operaciones();
            Operaciones.subTotal = total;

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
                //cant= int.Parse(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Cantidad"].Value.ToString());
                int id = int.Parse(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["ProductId"].Value.ToString());
                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    var oImg = db.Products.Find(id);
                    MemoryStream ms = new MemoryStream(oImg.Image);
                    Bitmap bmp = new Bitmap(ms);
                    pictureBox1.Image = bmp;
                }
                txtid.Text = dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Id"].Value.ToString();
                precio = double.Parse(dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["Precio"].Value.ToString());
               
                precio = precio * cant;

            }
            
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            llenar();
            habilitarEdit();
        }
        private void calcular()
        {
            using (ProyectopooEntities db = new ProyectopooEntities())
            {
                var cal = (from c in db.Cart
                           where c.Login_id == Login && c.Status == "open"
                           select c).ToList();
                int n = cal.Count;
                if (cal.Count > 0)
                {

                    
                    
                }
            }
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //calcular();
           
        }

        private void frmCarrito_Load(object sender, EventArgs e)
        {

        }
        private void limpiar()
        {
            txtCantidad.Text = "0";
            txtid.Text = "";
            txtSubtotal.Text = "0";
            Image Nothing = null;
            pictureBox1.Image = Nothing;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (txtid.Text == String.Empty)
            {
                MessageBox.Show("Debe seleccionar un registro para editar","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (txtCantidad.Text=="0")
            {
                MessageBox.Show("Debe ingresar un numero mayor a cero","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                int id = int.Parse(txtid.Text);
                using(ProyectopooEntities db = new ProyectopooEntities())
                {
                    Cart c = db.Cart.FirstOrDefault(x => x.CartId == id);
                    c.Quantity = cant;
                    db.SaveChanges();
                    cargar();
                    
                }
            }

            limpiar();
            cargar();
            
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (txtSubtotal.Text == "0")
            {
                MessageBox.Show("Debe generar su subtotal","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                frmPago frm = new frmPago(Login);
                frm.FormClosed += (s, args) => this.Close();
                frm.Show();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (txtid.Text==String.Empty)
            {
                MessageBox.Show("Debe seleccionar un registro para eliminar","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
            else
            {
                int id = int.Parse(txtid.Text);
                using(ProyectopooEntities db = new ProyectopooEntities())
                {
                    Cart c = db.Cart.FirstOrDefault(x => x.CartId == id);
                    db.Cart.Remove(c);
                    db.SaveChanges();
                    limpiar();
                    cargar();
                    
                }
            }
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            cant = int.Parse(txtCantidad.Text);
            cant++;
            txtCantidad.Text = cant.ToString();


        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            cant = int.Parse(txtCantidad.Text);
            cant--;
            if (cant < 0)
            {
                MessageBox.Show("No se admiten numeros menores a cero","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                cant++;
            }
            else
            {
                txtCantidad.Text = cant.ToString();
            }
        }
    }
}
