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

        private void ActualizarTipo()
        {
            try
            {
                var query = from c in dataContextSky.Inscripcion
                            where c.nombreInscripcion == txtInscripcion.Text
                            select c;

                foreach (Inscripcion c in query)
                {
                    c.precioInscripcion = Convert.ToDecimal(txtPrecioInscripcion.Text);
                    c.descripcion = txtDescripcion.Text;
                }
                dataContextSky.SubmitChanges();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error" + ex);
            }
        }

        private void insertarInscripcion()
        {
            Inscripcion inscripcion = new Inscripcion();
            inscripcion.nombreInscripcion = txtInscripcion.Text;
            inscripcion.precioInscripcion = Convert.ToDecimal(txtPrecioInscripcion.Text);
            inscripcion.descripcion = txtDescripcion.Text;

            dataContextSky.Inscripcion.InsertOnSubmit(inscripcion);
            dataContextSky.SubmitChanges();

            MessageBox.Show("La inscripción se ha agregado con éxito");

        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (chkModificar.IsChecked == true)
            {
                ActualizarTipo();
                MessageBox.Show("Registro actualizado");
                chkModificar.IsChecked = false;
                Limpiar();
                txtInscripcion.IsEnabled = true;
            }
            else
            {
                insertarInscripcion();
                Limpiar();
            }
            
        }

        private void Limpiar()
        {
            txtDescripcion.Clear();
            txtInscripcion.Clear();
            txtPrecioInscripcion.Clear();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ChkModificar_Click(object sender, RoutedEventArgs e)
        {
            if (chkModificar.IsChecked == true)
            {
                
                BtnModificar.IsEnabled = true;
            }
            if (chkModificar.IsChecked == false)
            {
                BtnModificar.IsEnabled = false;
            }
    }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var inscripciones = from client in dataContextSky.Inscripcion
                                where client.nombreInscripcion == txtInscripcion.Text
                                select client;

                List<Inscripcion> lista = inscripciones.ToList();
                var dato = lista[0];
                txtDescripcion.Text = dato.descripcion;
                txtPrecioInscripcion.Text = dato.precioInscripcion.ToString();
                BtnModificar.IsEnabled = false;
                txtInscripcion.IsEnabled = false;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha encontrado inscripcion");
            }
        }

        private void TxtPrecioInscripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.OemPeriod || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
    }
