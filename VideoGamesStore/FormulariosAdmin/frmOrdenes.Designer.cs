
namespace VideoGamesStore.FormulariosAdmin
{
    partial class frmOrdenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenes));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDordenes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblfecha = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEntrega = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1211, 343);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(12, 138);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(153, 39);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID Ordenes:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtIDordenes
            // 
            this.txtIDordenes.Location = new System.Drawing.Point(16, 35);
            this.txtIDordenes.Name = "txtIDordenes";
            this.txtIDordenes.Size = new System.Drawing.Size(123, 22);
            this.txtIDordenes.TabIndex = 3;
            this.txtIDordenes.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Producto:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 22);
            this.textBox1.TabIndex = 5;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(164, 86);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(123, 22);
            this.txtFecha.TabIndex = 6;
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfecha.Location = new System.Drawing.Point(160, 60);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(76, 23);
            this.lblfecha.TabIndex = 7;
            this.lblfecha.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(160, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(164, 35);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(123, 22);
            this.txtCliente.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(319, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Estado de entrega:";
            // 
            // txtEntrega
            // 
            this.txtEntrega.Location = new System.Drawing.Point(323, 35);
            this.txtEntrega.Name = "txtEntrega";
            this.txtEntrega.Size = new System.Drawing.Size(123, 22);
            this.txtEntrega.TabIndex = 11;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(171, 138);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(153, 39);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1030, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // frmOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1235, 538);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtEntrega);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIDordenes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmOrdenes";
            this.Text = "Administrar Ordenes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDordenes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEntrega;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}