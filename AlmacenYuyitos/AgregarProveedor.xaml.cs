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
using BibliotecaLosYuyitos;


namespace AlmacenYuyitos
{
    /// <summary>
    /// Lógica de interacción para AgregarProveedor.xaml
    /// </summary>
    public partial class AgregarProveedor
    {
        List<Proveedor> listaProveedor = new List<Proveedor>();
        public AgregarProveedor()
        {
            InitializeComponent();
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            GestionarProveedor gp = new GestionarProveedor();
            gp.Show();
            this.Close();
        }

        private void btnGuardarProveedor_Click(object sender, RoutedEventArgs e)
        {
            Proveedor prov = new Proveedor();
            prov.RutProveedor = txtRutProveedor.Text;
            prov.NombreProveedor = txtNombreProveedor.Text;
            prov.DireccionProveedor = txtDireccionProveedor.Text;
            prov.Telefono1_proveedor = int.Parse(txtFonoProveedorUno.Text);
            prov.Telefono2_proveedor = int.Parse(txtFonoProveedor2.Text);
            prov.NombreServidor = txtNombreServidor.Text;
            prov.TelefonoServidor = int.Parse(txtTelefonoServidor.Text);
            listaProveedor.Add(prov);
            MessageBox.Show("Proveedor Agregado Exitósamente"); 
        }
    }
}
