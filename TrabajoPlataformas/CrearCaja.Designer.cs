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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBoxCajaAgregar = new System.Windows.Forms.ComboBox();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.labelTitular = new System.Windows.Forms.Label();
            this.comboBoxTitular = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmar
            // 
            this.confirmar.Location = new System.Drawing.Point(314, 309);
            this.confirmar.Name = "confirmar";
            this.confirmar.Size = new System.Drawing.Size(218, 78);
            this.confirmar.TabIndex = 0;
            this.confirmar.Text = "Confirmar";
            this.confirmar.UseVisualStyleBackColor = true;
            this.confirmar.Click += new System.EventHandler(this.confirmar_Click);
            // 
            // cbu
            // 
            this.cbu.Location = new System.Drawing.Point(314, 189);
            this.cbu.Name = "cbu";
            this.cbu.Size = new System.Drawing.Size(218, 23);
            this.cbu.TabIndex = 1;
            this.cbu.TextChanged += new System.EventHandler(this.cbu_TextChanged);
            // 
            // saldo
            // 
            this.saldo.Location = new System.Drawing.Point(314, 237);
            this.saldo.Name = "saldo";
            this.saldo.Size = new System.Drawing.Size(218, 23);
            this.saldo.TabIndex = 2;
            this.saldo.Text = "0";
            this.saldo.TextChanged += new System.EventHandler(this.saldo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "CBU: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Saldo:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(147, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 48);
            this.button1.TabIndex = 5;
            this.button1.Text = "Crear caja";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(346, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 48);
            this.button2.TabIndex = 6;
            this.button2.Text = "Modificar caja";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(549, 69);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 48);
            this.button3.TabIndex = 7;
            this.button3.Text = "Eliminar caja";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBoxCajaAgregar
            // 
            this.comboBoxCajaAgregar.FormattingEnabled = true;
            this.comboBoxCajaAgregar.Location = new System.Drawing.Point(314, 189);
            this.comboBoxCajaAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxCajaAgregar.Name = "comboBoxCajaAgregar";
            this.comboBoxCajaAgregar.Size = new System.Drawing.Size(218, 23);
            this.comboBoxCajaAgregar.TabIndex = 8;
            this.comboBoxCajaAgregar.SelectedIndexChanged += new System.EventHandler(this.comboBoxCaja_SelectedIndexChanged);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(346, 220);
            this.buttonAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(63, 40);
            this.buttonAgregar.TabIndex = 10;
            this.buttonAgregar.Text = "Agregar Titular";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.Location = new System.Drawing.Point(431, 218);
            this.buttonBorrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(70, 42);
            this.buttonBorrar.TabIndex = 11;
            this.buttonBorrar.Text = "Eliminar Titular";
            this.buttonBorrar.UseVisualStyleBackColor = true;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // labelTitular
            // 
            this.labelTitular.AutoSize = true;
            this.labelTitular.Location = new System.Drawing.Point(207, 273);
            this.labelTitular.Name = "labelTitular";
            this.labelTitular.Size = new System.Drawing.Size(43, 15);
            this.labelTitular.TabIndex = 12;
            this.labelTitular.Text = "Titular:";
            // 
            // comboBoxTitular
            // 
            this.comboBoxTitular.FormattingEnabled = true;
            this.comboBoxTitular.Location = new System.Drawing.Point(314, 270);
            this.comboBoxTitular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTitular.Name = "comboBoxTitular";
            this.comboBoxTitular.Size = new System.Drawing.Size(218, 23);
            this.comboBoxTitular.TabIndex = 13;
            this.comboBoxTitular.SelectedIndexChanged += new System.EventHandler(this.comboBoxTitular_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(311, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ingrese la acción que desea realizar y luego ingrese titular.";
            // 
            // CrearCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxTitular);
            this.Controls.Add(this.labelTitular);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.comboBoxCajaAgregar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saldo);
            this.Controls.Add(this.cbu);
            this.Controls.Add(this.confirmar);
            this.Name = "CrearCaja";
            this.Text = "CrearCaja";
            this.Load += new System.EventHandler(this.CrearCaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button confirmar;
        private TextBox cbu;
        private TextBox saldo;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox comboBoxCajaAgregar;
        private TextBox titularModificar;
        private Button buttonAgregar;
        private Button buttonBorrar;
        private Label labelTitular;
        private ComboBox comboBoxTitular;
        private Label label3;



        //only read input with saldo in 0

    }
}