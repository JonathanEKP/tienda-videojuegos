﻿using System;
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

        ProyectopooEntities db1 = new ProyectopooEntities();
        int cant = 0;
        private int log_id;

        private string nombre, apellido, email;
        public int Login
        {
            get { return log_id; }
            set { log_id = value; }
        }
        public frmMain (int login)
        {
            Login = login;
            InitializeComponent();
            cargar();
            txtNombre.Enabled = false;
            txtid.Visible = false;


        }

        public frmMain()
        {
            InitializeComponent();
            cargar();
            txtNombre.Enabled = false;
            txtid.Visible = false;


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
                    dgvProductos.Columns["Imagen"].Visible = false;
                    

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
                txtid.Text= dgvProductos.Rows[dgvProductos.CurrentRow.Index].Cells["ProductId"].Value.ToString();

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
            txtid.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtSubTotal.Text = "";
            Image Nothing = null;
            pictureBox1.Image = Nothing;
            cant = 0;
            txtBuscar.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            cargar();
        }

        private void filtrar(string nombre, string criterio ="Description")
        {
            if (!txtBuscar.Text.Equals(""))
            {
                //dgvProductos.DataSource = db1.Products.SqlQuery("select * from Products where " + criterio + " like '" + nombre + "%'").ToList();
                //dgvProductos.Columns[]
                using(ProyectopooEntities db = new ProyectopooEntities())
                {
                    var cargar = (from p in db.Products
                                  join c in db.Categorie on p.CategoryId equals c.CategoryId
                                  where p.Description == nombre 
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
                    dgvProductos.Columns["Imagen"].Visible = false;

                }
            }

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar un registro para buscar");
            }
            else
            {
                filtrar(txtBuscar.Text);

            }
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCarrito frm = new frmCarrito();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();

        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == String.Empty)
            {
                MessageBox.Show("Debe seleccionar un juego a agregar");
            }
            else if (txtCant.Text=="0")
            {
                MessageBox.Show("Debe seleccionar la cantidad a agregar");
            }
            else
            {
                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    Cart ca = new Cart();
                    ca.Login_id = Login;
                    ca.Quantity = int.Parse(txtCant.Text);
                    ca.ProductId = int.Parse(txtid.Text);
                    db.Cart.Add(ca);
                    db.SaveChanges();
                }
                double añadir = 0;
                añadir += double.Parse(txtSubTotal.Text);
                Operaciones.subTotal += añadir;
            }
            limpiar();
        }
    }
}
