using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPlataformas
{
    internal class PlazoFijo
    {
        public int id { get; set; }
        public Usuario titular { get; set; }
        public float monto { get; set; }
        public DateTime fechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public float tasa { get; set; }
        public Boolean pagado { get; set; }

        public PlazoFijo(Usuario Titular, float Monto, DateTime FechaIni, DateTime FechaFin, float Tasa, bool Pagado)
        {
            this.titular = Titular;
            this.monto = Monto;
            this.fechaIni = FechaIni;
            this.FechaFin = FechaFin;
            this.tasa = Tasa;
            this.pagado = Pagado;
        }
    }
}
