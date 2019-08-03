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
    /// Lógica de interacción para ventanaListadoClientes.xaml
    /// </summary>
    public partial class ventanaListadoClientes : Window
    {
        SkyFitnessBDDataContext dataContextSky;
        SqlConnection conexion;
        public ventanaListadoClientes()
        {
            InitializeComponent();
            conexion = new SqlConnection("Data Source = ABELCONSUEGRA; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(conexion);
            MostrarClientes();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void MostrarClientes()
        {
            try
            {                
                Cliente cliente = new Cliente();

                var clientes = from cl in dataContextSky.Cliente
                               orderby cl.nombre ascending
                                select cl;



                dgListadoClientes.ItemsSource = dataContextSky.Cliente;                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }        
        
    }
}
