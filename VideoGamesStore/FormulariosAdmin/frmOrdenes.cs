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
    public partial class frmOrdenes : Form
    {
        public frmOrdenes()
        {
            InitializeComponent();
            cargar();
            limpiar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminPrincipal frm = new frmAdminPrincipal();
            frm.FormClosed += (s, args) => this.Close();
            frm.Show();

        }
       
        private void limpiar()
        {
            txtEstado.Text = "";
        }
        
        private void cargar()
        {
            try
            {

                using(ProyectopooEntities db = new ProyectopooEntities())
                {
                    var cargar = (from p in db.OrderStatuses
                                  select new
                                  {
                                      ID = p.OrderStatusId,
                                      Descripcion = p.Description,
                                  }).ToList();
                    dgvOrder.DataSource = cargar;

                    if(dgvOrder.RowCount>0)
                    {
                        dgvOrder.Rows[0].Selected = false;
                    }
                }
                txtId.Visible = false;



            }catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido lo siguiente: " + ex.Message);
            }
        }



        private void frmOrdenes_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtEstado.Text == String.Empty)
            {
                MessageBox.Show("Debe llenar todos los campos","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                using (ProyectopooEntities db = new ProyectopooEntities())
                {
                    OrderStatuses os = new OrderStatuses();
                    os.Description = txtEstado.Text;
                    db.OrderStatuses.Add(os);
                    db.SaveChanges();
                }
                cargar();
                limpiar();
                

            }
        }
        private void llenar()
        {
            if (dgvOrder.RowCount > 0)
            {
               
                txtEstado.Text = dgvOrder.Rows[dgvOrder.CurrentRow.Index].Cells["Descripcion"].Value.ToString();
                txtId.Text = dgvOrder.Rows[dgvOrder.CurrentRow.Index].Cells["ID"].Value.ToString();

            }
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            llenar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty)
            {
                MessageBox.Show("Debe seleccionar un registro para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (txtEstado.Text == String.Empty) 
            {
                MessageBox.Show("Debe rellenar el estado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int id = int.Parse(txtId.Text);
                string nombre = txtEstado.Text;
                using(ProyectopooEntities db = new ProyectopooEntities())
                {
                    OrderStatuses os = db.OrderStatuses.FirstOrDefault(x => x.OrderStatusId == id);
                    os.Description = nombre;
                    db.SaveChanges();
                    cargar();
                    limpiar();
                    
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmOrdenesReporte report = new frmOrdenesReporte();
            report.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFacturaReporte factReport = new frmFacturaReporte();
            factReport.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
