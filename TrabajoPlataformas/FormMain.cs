using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
            dataGridView1.Rows.Clear();
            comboBoxCbu.Items.Clear();
            comboBoxCbuDestino.Items.Clear();

            foreach (CajaAhorro caja in miBanco.obtenerCajasDelUsuario())
            {
                   dataGridView1.Rows.Add(caja.toArray());

                if (!comboBoxCbu.Items.Contains(caja.cbu))
                {                  
                    comboBoxCbu.Items.Add(caja.cbu);
                    comboBoxCbuPlazo.Items.Add(caja.cbu);
                }

            }
            foreach (CajaAhorro caja in miBanco.obtenerCajas())
            {
                // print every caja inside the list except the ones that belongs to the user
                if (!miBanco.obtenerCajasDelUsuario().Contains(caja))
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
                   dataGridView2.Rows.Add(plazo.toArray());

                if (!comboBox2.Items.Contains(plazo.id))
                {
                    comboBox2.Items.Add(plazo.id);
                }
            }
        }

        public void refreshTarjeta()
        {
            dataGridView5.Rows.Clear();
            //comboBoxCbuPlazo.Items.Clear();
            foreach (TarjetaCredito tarjeta in miBanco.obtenerTarjetasDelUsuario())
            {
                if (miBanco.obtenerTarjetasDelUsuario().Contains(tarjeta))
                    dataGridView5.Rows.Add(tarjeta.toArray());

            }
        }

        public void refreshPagos()
        {
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            
            foreach (Pago pago in miBanco.obtenerPagosDelUsuario())
            {
                if (miBanco.obtenerPagosDelUsuario().Contains(pago))
                    dataGridView3.Rows.Add(pago.toArray());

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

        //Caja de Ahorro
        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            switch (numeroDeClick)
            {
                case 1:
                    if (comboBoxCbu.SelectedItem != null)
                    {
                        // take the combobox selected item and convert it to int
                        int cbuenInt = Convert.ToInt32(comboBoxCbu.SelectedItem);
                        float monto = float.Parse(textMonto.Text);
                        if (miBanco.retirar(cbuenInt, monto)){
                            MessageBox.Show("Se ha retirado " + monto);
                            MessageBox.Show("Retiro realizado con exito"); 
                        }
                        else
                        {
                            MessageBox.Show("No se pudo realizar el retiro");
                        }
                        refreshData();
                    }
                    break;
                case 2:
                    if (comboBoxCbu.SelectedItem != null)
                    {
                        // take the combobox selected item and convert it to int
                        int cbuenInt = Convert.ToInt32(comboBoxCbu.SelectedItem);
                        float monto = float.Parse(textMonto.Text);
                        if (miBanco.depositar(cbuenInt, monto))
                        {
                            MessageBox.Show("Se ha depositado " + monto);
                            MessageBox.Show("Deposito realizado con exito");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo realizar el deposito");
                        }
                        refreshData();
                    }                  
                    break;
                case 3:
                    if (comboBoxCbu.SelectedItem != null)
                    {
                        MessageBox.Show("Transferencia realizandose");
                        // take the combobox selected item and convert it to int
                        int cbuenInt = Convert.ToInt32(comboBoxCbu.SelectedItem);
                        int cbuenIntDestino = Convert.ToInt32(comboBoxCbuDestino.SelectedItem);
                        float monto = float.Parse(textMonto.Text);
                        int result =  miBanco.transferir(cbuenInt, cbuenIntDestino, monto);
                        switch (result)
                        {
                            case 0:
                                MessageBox.Show("No existe la caja destino");
                                break;
                            case 1:
                                MessageBox.Show(" No hay saldo suficiente");
                                break;
                            case 2:
                                MessageBox.Show("Transferencia exitosa");
                                break;
                           
                        }
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

        //Plazos fijos
        private void CrearPlazo_Click(object sender, EventArgs e)
        {
            if(comboBoxCbuPlazo.SelectedItem != null)
            {
                int cbuenInt = Convert.ToInt32(comboBoxCbuPlazo.SelectedItem);
                //CajaAhorro caja = miBanco.obtenerCajasDelUsuario().First(x => x.cbu == cbuenInt);
                float monto = float.Parse(MontoInsertPlazo.Text);
                DateTime fechaIni = DateTime.Now;
                int tasa = 0;
                miBanco.altaPlazo(miBanco.usuarioActual, cbuenInt, monto, fechaIni, dateTimePicker1, tasa, false);
            }
        }

        private void BorrarPlazo_Click(object sender, EventArgs e)
        {
            int cbuenInt = Convert.ToInt32(comboBox2.SelectedItem);
            
            if (miBanco.bajaPlazo(cbuenInt))
            {
               MessageBox.Show("Se ha borrado el plazo fijo");
            }
            else
            {
                MessageBox.Show("No se pudo borrar el plazo fijo");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            refreshPlazos();
        }

        //Tarjetas
        private void buttonCrearTarjeta_Click(object sender, EventArgs e)
        {
              int numero = int.Parse(textBoxNumeroTarjeta.Text);
              int cvc = int.Parse(textBoxCVCTarjeta.Text);
              int limite = int.Parse(textBoxLimiteTarjeta.Text);
              
              //miBanco.altaTarjeta(miBanco.usuarioActual, numero, cvc, limite,//Pagos);
        }

        private void buttonPagarTarjeta_Click(object sender, EventArgs e)
        {
            if(comboBoxTarjetaPagar.SelectedItem != null && comboBoxCbuPagar.SelectedItem != null)
            {
                int cbuenIntTarjeta = Convert.ToInt32(comboBoxTarjetaPagar.SelectedItem);
                int cbuenIntCaja = Convert.ToInt32(comboBoxCbuPagar.SelectedItem);
                TarjetaCredito tarjeta = miBanco.obtenerTarjetasDelUsuario().First(x => x.numero == cbuenIntTarjeta);
                CajaAhorro caja = miBanco.obtenerCajasDelUsuario().First(x => x.cbu == cbuenIntCaja);
                if (miBanco.pagarTarjeta(tarjeta, caja))
                {
                    MessageBox.Show("Pago realizado");
                }
                else
                {
                    MessageBox.Show("No se pudo realizar el pago");
                }
            } else
            {
                MessageBox.Show("Debes ingresar la tarjeta y el cbu para realiza el pago");
            }
         
        }

        private void buttonBorrarTarjeta_Click(object sender, EventArgs e)
        {
            if (comboBoxTarjetaBorrar.SelectedItem != null)
            {
                int cbuenInt = Convert.ToInt32(comboBoxTarjetaBorrar.SelectedItem);
                TarjetaCredito tarjeta = miBanco.obtenerTarjetasDelUsuario().First(x => x.numero == cbuenInt);
                miBanco.bajaTarjeta(tarjeta);
            }
            else
            {
                MessageBox.Show("Debes ingresar la tarjeta que queres borrar");
            }
            
        }

        private void tabPageTarjetas_Click(object sender, EventArgs e)
        {

        }

        private void buttonMostrarDatosTarjeta_Click(object sender, EventArgs e)
        {
            refreshTarjeta();
        }

        private void buttonCrearPago_Click(object sender, EventArgs e)
        {
            if (textBoxMontoPago != null && textBoxDetalle != null)
            {
                float monto = float.Parse(textBoxMontoPago.Text);
                string detalle = textBoxDetalle.Text;
                if (miBanco.altaPago(miBanco.usuarioActual,monto, false, detalle))
                {
                    MessageBox.Show("Pago creado");
                }
                else
                {
                    MessageBox.Show("No se pudo crear el pago");
                }
            }
            else
            {
                MessageBox.Show("Debes ingresar el monto y detalle para crear un pago");
            }
        }

        private void buttonBorrarPago_Click(object sender, EventArgs e)
        {

        }

        private void buttonRealizarPago_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            refreshPagos();
        }
    }

}
