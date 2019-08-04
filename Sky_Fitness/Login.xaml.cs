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
using System.Data;
using System.Data.SqlClient;

namespace Sky_Fitness
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SkyFitnessBDDataContext dataContextSky;
        public Login()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection("Data Source = LAPTOP-H5OOPDVV\\SQLEXPRESS; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(conexion);
        }
        private void BtnSalirLogin_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Entrar_Click(object sender, RoutedEventArgs e)
        {            
            ValidarLogin();
        }

        private void ValidarLogin()
        {
            Usuario usuario = new Usuario();
            MainWindow inicio = new MainWindow();

            // sirve para validar si existe el usuario y contraseña en la base de datos, sintaxis lambda
            int validar = dataContextSky.Usuario.Where(t => t.nombreUsuario == txtUsuario.Text && t.contrasena == txtContrasena.Password).Count();
            if (validar > 0)
            {
                inicio.Show();
                this.Close();
            }
            else if (txtUsuario.Text == string.Empty || txtContrasena.Password == string.Empty)
            {
                MessageBox.Show("Debe ingresar un usuario y una contraseña \nIntente nuevamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUsuario.Focus();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. \nIntente nuevamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
