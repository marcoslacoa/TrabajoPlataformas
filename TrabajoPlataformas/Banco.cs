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
        private List<Movimiento> movimientos;
        private List<TarjetaCredito> tarjetas;

        public Usuario usuarioActual;
        //private CajaAhorro caja;
        
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
            userList = new List<Usuario>();
            cajasList = new List<CajaAhorro>();
            plazosFijos = new List<PlazoFijo>();
            pagos = new List<Pago>();
            movimientos = new List<Movimiento>();
            tarjetas = new List<TarjetaCredito>();
        }

        //CORREGIR LOS PARAMETROS DE LOS ABM, VER EN LA CONSIGA CUALES SON

        //ABM Usuario
        public bool altaUsuario(int dni, string nombre, string apellido, string mail, string contra, bool bloqueado)
        {
            try
            {
                Usuario nuevo = new Usuario(nombre, apellido, dni, mail, contra, bloqueado);
                userList.Add(nuevo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public bool bajaUsuario(int dni)
        {
            {
                bool elimine = false;
                int i = 0;
                while (!elimine && i < userList.Count)
                {
                    if (userList[i].dni == dni)
                    {
                        userList.RemoveAt(i);
                        elimine = true;
                    }
                    i++;
                }
                return elimine;
            }
        }

        public bool modificarUsuario(int id, int dni, string nombre, string mail, string apellido, string contra, bool bloqueado)
        {
            Usuario aModificar = userList[id];
            try
            {
                Usuario nuevo = new Usuario(nombre, apellido, dni, mail, contra, bloqueado);
                userList[id] = nuevo;
                return true;
            }
            catch (Exception)
            {
                userList[id] = aModificar;
                return false;
            }
        }

        //ABM Caja de Ahorro
        public CajaAhorro getCaja(int cbu)
        {
            return cajasList.FirstOrDefault(x => x.cbu == cbu);
        }
       
        
        public int crearCajaAhorro(int cbu2, float saldo, Usuario usuario)
        {
            if (this.cajasList.Any(caja => caja.cbu == cbu2))
            {
                return 1; // CBU ya existe
            }
            CajaAhorro cajaNueva = new CajaAhorro(cbu2, usuario);
            cajaNueva.saldo = saldo;
            this.usuarioActual.agregarCaja(cajaNueva);
            this.cajasList.Add(cajaNueva);
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
                this.cajasList.Remove(cajaToRemove);
                
                usuarioActual.eliminarCaja(cajaToRemove); // 
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

        public bool altaPlazo(Usuario titular, CajaAhorro caja , float monto, DateTime fechaIni, DateTimePicker fechaFin, float tasa, bool pagado)
        {
            try
            {
                PlazoFijo nuevo = new PlazoFijo(titular, caja ,monto, fechaIni, fechaFin, tasa, pagado);
                plazosFijos.Add(nuevo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool bajaPlazo(PlazoFijo plazo)
        {
            PlazoFijo plazaToRemove = this.plazosFijos.First(x => x.titular == plazo.titular);
            try
            {
                if (plazaToRemove != null)
                    usuarioActual.plazoFijo.Remove(plazaToRemove);
                return true;
            }
            catch
            {
                return false;
            }
        }

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
                pagos.Add(nuevo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool bajaPago(int id)
        {
            Pago aEliminar = pagos[id];
            try
            {
                pagos[id] = null;
                return true;
            }
            catch (Exception)
            {
                pagos[id] = aEliminar;
                return false;
            }
        }

        // NO implementar, no está permitido modificar un Plazo Fijo.
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
                movimientos.Add(nuevo);
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

        public bool modificarMovimiento(int id, CajaAhorro caja, string detalle, float monto, DateTime fecha)
        {
            Movimiento aModificar = movimientos[id];
            try
            {
                Movimiento nuevo = new Movimiento(caja, detalle, monto, fecha);
                movimientos[id] = nuevo;
                return true;
            }
            catch (Exception)
            {
                movimientos[id] = aModificar;
                return false;
            }
        }

        //ABM Tarjetas

        public bool altaTarjeta(Usuario titular, int numero, int codigoSeguridad, float limite, float consumos)
        {
            try
            {
                TarjetaCredito nuevo = new TarjetaCredito(titular, numero, codigoSeguridad, limite, consumos);
                tarjetas.Add(nuevo);
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
                    usuarioActual.tarjetas.Remove(tarjetaToRemove);
                return true;
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
            bool encontrar = false;
                    foreach (Usuario user in userList)
                    {
                     //MessageBox.Show(user.getNombre());
                                if (user.nombre.Equals(usuario) && user.contra.Equals(pass) && !user.bloqueado) { 
                                this.usuarioActual = user;
                                //usuarioActual.listaCajas = new List<CajaAhorro>(cajasList) ; 
                                return true;
                                }
                                else if (user.nombre.Equals(usuario) && !user.contra.Equals(pass))
                                {
                                    encontrar = false;
                                    user.intentosFallidos++;
                                    if (user.intentosFallidos > 3)
                                    {
                                        user.bloqueado = true;

                                    }
                                } else
                                {
                                    encontrar = false;
                                }
                                
                    }
            return encontrar;
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
            this.altaMovimiento(origen, "Transferencia", monto, DateTime.Now);
            destino.saldo += monto;
            this.altaMovimiento(destino, "Transferencia", monto, DateTime.Now);
            return 2; // Transferencia exitosa
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

        public List<Movimiento> obtenerMovimiento(int Cbu)
        {
            foreach(CajaAhorro c in usuarioActual.listaCajas)
            {
                if(c.cbu == Cbu)
                {
                    return c.movimientos.ToList();
                }
            }
            return null;
        }

        public List<TarjetaCredito> obtenerTarjeta()
        {
            return tarjetas.ToList();
        }

    }
}
