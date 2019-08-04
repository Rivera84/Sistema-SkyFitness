﻿using System;
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
    /// Lógica de interacción para ventanaReporteVentas.xaml
    /// </summary>
    public partial class ventanaReporteVentas : Window
    {
        SkyFitnessBDDataContext dataContextSky;
        SqlConnection conexion;
        public ventanaReporteVentas()
        {
            InitializeComponent();
            conexion = new SqlConnection("Data Source = ABELCONSUEGRA; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(conexion);
            MostrarReporteVentas();
        }

        private void MostrarReporteVentas()
        {
            try
            {
                ClienteProducto ventas = new ClienteProducto();

                var venta = from cl in dataContextSky.ClienteProducto
                                    orderby cl.idClienteProducto ascending
                                    select cl;

                dgReporteVentas.ItemsSource = dataContextSky.ClienteProducto;
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
    }
}
