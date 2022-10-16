using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TrabajoPlataformas.Login;

namespace TrabajoPlataformas
{
    public partial class Register : Form
    {
        public Banco banco;
        private string nombre;
        private string apellido;
        private int dni;
        private string email;
        private string password;
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

        private void buttonRegister_Click(object sender, EventArgs e)
        {

        }
    }
}
