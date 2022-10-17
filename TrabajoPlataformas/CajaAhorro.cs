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
        public List<Usuario> titulares { get; set; }
        public List <Movimiento> movimientos { get; set; }
        public float saldo;
        public Usuario usuario;

        public CajaAhorro(int Cbu, Usuario usuario)
        {
            this.usuario = usuario;
            this.cbu = Cbu;
        }                                    
        public string[] toArray()
        {
            return new string[] { cbu.ToString(), saldo.ToString() };
        }
    }
}
