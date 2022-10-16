﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPlataformas
{
    public class CajaAhorro
    {
        public int cbu;
        public List<Usuario> userList { get => userList.ToList(); }
        public float saldo;

        public CajaAhorro(int Cbu, float Saldo)
        {
            this.cbu = Cbu;
            this.saldo = Saldo;
        }
        public string[] toArray()
        {
            return new string[] { cbu.ToString(), saldo.ToString() };
        }
    }
}
