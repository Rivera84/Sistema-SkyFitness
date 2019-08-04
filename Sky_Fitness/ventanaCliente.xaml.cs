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
            SqlConnection conexion = new SqlConnection("Data Source =LAPTOP-H5OOPDVV\\SQLEXPRESS; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(conexion);
            //calculo = new CalculoIMC { Peso = Convert.ToString(txtPeso.Text), Estatura = Convert.ToString(txtEstatura.Text) };
            //this.DataContext = calculo;
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
            InsertarCliente();
            LimpiarDatos();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarDatos();
        }
        private void LimpiarDatos()
        {
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

        private void BtnListaClientes_Click(object sender, RoutedEventArgs e)
        {
            ventanaListadoClientes listaClientes = new ventanaListadoClientes();
            listaClientes.Show();
        }

        // IMC = peso(kg)/altura^2(m)
        // si está en libras -> libras/2.2 = kg
        // si IMC= menos de 18, esta bajo de peso, entre 18 a 24, esta saludable,
        // de 25 a 30 está en sobrepeso, de 30 en adelante está obeso
    }
}
