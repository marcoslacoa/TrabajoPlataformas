namespace TrabajoPlataformas
{
    public partial class FormPadre : Form
    {
        private Banco banco;
        Login hijoLogin;
        Register hijoRegister;
        FormMain hijoMain;
        internal string texto;
        string usuario;
        string pass;
        bool logued;
        public bool touched;
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
        private void loginDelegado(string Usuario, string Pass) // DELEGADO PARA INICIAR SESION 
        {
            this.usuario = Usuario;
            this.pass = Pass;
            if (banco.iniciarSesion(usuario, pass))
            {
                MessageBox.Show("Log in correcto, Usuario: " + usuario, "titulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hijoLogin.Close();
                hijoMain = new FormMain(/*new object[] { usuario, banco }*/);
                /* hijoMain.usuario = Usuario;
                hijoMain.MdiParent = this;
                hijoMain.Show();*/
            }
            else
            {
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
            this.hijoLogin = new Login(this.banco);
            this.hijoLogin.MdiParent = this;
            this.hijoLogin.regEvento += registerDelegado;
            this.hijoLogin.loginEvento += loginDelegado;
            hijoLogin.Show();
        }
    }
}