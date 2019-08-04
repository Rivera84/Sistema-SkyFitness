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
    /// Lógica de interacción para ventanaInscripcion.xaml
    /// </summary>
    public partial class ventanaInscripcion : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source = ABELCONSUEGRA; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
        private DataTable tabla;
        SkyFitnessBDDataContext dataContextSky;
        public ventanaInscripcion()
        {
            InitializeComponent();
            dataContextSky = new SkyFitnessBDDataContext(conexion);
            mostrarCMBInscripcion();
            mostrarCMBProducto();
            cmbTipoAccion.SelectedIndex = 1;
        }

        private void mostrarCMBInscripcion()
        {
            tabla = new DataTable();
            try
            {
                conexion.Open();
                string query = "SELECT * FROM Producto.Inscripcion";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                using (adapter)
                {
                    adapter.Fill(tabla);
                    cmbInscripcion.DisplayMemberPath = "nombreInscripcion";
                    cmbInscripcion.SelectedValuePath = "idInscripcion";
                    cmbInscripcion.ItemsSource = tabla.DefaultView;
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void mostrarCMBProducto()
        {
            tabla = new DataTable();
            try
            {
                conexion.Open();
                string query = "SELECT * FROM Producto.Producto";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                using (adapter)
                {
                    adapter.Fill(tabla);
                    cmbProducto.DisplayMemberPath = "nombreProducto";
                    cmbProducto.SelectedValuePath = "idProducto";
                    cmbProducto.ItemsSource = tabla.DefaultView;
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CmbTipoAccion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            if (cmbTipoAccion.SelectedIndex==1)
            {

                lbTipoInscripcion.Visibility = Visibility.Collapsed;
                cmbInscripcion.Visibility = Visibility.Collapsed;
                lbProducto.Visibility = Visibility.Visible;
                cmbProducto.Visibility = Visibility.Visible;
                lbcantidad.Visibility = Visibility.Visible;
                txtCantidad.Visibility = Visibility.Visible;
                txtidCliente.Clear();
                txtCantidad.Clear();
                cmbInscripcion.SelectedIndex = -1;
                cmbProducto.SelectedIndex = -1;
            }else
            {

                lbTipoInscripcion.Visibility = Visibility.Visible;
                cmbInscripcion.Visibility = Visibility.Visible;
                lbProducto.Visibility = Visibility.Collapsed;
                cmbProducto.Visibility = Visibility.Collapsed;
                lbcantidad.Visibility = Visibility.Collapsed;
                txtCantidad.Visibility = Visibility.Collapsed;
                txtidCliente.Clear();
                txtCantidad.Clear();
                cmbInscripcion.SelectedIndex = -1;
                cmbProducto.SelectedIndex = -1;
            }
        }


        private void pagarProducto()
        {            
            // validar la existencia del producto para proceder la compra   
            var existenciaProducto = dataContextSky.Producto.First(t => t.idProducto == Convert.ToInt32(cmbProducto.SelectedValue)).existencia;
            
            int clienteValido = dataContextSky.Cliente.Where(t => t.numeroIdentidad == txtidCliente.Text).Count();

            if (txtCantidad.Text == String.Empty || txtidCliente.Text == String.Empty || cmbProducto.SelectedIndex == -1)
                MessageBox.Show("Debe ingresar todos los datos");
            else if (Convert.ToInt32(txtCantidad.Text) > existenciaProducto)
                MessageBox.Show("No hay suficientes productos en existencia");
            else if (clienteValido < 1)
            {
                MessageBox.Show("El cliente no existe o no es válido");
                txtidCliente.Focus();
            }
            else
            {
                try
                {
                    Producto producto1 = new Producto();
                    ClienteProducto producto = new ClienteProducto();
                    producto.idCliente = txtidCliente.Text;
                    producto.idProducto = Convert.ToInt32(cmbProducto.SelectedValue);
                    producto.cantidad = Convert.ToInt32(txtCantidad.Text);
                    dataContextSky.ClienteProducto.InsertOnSubmit(producto);
                    dataContextSky.SubmitChanges();

                    var precio = dataContextSky.Producto.First(t => t.idProducto == Convert.ToInt32(cmbProducto.SelectedValue)).precioProducto;
                    var total = (precio * Convert.ToInt32(txtCantidad.Text));
                    var nombreCliente = dataContextSky.Cliente.First(t => t.numeroIdentidad == txtidCliente.Text).nombre;
                    MessageBox.Show("Se ha realizado el pago con éxito " + nombreCliente.ToString() + ". El total a pagar es: L." + Convert.ToDecimal(total.ToString()));

                    try
                    {
                        var resta = (existenciaProducto - Convert.ToInt32(txtCantidad.Text));
                        var query = from c in dataContextSky.Producto
                                    where c.idProducto == Convert.ToInt32(cmbProducto.SelectedValue)
                                    select c;
                        foreach (Producto c in query)
                        {
                            c.existencia = resta;
                        }
                        dataContextSky.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error" + ex);
                    }
                    finally
                    {
                        LimpiarProductos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error" + ex);
                }
            }
            
        }
    

        private void pagarIncripcion()
        {
            try
            {
                ClienteInscripcion inscripcion = new ClienteInscripcion();
                inscripcion.idCliente = txtidCliente.Text;
                inscripcion.idInscripcion = Convert.ToInt32(cmbInscripcion.SelectedValue);
                inscripcion.fechaPago = DateTime.Now;
                inscripcion.fechaFinal = DateTime.Now.AddMonths(1);
              
                dataContextSky.ClienteInscripcion.InsertOnSubmit(inscripcion);
                dataContextSky.SubmitChanges();
                MessageBox.Show("Se a realizado el pago con exito");
            }
            catch (Exception ex )
            {
                MessageBox.Show("ha ocurrido un error"+ ex);
            }
        }

        private void botonPagar(object sender, RoutedEventArgs e)
        {if(cmbTipoAccion.SelectionBoxItem.Equals("Producto") == true)
            {
                pagarProducto();
            }
            else
            {

                pagarIncripcion();
            }
           
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
           
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void LimpiarProductos()
        {
            txtidCliente.Clear();
            txtCantidad.Clear();
            cmbProducto.SelectedIndex = -1;
        }
    }
}
