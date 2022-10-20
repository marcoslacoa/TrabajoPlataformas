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
            this.cajas = new List<CajaAhorro>();
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
               
            refreshData();

        }

        public delegate void cerrarsesion();
        private void refreshData()
        {
            //borro los datos
            dataGridView1.Rows.Clear();
            
           
            foreach(CajaAhorro caja in miBanco.obtenerCajasDelUsuario()) 
                {
                
                //string[] arr = new string[] { caja.saldo.ToString(), caja.cbu.ToString() };
                //dataGridView1.Rows.Add(arr);
                    dataGridView1.Rows.Add(caja.toArray());
                // Mostrar solo 1 dato con el refresh
                comboBoxCbu.Items.Add(caja.cbu);

                /*if (comboBoxCbu.Items.Contains(caja.cbu)) {
                    return;
                } else
                {
                   
                }*/
            }
            foreach (CajaAhorro caja in miBanco.cajasList)
            {
                if(caja.usuario != miBanco.usuarioActual) {
                    comboBoxCbuDestino.Items.Add(caja.cbu);
                    /*if (comboBoxCbuDestino.Items.Contains(caja.cbu))
                    {
                       return;
                    }
                    else
                    {
                       
                    }*/
                }
            }

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
                        MessageBox.Show("Se ha retirado " + monto);
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
                        MessageBox.Show("Se ha depositados " + monto);
                    }                  
                    break;
                case 3:
                    if (comboBoxCbu.SelectedItem != null)
                    {
                        // take the combobox selected item and convert it to int
                        int cbuenInt = Convert.ToInt32(comboBoxCbu.SelectedItem);
                        int cbuenIntDestino = Convert.ToInt32(comboBoxCbuDestino.SelectedItem);
                        CajaAhorro origen = miBanco.obtenerCajasDelUsuario().First(x => x.cbu == cbuenInt);
                        CajaAhorro destino = miBanco.obtenerCajasDelUsuario().First(x => x.cbu == cbuenIntDestino);
                        float monto = float.Parse(textMonto.Text);
                        miBanco.transferir(origen, destino, monto);
                       
                        refreshData();
                        MessageBox.Show("Se ha transferido " + monto);

                    }

                    break;
            }
        }
    }

}
