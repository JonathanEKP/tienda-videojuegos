﻿using System;
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
    public partial class frmAgregarAdmin : Form
    {
        public frmAgregarAdmin()
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
                    dgvAdmin.DataSource = model.Users.ToList();
                    dgvAdmin.Columns["UserId"].Visible = false;
                    dgvAdmin.ClearSelection();
                    if (dgvAdmin.RowCount > 0)
                    {
                        dgvAdmin.Rows[0].Selected = false;

                    }
                }

                

            }catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void llenar()
        {
            if (dgvAdmin.RowCount > 0)
            {
                txtName.Text = dgvAdmin.Rows[dgvAdmin.CurrentRow.Index].Cells[2].Value.ToString();
                txtApellido.Text = dgvAdmin.Rows[dgvAdmin.CurrentRow.Index].Cells[3].Value.ToString();
                txtPass.Text = dgvAdmin.Rows[dgvAdmin.CurrentRow.Index].Cells[1].Value.ToString();
            }
        }

        private void dgvAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAdmin_Click(object sender, EventArgs e)
        {
            llenar();
        }
    }
}
