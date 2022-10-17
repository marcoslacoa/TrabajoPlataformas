using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public string nombre;
        public string apellido;
        public string mail;
        public string contra;
        public regBotonDelegado regBotonEvento;
        

        public Register(Banco b)
        {
            this.banco = b;
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

   
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            bool tryDni = Int32.TryParse(txtDni.Text, out this.dni);
            this.nombre = txtNombre.Text;
            this.apellido = txtApellido.Text;
            this.mail = txtMail.Text;
            this.contra = txtContra.Text;

            if (contra != "" && nombre != "" && apellido != "" && mail != "" && tryDni) {
                banco.altaUsuario(dni, nombre, apellido, mail, contra, false);
                MessageBox.Show("Usuario Agregado con éxito", "Registro");
                this.regBotonEvento();
            }
            else { 
                MessageBox.Show("No se pudo agregar el usuario");
            }
            
        }

        public delegate void regBotonDelegado();

        private void button1_Click(object sender, EventArgs e)
        {
            this.regBotonEvento();
        }
    }
}
