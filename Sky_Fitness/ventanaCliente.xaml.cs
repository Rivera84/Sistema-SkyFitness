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
    /// Lógica de interacción para ventanaCliente.xaml
    /// </summary>
    public partial class ventanaCliente : UserControl
    {
        SkyFitnessBDDataContext dataContextSky;
        CalculoIMC calculo { get; set; }
        public ventanaCliente()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection("Data Source = LAPTOP-H5OOPDVV\\SQLEXPRESS; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(conexion);
            //calculo = new CalculoIMC { Peso = Convert.ToString(txtPeso.Text), Estatura = Convert.ToString(txtEstatura.Text) };
            //this.DataContext = calculo;
            
        }        

        private void ActualizarCliente()
        {
            
            try
            {
                var query = from c in dataContextSky.Cliente
                            where c.numeroIdentidad == txtIdentidad.Text 
                            select c;

                foreach (Cliente c in query)
                {
                    c.nombre = txtNombre.Text;
                    c.apellido = txtApellido.Text;
                    c.correoElectronico = txtCorreo.Text;
                    c.direccion = txtDireccion.Text;
                    c.edad = Convert.ToInt32(txtEdad.Text);
                    c.estatura = Convert.ToDecimal(txtEstatura.Text);
                    c.fechaNacimiento = Convert.ToDateTime(dpFechaNacimiento.SelectedDate);
                    c.IMC = Convert.ToDecimal(txtIMC.Text);
                    c.peso = Convert.ToDecimal(txtPeso.Text);
                    c.razon = cmbRIngreso.Text;
                    if (rbMasculino.IsChecked == true)
                        c.sexo = "Masculino";
                    else if (rbFemenino.IsChecked == true)
                        c.sexo = "Femenino";
                    c.talla = Convert.ToDecimal(txtTalla.Text);
                    c.telefono = txtTelefono.Text;
                    
                }
                MessageBox.Show("Se han actualizado los datos");
                dataContextSky.SubmitChanges();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error"+ex);
            }
        }

        private void InsertarCliente()
        {
            try
            { 
                Cliente cliente = new Cliente();

                cliente.numeroIdentidad = txtIdentidad.Text;
                cliente.nombre = txtNombre.Text;
                cliente.apellido = txtApellido.Text;
                cliente.telefono = txtTelefono.Text;
                cliente.direccion = txtDireccion.Text;
                cliente.correoElectronico = txtCorreo.Text;
                cliente.fechaNacimiento = Convert.ToDateTime(dpFechaNacimiento.SelectedDate);
                cliente.razon = cmbRIngreso.Text;
                cliente.edad = Convert.ToInt32(txtEdad.Text);
                cliente.peso = Convert.ToDecimal(txtPeso.Text);
                cliente.estatura = Convert.ToDecimal(txtEstatura.Text);
                cliente.talla = Convert.ToDecimal(txtTalla.Text);
                cliente.IMC = Convert.ToDecimal(txtIMC.Text);
                cliente.estado = "inActivo";
                cliente.fechaCreacion = DateTime.Now;
                if (rbMasculino.IsChecked == true)
                    cliente.sexo = "Masculino";
                else if (rbFemenino.IsChecked == true)
                    cliente.sexo = "Femenino";
                dataContextSky.Cliente.InsertOnSubmit(cliente);
                dataContextSky.SubmitChanges();

                MessageBox.Show("El cliente se ha agregado con éxito");
                
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (chkModificar.IsChecked == true)
            {
                ActualizarCliente();
                LimpiarDatos();
                txtIdentidad.IsEnabled = true;
                chkModificar.IsChecked = false;
                MessageBox.Show("Registro Actualizado con éxito");
            }
            else
            {
                InsertarCliente();
                LimpiarDatos();
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarDatos();
        }
        private void LimpiarDatos()
        {

            txtIdentidad.IsEnabled = true;
            chkModificar.IsChecked = false;
            txtIdentidad.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            dpFechaNacimiento.SelectedDate = DateTime.Now;
            cmbRIngreso.SelectedIndex = -1;
            rbMasculino.IsChecked = false;
            rbFemenino.IsChecked = false;
            txtEdad.Clear();
            txtPeso.Clear();
            txtEstatura.Clear();
            txtTalla.Clear();
            txtIMC.Clear();

            txtNombre.Focus();
        }

     

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var clientes = from client in dataContextSky.Cliente
                               where client.numeroIdentidad == txtIdentidad.Text
                               select client;

                List<Cliente> lista = clientes.ToList();
                var dato = lista[0];
                txtNombre.Text = dato.nombre;
                txtApellido.Text = dato.apellido;
                txtCorreo.Text = dato.correoElectronico;
                txtDireccion.Text = dato.direccion;
                txtEdad.Text = dato.edad.ToString();
                txtEstatura.Text = dato.estatura.ToString();
                txtIMC.Text = dato.IMC.ToString();
                txtPeso.Text = dato.peso.ToString();
                txtTalla.Text = dato.talla.ToString();
                txtTelefono.Text = dato.telefono;
                dpFechaNacimiento.Text = dato.fechaNacimiento.ToString();
                cmbRIngreso.Text = dato.razon;
                if (dato.sexo == "Femenino")
                {

                    rbFemenino.IsChecked = true;
                }
                if (dato.sexo == "Masculino")
                {
                    rbMasculino.IsChecked = true;
                }

                BtnModificar.IsEnabled = false;
                txtIdentidad.IsEnabled = false;                          
            }
            catch (Exception)
            {
                MessageBox.Show("Identidad no encontrada");
            }
        }

        private void ChkModificar_Click(object sender, RoutedEventArgs e)
        {

            if (chkModificar.IsChecked==true)
            {
                BtnModificar.IsEnabled=true;
            }else if (chkModificar.IsChecked == false)
            {
                BtnModificar.IsEnabled=false;
            }
        }

        private void ChkEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (chkEliminar.IsChecked == true)
            {
                BtnEliminar.IsEnabled = true;
            }
            else if(chkEliminar.IsChecked == false)
            {
                BtnEliminar.IsEnabled = false;
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var query = from c in dataContextSky.Cliente
                            where c.numeroIdentidad == txtIdentidad.Text
                            select c;
                var nombreCliente = dataContextSky.Cliente.First(t => t.numeroIdentidad == txtIdentidad.Text).nombre;
                foreach (Cliente c in query)
                {
                    if (c.estado == "Inactivo")
                    {
                        MessageBox.Show("El Cliente " + nombreCliente.ToString() + " se ha Habilitado exitosamente");
                        c.estado = "Activo";
                    }                                           
                    else
                    {
                        MessageBox.Show("El Cliente " + nombreCliente.ToString() + " se ha Deshabilitado exitosamente");
                        c.estado = "Inactivo";
                    }
                        

                }                
                dataContextSky.SubmitChanges();

                BtnEliminar.IsEnabled = false;                
                chkEliminar.IsChecked = false;
                LimpiarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error" + ex);
            }
        }

        private void TxtIdentidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.OemMinus || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TxtTelefono_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.OemMinus || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TxtEdad_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)
                    e.Handled = false;
                else
                    e.Handled = true;
           
        }

        private void ValidacionDecimales(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.OemPeriod || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }        

        // IMC = peso(kg)/altura^2(m)
        // si está en libras -> libras/2.2 = kg
        // si IMC= menos de 18, esta bajo de peso, entre 18 a 24, esta saludable,
        // de 25 a 30 está en sobrepeso, de 30 en adelante está obeso
    }
}
