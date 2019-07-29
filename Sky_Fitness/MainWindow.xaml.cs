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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sky_Fitness
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool StateClosed = true;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void estadoMenu()
        {
            if (StateClosed)
            {
                Storyboard sb = this.FindResource("OpenMenu") as Storyboard;
                sb.Begin();
                btnUsuario.IsEnabled = true;
                btnProducto.IsEnabled = true;
                btnReporte.IsEnabled = true;
                btnCerrarSesion.IsEnabled = true;
                btnCliente.IsEnabled = true;
                btnInscripcion.IsEnabled = true;
            }
            else
            {
                Storyboard sb = this.FindResource("CloseMenu") as Storyboard;
                sb.Begin();
                btnUsuario.IsEnabled = false;
                btnProducto.IsEnabled = false;
                btnReporte.IsEnabled = false;
                btnCerrarSesion.IsEnabled = false;
                btnCliente.IsEnabled = false;
                btnInscripcion.IsEnabled = false;
            }
            StateClosed = !StateClosed;
        }


       

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)  //BotonMenu
        {
            estadoMenu();
        }
    


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                App.Current.Shutdown();
            else { }
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea cerrar sesión?", "Cerrar Sesión", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else { }
        }
        //boton Cliente
        private void Cliente(object sender, RoutedEventArgs e)
        {
            estadoMenu();
            ventanaCliente vc = new ventanaCliente();
            GridPrincipal.Children.Add(vc);
        
           


        }

        //Boton Producto
        private void Producto(object sender, RoutedEventArgs e)
        {
            estadoMenu();
        }

        //Boton inscripcion
        private void inscripcion(object sender, RoutedEventArgs e)
        {
            estadoMenu();
        }

        //Boton reporte
        private void Reporte(object sender, RoutedEventArgs e)
        {
            estadoMenu();
        }

        //Boton Usuario
        private void Usuario(object sender, RoutedEventArgs e)
        {
            estadoMenu();
        }
    }
}
