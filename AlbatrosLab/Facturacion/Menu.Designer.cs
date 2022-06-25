
namespace Facturacion
{
    partial class Menu
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnMantenimientoProductos = new System.Windows.Forms.Button();
            this.btnMantenimientoClientes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dbtSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(243, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Menu";
            // 
            // btnMantenimientoProductos
            // 
            this.btnMantenimientoProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMantenimientoProductos.Location = new System.Drawing.Point(61, 69);
            this.btnMantenimientoProductos.Name = "btnMantenimientoProductos";
            this.btnMantenimientoProductos.Size = new System.Drawing.Size(107, 64);
            this.btnMantenimientoProductos.TabIndex = 14;
            this.btnMantenimientoProductos.Text = "Mantenimiento Productos";
            this.btnMantenimientoProductos.UseVisualStyleBackColor = true;
            this.btnMantenimientoProductos.Click += new System.EventHandler(this.btnMantenimientoProductos_Click);
            // 
            // btnMantenimientoClientes
            // 
            this.btnMantenimientoClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMantenimientoClientes.Location = new System.Drawing.Point(400, 69);
            this.btnMantenimientoClientes.Name = "btnMantenimientoClientes";
            this.btnMantenimientoClientes.Size = new System.Drawing.Size(107, 64);
            this.btnMantenimientoClientes.TabIndex = 15;
            this.btnMantenimientoClientes.Text = "Mantenimiento Clientes";
            this.btnMantenimientoClientes.UseVisualStyleBackColor = true;
            this.btnMantenimientoClientes.Click += new System.EventHandler(this.btnMantenimientoClientes_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(61, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 64);
            this.button1.TabIndex = 16;
            this.button1.Text = "Facturar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dbtSalir
            // 
            this.dbtSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbtSalir.Location = new System.Drawing.Point(400, 173);
            this.dbtSalir.Name = "dbtSalir";
            this.dbtSalir.Size = new System.Drawing.Size(107, 64);
            this.dbtSalir.TabIndex = 17;
            this.dbtSalir.Text = "Salir";
            this.dbtSalir.UseVisualStyleBackColor = true;
            this.dbtSalir.Click += new System.EventHandler(this.dbtSalir_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(563, 282);
            this.Controls.Add(this.dbtSalir);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMantenimientoClientes);
            this.Controls.Add(this.btnMantenimientoProductos);
            this.Controls.Add(this.label2);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMantenimientoProductos;
        private System.Windows.Forms.Button btnMantenimientoClientes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button dbtSalir;
    }
}