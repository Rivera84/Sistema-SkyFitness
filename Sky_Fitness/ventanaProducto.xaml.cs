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
    /// Lógica de interacción para ventanaProducto.xaml
    /// </summary>
    public partial class ventanaProducto : UserControl
    {
        SkyFitnessBDDataContext dataContextSky;
        public ventanaProducto()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection("Data Source = ABELCONSUEGRA; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(conexion);
        }

        private void InsertarProducto()
        {
            try
            {
                Producto producto = new Producto();

                producto.nombreProducto = txtNombreProducto.Text;
                producto.precioProducto = Convert.ToDecimal(txtPrecioProducto.Text);
                producto.existencia = Convert.ToInt32(txtCantidad.Text);

                dataContextSky.Producto.InsertOnSubmit(producto);
                dataContextSky.SubmitChanges();

                MessageBox.Show("El producto se ha agregado con éxito");
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            InsertarProducto();
            Limpiar();
        }

        private void Limpiar()
        {
            txtNombreProducto.Clear();
            txtPrecioProducto.Clear();
            txtCantidad.Clear();
            txtNombreProducto.Focus();
        }

        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {
            vInventario vinv = new vInventario();

            vinv.Show();
        }
    }
}
