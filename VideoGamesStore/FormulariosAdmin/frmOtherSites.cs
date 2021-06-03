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
    public partial class frmOtherSites : Form
    {
        ProyectopooEntities db = new ProyectopooEntities();
        OtherSites op;
        public frmOtherSites()
        {
            ProyectopooEntities db = new ProyectopooEntities();
            InitializeComponent();
            cargardatos();
            combo();
        }
        private void cargardatos()
        {
            try
            {
                using (ProyectopooEntities model = new ProyectopooEntities())
                {
                    dataGridView1.DataSource = model.OtherSites.ToList();
                    //dataGridView1.Columns["ProductID"].Visible = false;
                    dataGridView1.Columns["Products"].Visible = false;
                    dataGridView1.ClearSelection();
                    if (dataGridView1.RowCount > 0)
                    {
                        dataGridView1.Rows[0].Selected = false;

                    }
                }

                txtOS.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
             
        }
        private void llenar()
        {
            this.txtOS.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.txtUrl.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            
            int valor = int.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            var lista = db.Products.ToList();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].ProductId == valor)
                {
                    cmbProducto.Text = lista[i].Description;
                }
            }

        }
        private void combo()
        {
            var lista = db.Products.ToList();

            if(lista.Count > 0)
            {
                cmbProducto.DataSource = lista;
                cmbProducto.DisplayMember = "Description";
                cmbProducto.ValueMember = "ProductId";
                if(cmbProducto.Items.Count >= 1)
                {
                    cmbProducto.SelectedIndex = -1;
                }
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            op = new OtherSites();
            op.ProductId = int.Parse(cmbProducto.SelectedValue.ToString());
            op.Webpagelink = txtUrl.Text;

            db.OtherSites.Add(op);
            db.SaveChanges();
            cargardatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(this.txtOS.Text);

            using (ProyectopooEntities db = new ProyectopooEntities())
            {
                OtherSites c = db.OtherSites.FirstOrDefault(x => x.OtherSitesId == id);
                db.OtherSites.Remove(c);
                db.SaveChanges();
                cargardatos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id1 = Convert.ToInt16(this.txtOS.Text);
            string o = txtUrl.Text;

            using (ProyectopooEntities db = new ProyectopooEntities())
            {
                OtherSites c = db.OtherSites.FirstOrDefault(x => x.OtherSitesId == id1);
                c.Webpagelink = o;
                db.SaveChanges();
                cargardatos();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            llenar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminPrincipal frm = new frmAdminPrincipal();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();
            
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
