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
                                    where c.contrasena == contraseñaActual
                                    select c;

                        foreach (Usuario c in query)
                        {
                            c.contrasena =contraseñaNueva;
                        }
                        dataContextSky.SubmitChanges();
                    }
                    MessageBox.Show("Se ha actualizado contraseña");
                    limpiar();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


       private  void limpiar()
        {
            txtContraseñaActual.Clear();
            txtNuevaContraseña.Clear();
            txtRepetirContraseña.Clear();
        }
    }
}
