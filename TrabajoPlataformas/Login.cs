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
        public int dni;
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
        
        public delegate void loginDelegado(int dni, string pass);
        public delegate void registerDelegado();

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            dni = Int32.Parse(txtDni.Text);
            pass = txtContra.Text;
            if (dni != 0 && pass != "")
            {
                if (banco.iniciarSesion(dni, pass))
                {
                    MessageBox.Show("Login exitoso", "Login");
                    this.loginEvento(dni, txtContra.Text);
                }
                else
                {
                    MessageBox.Show("Login fallido", "Login");
                }
            }
            else
            {
                MessageBox.Show("No se pudo loguear");
            }
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
