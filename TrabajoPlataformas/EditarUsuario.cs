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
    public partial class EditarUsuario : Form
    {
        public Banco banco;
        public Usuario usuario;
        public EditarUsuario(Banco banco, Usuario usuario)
        {
            InitializeComponent();
            this.banco = banco;
            this.usuario = usuario;
        }
    }
    
}
