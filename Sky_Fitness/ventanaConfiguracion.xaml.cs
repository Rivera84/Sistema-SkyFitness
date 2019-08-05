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
    /// Lógica de interacción para ventanaConfiguracion.xaml
    /// </summary>
    public partial class ventanaConfiguracion : Window
    {
        Seguridad seguridad = new Seguridad(); 
        private string contraseñaActual;
        private string contraseñaNueva;
        SkyFitnessBDDataContext dataContextSky;
        public ventanaConfiguracion()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection("Data Source = LAPTOP-H5OOPDVV\\SQLEXPRESS; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(conexion);
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            contraseñaNueva = seguridad.Encripta(txtNuevaContraseña.Password);
            contraseñaActual = seguridad.Encripta(txtContraseñaActual.Password);
            try
            {
                Usuario user = new Usuario();
                int validar = dataContextSky.Usuario.Where(t => t.contrasena == contraseñaActual).Count();
                if (validar > 0)
                {
                    if (txtNuevaContraseña.Password == txtRepetirContraseña.Password)
                    {
                        var query = from c in dataContextSky.Usuario
                                    where c.contrasena == txtContraseñaActual.Password
                                    select c;

                        foreach (Usuario c in query)
                        {
                            c.contrasena =seguridad.Encripta(txtContraseñaActual.Password);

                            dataContextSky.SubmitChanges();
                            MessageBox.Show("Se ha actualizado contraseña");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Los campos de la contraseña nueva no coinciden");
                        txtNuevaContraseña.Focus();
                    }
                   
                }
                else
                {
                    MessageBox.Show("Contraseña actual incorrecta");
                    txtContraseñaActual.Focus();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        //private void ValidarLogin()
        //{
        //    Usuario usuario = new Usuario();
        //    MainWindow inicio = new MainWindow();

        //    // sirve para validar si existe el usuario y contraseña en la base de datos, sintaxis lambda
        //    int validar = dataContextSky.Usuario.Where(t => t.nombreUsuario == txtUsuario.Text && t.contrasena == txtContrasena.Password).Count();
        //    if (validar > 0)
        //    {
        //        inicio.Show();
        //        this.Close();
        //    }
        //    else if (txtUsuario.Text == string.Empty || txtContrasena.Password == string.Empty)
        //    {
        //        MessageBox.Show("Debe ingresar un usuario y una contraseña \nIntente nuevamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        txtUsuario.Focus();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Usuario o contraseña incorrectos. \nIntente nuevamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //}
    }
}
