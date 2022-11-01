﻿using System;
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
        public float saldoCaja;
        public Usuario usuario;
        public int numeroDeClick;
        public cofirmoBorrarDelegate confirmBorrarEvento;
        public int numeroDeClickModificar;
        public int cbuSeleccionado;

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
                    saldoCaja = float.Parse(saldo.Text);
                    banco.crearCajaAhorro(cbuCaja, saldoCaja, usuario);
                    break;
                case 2:                  
                    switch (numeroDeClickModificar)
                    {
                        case 1:

                            int usuarioSeleccionado = Convert.ToInt32(comboBoxTitular.SelectedItem);
                            Usuario usuario = banco.userList.First(x => x.dni == usuarioSeleccionado);
                            CajaAhorro cajaSeleccionada = banco.cajasList.First(x => x.cbu == cbuSeleccionado);
                            cajaSeleccionada.titulares.Add(usuario);
                            usuario.listaCajas.Add(cajaSeleccionada);
                            
                            Trace.WriteLine(cajaSeleccionada.titulares.Count.ToString());
                            break;
                        case 2:

                            int usuarioSeleccionado2 = Convert.ToInt32(comboBoxTitular.SelectedItem);
                            Usuario usuario2 = banco.userList.First(x => x.dni == usuarioSeleccionado2);
                            CajaAhorro cajaSeleccionada2 = banco.cajasList.First(x => x.cbu == cbuSeleccionado);
                            cajaSeleccionada2.titulares.Remove(usuario2);
                            usuario2.listaCajas.Remove(cajaSeleccionada2);
                            Trace.WriteLine(cajaSeleccionada2.titulares.Count.ToString());
                            break;
                    }
                    break;
                case 3:                   
                    int cbuenInt = Convert.ToInt32(comboBoxCajaAgregar.SelectedItem);
                    CajaAhorro caja2 = banco.obtenerCajasDelUsuario().First(x => x.cbu == cbuenInt);
                    if (caja2.saldo != 0)
                        MessageBox.Show("Porfavor retire todo su dinero ante de eliminar la caja.");
                    else
                    {
                        banco.bajaCaja(caja2);
                        this.confirmBorrarEvento();
                    }
                    //Logica para borrar la caja
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

            cbuSeleccionado = Convert.ToInt32(comboBoxCajaAgregar.SelectedItem);
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


            cbuSeleccionado = Convert.ToInt32(comboBoxCajaAgregar.SelectedItem);
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
