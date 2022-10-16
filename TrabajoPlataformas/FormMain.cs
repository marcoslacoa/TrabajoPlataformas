using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPlataformas
{
    public partial class FormMain : Form
    {
        public object[] argumentos;
        List<List<string>> datos;
        public string usuario;
        public Banco miBanco;
        public FormMain()
        {
            InitializeComponent();
        }
        //public FormMain(string usuario, Banco b)
        //{
        //    InitializeComponent();
        //    miBanco = (Banco)args[1];
        //    argumentos = args;
        //    label1.Text = (string)args[0];
        //    datos = new List<List<string>>();
        //}

        //private void refreshData()
        //{
        //    //borro los datos
        //    dataGridView1.Rows.Clear();
        //    //agrego lo nuevo
        //    foreach (Usuario user in miBanco.obtenerUsuarios())
        //        dataGridView1.Rows.Add(user.toArray());
        //}
    }
}
