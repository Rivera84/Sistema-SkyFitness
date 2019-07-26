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

namespace Sky_Fitness
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void BtnSalirLogin_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)            
                App.Current.Shutdown();           
            else{ }            
        }

        private void Entrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            if (txtUsuario.Text == string.Empty|| txtContrasena.Password == string.Empty)
            {
                MessageBox.Show("Debe ingresar un usuario y una contraseña \nIntente nuevamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUsuario.Focus();
            }
            else if (txtUsuario.Text == "sky" && txtContrasena.Password == "sky")
            {                
                inicio.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. \nIntente nuevamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
