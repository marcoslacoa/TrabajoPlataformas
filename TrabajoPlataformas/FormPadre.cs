using static TrabajoPlataformas.Register;

namespace TrabajoPlataformas
{
    public partial class FormPadre : Form
    {
        private Banco banco;
        Login hijoLogin;
        Register hijoRegister;
        FormMain hijoMain;
        

        internal string texto;
        int dni;
        string pass;
        bool logued;
        public bool touched;
       

        public int intentosFallidos ;

        public FormPadre()
        {
            InitializeComponent();
            this.banco = new Banco();
            this.logued = false;
            this.hijoLogin = new Login(banco);
            this.hijoLogin.logued = false;
            this.hijoLogin.MdiParent = this;
            this.hijoLogin.loginEvento += loginDelegado;
            this.hijoRegister = new Register(banco);
            this.hijoLogin.regEvento += registerDelegado;
            this.hijoRegister.MdiParent = this;
            this.hijoRegister.regBotonEvento += regBotonDelegado;
            this.hijoLogin.Show();
            touched = false;
        }
        private void loginDelegado(int dni, string pass) // DELEGADO PARA INICIAR SESION 
        {
            this.dni = dni;
            this.pass = pass;
           
            if (banco.iniciarSesion(dni, pass))
            {
                MessageBox.Show("Inicio de sesión correcto, Usuario: " + dni, "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hijoMain = new FormMain(this.dni, banco);
                this.hijoMain.cerrarsesionEvento += cerrarsesion;
                hijoMain.dni = this.dni;
                hijoMain.MdiParent = this;
                // Transfevento para cerrar y volver al padre.
                hijoLogin.Hide();
                hijoMain.Show();
            }
            else // osea si dio false el metodo IniciarSesion
            {
                //aca falta preguntar si esta bloqueado
                //foreach (Usuario user in banco.obtenerUsuarios())
                //{
                //    if (user.nombre == this.usuario && user.bloqueado)
                //    {
                //        MessageBox.Show("Se ha bloqueado al usuario " + user.nombre, "titulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                MessageBox.Show("Log in incorrecto", "titulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hijoLogin.Show();
            }
        }
        private void registerDelegado() // Delegado para ir al REGISTER 
        {
            hijoLogin.Close();
            this.hijoRegister = new Register(banco);
            this.hijoRegister.MdiParent = this;
            this.hijoRegister.regBotonEvento += regBotonDelegado;
            hijoRegister.Show();
        }
        private void regBotonDelegado() // DAR DE ALTA UN USUARIO 
        {
            hijoRegister.Close();
            traerLogin();
            hijoLogin.Show();
        }
        private void cerrarsesion()
        {
            banco.cerrarSesion();
            hijoMain.Close();
            traerLogin();
            hijoLogin.Show();
        }
        private void traerLogin()
        {
            this.hijoLogin = new Login(this.banco);
            this.hijoLogin.MdiParent = this;
            this.hijoLogin.regEvento += registerDelegado;
            this.hijoLogin.loginEvento += loginDelegado;
        }

    }
}