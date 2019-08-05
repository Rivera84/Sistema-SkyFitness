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
    /// Lógica de interacción para vInventario.xaml
    /// </summary>
    public partial class vInventario : Window
    {
        SkyFitnessBDDataContext dataContextSky;
        public vInventario()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection("Data Source = ABELCONSUEGRA; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(conexion);
            MostrarProductos();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void MostrarProductos()
        {
            try
            {
                Producto producto = new Producto();

                var productos = from prod in dataContextSky.Producto
                                select new {IdProducto =prod.idProducto,Producto= prod.nombreProducto,Pecio = prod.precioProducto,Existencia= prod.existencia };

                dgInventario.ItemsSource = productos.ToList();                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var buscarProducto = from prod in dataContextSky.Producto
                                   where prod.nombreProducto.Contains(txtNombre.Text)
                                   select new { IdProducto = prod.idProducto, Producto = prod.nombreProducto, Pecio = prod.precioProducto, Existencia = prod.existencia };
                dgInventario.ItemsSource = buscarProducto.ToList();

            }
            catch (Exception)
            {
                MessageBox.Show("No se ha encontrado producto");
            }
        }

        //public void MostrarProductos()
        //{
        //    //var productos = from prod in dataContextSky.Producto
        //                    //select prod;
        //    List<Producto> inventario = new List<Producto>();

        //    Producto2 producto = new Producto2();

        //    foreach (var producto2 in dataContextSky.Producto)
        //    {
        //        producto.idproducto = producto2.idProducto;
        //        producto.NombreProducto = producto2.nombreProducto;
        //        producto.Precio = Convert.ToDecimal(producto2.precioProducto);
        //        producto.Existencia = Convert.ToInt32(producto2.existencia);

        //        inventario.Add(producto2);
        //    }
        //    lbInventario.ItemsSource = inventario;
        //}

    }
    public class Producto2
    {
        public int idproducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }        
    }
}
