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
        public frmOtherSites()
        {
            InitializeComponent();
            cargardatos();
        }
        private void cargardatos()
        {
            try
            {
                using (ProyectopooEntities model = new ProyectopooEntities())
                {
                    dataGridView1.DataSource = model.OtherSites.ToList();
                    dataGridView1.Columns["ProductID"].Visible = false;
                    dataGridView1.Columns["Products"].Visible = false;
                    dataGridView1.ClearSelection();
                    if (dataGridView1.RowCount > 0)
                    {
                        dataGridView1.Rows[0].Selected = false;

                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
             txtOS.Visible = false;
        }
        private void llenar()
        {
            this.txtOS.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.txtProduct.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            this.txtUrl.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (ProyectopooEntities db = new ProyectopooEntities())
            {
                OtherSites op = new OtherSites();
                op.Webpagelink = txtUrl.Text;
                op.OtherSitesId = int.Parse(txtProduct.Text);

                db.OtherSites.Add(op);
                db.SaveChanges();
                cargardatos();
            }
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
    }
}
