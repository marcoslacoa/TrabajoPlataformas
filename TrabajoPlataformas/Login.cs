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
        public Banco banco;
        public loginDelegado loginEvento;
        public registerDelegado regEvento;

        public Login(Banco b)
        {
            logued = false;
            InitializeComponent();
            banco = b;  
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonregister_Click(object sender, EventArgs e)
        {
            this.regEvento();
        }

        public delegate void loginDelegado(string usuario, string pass);
        public delegate void registerDelegado();

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            pass = txtContra.Text;
            if (usuario != null && usuario != "")
            {
                this.loginEvento(usuario, pass);
            }
            else
                MessageBox.Show("Debe ingresar un usuario!");
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
