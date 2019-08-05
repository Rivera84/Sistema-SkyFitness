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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace Sky_Fitness
{
    /// <summary>
    /// Lógica de interacción para ventanaReporte.xaml
    /// </summary>
    public partial class ventanaReporte : UserControl
    {

        public ventanaReporte()
        {
            InitializeComponent();
        }

        private void BtnVenta_Click(object sender, RoutedEventArgs e)
        {
            ventanaPago ventanaPago = new ventanaPago();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Hide();
            ventanaPago.Show();
        }

        private void BtnNuevaInscripcion_Click(object sender, RoutedEventArgs e)
        {
            nuevoTipoInscripcion ventanaTipoInscripcion = new nuevoTipoInscripcion();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Hide();
            ventanaTipoInscripcion.Show();
        }

        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {
            ventanaListadoClientes listaClientes = new ventanaListadoClientes();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Hide();            
            listaClientes.Show();
        }

        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {
            vInventario inventario = new vInventario();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Hide();
            inventario.Show();
        }

        private void BtnReportesIncripcion_Click(object sender, RoutedEventArgs e)
        {
            ventanaReporteInscripciones vri = new ventanaReporteInscripciones();
            vri.Show();
        }        

        private void BtnListaTiposInscripciones_Click(object sender, RoutedEventArgs e)
        {
            ventanaListaTiposInscripciones vlti = new ventanaListaTiposInscripciones();
            vlti.Show();
        }

        private void BtnReporteVenta_Click(object sender, RoutedEventArgs e)
        {
            ventanaReporteVentas vrv = new ventanaReporteVentas();
            vrv.Show();
        }        
    }
}
