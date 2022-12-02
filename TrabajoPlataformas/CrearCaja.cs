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
    public partial class CrearCaja : Form
    {
        public Banco banco;
        public int cbuCaja;
        
        public Usuario usuario;
        public int numeroDeClick;
        public cofirmoBorrarDelegate confirmBorrarEvento;
        public int numeroDeClickModificar;

        public CrearCaja(Banco banco, Usuario usuario)
        {
            InitializeComponent();
            this.banco = banco;
            this.usuario = usuario;
            int a = usuario.dni;
            int b = new Random().Next(100000, 999999);
            this.cbuCaja = a + b;
        }

        private void cbu_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            switch (numeroDeClick)
            {
                case 1:
                   float saldoCaja = float.Parse(saldo.Text);
                    if(banco.crearCajaAhorro(cbuCaja, saldoCaja) == 2)
                    {
                            MessageBox.Show("Caja de ahorro creada con exito");
                            this.Close();
                        }
                    else if (banco.crearCajaAhorro(cbuCaja, saldoCaja) == 1)
                    {
                            MessageBox.Show("No se pudo crear la caja de ahorro. El CBU ya existe");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear la caja de ahorro. El saldo es negativo");
                    }
                    
                    
                   
                    break;
                case 2:
                    if (numeroDeClickModificar == 1) { 
                        int usuarioSeleccionado = Convert.ToInt32(comboBoxTitular.SelectedItem); //dni
                        int cbuSeleccionado = Convert.ToInt32(comboBoxCajaAgregar.SelectedItem); //cbu
                        int aux2 = banco.agregarTitular(cbuSeleccionado, usuarioSeleccionado);
                        // execute the method agregarTitular from banco
                        if(aux2 == 0)
                        {
                            // No existe el usuario
                            MessageBox.Show("No existe el usuario");
                        }
                        else if (aux2 == 1) {
                            // El usuario ya es titular
                            MessageBox.Show("El usuario ya es titular");
                        }
                        else
                        {
                            // El usuario se agrego correctamente
                            MessageBox.Show("El usuario se agrego correctamente"); 
                        }


                    }
                    else if (numeroDeClickModificar == 2) { 

                        int usuarioSeleccionado2 = Convert.ToInt32(comboBoxTitular.SelectedItem);
                        int cbuSeleccionado = Convert.ToInt32(comboBoxCajaAgregar.SelectedItem);


                        int aux3 = banco.eliminarTitular(cbuSeleccionado, usuarioSeleccionado2);
                        if (aux3 == 0)
                        {
                            // No existe el usuario
                            MessageBox.Show("No existe el usuario");
                        }
                        else if (aux3 == 1)
                        {
                            // El usuario no es titular
                            MessageBox.Show("El usuario no es titular");
                        }
                        else if (aux3 == 2)
                        {
                            // El usuario es el unico titular 
                            MessageBox.Show("El usuario es el unico titular");
                        }
                        else
                        {
                            // El usuario se elimino correctamente
                            MessageBox.Show("El usuario se elimino correctamente");
                        }
                    }
                    break;
                case 3: // Borrar caja 
                    int cbuenInt = Convert.ToInt32(comboBoxCajaAgregar.SelectedItem);
                    int aux = banco.bajaCaja(cbuenInt);
                    if (aux == 1)
                        MessageBox.Show("Porfavor retire todo su dinero ante de eliminar la caja.");
                        
                    else if (aux == 3)
                        MessageBox.Show("La caja no existe.");
                    else
                        MessageBox.Show("La caja se ha eliminado correctamente.");
                        this.confirmBorrarEvento();
                    break;

            }          
            this.Close();
        }

        public delegate void cofirmoBorrarDelegate();

        private void CrearCaja_Load(object sender, EventArgs e)
        {
            comboBoxCajaAgregar.Visible = false;
            labelTitular.Visible = false;
            comboBoxTitular.Visible = false;
            buttonAgregar.Visible = false;
            buttonBorrar.Visible = false;
            label3.Visible = false;
            cbu.Visible = false;
            saldo.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            buttonAgregar.Visible = false;
            buttonBorrar.Visible = false;
            
      
        }

        private void saldo_TextChanged(object sender, EventArgs e)
        {

        }
        private void cbu_load_1(object sender, EventArgs e)
        {

            // show this.cbuCaja and make it readonly
            

        }
        private void saldo_load_1(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            cbu.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            saldo.Visible = true;
            comboBoxCajaAgregar.Visible = false;
            labelTitular.Visible = false;
            cbu.Text = "" + cbuCaja;
            cbu.ReadOnly = true;
            saldo.Text = "0";
            saldo.ReadOnly = true;
            comboBoxTitular.Visible = false;
            buttonAgregar.Visible = false;
            buttonBorrar.Visible = false;
            confirmar.Visible = true;
            numeroDeClick = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbu.Visible = false;
            label2.Visible = false;
            saldo.Visible = false;
            label1.Visible = true;
            comboBoxCajaAgregar.Visible = true;
            //labelTitular.Visible = true;
            //comboBoxTitular.Visible = true;
            buttonAgregar.Visible = true;
            buttonBorrar.Visible = true;
            confirmar.Visible = false;
            comboBoxCajaAgregar.Items.Clear();
            numeroDeClick = 2;
            foreach (CajaAhorro caja in banco.obtenerCajasDelUsuario())
            {
                comboBoxCajaAgregar.Items.Add(caja.cbu);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            cbu.Visible = false;
            label2.Visible = false;
            saldo.Visible = false;
            label1.Visible = true;
            comboBoxCajaAgregar.Visible = true;
            labelTitular.Visible = false;
            comboBoxTitular.Visible = false;
            buttonAgregar.Visible = false;
            buttonBorrar.Visible = false;
            confirmar.Visible = true;
            numeroDeClick = 3;
            comboBoxCajaAgregar.Items.Clear();
            foreach (CajaAhorro caja in banco.obtenerCajasDelUsuario())
            {
                comboBoxCajaAgregar.Items.Add(caja.cbu);
            }

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            labelTitular.Visible = true;
            comboBoxTitular.Visible = true;
            confirmar.Visible = true;
            numeroDeClickModificar = 1;

            int cbuSeleccionado = Convert.ToInt32(comboBoxCajaAgregar.SelectedItem);
            CajaAhorro caja = banco.obtenerCajasDelUsuario().First(x => x.cbu == cbuSeleccionado);
            comboBoxTitular.Items.Clear();

            foreach (Usuario user in banco.obtenerUsuarios())
            {
                if (!caja.titulares.Contains(user))
                {
                    comboBoxTitular.Items.Add(user.dni);
                }
            }

        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            labelTitular.Visible = true;
            comboBoxTitular.Visible = true;
            confirmar.Visible = true;
            numeroDeClickModificar = 2;


            int cbuSeleccionado = Convert.ToInt32(comboBoxCajaAgregar.SelectedItem);
            CajaAhorro caja = banco.obtenerCajasDelUsuario().First(x => x.cbu == cbuSeleccionado);
            comboBoxTitular.Items.Clear();

            foreach (Usuario user in caja.titulares)
            {
                comboBoxTitular.Items.Add(user.dni);
            }
        }

        private void comboBoxTitular_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
