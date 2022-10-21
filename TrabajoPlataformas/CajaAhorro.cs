using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPlataformas
{
    public class CajaAhorro
    {
        public int cbu;
        public List<Usuario> titulares { get; }
        public List <Movimiento> movimientos { get; set; }
        public float saldo;
        public Usuario usuario;

        public CajaAhorro(int cbu2, Usuario usuario)
        {
            this.usuario = usuario;
            this.cbu = cbu2;
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
