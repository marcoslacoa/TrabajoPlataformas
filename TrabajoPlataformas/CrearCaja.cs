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

        public CrearCaja(Banco banco, Usuario usuario)
        {
            InitializeComponent();
            this.banco = banco;
            this.usuario = usuario;
            int a = usuario.dni;
            int b = new Random().Next(100000, 999999);
            this.cbuCaja = a + b;
        }

        private void cbu_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            saldoCaja = float.Parse(saldo.Text);
            banco.crearCajaAhorro(cbuCaja, saldoCaja);
            this.Close();
        }

        private void CrearCaja_Load(object sender, EventArgs e)
        {
            
            cbu.Text = "" + cbuCaja;
            cbu.ReadOnly = true;
            saldo.Text = "0";
            saldo.ReadOnly = true;
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
    }
}
