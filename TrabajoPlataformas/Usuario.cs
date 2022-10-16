using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPlataformas
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public string mail { get; set; }
        public string contra { get; set; }
        public int intentosFallidos { get; set; }
        public Boolean bloqueado { get; set; }
        public List<CajaAhorro> cajasList { get; }
        public List<PlazoFijo> plazoFijo { get; }
        public List<Pago> pagos { get; }
        public List<TarjetaCredito> tarjetas { get; }

        public Usuario(string Nombre, string Apellido, int Dni, string Mail, string Contra, int IntentosFallidos, bool Bloqueado, List<CajaAhorro> CajasList, List<PlazoFijo> PlazoFijo, List<Pago>Pagos, List<TarjetaCredito> Tarjetas)
        {
             nombre = Nombre;
            apellido = Apellido;
            dni = Dni;
            mail = Mail;
            contra = Contra;
            this.intentosFallidos = IntentosFallidos;
            this.bloqueado = Bloqueado;
            this.cajasList = CajasList;
            this.plazoFijo = PlazoFijo;
            this.pagos = Pagos;
            this.tarjetas = Tarjetas;
        }

        public Usuario(string Nombre, string Apellido, int Dni, string Mail, string Contra, bool Bloqueado) : this(Nombre, Apellido)
        {
            dni = Dni;
            mail = Mail;
            contra = Contra;
            this.bloqueado = Bloqueado;
        }

        public Usuario(string Nombre, string Contra)
        {
            nombre = Nombre;
            contra = Contra;
        }

    }
}
