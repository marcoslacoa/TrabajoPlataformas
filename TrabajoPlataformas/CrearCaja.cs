using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPlataformas
{
    public partial class CrearCaja : Form
    {
        public Banco banco;
        public int cbuCaja;
        public float saldoCaja;
        public Usuario usuario;
        public int numeroDeClick;

        public CrearCaja(Banco banco, Usuario usuario)
        {
            InitializeComponent();
            this.banco = banco;
            this.usuario = usuario;
            int a = usuario.dni;
            int b = new Random().Next(100000, 999999);
            this.cbuCaja = a + b;
            comboBoxCaja.Visible = false;
            labelTitular.Visible = false;
            comboBoxTitular.Visible = false;
            buttonAgregar.Visible = false;
            buttonBorrar.Visible = false;

        }

        private void cbu_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            switch (numeroDeClick)
            {
                case 1:
                    saldoCaja = float.Parse(saldo.Text);
                    banco.crearCajaAhorro(cbuCaja, saldoCaja);
                    break;
                case 3:
                    int cbuenInt = Convert.ToInt32(comboBoxCaja.SelectedItem);
                    CajaAhorro caja = banco.obtenerCajasDelUsuario().First(x => x.cbu == cbuenInt);
                    banco.bajaCaja(caja);
                    //Logica para borrar la caja
                    break;

            }          
            this.Close();
        }

        private void CrearCaja_Load(object sender, EventArgs e)
        {
            
            cbu.Text = "" + cbuCaja;
            cbu.ReadOnly = true;
            saldo.Text = "0";
            saldo.ReadOnly = true;
            foreach (CajaAhorro caja in banco.obtenerCajasDelUsuario())
            {
                comboBoxCaja.Items.Add(caja.cbu);
                /* comboBoxTitular.Items.Add(caja.titulares);*/
            }
        }

        private void saldo_TextChanged(object sender, EventArgs e)
        {

        }
        private void cbu_load_1(object sender, EventArgs e)
        {

            // show this.cbuCaja and make it readonly
            

        }
        private void saldo_load_1(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbu.Visible = true;
            label2.Visible = true;
            saldo.Visible = true;
            comboBoxCaja.Visible = false;
            labelTitular.Visible = false;
            comboBoxTitular.Visible = false;
            buttonAgregar.Visible = false;
            buttonBorrar.Visible = false;
            confirmar.Visible = true;
            numeroDeClick = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbu.Visible = false;
            label2.Visible = false;
            saldo.Visible = false;
            comboBoxCaja.Visible = true;
            labelTitular.Visible = true;
            comboBoxTitular.Visible = true;
            buttonAgregar.Visible = true;
            buttonBorrar.Visible = true;
            confirmar.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            cbu.Visible = false;
            label2.Visible = true;
            saldo.Visible = true;
            comboBoxCaja.Visible = true;
            labelTitular.Visible = false;
            comboBoxTitular.Visible = false;
            buttonAgregar.Visible = false;
            buttonBorrar.Visible = false;
            confirmar.Visible = true;
            numeroDeClick = 3;

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {

        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {

        }
    }
}
