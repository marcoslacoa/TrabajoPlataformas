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
        public crearCajaDelegado crearCajaEvento;
        public CrearCaja(Banco banco)
        {
            InitializeComponent();
            this.banco = banco;

        }
        public delegate void crearCajaDelegado(Banco banco);
        private void cbu_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            // llamado a this.crearCajaEvento()
        }
    }
}
