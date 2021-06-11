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
        }
        public frmFactura()
        {
            InitializeComponent();
        }
    }
}
