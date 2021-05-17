using MahApps.Metro.Controls.Dialogs;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System;
using System.Windows;

namespace AlmacenYuyitos
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login
    {
        OracleConnection con = null;
        public Login()
        {
            this.setConnection();
            InitializeComponent();
        }
        private void setConnection()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con = new OracleConnection(connectionString);
            try
            {
                con.Open();
            }
            catch (Exception exp) { }
        }

        private async void btnIniciar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                String sql = 
            }
            catch (Exception) 
            {
                await this.ShowMessageAsync("Error", "No se pudo Iniciar Sesión ");
            }
        }

        private void btnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (LoginFlyout.IsOpen == true)
            {
                LoginFlyout.IsOpen = false;
            }
            else
            {
                LoginFlyout.IsOpen = true;
            }
            
        }

        private void btnRecuperarPass_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private async void AUD(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            switch (state)
            {
                case 0:
                    cmd.Parameters.Add("NOMBRE", OracleDbType.Varchar2, 100).Value = txtUser.Text;
                    break;
                case 1:
                    msg = "Row update successfully";
                    cmd.Parameters.Add("NOMBRE", OracleDbType.Varchar2, 100).Value = txtNombre.Text;
                    cmd.Parameters.Add("TELEFONO", OracleDbType.Varchar2, 20).Value = txtTelefono.Text;
                    cmd.Parameters.Add("ID", OracleDbType.Int32, 20).Value = Convert.ToInt32(txtId.Text);
                    break;
                
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                }
            }
            catch (Exception expe)
            {

            }
        }
    }
}
