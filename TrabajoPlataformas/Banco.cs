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
        private List<Usuario> userList;
        private List<CajaAhorro> cajasList;
        private List<PlazoFijo> plazosFijos;
        private List<Pago> pagos;
        private List<Pago> pagosPendientes;
        private List<Pago> pagosRealizados;
        private List<Movimiento> movimientos;
        private List<TarjetaCredito> tarjetas;

        public Usuario usuarioActual;
        //private CajaAhorro caja;
        private Contexto contexto;
        
        public List <CajaAhorro> obtenerCajasDelUsuario()
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
        public Banco()
        {
            inicializarAtributos();
            userList = new List<Usuario>();
            cajasList = new List<CajaAhorro>();
            plazosFijos = new List<PlazoFijo>();
            pagos = new List<Pago>();
            movimientos = new List<Movimiento>();
            tarjetas = new List<TarjetaCredito>();
        }
        private void inicializarAtributos()
        {
            try
            {
                contexto = new Contexto();
                contexto.usuarios.Include(u => u.listaCajas).Load();
                contexto.cajas.Include(p => p.titulares).Load();
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

        //CORREGIR LOS PARAMETROS DE LOS ABM, VER EN LA CONSIGA CUALES SON

        //ABM Usuario
        public bool altaUsuario(int dni, string nombre, string apellido, string mail, string contra, bool bloqueado, bool admin)
        {
            try
            {
                Usuario nuevo = new Usuario(nombre, apellido, dni, mail, contra, bloqueado, admin);
                //userList.Add(nuevo);
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
            {
                bool elimine = false;
                int i = 0;
                while (!elimine && i < userList.Count)
                {
                    if (userList[i].id == id)
                    {
                        //userList.RemoveAt(i);
                        contexto.usuarios.Remove(userList[i]);
                        contexto.SaveChanges();
                        elimine = true;
                    }
                    i++;
                }
                return elimine;
            }
        }

        //public bool modificarUsuario(int id, int dni, string nombre, string mail, string apellido, string contra, bool bloqueado)
        //{
        //    Usuario aModificar = this.userList.Find(x => x.dni == id);
        //    try
        //    {
        //        Usuario nuevo = new Usuario(nombre, apellido, dni, mail, contra, bloqueado);             
        //        userList[id] = nuevo;
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        userList[id] = aModificar;
        //        return false;
        //    }
        //}
        //public bool modificarUsuario(Usuario u)
        //{
        //    Usuario aModificar = this.userList.Find(x => x.dni == u.dni);
        //    try
        //    {
        //        Usuario nuevo = new Usuario(u.nombre, u.apellido, u.dni, u.mail, u.contra, u.bloqueado);
        //        userList[u.dni] = nuevo;
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        userList[u.dni] = aModificar;
        //        return false;
        //    }
        //}
        //public bool modificarUsuario(Usuario u)
        //{
        //    bool modifique = false;
        //    int i = 0;
        //    while (!modifique && i < userList.Count)
        //    {
        //        if (userList[i].dni == u.dni)
        //        {
        //            userList[i] = u;
        //            modifique = true;
        //        }
        //        i++;
        //    }
        //    return modifique;
        //}

        //ABM Caja de Ahorro
        public CajaAhorro getCaja(int cbu)
        {
            return cajasList.FirstOrDefault(x => x.cbu == cbu);
        }

        public Usuario getUsuario(int dni)
        {
            return userList.FirstOrDefault(x => x.dni == dni);
        }

        public PlazoFijo getPlazo(int id)
        {
            return plazosFijos.FirstOrDefault(x => x.id == id);
        }

        public Pago getPago(string detalle)// int id
        {
            return pagos.FirstOrDefault(x => x.detalle == detalle);
        }

        public TarjetaCredito getTarjeta(int numero)// int id
        {
            return tarjetas.FirstOrDefault(x => x.numero == numero);
        }

        public int crearCajaAhorro(int cbu2, float saldo, Usuario usuario)
        {
            if (this.cajasList.Any(caja => caja.cbu == cbu2))
            {
                return 1; // CBU ya existe
            }
            CajaAhorro cajaNueva = new CajaAhorro(cbu2, usuario);
            cajaNueva.saldo = saldo;
            //this.usuarioActual.agregarCaja(cajaNueva);
            cajaNueva.usuario.agregarCaja(cajaNueva);
            contexto.Update(cajaNueva.usuario);
            contexto.cajas.Add(cajaNueva);
            contexto.SaveChanges();
            //this.cajasList.Add(cajaNueva);
            try
            {
                Trace.WriteLine(cajaNueva);
                return 2;
            }
            catch (Exception)
            {
                return 3;
            }

        }


        public int bajaCaja(int cbuCaja)
        {   

            CajaAhorro cajaToRemove = this.getCaja(cbuCaja);
            if (cajaToRemove.saldo > 0)
            {
            //si la caja tiene saldo no se puede eliminar
                return 1;
            }
            else if (cajaToRemove != null) // si la caja existe
            {
                //this.cajasList.Remove(cajaToRemove);
                
                //usuarioActual.eliminarCaja(cajaToRemove);
                contexto.cajas.Remove(cajaToRemove);
                contexto.SaveChanges();
                return 2;
             }
              else return 3;
            
            
        }

        /*public bool modificarCaja(int cbu, Usuario usuario)
        {
            CajaAhorro aModificar = cajasList[id];
            try
            {
                CajaAhorro nuevo = new CajaAhorro(cbu, this.usuarioActual);
                cajasList[id] = nuevo;
                return true;
            }
            catch (Exception)
            {
                cajasList[id] = aModificar;
                return false;
            }
        }*/

        //ABM Plazo Fijo

        public bool altaPlazo(Usuario titular, int cbu , float monto, DateTime fechaIni, DateTime fechaFin, float tasa, bool pagado) // ESTA BIEN ESTO? PROFE
        {
            try
            {
                CajaAhorro caja = this.getCaja(cbu);
                PlazoFijo nuevo = new PlazoFijo(titular, caja ,monto, fechaIni, fechaFin, tasa, pagado);
                //this.plazosFijos.Add(nuevo);
                nuevo.titular.agregarPlazo(nuevo);
                contexto.Update(nuevo.titular);
                contexto.plazos.Add(nuevo);
                contexto.SaveChanges();
                
                //this.usuarioActual.agregarPlazo(nuevo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool bajaPlazo(int id)
        {

            PlazoFijo plazoToRemove = this.getPlazo(id);
            try
            {
                if (plazoToRemove != null)
                    //this.plazosFijos.Remove(plazoToRemove);
                    //this.usuarioActual.eliminarPlazo(plazoToRemove);
                    plazoToRemove.titular.eliminarPlazo(plazoToRemove);
                    contexto.Update(plazoToRemove.titular);
                    contexto.plazos.Remove(plazoToRemove);
                    contexto.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        //NO IMPLEMENTAR, NO SE PUEDEN MODIFICAR PLAZOS
        /*public bool modificarPlazo(int id, Usuario titular, float monto, DateTime fechaIni, DateTime fechaFin, float tasa, bool pagado)
        {
            PlazoFijo aModificar = plazosFijos[id];
            try
            {
                PlazoFijo nuevo = new PlazoFijo(titular, monto, fechaIni, fechaFin, tasa, pagado);
                plazosFijos[id] = nuevo;
                return true;
            }
            catch (Exception)
            {
                plazosFijos[id] = aModificar;
                return false;
            }
        }*/

        //ABM Pagos

        public bool altaPago(Usuario usuario, float monto, bool pagado, string detalle)
        {
            try
            {
                Pago nuevo = new Pago(usuario, monto, pagado, detalle);
                //pagos.Add(nuevo);
                //this.usuarioActual.agregarPago(nuevo);
                nuevo.usuario.agregarPago(nuevo);
                contexto.Update(nuevo.usuario);
                contexto.pagos.Add(nuevo);
                contexto.SaveChanges();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool bajaPago(string detalle)
        {
            // Solo se puede hacer si el pago esta hecho
            Pago pagoToRemove = this.getPago(detalle);
            try
            {
                if (pagoToRemove != null)
                pagoToRemove.usuario.eliminarPago(pagoToRemove);
                contexto.Update(pagoToRemove.usuario);
                contexto.pagos.Remove(pagoToRemove);
                contexto.SaveChanges();
                
                return true;
            }
            catch (Exception)
            {               
                return false;
            }
        }

        /*public bool modificarPago(int id, Usuario usuario, float monto, bool pagado)
        {
            Pago aModificar = pagos[id];
            try
            {
                Pago nuevo = new Pago(usuario, monto, pagado);
                pagos[id] = nuevo;
                return true;
            }
            catch (Exception)
            {
                pagos[id] = aModificar;
                return false;
            }
        }*/

        //ABM Movimientos

        public bool altaMovimiento(CajaAhorro caja, string detalle, float monto, DateTime fecha)
        {
            try
            {
                Movimiento nuevo = new Movimiento(caja, detalle, monto, fecha);
                //this.movimientos.Add(nuevo);
                //caja.movimientos.Add(nuevo);
                contexto.movimientos.Add(nuevo);
                contexto.SaveChanges();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*public bool bajaMovimiento(Movimiento mov)
        {
            Movimiento movToRemove = this.movimientos.First(x => x.detalle == mov.detalle);
            try
            {
                if (movToRemove != null)
                    usuarioActual.movimientos.Remove(movToRemove);
                return true;
            }
            catch
            {
                return false;
            }
        }*/

        //public bool modificarMovimiento(int id, CajaAhorro caja, string detalle, float monto, DateTime fecha)
        //{
        //    Movimiento aModificar = movimientos[id];
        //    try
        //    {
        //        Movimiento nuevo = new Movimiento(caja, detalle, monto, fecha);
        //        movimientos[id] = nuevo;
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        movimientos[id] = aModificar;
        //        return false;
        //    }
        //}

        //ABM Tarjetas

        public bool altaTarjeta(Usuario titular, int numero, int codigoSeguridad, float limite, float consumos)
        {
            try
            {
                TarjetaCredito nuevo = new TarjetaCredito(titular, numero, codigoSeguridad, limite, consumos);
                //tarjetas.Add(nuevo);
                //this.usuarioActual.agregarTarjeta(nuevo);
                nuevo.titular.agregarTarjeta(nuevo);
                contexto.Update(nuevo.titular);
                contexto.tarjetas.Add(nuevo);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool bajaTarjeta(TarjetaCredito tarjeta)
        {
            TarjetaCredito tarjetaToRemove = this.tarjetas.First(x => x.numero == tarjeta.numero);
            try
            {
                if (tarjetaToRemove != null)
                {
                    
                
                    //    tarjetas.Remove(tarjetaToRemove);
                    //usuarioActual.tarjetas.Remove(tarjetaToRemove);
                    tarjetaToRemove.titular.eliminarTarjeta(tarjetaToRemove);
                contexto.Update(tarjetaToRemove.titular);
                contexto.tarjetas.Remove(tarjetaToRemove);
                contexto.SaveChanges();
                


                return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool modificarTarjeta(int id, Usuario titular, int numero, int codigoSeguridad, float limite, float consumos)
        {
            TarjetaCredito aModificar = tarjetas[id];
            try
            {
                TarjetaCredito nuevo = new TarjetaCredito(titular, numero, codigoSeguridad, limite, consumos);
                tarjetas[id] = nuevo;
                
                return true;
            }
            catch (Exception)
            {
                tarjetas[id] = aModificar;
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
                if (user.contraseña == contraseña)
                {
                    this.usuarioActual = user;
                    return true;
                }
                else if (user.contraseña != contraseña)
                {
                    user.intentosFallidos++;
                    contexto.Update(user);
                    contexto.SaveChanges();
                    return false
                    if (user.intentosFallidos >= 3)
                    {
                        user.bloqueado = true;
                        contexto.Update(user);
                        contexto.SaveChanges();
                        return false;
                    }
                }
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
            this.altaMovimiento(origen, "Transferencia enviada ", monto, DateTime.Now);
            destino.saldo += monto;
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
            caja.agregarTitular(nuevoTitular);
            nuevoTitular.agregarCaja(caja);
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
            caja.eliminarTitular(usuario);
            usuario.eliminarCaja(caja);
            contexto.SaveChanges();
            return 3;
        }

        public bool pagarTarjeta(TarjetaCredito tarjeta, CajaAhorro caja)
        {
            if (tarjeta.consumos > caja.saldo)
            {
                return false;
            }
            else
            {
                caja.saldo -= tarjeta.consumos;
                this.altaMovimiento(caja, "Pago de tarjeta", tarjeta.consumos, DateTime.Now);
                contexto.SaveChanges();
                return true;
            }
            
        }

        public bool realizarPagoCaja(int cbuCaja, string detalle) // ID
        {
            CajaAhorro caja = getCaja(cbuCaja);
            Pago pago = getPago(detalle);
            if (caja.saldo < pago.monto)
            {
                return false;
            } else
            {
                pago.pagado = true;
                this.retirar(cbuCaja, pago.monto);
                contexto.SaveChanges();
                return true;
            }
        }

        public bool realizarPagoTarjeta(int numeroTarjeta , string detalle) //ID 
        {
            TarjetaCredito tarjeta = getTarjeta(numeroTarjeta);
            Pago pago = getPago(detalle);
            if (tarjeta.limite < pago.monto)
            {
                return false;
            }
            else
            {
                pago.pagado = true;
                tarjeta.consumos += pago.monto;
                contexto.SaveChanges();
                return true;
            }
        }

        //Mostrar datos

        public List<Usuario> obtenerUsuarios()
        {
            return userList.ToList();
        }

        public List<CajaAhorro> obtenerCajas()
        {
            return cajasList.ToList();
        }

        public List<PlazoFijo> obtenerPlazoFijo()
        {
            return plazosFijos.ToList();
        }

        public List<Pago> obtenerPago()
        {
            return pagos.ToList();
        }

        public List<Movimiento> obtenerMovimientos(int Cbu)
        {
            // brings all the user.movements
            CajaAhorro caja = getCaja(Cbu);
            return caja.movimientos.ToList();
        }

        public List<TarjetaCredito> obtenerTarjeta()
        {
            return tarjetas.ToList();
        }

    }
}
