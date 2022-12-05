﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrabajoPlataformas
{
    public class CajaAhorro
    {
        public int id { get; set; }
        public int cbu { get; set; }
        public ICollection<Usuario> titulares { get;} = new List<Usuario>();
        public List<Movimiento> movimientos { get; set; } = new List<Movimiento>();
        public float saldo;
        public Usuario usuario;
        public List<UsuarioCaja> UserCaja { get; set; }
        public CajaAhorro() 
        {
            movimientos = new List<Movimiento>(); // HACE FALTA?
            titulares = new List<Usuario>();
        }
        public CajaAhorro(int cbu2, Usuario usuario)
        {
            this.usuario = usuario;
            titulares = new List<Usuario>(); // Esto va aca o en la definicion?
            this.titulares.Add(usuario);
            movimientos = new List<Movimiento>();
            this.cbu = cbu2;
            this.saldo = 0;

        }
       
        public string[] toArray()
        {
            return new string[] { cbu.ToString(), saldo.ToString() };
        }
        // Tolist of titulares
        //public List<Usuario> obtenerTitulares()
        //{
        //    return titulares.ToList();
        //}
    }
}
