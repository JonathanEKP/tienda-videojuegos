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
