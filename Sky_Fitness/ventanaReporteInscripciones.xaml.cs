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
    /// Lógica de interacción para ventanaReporteInscripciones.xaml
    /// </summary>
    public partial class ventanaReporteInscripciones : Window
    {
        SkyFitnessBDDataContext dataContextSky;
        SqlConnection conexion;
        public ventanaReporteInscripciones()
        {
            InitializeComponent();
            conexion = new SqlConnection("Data Source = LAPTOP-H5OOPDVV\\SQLEXPRESS; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(conexion);
            MostrarReporteInscripciones();
        }

        private void MostrarReporteInscripciones()
        {
            try
            {
                ClienteInscripcion cinscripcion = new ClienteInscripcion();

                var inscripciones = from cl in dataContextSky.ClienteInscripcion
                                    join c in dataContextSky.Cliente on cl.idCliente equals c.numeroIdentidad
                                    join i in dataContextSky.Inscripcion on cl.idInscripcion equals i.idInscripcion
                                    orderby cl.fechaFinal ascending
                                    select new {
                                        Cliente = cl.idCliente,
                                        Nombre = c.nombre,
                                        Inscripcion = cl.idInscripcion,
                                        NombreInscripcion = i.nombreInscripcion,
                                        Precio = i.precioInscripcion,
                                        FechaFinal = cl.fechaFinal,
                                        FechaPago = cl.fechaPago,
                                        DiasRestantes = cl.diasRestantes,
                                        Estado = c.estado };



                dgListadoInscripciones.ItemsSource = inscripciones.ToList(); ;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            
            buscarFechas();
            
        }

        private void buscarFechas()
        {
            ClienteInscripcion inscripcion = new ClienteInscripcion();
            try
            {
                var buscarfecha = from cl in dataContextSky.ClienteInscripcion
                                  join c in dataContextSky.Cliente on cl.idCliente equals c.numeroIdentidad
                                  join i in dataContextSky.Inscripcion on cl.idInscripcion equals i.idInscripcion
                                  where cl.fechaPago == Convert.ToDateTime(dpDesde.SelectedDate) && cl.fechaPago == Convert.ToDateTime(dpHasta.SelectedDate)
                                  orderby cl.fechaFinal ascending
                                  select new
                                  {
                                      Cliente = cl.idCliente,
                                      Nombre = c.nombre,
                                      Inscripcion = cl.idInscripcion,
                                      NombreInscripcion = i.nombreInscripcion,
                                      Precio = i.precioInscripcion,
                                      FechaFinal = cl.fechaFinal,
                                      FechaPago = cl.fechaPago,
                                      DiasRestantes = cl.diasRestantes,
                                      Estado = c.estado
                                  };
                dgListadoInscripciones.ItemsSource = buscarfecha.ToList();


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encuentra resultado");
            }
        }


        //private void buscarFechasActivo()
        //{
        //    ClienteInscripcion inscripcion = new ClienteInscripcion();
        //    try
        //    {
        //        var buscarfecha = from cl in dataContextSky.ClienteInscripcion
        //                          join c in dataContextSky.Cliente on cl.idCliente equals c.numeroIdentidad
        //                          join i in dataContextSky.Inscripcion on cl.idInscripcion equals i.idInscripcion
        //                          where cl.fechaPago == Convert.ToDateTime(dpDesde.SelectedDate) && cl.fechaPago == Convert.ToDateTime(dpHasta.SelectedDate) && c.estado =="Activo"
        //                          orderby cl.fechaFinal ascending
        //                          select new
        //                          {
        //                              Cliente = cl.idCliente,
        //                              Nombre = c.nombre,
        //                              Inscripcion = cl.idInscripcion,
        //                              NombreInscripcion = i.nombreInscripcion,
        //                              Precio = i.precioInscripcion,
        //                              FechaFinal = cl.fechaFinal,
        //                              FechaPago = cl.fechaPago,
        //                              DiasRestantes = cl.diasRestantes,
        //                              Estado = c.estado
        //                          };
        //        dgListadoInscripciones.ItemsSource = buscarfecha.ToList();


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("No se encuentra resultado");
        //    }
        //}

        //private void buscarFechasinActivo()
        //{
        //    ClienteInscripcion inscripcion = new ClienteInscripcion();
        //    try
        //    {
        //        var buscarfecha = from cl in dataContextSky.ClienteInscripcion
        //                          join c in dataContextSky.Cliente on cl.idCliente equals c.numeroIdentidad
        //                          join i in dataContextSky.Inscripcion on cl.idInscripcion equals i.idInscripcion
        //                          where cl.fechaPago == Convert.ToDateTime(dpDesde.SelectedDate) && cl.fechaPago == Convert.ToDateTime(dpHasta.SelectedDate) && c.estado == "inActivo"
        //                          orderby cl.fechaFinal ascending
        //                          select new
        //                          {
        //                              Cliente = cl.idCliente,
        //                              Nombre = c.nombre,
        //                              Inscripcion = cl.idInscripcion,
        //                              NombreInscripcion = i.nombreInscripcion,
        //                              Precio = i.precioInscripcion,
        //                              FechaFinal = cl.fechaFinal,
        //                              FechaPago = cl.fechaPago,
        //                              DiasRestantes = cl.diasRestantes,
        //                              Estado = c.estado
        //                          };
        //        dgListadoInscripciones.ItemsSource = buscarfecha.ToList();


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("No se encuentra resultado");
        //    }
        //}


    }
}
