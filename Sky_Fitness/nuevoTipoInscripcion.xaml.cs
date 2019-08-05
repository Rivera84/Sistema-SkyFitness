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
            SqlConnection conexion = new SqlConnection("Data Source = LAPTOP-H5OOPDVV\\SQLEXPRESS; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
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
            inscripcion.precioInscripcion = Convert.ToInt32(txtPrecioInscripcion.Text);
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
                
                chkModificar.IsChecked = false;
            }
            else
            {
                insertarInscripcion();
                
            }
            
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ChkModificar_Click(object sender, RoutedEventArgs e)
        {
            if (chkModificar.IsEnabled == true)
            {
                
                BtnModificar.IsEnabled = true;
            }
            if (chkModificar.IsEnabled == false)
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
        }
    }
