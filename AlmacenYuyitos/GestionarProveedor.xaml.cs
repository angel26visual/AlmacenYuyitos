using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AlmacenYuyitos
{
    /// <summary>
    /// Lógica de interacción para GestionarProveedor.xaml
    /// </summary>
    public partial class GestionarProveedor
    {
        public GestionarProveedor()
        {
            InitializeComponent();
        }

        private void btnCerrarSesión_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }

        private void btnVolverAlMenu_Click(object sender, RoutedEventArgs e)
        {
            /*MainWindow mw = new MainWindow();
            mw.Show();*/
            this.Close();
        }

        private void btnAgregarProveedor_Click(object sender, RoutedEventArgs e)
        {
            AgregarProveedor ap = new AgregarProveedor();
            ap.Show();
            this.Close();
        }

        private void btnVisualizarProveedor_Click(object sender, RoutedEventArgs e)
        {
            VisualizarProveedor vp = new VisualizarProveedor();
            vp.Show();
            this.Close();

        }
    }
}
