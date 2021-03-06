
namespace VideoGamesStore.FormulariosVentas
{
    partial class frmCarrito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarrito));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvprecio = new System.Windows.Forms.DataGridView();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnMenos = new System.Windows.Forms.Button();
            this.btnMas = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvprecio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("LEMON MILK Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carrito de compras";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProductos.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvProductos.Location = new System.Drawing.Point(7, 37);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(327, 398);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "SubTotal:";
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.Blue;
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPagar.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.Transparent;
            this.btnPagar.Location = new System.Drawing.Point(491, 136);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(167, 34);
            this.btnPagar.TabIndex = 1;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BackColor = System.Drawing.Color.White;
            this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubtotal.Location = new System.Drawing.Point(575, 86);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(35, 19);
            this.txtSubtotal.TabIndex = 25;
            this.txtSubtotal.Text = "1";
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidad.Location = new System.Drawing.Point(584, 37);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.ReadOnly = true;
            this.txtCantidad.Size = new System.Drawing.Size(18, 19);
            this.txtCantidad.TabIndex = 27;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(513, 271);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // dgvprecio
            // 
            this.dgvprecio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvprecio.BackgroundColor = System.Drawing.Color.White;
            this.dgvprecio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvprecio.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvprecio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvprecio.Enabled = false;
            this.dgvprecio.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvprecio.Location = new System.Drawing.Point(340, 38);
            this.dgvprecio.MultiSelect = false;
            this.dgvprecio.Name = "dgvprecio";
            this.dgvprecio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvprecio.Size = new System.Drawing.Size(145, 398);
            this.dgvprecio.TabIndex = 0;
            // 
            // btnMod
            // 
            this.btnMod.BackColor = System.Drawing.Color.Blue;
            this.btnMod.FlatAppearance.BorderSize = 0;
            this.btnMod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMod.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMod.ForeColor = System.Drawing.Color.Transparent;
            this.btnMod.Location = new System.Drawing.Point(491, 191);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(167, 34);
            this.btnMod.TabIndex = 2;
            this.btnMod.Text = "Editar";
            this.btnMod.UseVisualStyleBackColor = false;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnMenos
            // 
            this.btnMenos.BackColor = System.Drawing.Color.White;
            this.btnMenos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMenos.BackgroundImage")));
            this.btnMenos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMenos.FlatAppearance.BorderSize = 0;
            this.btnMenos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenos.Location = new System.Drawing.Point(635, 36);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(24, 23);
            this.btnMenos.TabIndex = 4;
            this.btnMenos.UseVisualStyleBackColor = false;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click);
            // 
            // btnMas
            // 
            this.btnMas.BackColor = System.Drawing.Color.White;
            this.btnMas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMas.BackgroundImage")));
            this.btnMas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMas.FlatAppearance.BorderSize = 0;
            this.btnMas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMas.Location = new System.Drawing.Point(608, 36);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(21, 22);
            this.btnMas.TabIndex = 3;
            this.btnMas.UseVisualStyleBackColor = false;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtid.Location = new System.Drawing.Point(103, 11);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(23, 19);
            this.txtid.TabIndex = 35;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(7, 4);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(100, 26);
            this.txtLog.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Coral;
            this.label4.Location = new System.Drawing.Point(609, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Eliminar";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // frmCarrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(701, 445);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.btnMenos);
            this.Controls.Add(this.btnMas);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.dgvprecio);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCarrito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carrito";
            this.Load += new System.EventHandler(this.frmCarrito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvprecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvprecio;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.Button btnMas;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label4;
    }
}