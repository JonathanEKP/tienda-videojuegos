using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoGamesStore.Clases;

namespace VideoGamesStore.FormulariosVentas
{
    public partial class frmPago : Form
    {
        
        private int log_id;

        private string nombre, apellido, email;
        public int Login
        {
            get { return log_id; }
            set { log_id = value; }
        }

        private void btnCarro_Click(object sender, EventArgs e)
        {
           


            if(txtAño.Text==String.Empty || txtMes.Text==String.Empty || txtNombre.Text==String.Empty||
                txtNumero.Text==String.Empty || txtCvv.Text == String.Empty)
            {
                MessageBox.Show("Debe llenar todos los campos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            else { 
                int año = int.Parse(txtAño.Text);            
                int mes = int.Parse(txtMes.Text);
                int cvv = int.Parse(txtCvv.Text);
                int num = (int)Math.Floor(Math.Log10(cvv) + 1);
                string numt = txtNumero.Text;
                int x = numt.Length;

                if (mes >= 01 && mes <= 12)
                {
                    if (año >= 2021)
                    {
                        if (num == 3)
                        {
                            if (x >= 13 && x <= 18)
                            {
                                MessageBox.Show("Pago exitoso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                using (ProyectopooEntities db = new ProyectopooEntities())
                                {
                                    var xd = (from c in db.Cart
                                              where c.Login_id == Login && c.Status=="open"
                                              select c).ToArray();
                                    if (xd.Length > 0)
                                    {
                                        //int size = xd.Length;
                                        for (int i = 0; i < xd.Length; i++)
                                        {
                                            var cart = xd[i].CartId;
                                            var q = xd[i].Quantity;
                                            //var pro = xd[i].ProductId;
                                            //var qua = xd[i].Quantity;
                                            //var log = xd[i].Login_id;
                                            //var st = xd[i].Status;
                                            Orders o = new Orders();                                               //o.CartId
                                            o.CartId = cart;
                                            o.Quantity = q;
                                            o.Date = DateTime.Now;
                                            o.OrderStatusID = 1;
                                            db.Orders.Add(o);
                                            db.SaveChanges();

                                        }

                                    }


                                    var inv = (from q in db.Orders
                                               where q.Cart.Login_id == Login && q.Cart.Status == "open"
                                               select q).ToArray();
                                    if (inv.Length > 0)
                                    {
                                        for(int i = 0; i < inv.Length; i++)
                                        {
                                            var orid = inv[i].OrderId;
                                            Invoice inn = new Invoice();
                                            inn.OrderId = orid;
                                            inn.Date = DateTime.Now;
                                            inn.InvoiceTotalAmount = Operaciones.subTotal;
                                            db.Invoice.Add(inn);
                                            db.SaveChanges();
                                        }
                                    }

                                    var cart1 = (from ca in db.Cart
                                                where ca.Login_id == Login && ca.Status=="open" select ca).ToArray();
                                    if (cart1.Length > 0)
                                    {
                                        for(int i = 0; i < cart1.Length; i++)
                                        {
                                            var id = cart1[i].CartId;
                                            Cart c = db.Cart.FirstOrDefault(x1 => x1.CartId == id);
                                            c.Status = "pagado";
                                            db.SaveChanges();


                                        }
                                    }



                                }

                                this.Hide();
                                FormulariosVentas.frmFactura frm = new frmFactura(Login);
                                frm.FormClosed += (s, args) => this.Close();
                                frm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Numero de tarjeta incorrecto", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("CVV incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Año no valido, ingrese uno correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mes no valido, ingrese uno correcto", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

           
        }

        private void txtMes_TextChanged(object sender, EventArgs e)
        {
           // txtMes.Text = "";
        }

        private void txtMes_Click(object sender, EventArgs e)
        {
            txtMes.Text = "";

        }

        private void txtMes_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtAño_Click(object sender, EventArgs e)
        {
            txtAño.Text = "";
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCvv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void frmPago_Load(object sender, EventArgs e)
        {

        }

        public frmPago(int login)
        {
            Login = login;
            InitializeComponent();

        }
        public frmPago()
        {
            InitializeComponent();
        }
    }
}
