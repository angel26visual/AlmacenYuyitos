namespace AlmacenYuyitos
{
    /// <summary>
    /// Lógica de interacción para AgregarUsuario.xaml
    /// </summary>
    public partial class AgregarUsuario
    {
        public AgregarUsuario()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GestionarUsuarios gu = new GestionarUsuarios();
            gu.Show();
            this.Close();
        }

        private void btnCerrarSesion_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }
    }
}
