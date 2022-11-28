USE master
GO
CREATE DATABASE webapi
GO
USE webapi
go
CREATE TABLE EstadoPedido(
	IdEstado [int] NOT NULL,
	TipoEstado [varchar](50) NOT NULL,
 CONSTRAINT PK_EstadoPedido PRIMARY KEY (IdEstado)
);
GO

CREATE TABLE Pedido(
	IdPedido [int] IDENTITY(1,1) NOT NULL,
	IdProveedor [int] NOT NULL,
	IdSucursal [int] NULL,
	IdEstado [int] NOT NULL,
	Fecha [date] NULL,
	Descripcion [varchar](max) NULL,
	Monto [decimal](18, 0) NULL,
 CONSTRAINT PK_Pedido PRIMARY KEY (IdPedido)
);
GO

CREATE TABLE Proveedor(
	IdProveedor [int] IDENTITY(1,1) NOT NULL,
	Nombre [varchar](50) NULL,
	Comision [int] NOT NULL,
 CONSTRAINT PK_Proveedor PRIMARY KEY (IdProveedor)
 );
GO
CREATE TABLE Provincia(
	IdProvincia [int] IDENTITY(1,1) NOT NULL,
	Nombre [varchar](50) NOT NULL,
 CONSTRAINT PK_Provincia PRIMARY KEY (IdProvincia)
 ); 
GO

CREATE TABLE ProvSuc(
	IdProveedor [int] NOT NULL,
	IdSucursal [int] NOT NULL,
 CONSTRAINT PK_ProvSuc PRIMARY KEY (IdProveedor,IdSucursal)
);
GO

CREATE TABLE Sucursal(
	IdSucursal [int] IDENTITY(1,1) NOT NULL,
	Calle [varchar](50) NOT NULL,
	Numero [int] NOT NULL,
	Localidad [varchar](50) NOT NULL,
	IdProvincia [int] NOT NULL,
 CONSTRAINT PK_Sucursal PRIMARY KEY (IdSucursal)
 );
GO

CREATE TABLE Usuario(
	Id [int] IDENTITY(1,1) NOT NULL,
	[User] [varchar](50) Unique NOT NULL,
	Pass [varchar](50) NOT NULL,
	IdProveedor [int] NOT NULL,
 CONSTRAINT PK_Usuario PRIMARY KEY (Id)
 );
GO

ALTER TABLE Pedido ADD  CONSTRAINT FK_Pedido_EstadoPedido FOREIGN KEY(IdEstado)
REFERENCES EstadoPedido (IdEstado)
GO
ALTER TABLE Pedido ADD  CONSTRAINT FK_Pedido_ProvSuc FOREIGN KEY(IdProveedor, IdSucursal)
REFERENCES ProvSuc (IdProveedor, IdSucursal)
GO
ALTER TABLE ProvSuc ADD  CONSTRAINT FK_ProvSuc_Proveedor FOREIGN KEY(IdProveedor)
REFERENCES Proveedor (IdProveedor)
GO
ALTER TABLE ProvSuc ADD  CONSTRAINT FK_ProvSuc_Sucursal FOREIGN KEY(IdSucursal)
REFERENCES Sucursal (IdSucursal)
GO
ALTER TABLE Sucursal ADD  CONSTRAINT FK_Sucursal_Provincia FOREIGN KEY(IdProvincia)
REFERENCES Provincia (IdProvincia)
GO
ALTER TABLE Usuario  WITH CHECK ADD  CONSTRAINT FK_Usuario_Proveedor FOREIGN KEY(IdProveedor)
REFERENCES Proveedor (IdProveedor)

