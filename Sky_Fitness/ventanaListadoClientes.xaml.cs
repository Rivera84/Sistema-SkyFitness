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
        Cliente cliente = new Cliente();
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


                var clientes = from client in dataContextSky.Cliente
                               orderby client.nombre ascending
                               select new {Identidad=client.numeroIdentidad,
                                   Nombre=client.nombre,
                                   Apellido=client.apellido,
                                   FechaNacimiento=client.fechaNacimiento,
                                   FechaCreación=client.fechaCreacion,
                                   Edad= client.edad,
                                   Sexo=client.sexo,
                                   Telefono=client.telefono,
                                   Direccion=client.direccion,
                                   CorreoElectronico=client.correoElectronico,
                                   Razon=client.razon,
                                   Peso=client.peso,
                                   Estatura=client.estatura,
                                   Talla=client.talla,
                                   Estado=client.estado, 
                                   IMC=client.IMC };



                dgListadoClientes.ItemsSource = clientes.ToList();

                dgListadoClientes.SelectedValuePath = cliente.numeroIdentidad;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MostrarbusquedaNombre()
        {

            try
            {
                var buscarNombre = from client in dataContextSky.Cliente
                                   where client.nombre == txtBuscar.Text
                                   select new { client.numeroIdentidad, client.nombre, client.apellido, client.fechaNacimiento, client.fechaCreacion, client.edad, client.sexo, client.telefono, client.direccion, client.correoElectronico, client.razon, client.peso, client.estatura, client.talla, client.estado, client.IMC };
                dgListadoClientes.ItemsSource = buscarNombre.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("no se encuentra busqueda" + ex);
            }
        }
        private void MostrarbusquedaIdentidad()
        {

            try
            {
                var buscarIdentidad = from client in dataContextSky.Cliente
                                      where client.numeroIdentidad == txtBuscar.Text
                                      select new { client.numeroIdentidad, client.nombre, client.apellido, client.fechaNacimiento, client.fechaCreacion, client.edad, client.sexo, client.telefono, client.direccion, client.correoElectronico, client.razon, client.peso, client.estatura, client.talla, client.estado, client.IMC };
                dgListadoClientes.ItemsSource = buscarIdentidad.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("no se encuentra busqueda" + ex);
            }
        }

        private void MostrarbusquedaDireccion()
        {

            try
            {
                var buscarDireccion = from client in dataContextSky.Cliente
                                      where client.direccion == txtBuscar.Text
                                      select new {Identidad= client.numeroIdentidad,
                                                  Nombre=client.nombre,
                                                  Apellido=client.apellido,
                                                  FechaNacimiento=client.fechaNacimiento,
                                                  FechaCreacion=client.fechaCreacion,
                                                  Edad=client.edad,
                                                  Sexo=client.sexo,
                                                  Telefono=client.telefono,
                                                  Direccion=client.direccion,
                                                   CorreoElectronico=client.correoElectronico,
                                                  Razon=client.razon,
                                                  Peso=client.peso,
                                                  Estatura=client.estatura,
                                                  Talla=client.talla,
                                                  Estado=client.estado,
                                                  IMC=client.IMC };
                dgListadoClientes.ItemsSource = buscarDireccion.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("no se encuentra busqueda" + ex);
            }
        }
        private void MostrarbusquedaEstado()
        {

            try
            {
                var buscarEstado = from client in dataContextSky.Cliente
                                   where client.estado == txtBuscar.Text
                                   select new { client.numeroIdentidad, client.nombre, client.apellido, client.fechaNacimiento, client.fechaCreacion, client.edad, client.sexo, client.telefono, client.direccion, client.correoElectronico, client.razon, client.peso, client.estatura, client.talla, client.estado, client.IMC };
                dgListadoClientes.ItemsSource = buscarEstado.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("no se encuentra busqueda" + ex);
            }
        }

        private void BusquedaEspecifica(object sender, RoutedEventArgs e)
        {
            if (rbIdentidad.IsChecked == false && rbNombre.IsChecked == false && rbDireccion.IsChecked == false && rbEstado.IsChecked == false)
            {
                MessageBox.Show("Seleccione un tipo de busqueda");
            }
            else
            if (rbNombre.IsChecked == true)
            {
                MostrarbusquedaNombre();
            }
            if (rbIdentidad.IsChecked == true)
            {
                MostrarbusquedaIdentidad();
            }
            if (rbDireccion.IsChecked == true)
            {
                MostrarbusquedaDireccion();
            }
            if (rbEstado.IsChecked == true)
            {
                MostrarbusquedaEstado();
            }

        }

        private void Limpiar(object sender, RoutedEventArgs e)
        {
            txtBuscar.Clear();
            rbDireccion.IsChecked = false;
            rbEstado.IsChecked = false;
            rbIdentidad.IsChecked = false;
            rbNombre.IsChecked = false;
            MostrarClientes();
        }

        private void DgListadoClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if(MessageBox.Show("¿Desea eliminar este cliente?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            //{
            //    try
            //    {
            //        var clienteEliminado = (from cl in dataContextSky.Cliente
            //                                where cl.numeroIdentidad.Equals(dgListadoClientes.SelectedValue.ToString())
            //                                select cl).FirstOrDefault();
            //        dataContextSky.Cliente.DeleteOnSubmit(clienteEliminado);
            //        dataContextSky.SubmitChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
            //else
            //{

            //}
        }
    }
}
