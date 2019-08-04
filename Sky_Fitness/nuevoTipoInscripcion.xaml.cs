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
using System.Data.SqlClient;

namespace Sky_Fitness
{
    /// <summary>
    /// Lógica de interacción para nuevoTipoInscripcion.xaml
    /// </summary>
    public partial class nuevoTipoInscripcion : Window
    {
        SkyFitnessBDDataContext dataContextSky;
        public nuevoTipoInscripcion()
        {
            SqlConnection conexion = new SqlConnection("Data Source = ABELCONSUEGRA; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(conexion);
            InitializeComponent();
        }

        private void insertarInscripcion()
        {
            Inscripcion inscripcion = new Inscripcion();
            inscripcion.nombreInscripcion = txtInscripcion.Text;
            inscripcion.precioInscripcion = Convert.ToInt32(txtPrecioInscripcion.Text);

            dataContextSky.Inscripcion.InsertOnSubmit(inscripcion);
            dataContextSky.SubmitChanges();

            MessageBox.Show("La inscripción se ha agregado con éxito");

        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            insertarInscripcion();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
