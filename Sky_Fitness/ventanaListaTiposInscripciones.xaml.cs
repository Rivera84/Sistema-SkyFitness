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
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace Sky_Fitness
{
    /// <summary>
    /// Lógica de interacción para ventanaListaTiposInscripciones.xaml
    /// </summary>
    public partial class ventanaListaTiposInscripciones : Window
    {
        SkyFitnessBDDataContext dataContextSky;
        SqlConnection conexion;
        public ventanaListaTiposInscripciones()
        {
            InitializeComponent();
            conexion = new SqlConnection("Data Source = ABELCONSUEGRA; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(conexion);
            MostrarTiposInscripciones();
        }

        private void MostrarTiposInscripciones()
        {
            try
            {
                Inscripcion inscripcion = new Inscripcion();

                var inscripciones = (from cl in dataContextSky.Inscripcion
                                    orderby cl.idInscripcion ascending
                                    //cl.idInscripcion, cl.nombreInscripcion, cl.precioInscripcion
                                    select new
                                    {
                                        cl.idInscripcion,
                                        cl.nombreInscripcion,
                                        cl.precioInscripcion
                                    }).ToList();

                dgListadoTipoInscripciones.ItemsSource = inscripciones.ToList();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
