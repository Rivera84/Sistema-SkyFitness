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
        public ventanaCliente()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection("Data Source = (local); Initial Catalog = SistemaDeEstacionamiento; Integrated Security = True");
            dataContextSky = new SkyFitnessBDDataContext(); 
        }

        private void InsertarCliente()
        {
            Cliente cliente = new Cliente();

            cliente.numeroIdentidad = txtIdentidad.Text;
            cliente.nombre = txtNombre.Text;
            cliente.apellido = txtApellido.Text;
            cliente.telefono = txtTelefono.Text;
            cliente.direccion = txtDireccion.Text;
            cliente.correoElectronico = txtCorreo.Text;
            cliente.fechaNacimiento = dpFechaNacimiento.DisplayDate;
            cliente.razon = cbRIngreso.SelectedValue.ToString();
            cliente.edad = Convert.ToInt32(txtEdad);
            cliente.peso = Convert.ToDecimal(txtPeso);
            cliente.estatura = Convert.ToDecimal(txtEstatura);
            cliente.talla = Convert.ToDecimal(txtTalla);
            cliente.IMC = Convert.ToDecimal(txtIMC);
            if (rbMasculino.IsEnabled)
                cliente.sexo = "Masculino";
            else if (rbFemenino.IsEnabled)
                cliente.sexo = "Femenino";
        }
    }
}
