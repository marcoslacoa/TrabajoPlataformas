using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static TrabajoPlataformas.Login;

namespace TrabajoPlataformas
{
    public partial class FormMain : Form
    {
        List<List<string>> datos;
        public string usuario;
        public Banco miBanco;
        CrearCaja hijoCrearCaja;
        
        public cerrarsesion cerrarsesionEvento;
        public List<CajaAhorro> cajas;
        int numeroDeClick = 0;

        public FormMain(string usuario, Banco b)
        {
            InitializeComponent();
            this.miBanco = b;
            this.usuario = usuario;
            label2.Text = miBanco.usuarioActual.nombre;
            cbuDesitinoLabel.Visible = false;
            cbuLabel.Visible = false;
            textMonto .Visible = false;
            montoLabel.Visible = false;
            comboBoxCbu.Visible = false;
            comboBoxCbuDestino.Visible = false;
            buttonConfirmar.Visible = false;
            comboBoxCbuPagos.Visible = false;
            comboBoxTarjetaPagos.Visible = false;
            comboBoxPagos.Visible = false;
            labelMontoPagos.Visible = false;
            labelNumeroPagos.Visible = false;
            
        }
        //public FormMain(object[] args)
        //{
        //    InitializeComponent();
        //    miBanco = (Banco)args[1];
        //    argumentos = args;
        //    datos = new List<List<string>>();
        //}
        //private void cerrarCajaDelegado()
        //{
        //    this.hijoCrearCaja.cerrarCajaEvento += cerrarCajaDelegado;
        //    this.hijoCrearCaja.Close();
        //}
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            //Boton mostrar datos
            refreshData();
        }

        public delegate void cerrarsesion();
        private void refreshData()
        {
            //borro los datos
            dataGridView1.Rows.Clear();
            comboBoxCbu.Items.Clear();
            comboBoxCbuDestino.Items.Clear();

            foreach (CajaAhorro caja in miBanco.obtenerCajasDelUsuario())
            {
                //string[] arr = new string[] { caja.saldo.ToString(), caja.cbu.ToString() };
                //dataGridView1.Rows.Add(arr);
                if (miBanco.obtenerCajasDelUsuario().Contains(caja))
                    dataGridView1.Rows.Add(caja.toArray());

                if (!comboBoxCbu.Items.Contains(caja.cbu))
                {                  
                    comboBoxCbu.Items.Add(caja.cbu);
                    comboBoxCbuPlazo.Items.Add(caja.cbu);
                }

            }
            foreach (CajaAhorro caja in miBanco.cajasList)
            {
                if (caja.usuario != miBanco.usuarioActual)
                {
                    if (!comboBoxCbuDestino.Items.Contains(caja.cbu))
                    {
                        comboBoxCbuDestino.Items.Add(caja.cbu);
                    }
                }
            }
           

        }

        public void refreshPlazos()
        {
            dataGridView2.Rows.Clear();
            comboBoxCbuPlazo.Items.Clear();
            foreach (PlazoFijo plazo in miBanco.obtenerPlazosDelUsuario())
            {
               if (miBanco.obtenerPlazosDelUsuario().Contains(plazo))
                   dataGridView1.Rows.Add(plazo.toArray());
              
            }
        }

        private void confirmoBorrarDelegado()
        {
            refreshData();            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.cerrarsesionEvento();
        }

        private void retirar_Click(object sender, EventArgs e)
        {
            cbuLabel.Visible = true;
            textMonto.Visible = true;
            montoLabel.Visible = true;
            comboBoxCbu.Visible = true;
            buttonConfirmar.Visible = true;
            comboBoxCbuDestino.Visible = false;
            cbuDesitinoLabel.Visible = false;
            numeroDeClick = 1;           
        }

        private void depositar_Click(object sender, EventArgs e)
        {
            cbuLabel.Visible = true;
            textMonto.Visible = true;
            montoLabel.Visible = true;
            comboBoxCbu.Visible = true;
            buttonConfirmar.Visible = true;
            comboBoxCbuDestino.Visible = false;
            cbuDesitinoLabel.Visible = false;
            numeroDeClick = 2;
        }

        private void transferir_Click(object sender, EventArgs e)
        {
            cbuLabel.Visible = true;
            textMonto.Visible = true;
            montoLabel.Visible = true;
            comboBoxCbu.Visible = true;
            buttonConfirmar.Visible = true;
            comboBoxCbuDestino.Visible = true;
            cbuDesitinoLabel.Visible = true;
            numeroDeClick = 3;
        }

        private void crearcaja_Click(object sender, EventArgs e)
        {          
            this.hijoCrearCaja = new CrearCaja(miBanco, miBanco.usuarioActual);
            this.hijoCrearCaja.confirmBorrarEvento += confirmoBorrarDelegado;
            hijoCrearCaja.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            switch (numeroDeClick)
            {
                case 1:
                    if (comboBoxCbu.SelectedItem != null)
                    {
                        // take the combobox selected item and convert it to int
                        int cbuenInt = Convert.ToInt32(comboBoxCbu.SelectedItem);
                        CajaAhorro caja = miBanco.obtenerCajasDelUsuario().First(x => x.cbu == cbuenInt);
                        float monto = float.Parse(textMonto.Text);
                        miBanco.retirar(caja, monto);
                        
                        refreshData();
                    }
                    break;
                case 2:
                    if (comboBoxCbu.SelectedItem != null)
                    {
                        // take the combobox selected item and convert it to int
                        int cbuenInt = Convert.ToInt32(comboBoxCbu.SelectedItem);
                        CajaAhorro caja = miBanco.obtenerCajasDelUsuario().First(x => x.cbu == cbuenInt);
                        float monto = float.Parse(textMonto.Text);
                        miBanco.depositar(caja, monto);
                        
                        refreshData();
                    }                  
                    break;
                case 3:
                    if (comboBoxCbu.SelectedItem != null)
                    {
                        // take the combobox selected item and convert it to int
                        int cbuenInt = Convert.ToInt32(comboBoxCbu.SelectedItem);
                        int cbuenIntDestino = Convert.ToInt32(comboBoxCbuDestino.SelectedItem);
                        CajaAhorro origen = miBanco.obtenerCajasDelUsuario().First(x => x.cbu == cbuenInt);
                        CajaAhorro destino = miBanco.cajasList.First(x => x.cbu == cbuenIntDestino);
                        float monto = float.Parse(textMonto.Text);
                        miBanco.transferir(origen, destino, monto);
                       
                        refreshData();

                    }

                    break;
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           comboBoxCbuPagos.Visible = true;
           comboBoxTarjetaPagos.Visible = true;
           comboBoxPagos.Visible = true;
           labelMontoPagos.Visible = true;
           labelNumeroPagos.Visible = true;
           buttonConfirmarPago.Visible = true;              
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCbu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void CrearPlazo_Click(object sender, EventArgs e)
        {
            if(comboBoxCbuPlazo.SelectedItem != null)
            {
                int cbuenInt = Convert.ToInt32(comboBoxCbuPlazo.SelectedItem);
                CajaAhorro caja = miBanco.obtenerCajasDelUsuario().First(x => x.cbu == cbuenInt);
                float monto = float.Parse(MontoInsertPlazo.Text);
                DateTime fechaIni = DateTime.Now;
                int tasa = 0;
                miBanco.altaPlazo(miBanco.usuarioActual, caja, monto, fechaIni, dateTimePicker1, tasa, false);
                refreshPlazos();
            }
        }

        private void BorrarPlazo_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refreshPlazos();
        }
    }

}
