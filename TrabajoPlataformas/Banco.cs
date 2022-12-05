using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TrabajoPlataformas
{
    public class Banco
    {
        //private List<Usuario> userList;
        //private List<CajaAhorro> cajasList;
        //private List<PlazoFijo> plazosFijos;
        //private List<Pago> pagos;
        //private List<Pago> pagosPendientes;
        //private List<Pago> pagosRealizados;
        //private List<Movimiento> movimientos;
        //private List<TarjetaCredito> tarjetas;

        public Usuario usuarioActual;

        private Contexto contexto;

        public Banco()
        {
            inicializarAtributos();
            //userList = new List<Usuario>();
            //cajasList = new List<CajaAhorro>();
            //plazosFijos = new List<PlazoFijo>();
            //pagos = new List<Pago>();
            //movimientos = new List<Movimiento>();
            //tarjetas = new List<TarjetaCredito>();
        }
        private void inicializarAtributos()
        {
            try
            {
                contexto = new Contexto();
                contexto.usuarios
                    .Include(u => u.listaCajas)
                    .Include(u => u.tarjetas)
                    .Include(u => u.plazoFijo)
                    .Include(u => u.pagos)
                    .Load();
                contexto.cajas
                    .Include(p => p.titulares)
                    .Include(p => p.movimientos)
                    .Load();
                contexto.plazos.Load();
                contexto.pagos.Load();
                contexto.movimientos.Load();
                contexto.tarjetas.Load();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void cerrar()
        {
            contexto.Dispose();
        }


        //ABM Usuario
        public bool altaUsuario(int dni, string nombre, string apellido, string mail, string contra, bool bloqueado, bool admin)
        {
            try
            {
                Usuario nuevo = new Usuario(nombre, apellido, dni, mail, contra, bloqueado, admin);

                contexto.usuarios.Add(nuevo);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool bajaUsuario(int id)
        {
            try {
                Usuario usuarioToRemove = getUsuario(id);
                if (usuarioToRemove != null)
                {
                    contexto.usuarios.Remove(usuarioToRemove);
                    contexto.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool modificarUsuario(int Id, int dni, string mail, string pass)
        {
            try
            {
                Usuario usuarioModificar = getUsuario(Id);
                if (usuarioModificar != null)
                {
                    usuarioModificar.mail = mail;
                    usuarioModificar.contra = pass;
                    contexto.Update(usuarioModificar);
                    contexto.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //ABM Caja de Ahorro

        //Ver como hacer el crear caja

        public int crearCajaAhorro()
        {
            // return 1 si ya existe, 2 si se crea bien, 3 si tiene saldo negativo
            int min = 100000;
            int max = 999999;
            Random random = new Random();
            int numero = random.Next(min, max);
            

            if (contexto.cajas.Any(c => c.cbu == numero))
            {
                return 1; // ya existe
            }
            else
            {
                CajaAhorro nueva = new CajaAhorro(numero, usuarioActual);
                contexto.cajas.Add(nueva);
                contexto.Update(usuarioActual);
                contexto.SaveChanges();
                return 2;
            }
        }

        public int bajaCaja(int cbuCaja)
        {
            try
            {
                CajaAhorro? cajaToRemove = this.getCaja(cbuCaja);
                if (cajaToRemove == null)
                {
                    return 1;
                }
                if (cajaToRemove.saldo != 0)
                {
                    return 2;
                }
                foreach (Usuario titular in cajaToRemove.titulares)
                {
                    titular.listaCajas.Remove(cajaToRemove);
                }
                contexto.cajas.Remove(cajaToRemove);
                contexto.SaveChanges();

                return 0;
            }
            catch
            {
                return 3;
            }

        }


        //ABM Plazo Fijo

        public bool altaPlazo(int cbu, float monto, DateTime fechaIni, DateTime fechaFin, bool pagado) // ESTA BIEN ESTO? PROFE
        {
            try
            {
                float tasa = 0.1f;
                Usuario user = usuarioActual;
                PlazoFijo nuevoPlazoFijo = new PlazoFijo(user, cbu, monto, fechaIni, fechaFin, tasa, pagado);
                CajaAhorro? caja = getCaja(cbu);

                if (monto < 1000)
                {
                    return false; //Monto insuficiente
                }
                if (caja == null)
                {
                    return false; //No se encontró la caja
                }
                if (caja.saldo < monto)
                {
                    return false; //Fondos insuficientes
                }
                caja.saldo -= monto;
                this.altaMovimiento(caja, "Alta plazo fijo", monto, DateTime.Now);
                contexto.plazos.Add(nuevoPlazoFijo);
                contexto.Update(caja);
                contexto.Update(usuarioActual);
                contexto.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bajaPlazo(int id)
        {
            try
            {
                PlazoFijo plazoFijoToRemove = getPlazo(id);
                if (plazoFijoToRemove == null)
                {
                    return false;
                }
                if (!plazoFijoToRemove.pagado || DateTime.Now < plazoFijoToRemove.FechaFin.AddMonths(1))
                {
                    return false;
                }
                plazoFijoToRemove.titular.plazoFijo.Remove(plazoFijoToRemove);
                contexto.Update(plazoFijoToRemove.titular);
                contexto.plazos.Remove(plazoFijoToRemove);
                contexto.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //ABM Pagos

        public bool altaPago(float monto, bool pagado, string detalle)
        {
            try
            {
                Usuario usuario = usuarioActual;
                Pago nuevo = new Pago(usuario, monto, pagado, detalle);

                contexto.pagos.Add(nuevo);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool bajaPago(int IdPago)
        {

            Pago pagoToRemove = this.getPago(IdPago);
            try
            {
                if (pagoToRemove == null)
                {
                    return false;
                }
                if (!pagoToRemove.pagado)
                {
                    return false;
                }

                contexto.pagos.Remove(pagoToRemove);
                pagoToRemove.usuario.pagos.Remove(pagoToRemove);
                contexto.Update(pagoToRemove.usuario);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool modificarPago(int IdPago)
        {
            Pago pagoModificar = getPago(IdPago);
            try
            {
                if (pagoModificar == null)
                {
                    return false;
                }
                pagoModificar.pagado = true;
                contexto.Update(pagoModificar);
                contexto.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //ABM Movimientos

        public bool altaMovimiento(CajaAhorro caja, string detalle, float monto, DateTime fecha)
        {
            try
            {
                Movimiento nuevo = new Movimiento(caja, detalle, monto, fecha);

                contexto.movimientos.Add(nuevo);
                caja.movimientos.Add(nuevo);
                contexto.Update(caja);
                contexto.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        //ABM Tarjetas

        public bool altaTarjeta(int numero, int codigoSeguridad, float limite, float consumos)
        {
            try
            {
                Usuario titular = usuarioActual;
                TarjetaCredito nuevo = new TarjetaCredito(titular, numero, codigoSeguridad, limite, consumos);

                nuevo.titular = usuarioActual;
                titular.tarjetas.Add(nuevo);
                contexto.tarjetas.Add(nuevo);
                contexto.Update(usuarioActual);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool bajaTarjeta(int IdTarjeta)
        {
            TarjetaCredito? tarjetaToRemove = getTarjeta(IdTarjeta);
            try
            {
                if (tarjetaToRemove == null)
                {
                    return false;
                }
                if (tarjetaToRemove.consumos != 0) // La condición para eliminar es que no tenga consumos sin pagar.
                {
                    return false;
                }

                tarjetaToRemove.titular.tarjetas.Remove(tarjetaToRemove);
                contexto.Update(tarjetaToRemove.titular);
                contexto.tarjetas.Remove(tarjetaToRemove);
                contexto.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }


        //Metodos

        public bool iniciarSesion(string usuario, string pass)
        {
            // define a query with contexto filtering with usuario
            Usuario user = contexto.usuarios.Where(x => x.nombre == usuario).FirstOrDefault();
            if (user != null)
            {
                if (user.contra == pass)
                {
                    this.usuarioActual = user;
                    user.intentosFallidos = 0;
                    contexto.Update(user);
                    contexto.SaveChanges();
                    return true;
                }
                if (user.contra != pass)
                {
                    user.intentosFallidos++;
                    if (user.intentosFallidos >= 3)
                    {
                        user.bloqueado = true;
                    }
                    contexto.Update(user);
                    contexto.SaveChanges();
                    return false;
                }
                return false;
            } else
            {
                return false;
            }
        }

        public bool cerrarSesion()
        {
            this.usuarioActual = null;
            return true;
        }


        // Metodo para obtener una caja en especifico

        public bool depositar(int cbuCaja, float monto)
        {
            CajaAhorro caja = getCaja(cbuCaja);

            if (monto <= 0)
            {
                return false; //No se puede depositar un monto negativo o cero.
            }
            caja.saldo += monto;
            contexto.Update(caja);
            this.altaMovimiento(caja, "Deposito", monto, DateTime.Now);
            contexto.SaveChanges();

            return true;
        }

        public bool retirar(int cbuCaja, float monto)
        {
            CajaAhorro caja = getCaja(cbuCaja);
            if (monto > caja.saldo)
            {
                return false; //No hay saldo suficiente
            }
            caja.saldo -= monto;
            contexto.Update(caja);
            this.altaMovimiento(caja, "Retiro", monto, DateTime.Now);
            contexto.SaveChanges();

            return true; //Retiro exitoso 
            // Mensaje de respuesta con datos del objeto
        }

        public int transferir(int cbuOrigen, int cbuDestino, float monto) // If monto <= 0 entonces retorna 1. Si monto > saldo entonces retorna 2. Si no hay error retorna 0.
        {
            CajaAhorro origen = this.getCaja(cbuOrigen);
            CajaAhorro destino = this.getCaja(cbuDestino);
            if (destino == null)
            {
                return 0; // No existe la caja destino
            }
            if (origen.saldo < monto)
            {
                return 1; // No hay saldo suficiente
            }
            origen.saldo -= monto;
            contexto.Update(origen);
            this.altaMovimiento(origen, "Transferencia enviada ", monto, DateTime.Now);
            destino.saldo += monto;
            contexto.Update(destino);
            this.altaMovimiento(destino, "Transferencia recibida", monto, DateTime.Now);
            contexto.SaveChanges();

            return 2; // Transferencia exitosa
        }

        public int agregarTitular(int cbu, int dni) { // PROFE: ACA TENGO QUE PASARLE SOLO CBU Y DNI A LA CLASE CAJA AHORRO Y A USUARIO,
            CajaAhorro caja = getCaja(cbu);
            Usuario nuevoTitular = getUsuario(dni);
            if (nuevoTitular == null)
            {
                return 0; // No existe el usuario
            }
            if (caja.titulares.Contains(nuevoTitular))
            {
                return 1; // El usuario ya es titular
            }
            caja.titulares.Add(nuevoTitular);
            nuevoTitular.listaCajas.Add(caja);
            contexto.Update(caja);
            contexto.Update(nuevoTitular);
            contexto.SaveChanges();

            return 2; // Titular agregado exitosamente
        }

        public int eliminarTitular(int cbu, int dni)
        {
            CajaAhorro caja = getCaja(cbu);
            Usuario usuario = getUsuario(dni);

            if (usuario == null)
            {
                return 0; // No existe el usuario
            }
            if (!caja.titulares.Contains(usuario))
            {
                return 1; // El usuario no es titular
            }
            if (caja.titulares.Count == 1)
            {

                return 2; // No se puede eliminar el unico titular
            }
            caja.titulares.Remove(usuario);
            usuario.listaCajas.Remove(caja);
            contexto.Update(caja);
            contexto.Update(usuario);
            contexto.SaveChanges();
            return 3;
        }

        public bool pagarTarjeta(int numero, int cbu)
        {
            CajaAhorro? caja = getCaja(numero);
            TarjetaCredito? tarjeta = getTarjeta(cbu);

            if (tarjeta.consumos > caja.saldo)
            {
                return false;
            }
            else
            {
                caja.saldo -= tarjeta.consumos;
                this.altaMovimiento(caja, "Pago de tarjeta", tarjeta.consumos, DateTime.Now);
                tarjeta.consumos = 0;
                contexto.Update(tarjeta);
                contexto.Update(caja);
                contexto.SaveChanges();
                return true;
            }

        }

        public bool realizarPagoCaja(int cbuCaja, int IdPago) // ID
        {
            CajaAhorro caja = getCaja(cbuCaja);
            Pago pago = getPago(IdPago);
            if (caja.saldo < pago.monto)
            {
                return false;
            }

            else
            {
                caja.saldo -= pago.monto;
                this.modificarPago(IdPago);
                this.altaMovimiento(caja, "Pago de " + pago.detalle, pago.monto, DateTime.Now);
                contexto.Update(caja);
                contexto.Update(pago);
                contexto.SaveChanges();
                return true;
            }
        }

        public bool realizarPagoTarjeta(int numeroTarjeta, int IdPago) //ID 
        {
            TarjetaCredito? tarjeta = getTarjeta(numeroTarjeta);
            Pago pago = getPago(IdPago);
            if ((tarjeta.consumos < pago.monto)&&(tarjeta.limite < pago.monto))
            {
                return false;
            }
            else
            {
                tarjeta.consumos += pago.monto;
                this.modificarPago(IdPago);
                contexto.Update(tarjeta);
                contexto.Update(pago);
                contexto.SaveChanges();
                return true;
            }
        }

        public void pagarPlazoVencido(int cbu, int idPlazo)
        {
            CajaAhorro caja = getCaja(cbu);
            PlazoFijo plazo = getPlazo(idPlazo);
            if (caja.saldo < plazo.monto)
            {
                // imprimir por pantalla que No hay saldo suficiente
                MessageBox.Show("No hay saldo suficiente");

            }
            if (plazo.FechaFin > DateTime.Now)
            {
                MessageBox.Show("El plazo no ha vencido");
            }
            if (plazo.FechaFin >= DateTime.Now && plazo.pagado == false)
            {
                caja.saldo -= plazo.monto;
                this.altaMovimiento(caja, "Pago de plazo fijo", plazo.monto, DateTime.Now);
                plazo.pagado = true;
                contexto.Update(caja);
                contexto.Update(plazo);
                contexto.SaveChanges();
                MessageBox.Show("Pago realizado con exito");
            }
            else if (plazo.FechaFin >= DateTime.Now && plazo.pagado == true)
            {
                MessageBox.Show("El plazo ya fue pagado");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }


        //Mostrar datos

        // Memory
        //public List<Usuario> obtenerUsuarios()
        //{
        //    return userList.ToList();
        //}
        // Entity
        public List<Usuario> obtenerUsuarios()
        {
            return contexto.usuarios.ToList();
        }

        public List<CajaAhorro> obtenerCajas()
        {
            return contexto.cajas.ToList();
        }
        

        public List<PlazoFijo> obtenerPlazoFijo()
        {
            return contexto.plazos.ToList();
        }

        public List<Pago> obtenerPago()
        {
            return contexto.pagos.ToList();
        }

        public List<Movimiento> obtenerMovimientos(int Cbu)
        {
            CajaAhorro caja = getCaja(Cbu);
            return caja.movimientos.ToList();
        }

        public List<TarjetaCredito> obtenerTarjeta()
        {
            return contexto.tarjetas.ToList();
        }

        public List<CajaAhorro> obtenerCajasDelUsuario()
        {
            return this.usuarioActual.listaCajas.ToList();
        }
        public List<PlazoFijo> obtenerPlazosDelUsuario()
        {
            return this.usuarioActual.plazoFijo.ToList();
        }
        public List<TarjetaCredito> obtenerTarjetasDelUsuario()
        {
            return this.usuarioActual.tarjetas.ToList();
        }
        public List<Pago> obtenerPagosDelUsuario()
        {
            return this.usuarioActual.pagos.ToList();
        }

        //Getters
        public CajaAhorro getCaja(int cbu)
        {
            return contexto.cajas.Where(caja => caja.cbu == cbu).FirstOrDefault();
        }

        public Usuario getUsuario(int dni)
        {
            return contexto.usuarios.Where(usuario => usuario.dni == dni).FirstOrDefault();
        }

        public PlazoFijo getPlazo(int id)
        {
            return contexto.plazos.Where(plazo => plazo.id == id).FirstOrDefault();
        }

        public Pago getPago(int id)// int id
        {
            return contexto.pagos.Where(pago => pago.id == id).FirstOrDefault();
        }

        public TarjetaCredito getTarjeta(int numero)// int id
        {
            return contexto.tarjetas.Where(tarjeta => tarjeta.numero == numero).FirstOrDefault();
        }

    }
}
