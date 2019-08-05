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
numeroIdentidad VARCHAR(15) NOT NULL
		CONSTRAINT PK_idCliente PRIMARY KEY CLUSTERED,
nombre NVARCHAR(20) NOT NULL,
apellido NVARCHAR(20) NOT NULL,
fechaNacimiento DATE NOT NULL,
fechaCreacion DATE NOT NULL,
edad INT NOT NULL,
sexo VARCHAR(10) NOT NULL,
telefono VARCHAR(10) NOT NULL,
direccion NVARCHAR(50) NOT NULL,
correoElectronico NVARCHAR(20),
razon NVARCHAR(50) NOT NULL,
peso DECIMAL NOT NULL,
estatura DECIMAL NOT NULL,
talla DECIMAL NOT NULL,
estado VARCHAR(10) NULL,
IMC DECIMAL NOT NULL
)
GO

CREATE TABLE Persona.Usuario(
nombreUsuario NVARCHAR(20) NOT NULL
			CONSTRAINT PK_nombreUsuario PRIMARY KEY CLUSTERED,
contrasena NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE Producto.Inscripcion(
idInscripcion INT IDENTITY (100,1) NOT NULL
			CONSTRAINT PK_idInscripcion PRIMARY KEY CLUSTERED,
nombreInscripcion VARCHAR(20) NOT NULL,
precioInscripcion DECIMAL NOT NULL,
descripcion VARCHAR(50) NOT NULL
)
GO

CREATE TABLE Producto.Producto(
idProducto INT IDENTITY (1000,1) NOT NULL
			CONSTRAINT PK_idProducto PRIMARY KEY CLUSTERED,
nombreProducto VARCHAR(20),
precioProducto DECIMAL,
existencia INT NULL
)
GO


CREATE TABLE Detalle.ClienteInscripcion(
idClienteInscripcion INT IDENTITY(1,1) NOT NULL
						CONSTRAINT PK_idClienteInscripcion PRIMARY KEY CLUSTERED,
idCliente VARCHAR(15) NOT NULL,
idInscripcion INT NOT NULL,
fechaPago DATE  NULL,
fechaFinal DATE NULL,
diasRestantes INT NULL
)
GO

CREATE TABLE Detalle.ClienteProducto(
idClienteProducto INT IDENTITY(1,1) NOT NULL
						CONSTRAINT PK_idClienteProducto PRIMARY KEY CLUSTERED,
idCliente VARCHAR(15) NOT NULL,
cantidad INT NOT NULL,
idProducto INT NOT NULL,
total DECIMAL
)
GO


ALTER TABLE Detalle.ClienteProducto
	ADD CONSTRAINT
		FK_Detalle_ClienteProducto$TieneUn$Cliente_numeroIdentidad
		FOREIGN KEY (idCliente) REFERENCES Persona.Cliente(numeroIdentidad)
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
		FK_Detalle_ClienteInscripcion$TieneUn$Cliente_numeroIdentidad
		FOREIGN KEY (idCliente) REFERENCES Persona.Cliente(numeroIdentidad)
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


/*Creacion del Trigger estado*/
CREATE TRIGGER TR_EstadoCliente
ON Detalle.ClienteInscripcion FOR INSERT, UPDATE
AS 
BEGIN
DECLARE @identidad VARCHAR(15), @fechaFinal Date, @idCliente VARCHAR(15)
SELECT @idCliente = idCliente FROM Detalle.ClienteInscripcion
SELECT @fechaFinal = fechaFinal FROM Detalle.ClienteInscripcion
SELECT @identidad = numeroIdentidad FROM Persona.Cliente where numeroIdentidad = @idCliente
UPDATE Persona.Cliente SET estado = 'Activo' WHERE numeroIdentidad = @identidad
if(@fechaFinal=GETDATE()) BEGIN
UPDATE Persona.Cliente SET estado = 'Inactivo' WHERE numeroIdentidad = @identidad
END
END
GO

/*trigger Detalle.ClienteInscripcion*/





/*Creacion Trigger inscripcion
CREATE TRIGGER TR_TiempoInscripcion
ON Detalle.ClienteInscripcion FOR INSERT
AS
BEGIN
UPDATE Detalle.ClienteInscripcion SET 

ejemplo de insertar clienteInscripcion
INSERT INTO Detalle.ClienteInscripcion  VALUES ('031825',100,GETDATE(),DATEADD(DAY,10,GETDATE()),0)
GO

EXEC SP_diasRestantes

*/