namespace TrabajoPlataformas
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.cbuDesitinoLabel = new System.Windows.Forms.Label();
            this.comboBoxCbuDestino = new System.Windows.Forms.ComboBox();
            this.cbuLabel = new System.Windows.Forms.Label();
            this.montoLabel = new System.Windows.Forms.Label();
            this.textMonto = new System.Windows.Forms.TextBox();
            this.comboBoxCbu = new System.Windows.Forms.ComboBox();
            this.crearcaja = new System.Windows.Forms.Button();
            this.transferir = new System.Windows.Forms.Button();
            this.depositar = new System.Windows.Forms.Button();
            this.retirar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBoxPagos = new System.Windows.Forms.ComboBox();
            this.comboBoxCbuPagos = new System.Windows.Forms.ComboBox();
            this.comboBoxTarjetaPagos = new System.Windows.Forms.ComboBox();
            this.buttonConfirmarPago = new System.Windows.Forms.Button();
            this.labelNumeroPagos = new System.Windows.Forms.Label();
            this.labelMontoPagos = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LIMITE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONSUMOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(97, 97);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(621, 476);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonConfirmar);
            this.tabPage1.Controls.Add(this.cbuDesitinoLabel);
            this.tabPage1.Controls.Add(this.comboBoxCbuDestino);
            this.tabPage1.Controls.Add(this.cbuLabel);
            this.tabPage1.Controls.Add(this.montoLabel);
            this.tabPage1.Controls.Add(this.textMonto);
            this.tabPage1.Controls.Add(this.comboBoxCbu);
            this.tabPage1.Controls.Add(this.crearcaja);
            this.tabPage1.Controls.Add(this.transferir);
            this.tabPage1.Controls.Add(this.depositar);
            this.tabPage1.Controls.Add(this.retirar);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(613, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Caja de Ahorro";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Location = new System.Drawing.Point(363, 369);
            this.buttonConfirmar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(136, 29);
            this.buttonConfirmar.TabIndex = 12;
            this.buttonConfirmar.Text = "Confimar";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // cbuDesitinoLabel
            // 
            this.cbuDesitinoLabel.AutoSize = true;
            this.cbuDesitinoLabel.Location = new System.Drawing.Point(250, 314);
            this.cbuDesitinoLabel.Name = "cbuDesitinoLabel";
            this.cbuDesitinoLabel.Size = new System.Drawing.Size(92, 20);
            this.cbuDesitinoLabel.TabIndex = 11;
            this.cbuDesitinoLabel.Text = "CBU Destino";
            this.cbuDesitinoLabel.Click += new System.EventHandler(this.label6_Click);
            // 
            // comboBoxCbuDestino
            // 
            this.comboBoxCbuDestino.FormattingEnabled = true;
            this.comboBoxCbuDestino.Location = new System.Drawing.Point(348, 311);
            this.comboBoxCbuDestino.Name = "comboBoxCbuDestino";
            this.comboBoxCbuDestino.Size = new System.Drawing.Size(151, 28);
            this.comboBoxCbuDestino.TabIndex = 10;
            // 
            // cbuLabel
            // 
            this.cbuLabel.AutoSize = true;
            this.cbuLabel.Location = new System.Drawing.Point(25, 314);
            this.cbuLabel.Name = "cbuLabel";
            this.cbuLabel.Size = new System.Drawing.Size(37, 20);
            this.cbuLabel.TabIndex = 9;
            this.cbuLabel.Text = "CBU";
            // 
            // montoLabel
            // 
            this.montoLabel.AutoSize = true;
            this.montoLabel.Location = new System.Drawing.Point(25, 369);
            this.montoLabel.Name = "montoLabel";
            this.montoLabel.Size = new System.Drawing.Size(53, 20);
            this.montoLabel.TabIndex = 8;
            this.montoLabel.Text = "Monto";
            // 
            // textMonto
            // 
            this.textMonto.Location = new System.Drawing.Point(84, 366);
            this.textMonto.Name = "textMonto";
            this.textMonto.Size = new System.Drawing.Size(151, 27);
            this.textMonto.TabIndex = 7;
            // 
            // comboBoxCbu
            // 
            this.comboBoxCbu.FormattingEnabled = true;
            this.comboBoxCbu.Location = new System.Drawing.Point(84, 311);
            this.comboBoxCbu.Name = "comboBoxCbu";
            this.comboBoxCbu.Size = new System.Drawing.Size(151, 28);
            this.comboBoxCbu.TabIndex = 6;
            this.comboBoxCbu.SelectedIndexChanged += new System.EventHandler(this.comboBoxCbu_SelectedIndexChanged);
            // 
            // crearcaja
            // 
            this.crearcaja.Location = new System.Drawing.Point(465, 226);
            this.crearcaja.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.crearcaja.Name = "crearcaja";
            this.crearcaja.Size = new System.Drawing.Size(136, 31);
            this.crearcaja.TabIndex = 5;
            this.crearcaja.Text = "Administrar Cajas";
            this.crearcaja.UseVisualStyleBackColor = true;
            this.crearcaja.Click += new System.EventHandler(this.crearcaja_Click);
            // 
            // transferir
            // 
            this.transferir.Location = new System.Drawing.Point(465, 177);
            this.transferir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.transferir.Name = "transferir";
            this.transferir.Size = new System.Drawing.Size(136, 31);
            this.transferir.TabIndex = 4;
            this.transferir.Text = "Transferir";
            this.transferir.UseVisualStyleBackColor = true;
            this.transferir.Click += new System.EventHandler(this.transferir_Click);
            // 
            // depositar
            // 
            this.depositar.Location = new System.Drawing.Point(466, 128);
            this.depositar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.depositar.Name = "depositar";
            this.depositar.Size = new System.Drawing.Size(136, 31);
            this.depositar.TabIndex = 3;
            this.depositar.Text = "Depositar";
            this.depositar.UseVisualStyleBackColor = true;
            this.depositar.Click += new System.EventHandler(this.depositar_Click);
            // 
            // retirar
            // 
            this.retirar.Location = new System.Drawing.Point(466, 77);
            this.retirar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.retirar.Name = "retirar";
            this.retirar.Size = new System.Drawing.Size(136, 31);
            this.retirar.TabIndex = 2;
            this.retirar.Text = "Retirar";
            this.retirar.UseVisualStyleBackColor = true;
            this.retirar.Click += new System.EventHandler(this.retirar_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(466, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Ver Movimientos";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(441, 259);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "CBU";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "SALDO";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(613, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plazo Fijo";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(508, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 1;
            this.button3.Text = "Crear";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(299, 188);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBoxPagos);
            this.tabPage3.Controls.Add(this.comboBoxCbuPagos);
            this.tabPage3.Controls.Add(this.comboBoxTarjetaPagos);
            this.tabPage3.Controls.Add(this.buttonConfirmarPago);
            this.tabPage3.Controls.Add(this.labelNumeroPagos);
            this.tabPage3.Controls.Add(this.labelMontoPagos);
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Controls.Add(this.dataGridView4);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(613, 443);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Pagos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboBoxPagos
            // 
            this.comboBoxPagos.FormattingEnabled = true;
            this.comboBoxPagos.Location = new System.Drawing.Point(218, 356);
            this.comboBoxPagos.Name = "comboBoxPagos";
            this.comboBoxPagos.Size = new System.Drawing.Size(184, 28);
            this.comboBoxPagos.TabIndex = 15;
            this.comboBoxPagos.Tag = "";
            this.comboBoxPagos.Text = "PAGO";
            // 
            // comboBoxCbuPagos
            // 
            this.comboBoxCbuPagos.FormattingEnabled = true;
            this.comboBoxCbuPagos.Location = new System.Drawing.Point(218, 292);
            this.comboBoxCbuPagos.Name = "comboBoxCbuPagos";
            this.comboBoxCbuPagos.Size = new System.Drawing.Size(184, 28);
            this.comboBoxCbuPagos.TabIndex = 14;
            this.comboBoxCbuPagos.Tag = "";
            this.comboBoxCbuPagos.Text = "CAJA";
            this.comboBoxCbuPagos.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBoxTarjetaPagos
            // 
            this.comboBoxTarjetaPagos.FormattingEnabled = true;
            this.comboBoxTarjetaPagos.Location = new System.Drawing.Point(418, 292);
            this.comboBoxTarjetaPagos.Name = "comboBoxTarjetaPagos";
            this.comboBoxTarjetaPagos.Size = new System.Drawing.Size(184, 28);
            this.comboBoxTarjetaPagos.TabIndex = 13;
            this.comboBoxTarjetaPagos.Tag = "";
            this.comboBoxTarjetaPagos.Text = "TARJETA";
            // 
            // buttonConfirmarPago
            // 
            this.buttonConfirmarPago.Location = new System.Drawing.Point(418, 356);
            this.buttonConfirmarPago.Name = "buttonConfirmarPago";
            this.buttonConfirmarPago.Size = new System.Drawing.Size(184, 58);
            this.buttonConfirmarPago.TabIndex = 12;
            this.buttonConfirmarPago.Text = "CONFIMAR PAGO";
            this.buttonConfirmarPago.UseVisualStyleBackColor = true;
            // 
            // labelNumeroPagos
            // 
            this.labelNumeroPagos.AutoSize = true;
            this.labelNumeroPagos.Location = new System.Drawing.Point(294, 394);
            this.labelNumeroPagos.Name = "labelNumeroPagos";
            this.labelNumeroPagos.Size = new System.Drawing.Size(33, 20);
            this.labelNumeroPagos.TabIndex = 11;
            this.labelNumeroPagos.Text = "000";
            // 
            // labelMontoPagos
            // 
            this.labelMontoPagos.AutoSize = true;
            this.labelMontoPagos.Location = new System.Drawing.Point(218, 394);
            this.labelMontoPagos.Name = "labelMontoPagos";
            this.labelMontoPagos.Size = new System.Drawing.Size(56, 20);
            this.labelMontoPagos.TabIndex = 10;
            this.labelMontoPagos.Text = "Monto:";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView3.Location = new System.Drawing.Point(3, 44);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 29;
            this.dataGridView3.Size = new System.Drawing.Size(294, 227);
            this.dataGridView3.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "MONTO";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "DETALLE";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView4.Location = new System.Drawing.Point(311, 44);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersWidth = 51;
            this.dataGridView4.RowTemplate.Height = 29;
            this.dataGridView4.Size = new System.Drawing.Size(299, 227);
            this.dataGridView4.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "MONTO";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "DETALLE";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(389, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "PAGOS REALIZADOS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "PAGOS PENDIENTES";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 356);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(185, 58);
            this.button7.TabIndex = 6;
            this.button7.Text = "Realizar pago";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 290);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(185, 58);
            this.button6.TabIndex = 5;
            this.button6.Text = "ADMINISTRAR PAGOS";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.dataGridView5);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(613, 443);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tarjetas";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 268);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(174, 58);
            this.button5.TabIndex = 2;
            this.button5.Text = "ADMINISTRAR TARJETAS";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.LIMITE,
            this.CONSUMOS});
            this.dataGridView5.Location = new System.Drawing.Point(3, 3);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.RowHeadersWidth = 51;
            this.dataGridView5.RowTemplate.Height = 29;
            this.dataGridView5.Size = new System.Drawing.Size(551, 259);
            this.dataGridView5.TabIndex = 1;
            this.dataGridView5.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView5_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "NUMERO";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "CVC";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // LIMITE
            // 
            this.LIMITE.HeaderText = "LIMITE";
            this.LIMITE.MinimumWidth = 6;
            this.LIMITE.Name = "LIMITE";
            this.LIMITE.ReadOnly = true;
            this.LIMITE.Width = 125;
            // 
            // CONSUMOS
            // 
            this.CONSUMOS.HeaderText = "CONSUMOS";
            this.CONSUMOS.MinimumWidth = 6;
            this.CONSUMOS.Name = "CONSUMOS";
            this.CONSUMOS.ReadOnly = true;
            this.CONSUMOS.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Mostrar Datos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bienvenido usuario: ";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(617, 40);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 31);
            this.button4.TabIndex = 9;
            this.button4.Text = "Salir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(914, 800);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;


        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button button2;
        private TabPage tabPage2;
        private Button button3;
        private DataGridView dataGridView2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Label label3;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Button button4;
        private Button transferir;
        private Button depositar;
        private Button retirar;
        private Button crearcaja;
        private Label cbuDesitinoLabel;
        private ComboBox comboBoxCbuDestino;
        private Label cbuLabel;
        private Label montoLabel;
        private TextBox textMonto;
        private ComboBox comboBoxCbu;
        private Button buttonConfirmar;
        private DataGridView dataGridView5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn LIMITE;
        private DataGridViewTextBoxColumn CONSUMOS;
        private Button button5;
        private Label label5;
        private Label label4;
        private Button button7;
        private Button button6;
        private ComboBox comboBoxPagos;
        private ComboBox comboBoxCbuPagos;
        private ComboBox comboBoxTarjetaPagos;
        private Button buttonConfirmarPago;
        private Label labelNumeroPagos;
        private Label labelMontoPagos;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridView dataGridView4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}