using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPlataformas
{
    public class Pago
    {
        public int id { get; set; }
        public Usuario usuario { get; set; }
        public float monto { get; set; }
        public Boolean pagado { get; set; }

        public Pago(Usuario Usuario, float Monto, bool Pagado)
        {
            this.usuario = Usuario;
            this.monto = Monto;
            this.pagado = Pagado;
        }
    }
}
