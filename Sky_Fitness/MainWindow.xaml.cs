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
        //Clases
        CalculoIMC calculo { get; set; }
        ventanaCliente vc = new ventanaCliente();
        ventanaPago vp = new ventanaPago();
        ventanaInscripcion vi = new ventanaInscripcion();
        ventanaReporte vr = new ventanaReporte();


        bool StateClosed = false;
        public MainWindow()
        {
            InitializeComponent();

            //ventanaCliente vc = new ventanaCliente();
            //calculo = new CalculoIMC { Peso = "1", Estatura = "1" };
            //vc.DataContext = calculo;
        }


        private void estadoMenu()
        {
            if (StateClosed)
            {
                Storyboard sb = this.FindResource("OpenMenu") as Storyboard;
                sb.Begin();
                btnUsuario.IsEnabled = true;
                
                btnReporte.IsEnabled = true;
                btnCerrarSesion.IsEnabled = true;
                btnCliente.IsEnabled = true;
                btnPago.IsEnabled = true;
                vi.mostrarCMBInscripcion();
                vi.mostrarCMBProducto();
                GridPrincipal.Children.Remove(vc);
                GridPrincipal.Children.Remove(vi);
                GridPrincipal.Children.Remove(vr);
            }
            else
            {
                Storyboard sb = this.FindResource("CloseMenu") as Storyboard;
                sb.Begin();
                btnUsuario.IsEnabled = false;
               
                btnReporte.IsEnabled = false;
                btnCerrarSesion.IsEnabled = false;
                btnCliente.IsEnabled = false;
                btnPago.IsEnabled = false;
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
            this.Hide();
            Login login = new Login();
            login.Show();
        }
        //boton Cliente
        private void Cliente(object sender, RoutedEventArgs e)
        {
            estadoMenu();
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
            GridPrincipal.Children.Add(vi);
        }

        //Boton reporte
        private void Reporte(object sender, RoutedEventArgs e)
        {
            estadoMenu();
            GridPrincipal.Children.Add(vr);
        }

        //Boton Usuario
        private void Usuario(object sender, RoutedEventArgs e)
        {
            estadoMenu();
        }
    }
}
