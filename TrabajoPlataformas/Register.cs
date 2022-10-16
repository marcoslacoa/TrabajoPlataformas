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
using static TrabajoPlataformas.Login;

namespace TrabajoPlataformas
{
    public partial class Register : Form
    {
        public Banco banco;
        public int dni;
        public regBotonDelegado regBotonEvento;

        public Register(Banco b)
        {
            banco = b;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
     
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        public delegate void regBotonDelegado();

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            bool tryDni = Int32.TryParse(txtDni.Text, out this.dni);

            if (banco.altaUsuario(dni, txtNombre.Text, txtApellido.Text, txtMail.Text, txtContra.Text, false)) { 
                MessageBox.Show("Usuario Agregado con éxito");
                this.regBotonEvento();
            }
            else { 
                MessageBox.Show("No se pudo agregar el usuario");
            }
        }

    }
}
