﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sky_Fitness
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Sky_FitnessDB")]
	public partial class SkyFitnessBDDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertClienteInscripcion(ClienteInscripcion instance);
    partial void UpdateClienteInscripcion(ClienteInscripcion instance);
    partial void DeleteClienteInscripcion(ClienteInscripcion instance);
    partial void InsertClienteProducto(ClienteProducto instance);
    partial void UpdateClienteProducto(ClienteProducto instance);
    partial void DeleteClienteProducto(ClienteProducto instance);
    partial void InsertCliente(Cliente instance);
    partial void UpdateCliente(Cliente instance);
    partial void DeleteCliente(Cliente instance);
    partial void InsertUsuario(Usuario instance);
    partial void UpdateUsuario(Usuario instance);
    partial void DeleteUsuario(Usuario instance);
    partial void InsertInscripcion(Inscripcion instance);
    partial void UpdateInscripcion(Inscripcion instance);
    partial void DeleteInscripcion(Inscripcion instance);
    partial void InsertProducto(Producto instance);
    partial void UpdateProducto(Producto instance);
    partial void DeleteProducto(Producto instance);
    #endregion
		
		public SkyFitnessBDDataContext() : 
				base(global::Sky_Fitness.Properties.Settings.Default.Sky_FitnessDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SkyFitnessBDDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SkyFitnessBDDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SkyFitnessBDDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SkyFitnessBDDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ClienteInscripcion> ClienteInscripcion
		{
			get
			{
				return this.GetTable<ClienteInscripcion>();
			}
		}
		
		public System.Data.Linq.Table<ClienteProducto> ClienteProducto
		{
			get
			{
				return this.GetTable<ClienteProducto>();
			}
		}
		
		public System.Data.Linq.Table<Cliente> Cliente
		{
			get
			{
				return this.GetTable<Cliente>();
			}
		}
		
		public System.Data.Linq.Table<Usuario> Usuario
		{
			get
			{
				return this.GetTable<Usuario>();
			}
		}
		
		public System.Data.Linq.Table<Inscripcion> Inscripcion
		{
			get
			{
				return this.GetTable<Inscripcion>();
			}
		}
		
		public System.Data.Linq.Table<Producto> Producto
		{
			get
			{
				return this.GetTable<Producto>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Detalle.ClienteInscripcion")]
	public partial class ClienteInscripcion : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idClienteInscripcion;
		
		private string _idCliente;
		
		private int _idInscripcion;
		
		private System.Nullable<System.DateTime> _fechaPago;
		
		private System.Nullable<System.DateTime> _fechaFinal;
		
		private System.Nullable<int> _diasRestantes;
		
		private EntityRef<Cliente> _Cliente;
		
		private EntityRef<Inscripcion> _Inscripcion;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidClienteInscripcionChanging(int value);
    partial void OnidClienteInscripcionChanged();
    partial void OnidClienteChanging(string value);
    partial void OnidClienteChanged();
    partial void OnidInscripcionChanging(int value);
    partial void OnidInscripcionChanged();
    partial void OnfechaPagoChanging(System.Nullable<System.DateTime> value);
    partial void OnfechaPagoChanged();
    partial void OnfechaFinalChanging(System.Nullable<System.DateTime> value);
    partial void OnfechaFinalChanged();
    partial void OndiasRestantesChanging(System.Nullable<int> value);
    partial void OndiasRestantesChanged();
    #endregion
		
		public ClienteInscripcion()
		{
			this._Cliente = default(EntityRef<Cliente>);
			this._Inscripcion = default(EntityRef<Inscripcion>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idClienteInscripcion", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int idClienteInscripcion
		{
			get
			{
				return this._idClienteInscripcion;
			}
			set
			{
				if ((this._idClienteInscripcion != value))
				{
					this.OnidClienteInscripcionChanging(value);
					this.SendPropertyChanging();
					this._idClienteInscripcion = value;
					this.SendPropertyChanged("idClienteInscripcion");
					this.OnidClienteInscripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCliente", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string idCliente
		{
			get
			{
				return this._idCliente;
			}
			set
			{
				if ((this._idCliente != value))
				{
					if (this._Cliente.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidClienteChanging(value);
					this.SendPropertyChanging();
					this._idCliente = value;
					this.SendPropertyChanged("idCliente");
					this.OnidClienteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idInscripcion", DbType="Int NOT NULL")]
		public int idInscripcion
		{
			get
			{
				return this._idInscripcion;
			}
			set
			{
				if ((this._idInscripcion != value))
				{
					if (this._Inscripcion.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidInscripcionChanging(value);
					this.SendPropertyChanging();
					this._idInscripcion = value;
					this.SendPropertyChanged("idInscripcion");
					this.OnidInscripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fechaPago", DbType="Date")]
		public System.Nullable<System.DateTime> fechaPago
		{
			get
			{
				return this._fechaPago;
			}
			set
			{
				if ((this._fechaPago != value))
				{
					this.OnfechaPagoChanging(value);
					this.SendPropertyChanging();
					this._fechaPago = value;
					this.SendPropertyChanged("fechaPago");
					this.OnfechaPagoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fechaFinal", DbType="Date")]
		public System.Nullable<System.DateTime> fechaFinal
		{
			get
			{
				return this._fechaFinal;
			}
			set
			{
				if ((this._fechaFinal != value))
				{
					this.OnfechaFinalChanging(value);
					this.SendPropertyChanging();
					this._fechaFinal = value;
					this.SendPropertyChanged("fechaFinal");
					this.OnfechaFinalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_diasRestantes", DbType="Int")]
		public System.Nullable<int> diasRestantes
		{
			get
			{
				return this._diasRestantes;
			}
			set
			{
				if ((this._diasRestantes != value))
				{
					this.OndiasRestantesChanging(value);
					this.SendPropertyChanging();
					this._diasRestantes = value;
					this.SendPropertyChanged("diasRestantes");
					this.OndiasRestantesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Cliente_ClienteInscripcion", Storage="_Cliente", ThisKey="idCliente", OtherKey="numeroIdentidad", IsForeignKey=true)]
		public Cliente Cliente
		{
			get
			{
				return this._Cliente.Entity;
			}
			set
			{
				Cliente previousValue = this._Cliente.Entity;
				if (((previousValue != value) 
							|| (this._Cliente.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cliente.Entity = null;
						previousValue.ClienteInscripcion.Remove(this);
					}
					this._Cliente.Entity = value;
					if ((value != null))
					{
						value.ClienteInscripcion.Add(this);
						this._idCliente = value.numeroIdentidad;
					}
					else
					{
						this._idCliente = default(string);
					}
					this.SendPropertyChanged("Cliente");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Inscripcion_ClienteInscripcion", Storage="_Inscripcion", ThisKey="idInscripcion", OtherKey="idInscripcion", IsForeignKey=true)]
		public Inscripcion Inscripcion
		{
			get
			{
				return this._Inscripcion.Entity;
			}
			set
			{
				Inscripcion previousValue = this._Inscripcion.Entity;
				if (((previousValue != value) 
							|| (this._Inscripcion.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Inscripcion.Entity = null;
						previousValue.ClienteInscripcion.Remove(this);
					}
					this._Inscripcion.Entity = value;
					if ((value != null))
					{
						value.ClienteInscripcion.Add(this);
						this._idInscripcion = value.idInscripcion;
					}
					else
					{
						this._idInscripcion = default(int);
					}
					this.SendPropertyChanged("Inscripcion");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Detalle.ClienteProducto")]
	public partial class ClienteProducto : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idClienteProducto;
		
		private string _idCliente;
		
		private int _cantidad;
		
		private int _idProducto;
		
		private System.Nullable<decimal> _total;
		
		private EntityRef<Cliente> _Cliente;
		
		private EntityRef<Producto> _Producto;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidClienteProductoChanging(int value);
    partial void OnidClienteProductoChanged();
    partial void OnidClienteChanging(string value);
    partial void OnidClienteChanged();
    partial void OncantidadChanging(int value);
    partial void OncantidadChanged();
    partial void OnidProductoChanging(int value);
    partial void OnidProductoChanged();
    partial void OntotalChanging(System.Nullable<decimal> value);
    partial void OntotalChanged();
    #endregion
		
		public ClienteProducto()
		{
			this._Cliente = default(EntityRef<Cliente>);
			this._Producto = default(EntityRef<Producto>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idClienteProducto", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int idClienteProducto
		{
			get
			{
				return this._idClienteProducto;
			}
			set
			{
				if ((this._idClienteProducto != value))
				{
					this.OnidClienteProductoChanging(value);
					this.SendPropertyChanging();
					this._idClienteProducto = value;
					this.SendPropertyChanged("idClienteProducto");
					this.OnidClienteProductoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCliente", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string idCliente
		{
			get
			{
				return this._idCliente;
			}
			set
			{
				if ((this._idCliente != value))
				{
					if (this._Cliente.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidClienteChanging(value);
					this.SendPropertyChanging();
					this._idCliente = value;
					this.SendPropertyChanged("idCliente");
					this.OnidClienteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cantidad", DbType="Int NOT NULL")]
		public int cantidad
		{
			get
			{
				return this._cantidad;
			}
			set
			{
				if ((this._cantidad != value))
				{
					this.OncantidadChanging(value);
					this.SendPropertyChanging();
					this._cantidad = value;
					this.SendPropertyChanged("cantidad");
					this.OncantidadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idProducto", DbType="Int NOT NULL")]
		public int idProducto
		{
			get
			{
				return this._idProducto;
			}
			set
			{
				if ((this._idProducto != value))
				{
					if (this._Producto.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidProductoChanging(value);
					this.SendPropertyChanging();
					this._idProducto = value;
					this.SendPropertyChanged("idProducto");
					this.OnidProductoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_total", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> total
		{
			get
			{
				return this._total;
			}
			set
			{
				if ((this._total != value))
				{
					this.OntotalChanging(value);
					this.SendPropertyChanging();
					this._total = value;
					this.SendPropertyChanged("total");
					this.OntotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Cliente_ClienteProducto", Storage="_Cliente", ThisKey="idCliente", OtherKey="numeroIdentidad", IsForeignKey=true)]
		public Cliente Cliente
		{
			get
			{
				return this._Cliente.Entity;
			}
			set
			{
				Cliente previousValue = this._Cliente.Entity;
				if (((previousValue != value) 
							|| (this._Cliente.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cliente.Entity = null;
						previousValue.ClienteProducto.Remove(this);
					}
					this._Cliente.Entity = value;
					if ((value != null))
					{
						value.ClienteProducto.Add(this);
						this._idCliente = value.numeroIdentidad;
					}
					else
					{
						this._idCliente = default(string);
					}
					this.SendPropertyChanged("Cliente");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Producto_ClienteProducto", Storage="_Producto", ThisKey="idProducto", OtherKey="idProducto", IsForeignKey=true)]
		public Producto Producto
		{
			get
			{
				return this._Producto.Entity;
			}
			set
			{
				Producto previousValue = this._Producto.Entity;
				if (((previousValue != value) 
							|| (this._Producto.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Producto.Entity = null;
						previousValue.ClienteProducto.Remove(this);
					}
					this._Producto.Entity = value;
					if ((value != null))
					{
						value.ClienteProducto.Add(this);
						this._idProducto = value.idProducto;
					}
					else
					{
						this._idProducto = default(int);
					}
					this.SendPropertyChanged("Producto");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Persona.Cliente")]
	public partial class Cliente : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _numeroIdentidad;
		
		private string _nombre;
		
		private string _apellido;
		
		private System.DateTime _fechaNacimiento;
		
		private System.DateTime _fechaCreacion;
		
		private int _edad;
		
		private string _sexo;
		
		private string _telefono;
		
		private string _direccion;
		
		private string _correoElectronico;
		
		private string _razon;
		
		private decimal _peso;
		
		private decimal _estatura;
		
		private decimal _talla;
		
		private string _estado;
		
		private decimal _IMC;
		
		private EntitySet<ClienteInscripcion> _ClienteInscripcion;
		
		private EntitySet<ClienteProducto> _ClienteProducto;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnnumeroIdentidadChanging(string value);
    partial void OnnumeroIdentidadChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    partial void OnapellidoChanging(string value);
    partial void OnapellidoChanged();
    partial void OnfechaNacimientoChanging(System.DateTime value);
    partial void OnfechaNacimientoChanged();
    partial void OnfechaCreacionChanging(System.DateTime value);
    partial void OnfechaCreacionChanged();
    partial void OnedadChanging(int value);
    partial void OnedadChanged();
    partial void OnsexoChanging(string value);
    partial void OnsexoChanged();
    partial void OntelefonoChanging(string value);
    partial void OntelefonoChanged();
    partial void OndireccionChanging(string value);
    partial void OndireccionChanged();
    partial void OncorreoElectronicoChanging(string value);
    partial void OncorreoElectronicoChanged();
    partial void OnrazonChanging(string value);
    partial void OnrazonChanged();
    partial void OnpesoChanging(decimal value);
    partial void OnpesoChanged();
    partial void OnestaturaChanging(decimal value);
    partial void OnestaturaChanged();
    partial void OntallaChanging(decimal value);
    partial void OntallaChanged();
    partial void OnestadoChanging(string value);
    partial void OnestadoChanged();
    partial void OnIMCChanging(decimal value);
    partial void OnIMCChanged();
    #endregion
		
		public Cliente()
		{
			this._ClienteInscripcion = new EntitySet<ClienteInscripcion>(new Action<ClienteInscripcion>(this.attach_ClienteInscripcion), new Action<ClienteInscripcion>(this.detach_ClienteInscripcion));
			this._ClienteProducto = new EntitySet<ClienteProducto>(new Action<ClienteProducto>(this.attach_ClienteProducto), new Action<ClienteProducto>(this.detach_ClienteProducto));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_numeroIdentidad", DbType="VarChar(15) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string numeroIdentidad
		{
			get
			{
				return this._numeroIdentidad;
			}
			set
			{
				if ((this._numeroIdentidad != value))
				{
					this.OnnumeroIdentidadChanging(value);
					this.SendPropertyChanging();
					this._numeroIdentidad = value;
					this.SendPropertyChanged("numeroIdentidad");
					this.OnnumeroIdentidadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_apellido", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string apellido
		{
			get
			{
				return this._apellido;
			}
			set
			{
				if ((this._apellido != value))
				{
					this.OnapellidoChanging(value);
					this.SendPropertyChanging();
					this._apellido = value;
					this.SendPropertyChanged("apellido");
					this.OnapellidoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fechaNacimiento", DbType="Date NOT NULL")]
		public System.DateTime fechaNacimiento
		{
			get
			{
				return this._fechaNacimiento;
			}
			set
			{
				if ((this._fechaNacimiento != value))
				{
					this.OnfechaNacimientoChanging(value);
					this.SendPropertyChanging();
					this._fechaNacimiento = value;
					this.SendPropertyChanged("fechaNacimiento");
					this.OnfechaNacimientoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fechaCreacion", DbType="Date NOT NULL")]
		public System.DateTime fechaCreacion
		{
			get
			{
				return this._fechaCreacion;
			}
			set
			{
				if ((this._fechaCreacion != value))
				{
					this.OnfechaCreacionChanging(value);
					this.SendPropertyChanging();
					this._fechaCreacion = value;
					this.SendPropertyChanged("fechaCreacion");
					this.OnfechaCreacionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_edad", DbType="Int NOT NULL")]
		public int edad
		{
			get
			{
				return this._edad;
			}
			set
			{
				if ((this._edad != value))
				{
					this.OnedadChanging(value);
					this.SendPropertyChanging();
					this._edad = value;
					this.SendPropertyChanged("edad");
					this.OnedadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sexo", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string sexo
		{
			get
			{
				return this._sexo;
			}
			set
			{
				if ((this._sexo != value))
				{
					this.OnsexoChanging(value);
					this.SendPropertyChanging();
					this._sexo = value;
					this.SendPropertyChanged("sexo");
					this.OnsexoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_telefono", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string telefono
		{
			get
			{
				return this._telefono;
			}
			set
			{
				if ((this._telefono != value))
				{
					this.OntelefonoChanging(value);
					this.SendPropertyChanging();
					this._telefono = value;
					this.SendPropertyChanged("telefono");
					this.OntelefonoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_direccion", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string direccion
		{
			get
			{
				return this._direccion;
			}
			set
			{
				if ((this._direccion != value))
				{
					this.OndireccionChanging(value);
					this.SendPropertyChanging();
					this._direccion = value;
					this.SendPropertyChanged("direccion");
					this.OndireccionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_correoElectronico", DbType="NVarChar(20)")]
		public string correoElectronico
		{
			get
			{
				return this._correoElectronico;
			}
			set
			{
				if ((this._correoElectronico != value))
				{
					this.OncorreoElectronicoChanging(value);
					this.SendPropertyChanging();
					this._correoElectronico = value;
					this.SendPropertyChanged("correoElectronico");
					this.OncorreoElectronicoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_razon", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string razon
		{
			get
			{
				return this._razon;
			}
			set
			{
				if ((this._razon != value))
				{
					this.OnrazonChanging(value);
					this.SendPropertyChanging();
					this._razon = value;
					this.SendPropertyChanged("razon");
					this.OnrazonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_peso", DbType="Decimal(18,0) NOT NULL")]
		public decimal peso
		{
			get
			{
				return this._peso;
			}
			set
			{
				if ((this._peso != value))
				{
					this.OnpesoChanging(value);
					this.SendPropertyChanging();
					this._peso = value;
					this.SendPropertyChanged("peso");
					this.OnpesoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_estatura", DbType="Decimal(18,0) NOT NULL")]
		public decimal estatura
		{
			get
			{
				return this._estatura;
			}
			set
			{
				if ((this._estatura != value))
				{
					this.OnestaturaChanging(value);
					this.SendPropertyChanging();
					this._estatura = value;
					this.SendPropertyChanged("estatura");
					this.OnestaturaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_talla", DbType="Decimal(18,0) NOT NULL")]
		public decimal talla
		{
			get
			{
				return this._talla;
			}
			set
			{
				if ((this._talla != value))
				{
					this.OntallaChanging(value);
					this.SendPropertyChanging();
					this._talla = value;
					this.SendPropertyChanged("talla");
					this.OntallaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_estado", DbType="VarChar(10)")]
		public string estado
		{
			get
			{
				return this._estado;
			}
			set
			{
				if ((this._estado != value))
				{
					this.OnestadoChanging(value);
					this.SendPropertyChanging();
					this._estado = value;
					this.SendPropertyChanged("estado");
					this.OnestadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IMC", DbType="Decimal(18,0) NOT NULL")]
		public decimal IMC
		{
			get
			{
				return this._IMC;
			}
			set
			{
				if ((this._IMC != value))
				{
					this.OnIMCChanging(value);
					this.SendPropertyChanging();
					this._IMC = value;
					this.SendPropertyChanged("IMC");
					this.OnIMCChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Cliente_ClienteInscripcion", Storage="_ClienteInscripcion", ThisKey="numeroIdentidad", OtherKey="idCliente")]
		public EntitySet<ClienteInscripcion> ClienteInscripcion
		{
			get
			{
				return this._ClienteInscripcion;
			}
			set
			{
				this._ClienteInscripcion.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Cliente_ClienteProducto", Storage="_ClienteProducto", ThisKey="numeroIdentidad", OtherKey="idCliente")]
		public EntitySet<ClienteProducto> ClienteProducto
		{
			get
			{
				return this._ClienteProducto;
			}
			set
			{
				this._ClienteProducto.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ClienteInscripcion(ClienteInscripcion entity)
		{
			this.SendPropertyChanging();
			entity.Cliente = this;
		}
		
		private void detach_ClienteInscripcion(ClienteInscripcion entity)
		{
			this.SendPropertyChanging();
			entity.Cliente = null;
		}
		
		private void attach_ClienteProducto(ClienteProducto entity)
		{
			this.SendPropertyChanging();
			entity.Cliente = this;
		}
		
		private void detach_ClienteProducto(ClienteProducto entity)
		{
			this.SendPropertyChanging();
			entity.Cliente = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Persona.Usuario")]
	public partial class Usuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _nombreUsuario;
		
		private string _contrasena;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnnombreUsuarioChanging(string value);
    partial void OnnombreUsuarioChanged();
    partial void OncontrasenaChanging(string value);
    partial void OncontrasenaChanged();
    #endregion
		
		public Usuario()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombreUsuario", DbType="NVarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string nombreUsuario
		{
			get
			{
				return this._nombreUsuario;
			}
			set
			{
				if ((this._nombreUsuario != value))
				{
					this.OnnombreUsuarioChanging(value);
					this.SendPropertyChanging();
					this._nombreUsuario = value;
					this.SendPropertyChanged("nombreUsuario");
					this.OnnombreUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_contrasena", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string contrasena
		{
			get
			{
				return this._contrasena;
			}
			set
			{
				if ((this._contrasena != value))
				{
					this.OncontrasenaChanging(value);
					this.SendPropertyChanging();
					this._contrasena = value;
					this.SendPropertyChanged("contrasena");
					this.OncontrasenaChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Producto.Inscripcion")]
	public partial class Inscripcion : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idInscripcion;
		
		private string _nombreInscripcion;
		
		private decimal _precioInscripcion;
		
		private string _descripcion;
		
		private EntitySet<ClienteInscripcion> _ClienteInscripcion;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidInscripcionChanging(int value);
    partial void OnidInscripcionChanged();
    partial void OnnombreInscripcionChanging(string value);
    partial void OnnombreInscripcionChanged();
    partial void OnprecioInscripcionChanging(decimal value);
    partial void OnprecioInscripcionChanged();
    partial void OndescripcionChanging(string value);
    partial void OndescripcionChanged();
    #endregion
		
		public Inscripcion()
		{
			this._ClienteInscripcion = new EntitySet<ClienteInscripcion>(new Action<ClienteInscripcion>(this.attach_ClienteInscripcion), new Action<ClienteInscripcion>(this.detach_ClienteInscripcion));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idInscripcion", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int idInscripcion
		{
			get
			{
				return this._idInscripcion;
			}
			set
			{
				if ((this._idInscripcion != value))
				{
					this.OnidInscripcionChanging(value);
					this.SendPropertyChanging();
					this._idInscripcion = value;
					this.SendPropertyChanged("idInscripcion");
					this.OnidInscripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombreInscripcion", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string nombreInscripcion
		{
			get
			{
				return this._nombreInscripcion;
			}
			set
			{
				if ((this._nombreInscripcion != value))
				{
					this.OnnombreInscripcionChanging(value);
					this.SendPropertyChanging();
					this._nombreInscripcion = value;
					this.SendPropertyChanged("nombreInscripcion");
					this.OnnombreInscripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_precioInscripcion", DbType="Decimal(18,0) NOT NULL")]
		public decimal precioInscripcion
		{
			get
			{
				return this._precioInscripcion;
			}
			set
			{
				if ((this._precioInscripcion != value))
				{
					this.OnprecioInscripcionChanging(value);
					this.SendPropertyChanging();
					this._precioInscripcion = value;
					this.SendPropertyChanged("precioInscripcion");
					this.OnprecioInscripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_descripcion", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string descripcion
		{
			get
			{
				return this._descripcion;
			}
			set
			{
				if ((this._descripcion != value))
				{
					this.OndescripcionChanging(value);
					this.SendPropertyChanging();
					this._descripcion = value;
					this.SendPropertyChanged("descripcion");
					this.OndescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Inscripcion_ClienteInscripcion", Storage="_ClienteInscripcion", ThisKey="idInscripcion", OtherKey="idInscripcion")]
		public EntitySet<ClienteInscripcion> ClienteInscripcion
		{
			get
			{
				return this._ClienteInscripcion;
			}
			set
			{
				this._ClienteInscripcion.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ClienteInscripcion(ClienteInscripcion entity)
		{
			this.SendPropertyChanging();
			entity.Inscripcion = this;
		}
		
		private void detach_ClienteInscripcion(ClienteInscripcion entity)
		{
			this.SendPropertyChanging();
			entity.Inscripcion = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Producto.Producto")]
	public partial class Producto : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idProducto;
		
		private string _nombreProducto;
		
		private System.Nullable<decimal> _precioProducto;
		
		private System.Nullable<int> _existencia;
		
		private EntitySet<ClienteProducto> _ClienteProducto;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidProductoChanging(int value);
    partial void OnidProductoChanged();
    partial void OnnombreProductoChanging(string value);
    partial void OnnombreProductoChanged();
    partial void OnprecioProductoChanging(System.Nullable<decimal> value);
    partial void OnprecioProductoChanged();
    partial void OnexistenciaChanging(System.Nullable<int> value);
    partial void OnexistenciaChanged();
    #endregion
		
		public Producto()
		{
			this._ClienteProducto = new EntitySet<ClienteProducto>(new Action<ClienteProducto>(this.attach_ClienteProducto), new Action<ClienteProducto>(this.detach_ClienteProducto));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idProducto", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int idProducto
		{
			get
			{
				return this._idProducto;
			}
			set
			{
				if ((this._idProducto != value))
				{
					this.OnidProductoChanging(value);
					this.SendPropertyChanging();
					this._idProducto = value;
					this.SendPropertyChanged("idProducto");
					this.OnidProductoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombreProducto", DbType="VarChar(20)")]
		public string nombreProducto
		{
			get
			{
				return this._nombreProducto;
			}
			set
			{
				if ((this._nombreProducto != value))
				{
					this.OnnombreProductoChanging(value);
					this.SendPropertyChanging();
					this._nombreProducto = value;
					this.SendPropertyChanged("nombreProducto");
					this.OnnombreProductoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_precioProducto", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> precioProducto
		{
			get
			{
				return this._precioProducto;
			}
			set
			{
				if ((this._precioProducto != value))
				{
					this.OnprecioProductoChanging(value);
					this.SendPropertyChanging();
					this._precioProducto = value;
					this.SendPropertyChanged("precioProducto");
					this.OnprecioProductoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_existencia", DbType="Int")]
		public System.Nullable<int> existencia
		{
			get
			{
				return this._existencia;
			}
			set
			{
				if ((this._existencia != value))
				{
					this.OnexistenciaChanging(value);
					this.SendPropertyChanging();
					this._existencia = value;
					this.SendPropertyChanged("existencia");
					this.OnexistenciaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Producto_ClienteProducto", Storage="_ClienteProducto", ThisKey="idProducto", OtherKey="idProducto")]
		public EntitySet<ClienteProducto> ClienteProducto
		{
			get
			{
				return this._ClienteProducto;
			}
			set
			{
				this._ClienteProducto.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ClienteProducto(ClienteProducto entity)
		{
			this.SendPropertyChanging();
			entity.Producto = this;
		}
		
		private void detach_ClienteProducto(ClienteProducto entity)
		{
			this.SendPropertyChanging();
			entity.Producto = null;
		}
	}
}
#pragma warning restore 1591
