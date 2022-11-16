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

        public CajaAhorro() { }
        public CajaAhorro(int cbu2, Usuario usuario)
        {
            this.usuario = usuario;
            titulares = new List<Usuario>();
            this.titulares.Add(usuario);
            movimientos = new List<Movimiento>();
            this.cbu = cbu2;
        }
        public void agregarTitular(Usuario usuario)
        {
            this.titulares.Add(usuario);
        }
        public void eliminarTitular(Usuario usuario)
        {
            this.titulares.Remove(usuario);
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
