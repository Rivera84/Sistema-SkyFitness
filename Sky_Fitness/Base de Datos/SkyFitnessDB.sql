USE tempdb
GO

CREATE DATABASE Sky_FitnessDB
GO

USE Sky_FitnessDB
GO

CREATE SCHEMA Persona
GO

CREATE SCHEMA Producto
GO

CREATE TABLE Persona.Cliente(
numeroIdentidad INT NOT NULL
		CONSTRAINT PK_idCliente PRIMARY KEY CLUSTERED,
nombre NVARCHAR(20) NOT NULL,
apellido NVARCHAR(20) NOT NULL,
fechaNacimiento DATE NOT NULL,
fechaCreacion DATE NOT NULL,
edad INT NOT NULL,
telefono INT NOT NULL,
direccion NVARCHAR(50) NOT NULL,
correoElectronico NVARCHAR(20),
razon NVARCHAR(50) NOT NULL,
peso DECIMAL NOT NULL,
medidas DECIMAL NOT NULL
)
GO

CREATE TABLE Persona.Usuario(
nombreUsuario NVARCHAR(20) NOT NULL
			CONSTRAINT PK_nombreUsuario PRIMARY KEY CLUSTERED,
constrasena NVARCHAR NOT NULL
)
GO

CREATE TABLE Producto.Inscripcion(
idInscripcion INT IDENTITY (100,1) NOT NULL
			CONSTRAINT PK_idInscripcion PRIMARY KEY CLUSTERED,
nombreInscripcion VARCHAR(20),
precioInscripcion DECIMAL
)
GO

CREATE TABLE Producto.producto(
idProducto INT IDENTITY (1000,1) NOT NULL
			CONSTRAINT PK_idProducto PRIMARY KEY CLUSTERED,
nombreProducto VARCHAR(20),
precioProducto DECIMAL
)
GO
