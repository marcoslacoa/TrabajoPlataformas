using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        List<List<string>> datos;
        public string usuario;
        public Banco miBanco;
        public cerrarsesion cerrarsesionEvento;


        public FormMain(Usuario usuario, Banco b)
        {
            InitializeComponent();

            this.miBanco = b;
            this.usuario = usuario.nombre;
            label2.Text = usuario.nombre;
        }

        //public FormMain(object[] args)
        //{
        //    InitializeComponent();
        //    miBanco = (Banco)args[1];
        //    argumentos = args;
        //    datos = new List<List<string>>();
        //}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        public delegate void cerrarsesion();

        private void refreshData()
        {
            //borro los datos
            dataGridView1.Rows.Clear();
            //agrego lo nuevo
            //    foreach (Usuario user in miBanco.obtenerUsuarios())
            //        //string[] arr = new string[] { user.nombre, user.contra };
            //        //dataGridView1.Add(arr);
            //        dataGridView1.Rows.Add(user.toArray());
            //}
            
           
            foreach(CajaAhorro caja in miBanco.obtenerCajasDelUsuario())
                {
                //string[] arr = new string[] { caja.saldo.ToString(), caja.cbu.ToString() };
                //dataGridView1.Rows.Add(arr);
                try { 
                    dataGridView1.Rows.Add(caja.toArray());
                } catch {
                    
                }
            }
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.cerrarsesionEvento();
        }

        private void retirar_Click(object sender, EventArgs e)
        {

        }

        private void depositar_Click(object sender, EventArgs e)
        {

        }

        private void transferir_Click(object sender, EventArgs e)
        {

        }
    }

}
