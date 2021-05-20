
using System.Data;
using MahApps.Metro.Controls.Dialogs;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System;

namespace AlmacenYuyitos
{
    /// <summary>
    /// Lógica de interacción para AgregarUsuario.xaml
    /// </summary>
    public partial class AgregarUsuario
    {
        OracleConnection con = null;
        public AgregarUsuario()
        {
            this.setConnection();
            InitializeComponent();
            ActualizarCargo();
            ActualizarEstado();
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
