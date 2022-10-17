namespace TrabajoPlataformas
{
    partial class CrearCaja
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
            this.confirmar = new System.Windows.Forms.Button();
            this.cbu = new System.Windows.Forms.TextBox();
            this.saldo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // confirmar
            // 
            this.confirmar.Location = new System.Drawing.Point(314, 236);
            this.confirmar.Name = "confirmar";
            this.confirmar.Size = new System.Drawing.Size(218, 78);
            this.confirmar.TabIndex = 0;
            this.confirmar.Text = "Confirmar";
            this.confirmar.UseVisualStyleBackColor = true;
            this.confirmar.Click += new System.EventHandler(this.confirmar_Click);
            // 
            // cbu
            // 
            this.cbu.Location = new System.Drawing.Point(314, 136);
            this.cbu.Name = "cbu";
            this.cbu.Size = new System.Drawing.Size(218, 23);
            this.cbu.TabIndex = 1;
            this.cbu.Text = "CBU";
            this.cbu.TextChanged += new System.EventHandler(this.cbu_TextChanged);
            // 
            // saldo
            // 
            this.saldo.Location = new System.Drawing.Point(314, 184);
            this.saldo.Name = "saldo";
            this.saldo.Size = new System.Drawing.Size(218, 23);
            this.saldo.TabIndex = 2;
            this.saldo.Text = "Saldo";
            // 
            // CrearCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saldo);
            this.Controls.Add(this.cbu);
            this.Controls.Add(this.confirmar);
            this.Name = "CrearCaja";
            this.Text = "CrearCaja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button confirmar;
        private TextBox cbu;
        private TextBox saldo;
    }
}