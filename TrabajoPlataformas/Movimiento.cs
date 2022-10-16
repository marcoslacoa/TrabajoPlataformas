using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPlataformas
{
    internal class Movimiento
    {
        public int id { get; set; }
        public CajaAhorro caja;
        public string detalle { get; set; }
        public float monto { get; set; }
        public DateTime fecha { get; set; }

        public Movimiento(CajaAhorro Caja, string Detalle, float Monto, DateTime Fecha)
        {
            this.caja = Caja;
            this.detalle = Detalle;
            this.monto = Monto;
            this.fecha = Fecha;
        }
    }
}
