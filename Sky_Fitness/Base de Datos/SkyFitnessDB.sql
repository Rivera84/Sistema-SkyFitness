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

CREATE SCHEMA Detalle
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


CREATE TABLE Detalle.ClienteInscripcion(
idClienteInscripcion INT IDENTITY(1,1) NOT NULL
						CONSTRAINT PK_idClienteInscripcion PRIMARY KEY CLUSTERED,
nombreUsuario NVARCHAR(20) NOT NULL,
numeroIdentidad INT NOT NULL,
idInscripcion INT NOT NULL
)
GO

CREATE TABLE Detalle.ClienteProducto(
idClienteProducto INT IDENTITY(1,1) NOT NULL
						CONSTRAINT PK_idClienteProducto PRIMARY KEY CLUSTERED,
nombreUsuario NVARCHAR(20) NOT NULL,
idProducto INT NOT NULL
)
GO


ALTER TABLE Detalle.ClienteProducto
	ADD CONSTRAINT
		FK_Detalle_ClienteProducto$TieneUn$nombre_Usuario
		FOREIGN KEY (nombreUsuario) REFERENCES Persona.Usuario(nombreUsuario)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION
GO

ALTER TABLE Detalle.ClienteProducto
	ADD CONSTRAINT
		FK_Detalle_ClienteProducto$TieneUn$producto
		FOREIGN KEY (idProducto) REFERENCES Producto.producto(idProducto)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION
GO

ALTER TABLE Detalle.ClienteInscripcion
	ADD CONSTRAINT
		FK_Detalle_ClienteInscripcion$TieneUn$nombre_Usuario
		FOREIGN KEY (nombreUsuario) REFERENCES Persona.Usuario(nombreUsuario)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION
GO




ALTER TABLE Detalle.ClienteInscripcion
	ADD CONSTRAINT
		FK_Detalle_ClienteInscripcion$TieneUn$nuemroIdentidad
		FOREIGN KEY (numeroIdentidad) REFERENCES Persona.Cliente(numeroIdentidad)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION
GO


ALTER TABLE Detalle.ClienteInscripcion
	ADD CONSTRAINT
		FK_Detalle_ClienteInscripcion$TieneUn$idInscripcion
		FOREIGN KEY (idInscripcion) REFERENCES Producto.Inscripcion(idInscripcion)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION
GO