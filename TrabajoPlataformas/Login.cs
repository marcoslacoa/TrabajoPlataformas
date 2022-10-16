using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrabajoPlataformas
{
    public partial class Login : Form
    {
        public bool logued;
        public string usuario;
        public string pass;
        public Banco elBanco;

        public TransfDelegado TransfEvento;
        public registerDelegado regEvento;
        public Login(Banco b)
        {
            logued = false;
            InitializeComponent();
            elBanco = b;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonregister_Click(object sender, EventArgs e)
        {
            // LOGICA DE LLAMADO A PADRE. CLOSE DE LOGIN

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            pass = txtContra.Text;
            if (usuario != null && usuario != "")
            {
                this.TransfEvento(usuario, pass);
            }
            else
                MessageBox.Show("Debe ingresar un usuario!");
        }
        public delegate void TransfDelegado(string usuario, string pass);
        public delegate void registerDelegado();

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
