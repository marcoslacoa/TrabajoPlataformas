using Microsoft.VisualBasic.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TrabajoPlataformas
{
    public class Banco
    {
        public List<Usuario> userList { get; }
        public List<CajaAhorro> cajasList { get; }
        public List<PlazoFijo> plazosFijos { get; }
        public List<Pago> pagos { get; }
        public List<Movimiento> movimientos { get; }
        public List<TarjetaCredito> tarjetas { get; }

        public Usuario usuarioActual;

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

        public bool altaCaja(int cbu, float saldo)
        {
            try
            {
                CajaAhorro nuevo = new CajaAhorro(cbu, saldo);
                cajasList.Add(nuevo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool bajaCaja(int id)
        {
            CajaAhorro aEliminar = cajasList[id];
            try
            {
                userList[id] = null;
                return true;
            }
            catch (Exception)
            {
                cajasList[id] = aEliminar;
                return false;
            }
        }

        public bool modificarCaja(int id, int cbu, float saldo)
        {
            CajaAhorro aModificar = cajasList[id];
            try
            {
                CajaAhorro nuevo = new CajaAhorro(cbu, saldo);
                cajasList[id] = nuevo;
                return true;
            }
            catch (Exception)
            {
                cajasList[id] = aModificar;
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
                                if (user.nombre.Equals(usuario) && user.contra.Equals(pass) && !user.bloqueado)
                                    encontrar = true;
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
           // usuarioActual; //Usuario actual pasa a ser nulo
           return true;
        }

        public void crearCajaAhorro()
        {
            // Crea una nueva Caja de Ahorro con los datos ingresados.
        }

        public void depositar(CajaAhorro caja, float monto)
        {
            // Deposita el monto ingresado en la Caja de Ahorro seleccionada.
        }

        public void retirar(CajaAhorro caja, float monto)
        {
            // Retira el monto ingresado en la Caja de Ahorro seleccionada siempre que cuente
            // con saldo suficiente, caso contrario devuelve un error.
        }

        public void transferir(CajaAhorro origen, CajaAhorro destino, float monto)
        {
            // Transfiere el monto indicado de la caja de ahorro seleccionada del usuario actual
            // (origen) a otra caja de ahorro(destino, que puede ser del usuario actual o no), siempre
            // que el saldo de origen sea suficiente para realizar la operación caso contrario genera un error.
        }

        public void buscarMovimiento(CajaAhorro caja, string detalle, DateTime fecha, float monto)
        {
            // Devuelve una lista de movimientos de la caja de ahorro filtrada por al menos uno de
            // los parámetros(el usuario puede ingresar los 3 parámetros, 2 o 1) Detalle, Fecha y Monto.
        }

        public void pagarTarjeta(TarjetaCredito tarjeta, CajaAhorro caja)
        {
            // Descuenta el saldo total de consumos de la
            // tarjeta del saldo de la caja de ahorro(generando el movimiento correspondiente)
            // siempre que el saldo sea suficiente, caso contrario, no permite operar.
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

        public List<Movimiento> obtenerMovimiento()
        {
            return movimientos.ToList();
        }

        public List<TarjetaCredito> obtenerTarjeta()
        {
            return tarjetas.ToList();
        }

    }
}
