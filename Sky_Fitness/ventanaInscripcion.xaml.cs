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
        private DateTime fechaPago;
        private DateTime fechaFinal;
        private TimeSpan tSpan;
        private int dias;
        public ventanaInscripcion()
        {
            InitializeComponent();
            dataContextSky = new SkyFitnessBDDataContext(conexion);
            mostrarCMBInscripcion();
            mostrarCMBProducto();
            cmbTipoAccion.SelectedIndex = 1;
        }

        public void mostrarCMBInscripcion()
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

        public void mostrarCMBProducto()
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
                    

                    var precio = dataContextSky.Producto.First(t => t.idProducto == Convert.ToInt32(cmbProducto.SelectedValue)).precioProducto;
                    producto.total = (precio * Convert.ToInt32(txtCantidad.Text));

                    dataContextSky.ClienteProducto.InsertOnSubmit(producto);
                    dataContextSky.SubmitChanges();

                    var nombreCliente = dataContextSky.Cliente.First(t => t.numeroIdentidad == txtidCliente.Text).nombre;
                    MessageBox.Show("Se ha realizado el pago con éxito " + nombreCliente.ToString() + ". El total a pagar es: L." + producto.total.ToString());

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
                        Limpiar();
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
            fechaPago = DateTime.Now;
            fechaFinal = DateTime.Now.AddMonths(1);
            tSpan = fechaFinal - fechaPago;
            dias = tSpan.Days;

            int clienteValido = dataContextSky.Cliente.Where(t => t.numeroIdentidad == txtidCliente.Text).Count();
            int ValidarClienteInscrito = dataContextSky.ClienteInscripcion.Where(t => t.idCliente == txtidCliente.Text).Count();
            if (txtidCliente.Text == String.Empty || cmbInscripcion.SelectedIndex == -1)
                MessageBox.Show("Complete todos los campos");
            if (clienteValido < 1)
            {
                MessageBox.Show("El cliente no existe o no es válido");
                txtidCliente.Focus();
            }
            if (ValidarClienteInscrito > 1)
            {
                MessageBox.Show("El cliente ya se encuentra inscrito");
                txtidCliente.Focus();
            }
            else
            {
                try
                {
                    ClienteInscripcion inscripcion = new ClienteInscripcion();
                    inscripcion.idCliente = txtidCliente.Text;
                    inscripcion.idInscripcion = Convert.ToInt32(cmbInscripcion.SelectedValue);
                    inscripcion.fechaPago = DateTime.Now;
                    inscripcion.fechaFinal = DateTime.Now.AddMonths(1);
                    inscripcion.diasRestantes = dias;

                    dataContextSky.ClienteInscripcion.InsertOnSubmit(inscripcion);
                    dataContextSky.SubmitChanges();
                    var precio = dataContextSky.Inscripcion.First(t => t.idInscripcion == Convert.ToInt32(cmbInscripcion.SelectedValue)).precioInscripcion;
                    var nombreCliente = dataContextSky.Cliente.First(t => t.numeroIdentidad == txtidCliente.Text).nombre;
                    var nombreInscripcion = dataContextSky.Inscripcion.First(t => t.idInscripcion == Convert.ToInt32(cmbInscripcion.SelectedValue)).nombreInscripcion;
                    MessageBox.Show(nombreCliente.ToString() + " se ha inscrito a: " + nombreInscripcion.ToString() + ". El total a pagar es: L." + Convert.ToDecimal(precio.ToString()));
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ha ocurrido un error" + ex);
                }
                finally
                {
                    Limpiar();
                }
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

        private void Limpiar()
        {
            txtidCliente.Clear();
            txtCantidad.Clear();
            cmbProducto.SelectedIndex = -1;
            cmbInscripcion.SelectedIndex = -1;
        }

        private void TxtidCliente_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.OemMinus || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TxtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
