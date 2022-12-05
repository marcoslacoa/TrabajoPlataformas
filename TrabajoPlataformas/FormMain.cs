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
        int numeroDeClickPagar = 0;
        EditarUsuario hijoEditarUsuario;
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
            comboBoxCbuPagos.Items.Clear();
            comboBoxCbuMov.Items.Clear();
            comboBoxCbuPagar.Items.Clear();

            //Logica para el usuario admin - aca iria un foreach con todas los cajas que hay

            foreach (CajaAhorro caja in miBanco.obtenerCajasDelUsuario())
            {
                   dataGridView1.Rows.Add(caja.toArray());

                if (!comboBoxCbu.Items.Contains(caja.cbu))
                {                  
                    comboBoxCbu.Items.Add(caja.cbu);
                    comboBoxCbuPlazo.Items.Add(caja.cbu);
                    comboBoxCbuPagos.Items.Add(caja.cbu);
                    comboBoxCbuMov.Items.Add(caja.cbu);
                    comboBoxCbuPagar.Items.Add(caja.cbu);
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

        public void refreshMovimientos()
        {           
            dataGridView6.Rows.Clear();
            int cbuSeleccionadoMovimientos = Convert.ToInt32(comboBoxCbuMov.SelectedItem);

            //Logica para el usuario admin - aca iria un foreach con todas los movimientos que hay

            foreach (Movimiento movimiento in miBanco.obtenerMovimientos(cbuSeleccionadoMovimientos))
                {
                    dataGridView6.Rows.Add(movimiento.toArray());
                }       
        }
        public void refreshPlazos()
        {
            dataGridView2.Rows.Clear();
            comboBoxCbuPlazo.Items.Clear();

            //Logica para el usuario admin - aca iria un foreach con todas los plazos que hay

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

            ////Logica para el usuario admin - aca iria un foreach con todas las tarjetas que hay

            foreach (TarjetaCredito tarjeta in miBanco.obtenerTarjetasDelUsuario())
            {
                if (miBanco.obtenerTarjetasDelUsuario().Contains(tarjeta))
                    dataGridView5.Rows.Add(tarjeta.toArray());

                if (!comboBoxTarjetaPagos.Items.Contains(tarjeta.numero))
                {
                    comboBoxTarjetaPagos.Items.Add(tarjeta.numero);
                }
                if (!comboBoxTarjetaBorrar.Items.Contains(tarjeta.numero))
                {
                    comboBoxTarjetaBorrar.Items.Add(tarjeta.numero);
                }
                if (!comboBoxTarjetaPagar.Items.Contains(tarjeta.numero))
                {
                    comboBoxTarjetaPagar.Items.Add(tarjeta.numero);
                }
            }
        }

        public void refreshPagos()
        {
            dataGridView3.Rows.Clear(); //Pendientes
            dataGridView4.Rows.Clear(); //Realizados
            comboBoxCbuPagosEliminar.Items.Clear();
            comboBoxPagos.Items.Clear();

            //Logica para el usuario admin - aca iria un foreach con todas los pagos que hay

            
            foreach (Pago pago in miBanco.obtenerPagosDelUsuario())
            {
                //if (miBanco.obtenerPagosDelUsuario().Contains(pago))
                if(!pago.pagado) // pago pendiente 
                { 
                   dataGridView3.Rows.Add(pago.toArray());
                   comboBoxPagos.Items.Add(pago.detalle); //Id para base de datos

                }
                else // pago realizado
                { 
                    dataGridView4.Rows.Add(pago.toArray());
                    comboBoxCbuPagosEliminar.Items.Add(pago.detalle);
                    
                }


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
                // now + 30 days
                DateTime fechaFin = DateTime.Now.AddDays(30);
               
                miBanco.altaPlazo(cbuenInt, monto, fechaIni, fechaFin, false);
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
              float consumos = 0; 
              miBanco.altaTarjeta( numero, cvc, limite, consumos);
        }

        private void buttonPagarTarjeta_Click(object sender, EventArgs e)
        {
            if(comboBoxTarjetaPagar.SelectedItem != null && comboBoxCbuPagar.SelectedItem != null)
            {
                int cbuenIntTarjeta = Convert.ToInt32(comboBoxTarjetaPagar.SelectedItem);
                int cbuenIntCaja = Convert.ToInt32(comboBoxCbuPagar.SelectedItem);
                //TarjetaCredito tarjeta = miBanco.obtenerTarjetasDelUsuario().First(x => x.numero == cbuenIntTarjeta);
                //CajaAhorro caja = miBanco.obtenerCajasDelUsuario().First(x => x.cbu == cbuenIntCaja);
                if (miBanco.pagarTarjeta(cbuenIntTarjeta, cbuenIntCaja))
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
                //TarjetaCredito tarjeta = miBanco.obtenerTarjetasDelUsuario().First(x => x.numero == cbuenInt);
                miBanco.bajaTarjeta(cbuenInt);
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
                if (miBanco.altaPago(monto, false, detalle))
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
            int pago = Convert.ToInt32(comboBoxTarjetaBorrar.SelectedItem);
            if (miBanco.bajaPago(pago))
            {
                MessageBox.Show("Pago eliminado");
                refreshPagos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el pago");
            }
        }

        private void buttonRealizarPago_Click(object sender, EventArgs e)
        {
            int cbuenIntPago = Convert.ToInt32(comboBoxPagos.SelectedItem);
            //Pago pago = miBanco.obtenerPagosDelUsuario().FirstOrDefault(x => x.detalle == cbuenStringPago);

            switch (numeroDeClickPagar)
            {
                case 1:
                    int cbuenIntTarjetaPago = Convert.ToInt32(comboBoxTarjetaPagos.SelectedItem);
                   
                    if (!miBanco.realizarPagoTarjeta(cbuenIntTarjetaPago, cbuenIntPago))
                    {
                        MessageBox.Show("El monto del pago excede el limite de la tarjeta");
                    }
                    else
                    {
                        MessageBox.Show("Pago realizado");
                        refreshPagos();
                        refreshData();
                    }
                    break;
                case 2:

                    int cbuenIntCajaPago = Convert.ToInt32(comboBoxCbuPagos.SelectedItem);

                    if (!miBanco.realizarPagoCaja(cbuenIntCajaPago, cbuenIntPago))
                    {
                        MessageBox.Show("Usted no tiene saldo para realizar el pago");
                    }
                    else
                    {
                        MessageBox.Show("Pago realizado");
                        refreshPagos();
                        refreshData();
                    }
                    break;
            }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            refreshPagos();
        }

        private void comboBoxPagos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCbuPagos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCbuMov_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshMovimientos();
        }

        private void mostrar2_Click(object sender, EventArgs e)
        {
            refreshMovimientos();

        }

        private void buttonPagarConTarjeta_Click(object sender, EventArgs e)
        {
            comboBoxTarjetaPagos.Visible = true;
            comboBoxCbuPagos.Visible = false;
            numeroDeClickPagar = 1;
        }

        private void buttonPagarConCaja_Click(object sender, EventArgs e)
        {
            comboBoxTarjetaPagos.Visible = false;
            comboBoxCbuPagos.Visible = true;
            numeroDeClickPagar = 2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.hijoEditarUsuario = new EditarUsuario(miBanco, miBanco.usuarioActual);

            hijoEditarUsuario.Show();
        }
    }

}
