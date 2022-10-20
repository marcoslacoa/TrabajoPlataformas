using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPlataformas
{
    public class PlazoFijo
    {
        public int id { get; set; }
        public Usuario titular { get; set; }
        public float monto { get; set; }
        public DateTime fechaIni { get; set; }
        public DateTimePicker FechaFin { get; set; }
        public float tasa { get; set; }
        public CajaAhorro caja { get; set; }
        public Boolean pagado { get; set; }

        public PlazoFijo(Usuario Titular, CajaAhorro Caja , float Monto,DateTime FechaIni, DateTimePicker FechaFin, float Tasa, bool Pagado)
        {
            this.titular = Titular;
            this.monto = Monto;
            this.fechaIni = FechaIni;
            this.FechaFin = FechaFin;
            this.tasa = Tasa;
            this.pagado = Pagado;
            this.caja = Caja;
        }

        public string[] toArray()
        {
            return new string[] { monto.ToString(), fechaIni.ToString(), fechaIni.ToString(), tasa.ToString() };
        }
    }
}
