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
            numeroDeClick = 1;
            foreach (CajaAhorro caja in miBanco.usuarioActual.listaCajas)
            {
                comboBoxCbu.Items.Add(caja.cbu);
            }
        }

        private void depositar_Click(object sender, EventArgs e)
        {
            cbuLabel.Visible = true;
            textMonto.Visible = true;
            montoLabel.Visible = true;
            comboBoxCbu.Visible = true;
            buttonConfirmar.Visible = true;
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
                    CajaAhorro caja = miBanco.usuarioActual.listaCajas.Where(f => f.cbu.Equals(comboBoxCbu.SelectedValue)).FirstOrDefault();
                    if (caja != null)
                    {
                        miBanco.retirar(caja, float.Parse(textMonto.Text));
                    }
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
            }
        }
    }

}
