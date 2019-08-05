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
using System.Data.SqlClient;

namespace Sky_Fitness
{
    /// <summary>
    /// Lógica de interacción para ventanaPago.xaml
    /// </summary>
    public partial class ventanaPago : Window
    {
        SkyFitnessBDDataContext dataContextSky;
        public ventanaPago()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection("Data Source = LAPTOP-H5OOPDVV\\SQLEXPRESS; Initial Catalog = Sky_FitnessDB; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(conexion);

        }


        private void ActualizarProducto()
        {
            
            try
            {
                var query = from c in dataContextSky.Producto
                            where c.nombreProducto == txtNombreProducto.Text
                            select c;

                foreach (Producto c in query)
                {
                    c.precioProducto = Convert.ToDecimal(txtPrecioProducto.Text);
                    c.existencia = Convert.ToInt32(txtCantidad.Text);
                  

                }
                dataContextSky.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio un error" + ex);
            }
        }

        private void InsertarProducto()
        {
            try
            {
                Producto producto = new Producto();

                producto.nombreProducto = txtNombreProducto.Text;
                producto.precioProducto = Convert.ToDecimal(txtPrecioProducto.Text);
                producto.existencia = Convert.ToInt32(txtCantidad.Text);

                dataContextSky.Producto.InsertOnSubmit(producto);
                dataContextSky.SubmitChanges();

                MessageBox.Show("El producto se ha agregado con éxito");
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (chkModificar.IsChecked == true)
            {
                ActualizarProducto();
                Limpiar();
                chkModificar.IsChecked = false;
            }
            else
            {
                InsertarProducto();
                Limpiar();
            }
        
        
        }

        private void Limpiar()
        {
            txtNombreProducto.Clear();
            txtPrecioProducto.Clear();
            txtCantidad.Clear();
            txtNombreProducto.Focus();
        }

        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {
            vInventario vinv = new vInventario();

            vinv.Show();
        }

       

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
           
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try { 
            var productos = from client in dataContextSky.Producto
                            where client.nombreProducto == txtNombreProducto.Text 
                           select client;

            List<Producto> lista = productos.ToList();
            var dato = lista[0];
            txtCantidad.Text = dato.existencia.ToString();
             txtPrecioProducto.Text = dato.precioProducto.ToString();
            BtnModificar.IsEnabled = false;
            txtNombreProducto.IsEnabled = false;
            }
            catch(Exception ex) {
                MessageBox.Show("Nombre de producto no encontrado");
            }
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
    }
}
