using Microsoft.VisualBasic.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TrabajoPlataformas
{
    public class Banco 
    {
        public List<Usuario> userList;
        public List<CajaAhorro> cajasList;
        public List<PlazoFijo> plazosFijos { get; }
        public List<Pago> pagos { get; }
        public List<Movimiento> movimientos { get; }
        public List<TarjetaCredito> tarjetas { get; }

        public Usuario usuarioActual;
        public CajaAhorro caja;
        
        public List <CajaAhorro> obtenerCajasDelUsuario()
        {
            //foreach (Usuario u in this.userList)
            //{
            //    if(u.dni == Dni)
            //    {
            //        return u.listaCajas.ToList();
            //    }
            //}
            //return null
            //return cajasList.Where(x => x.titulares.Contains(this.usuarioActual)).ToList(); 
            return this.usuarioActual.listaCajas.ToList(); 

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
        
        public bool bajaUsuario(int id)
        {
            Usuario aEliminar = userList[id];
            try
            {
                userList[id] = null;
                return true;
            }
            catch (Exception)
            {
                userList[id] = aEliminar;
                return false;
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

        public void altaCaja(CajaAhorro caja)
        {
            cajasList.Add(caja);
            //this.usuarioActual.listaCajas.Add(caja);
        }

        public bool crearCajaAhorro(int cbu2, float saldo)
        {
            if (this.cajasList.Any(caja => caja.cbu == cbu2))
            {
                MessageBox.Show("El CBU ya existe", "Ingreso");
            }
            CajaAhorro cajaNueva = new CajaAhorro(cbu2, this.usuarioActual);
            this.usuarioActual.listaCajas.Add(cajaNueva);
            cajaNueva.saldo = saldo;
            try
            {
                altaCaja(cajaNueva);
                Trace.WriteLine(cajaNueva);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public bool bajaCaja(int cbu)
        {
            CajaAhorro caja = cajasList[cbu];
            try
            {
                caja = null;
                return true;
            }
            catch (Exception)
            {             
                return false;
            }
        }

        public bool modificarCaja(int cbu, Usuario usuario)
        {
            CajaAhorro aModificar = cajasList[cbu];
            try
            {
                CajaAhorro nuevo = new CajaAhorro(cbu, this.usuarioActual);
                cajasList[cbu] = nuevo;
                return true;
            }
            catch (Exception)
            {
                cajasList[cbu] = aModificar;
                return false;
            }
        }

        //ABM Plazo Fijo

        public bool altaPlazo(Usuario titular, float monto, DateTime fechaIni, DateTime fechaFin, float tasa, bool pagado)
        {
            try
            {
                PlazoFijo nuevo = new PlazoFijo(titular, monto, fechaIni, fechaFin, tasa, pagado);
                plazosFijos.Add(nuevo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool bajaPlazo(int id)
        {
            PlazoFijo aEliminar = plazosFijos[id];
            try
            {
                plazosFijos[id] = null;
                return true;
            }
            catch (Exception)
            {
                plazosFijos[id] = aEliminar;
                return false;
            }
        }

        public bool modificarPlazo(int id, Usuario titular, float monto, DateTime fechaIni, DateTime fechaFin, float tasa, bool pagado)
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
        }

        //ABM Pagos

        public bool altaPago(Usuario usuario, float monto, bool pagado)
        {
            try
            {
                Pago nuevo = new Pago(usuario, monto, pagado);
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

        public bool bajaMovimiento(int id)
        {
            Movimiento aEliminar = movimientos[id];
            try
            {
                movimientos[id] = null;
                return true;
            }
            catch (Exception)
            {
                movimientos[id] = aEliminar;
                return false;
            }
        }

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

        public bool bajaTarjeta(int id)
        {
            TarjetaCredito aEliminar = tarjetas[id];
            try
            {
                tarjetas[id] = null;
                return true;
            }
            catch (Exception)
            {
                tarjetas[id] = aEliminar;
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
                                if (user.nombre.Equals(usuario) && user.contra.Equals(pass) && !user.bloqueado) { 
                                this.usuarioActual = user;
                                //usuarioActual.listaCajas = new List<CajaAhorro>(cajasList) ; 
                                encontrar = true;
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
                                // ELSE DE SI EL USUARIO ESTÁ BLOQUEADO. QUE PASA ACA?
                    }
            return encontrar;
        }

        public bool cerrarSesion()
        {
            usuarioActual = null;
            return true;
        }

    
        public Movimiento depositar(CajaAhorro caja, float monto)
        {
            if (monto <= 0)
            {
                throw new ApplicationException("Monto invalido");
            }
            caja.saldo += monto;
            Movimiento mov = new Movimiento(caja, "Deposito", monto, DateTime.Now);
            return mov;
            MessageBox.Show("Se ha depositado " + monto);
        }

        public Movimiento retirar(CajaAhorro caja, float monto)
        {
            if (monto > caja.saldo)
            {
                throw new ApplicationException("Saldo insuficiente");
            }
            caja.saldo -= monto;
            Movimiento mov = new Movimiento(caja, "Retiro", monto, DateTime.Now);
            return mov;
             MessageBox.Show("Se ha retirado " + monto);
            // Mensaje de respuesta con datos del objeto
        }

        public Movimiento transferir(CajaAhorro origen, CajaAhorro destino, float monto)
        {
            if (monto <= 0)
            {
                throw new ApplicationException("Monto invalido");
            }
            origen.saldo -= monto;
            destino.saldo += monto;
            Movimiento movOrigen = new Movimiento(origen, "Transferencia", monto, DateTime.Now);
            Movimiento movDestino = new Movimiento(destino, "Transferencia", monto, DateTime.Now);
            
            return movOrigen;
            MessageBox.Show("Se ha transferido " + monto);
        }

        /*public List<Movimiento> buscarMovimiento(CajaAhorro caja, string detalle, DateTime fecha, float monto)
        {
            // Devuelve una lista de movimientos de la caja de ahorro filtrada por al menos uno de
            // los parámetros(el usuario puede ingresar los 3 parámetros, 2 o 1) Detalle, Fecha y Monto.           
            List<Movimiento> filtrado = new List<Movimiento>();
            
        }*/

        public Movimiento pagarTarjeta(TarjetaCredito tarjeta, CajaAhorro caja)
        {
            if (tarjeta.consumos > caja.saldo)
            {
                throw new ApplicationException("Saldo en caja insuficiente");
            }
            caja.saldo -= tarjeta.consumos;
            Movimiento mov = new Movimiento(caja, "Pago de tarjeta", tarjeta.consumos, DateTime.Now);
            return mov;
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
