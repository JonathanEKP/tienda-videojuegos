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
    public partial class frmFactura : Form
    {
        private int log_id;
        private string nombre, apellido, email;
        public int Login
        {
            get { return log_id; }
            set { log_id = value; }
        }
        public frmFactura(int login)
        {
            Login = login;
            InitializeComponent();
            cargar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            using (ProyectopooEntities db = new ProyectopooEntities())
            {
                var cart = (from d in db.Cart
                            where d.Login_id == Login && d.Status == "pagado"
                            select d).ToArray();
                if (cart.Length > 0)
                {
                    for(int i = 0; i < cart.Length; i++)
                    {
                        var iD = cart[i].CartId;
                        Cart c = db.Cart.FirstOrDefault(x => x.CartId == iD);
                        c.Status = "entregado";
                        //db.Cart.Add(c);
                        db.SaveChanges();
                    }
                }
            }

            this.Close();


        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            using (ProyectopooEntities db = new ProyectopooEntities())
            {
                var cart = (from d in db.Cart
                            where d.Login_id == Login && d.Status == "pagado"
                            select d).ToArray();
                if (cart.Length > 0)
                {
                    for (int i = 0; i < cart.Length; i++)
                    {
                        var iD = cart[i].CartId;
                        Cart c = db.Cart.FirstOrDefault(x => x.CartId == iD);
                        c.Status = "entregado";
                        //db.Cart.Add(c);
                        db.SaveChanges();
                    }
                }
            }

            this.Hide();
            frmMain frm = new frmMain(Login);
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();


        }

        public frmFactura()
        {
            InitializeComponent();
            cargar();
        }


        private void cargar()
        {
            using(ProyectopooEntities db = new ProyectopooEntities())
            {
                var datos = (from d in db.Invoice
                             where d.Orders.Cart.Login_id == Login
                             select new 
                             {
                                 NoFactura=d.InvoiceId,
                                 NoOrden=d.OrderId,
                                 Fecha=d.Date,
                                 MontoTotal=d.InvoiceTotalAmount
                             }).ToList();

                
                dgvProductos.DataSource = datos;
                dgvProductos.ClearSelection();
                if (dgvProductos.RowCount > 0)
                {
                    dgvProductos.Rows[0].Selected = false;
                }
                //dgvProductos.Columns["Orders"].Visible = false;


                var dat = (from c in db.Cart
                           join p in db.Products on c.ProductId equals p.ProductId
                           where c.Login_id == Login && c.Status == "pagado"
                           select new
                           {
                               Nombre=p.Description,
                               Key=p.ProductKey
                           }).ToList();
                
                dataGridView1.DataSource = dat;
                dataGridView1.ClearSelection();
                if(dataGridView1.RowCount>0)
                {
                    dataGridView1.Rows[0].Selected = false;
                }
            }
        }
    }
}
