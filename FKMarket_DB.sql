USE master
GO

CREATE DATABASE FKMarket
GO

USE FKMarket
GO

CREATE TABLE [dbo].[MARCAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	CONSTRAINT [PK_MARCAS] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CATEGORIAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ARTICULOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	[IdMarca] [int] NULL,
	[IdCategoria] [int] NULL,
	[Precio] [money] NULL,
	CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[IMAGENES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdArticulo] [int] NOT NULL,
	[ImagenUrl] [varchar](1000) NOT NULL,
	CONSTRAINT [PK_IMAGENES] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO

insert into MARCAS values ('Samsung'), ('Apple'), ('Sony'), ('Huawei'), ('Motorola')
insert into CATEGORIAS values ('Celulares'),('Televisores'), ('Media'), ('Audio')
insert into ARTICULOS values ('S01', 'Galaxy S10', 'Un teléfono inteligente de alta gama con características premium.', 1, 1, 149999),
('M03', 'Moto G Play 7ma Gen', 'Un teléfono confiable y económico para uso diario.', 1, 5, 156999),
('S99', 'PlayStation 4', 'Consola de videojuegos líder en entretenimiento.', 3, 3, 749000),
('S56', 'Sony Bravia 55', 'Televisor con una calidad de imagen excepcional y funciones avanzadas.', 3, 2, 149500),
('A23', 'Apple TV', 'Dispositivo de streaming para disfrutar contenido multimedia.', 2, 3, 607850),
('I12', 'iPad Pro 12.9"', 'Tablet potente y versátil para usuarios exigentes.', 2, 4, 455000),
('N78', 'Nintendo Switch', 'Consola híbrida para jugar en casa o en movimiento.', 3, 5, 250000),
('L45', 'Logitech MX Master 3', 'Ratón ergonómico de alto rendimiento para trabajo profesional.', 1, 8, 20000),
('P32', 'PlayStation 5', 'La última generación de la consola de videojuegos de Sony con gráficos de alta calidad.', 3, 3, 999999),
('I11', 'iPhone 13 Pro', 'Teléfono inteligente de Apple con cámara de última generación y potente rendimiento.', 2, 1, 489999),
('L72', 'Lenovo ThinkPad X1 Carbon', 'Portátil ultraligero y potente para usuarios profesionales.', 1, 2, 320000),
('G84', 'GoPro Hero 10 Black', 'Cámara de acción líder en su segmento con calidad de video 5K.', 1, 4, 328999),
('S70', 'Samsung Odyssey G9', 'Monitor curvo ultraancho para gaming con alta tasa de refresco.', 3, 2, 189999);

insert into imagenes values
(1,'https://images.samsung.com/is/image/samsung/co-galaxy-s10-sm-g970-sm-g970fzyjcoo-frontcanaryyellow-thumb-149016542'),
(2, 'https://www.motorola.cl/arquivos/moto-g7-play-img-product.png?v=636862863804700000'),
(2, 'https://i.blogs.es/9da288/moto-g7-/1366_2000.jpg'),
(3, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTFXkzTPbdp9VHDCQwaZFUf9Ms2u0YX6eg_ej7NJbibvmxtYmV98xIWZmLJJ3xqAtZfa1U&usqp=CAU'),
(4, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTsP5f7O_PK0U79gMo6RtKkn124-t3NS6qMxw&usqp=CAU'),
(5, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTLuaVcaE1HuWslffp41aLpQQzjmCEgPjLetg&usqp=CAU'),
(6, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRgzNZRL6xv6qTbKsqL__2wMNHOiENdrtRGAw&usqp=CAU'),
(7, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcStVtPMEtD4kDBowwp7DWsfgjlzaio52VcazQ&usqp=CAU'),
(7, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSJ6t-WQc4sYO2Fx9cS-Hof72qEK-HSi_rpJQ&usqp=CAU'),
(8, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRwQgbgwoO2rogEhVUF_ob92dqABTlLeCBq6Q&usqp=CAU'),
(8, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQCDqd169MtK8rw9kDYgWXMpxG0iD1fvINbFw&usqp=CAU'),
(9, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAFFKYbp3rJCOFq81FYEY9yTujdCGdLh34Aw&usqp=CAU '),
(10,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTzyKglwZzON9HzlcwguS5fgtqTgZLdW0ZvA&usqp=CAU'),
(11,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJ2-HH_qaKa3QNFw-J-sPqLu7sY1nSjUhiKQ&usqp=CAU'),
(12,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQHWyuT9Z41ykEM-EvonneLvtS3wpsTSjUGOQ&usqp=CAU'),
(12,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRhKM2poHbCSJSw-F2fNFmBEaDTG9upetyEWw&usqp=CAU'),
(13,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRmcgYs8CUEfoWMhTyvPwJCBGe3ZcP1igf91Q&usqp=CAU')

go

----Creción Tabla Paises----
Create table PAISES(
    Id int Primary Key identity(1,1),
	Nombre varchar(50) null,
)
GO

----Inserto Datos Paises----

Insert Into PAISES(Nombre) Values('Argentina')

Go


----Creción Tabla Provincias----
Create Table PROVINCIAS(
	Id int primary key identity(1,1),
	Nombre Varchar(50)
)

Go


----Inserto Datos Provincias----

INSERT INTO PROVINCIAS (Nombre) VALUES ('Buenos Aires'), ('Ciudad Autónoma de Buenos Aires');

Go


----Creación Tabla Ciudades----

Create Table CIUDADES (
	Id int primary key identity(1,1),
	IdProvincia int Foreign key references PROVINCIAS(Id),
	Nombre Varchar(50) 
	)

Go

----Inserto Datos Ciudades----
INSERT INTO CIUDADES (IdProvincia, Nombre) VALUES
(1, 'La Matanza'),
(1, 'Morón'),
(1, 'Ituzaingó'),
(1, 'Merlo'),
(1, 'Moreno'),
(1, 'Hurlingham'),
(1, 'Tres de Febrero'),
(2, 'Ciudad Autónoma de Buenos Aires');

Go


----Creación Tabla Domicilios----

Create Table DOMICILIOS(
	Id int Primary Key identity(1,1),
	IdUsuario int,
	Pais Varchar(50),
	Provincia Varchar (50),
	Ciudad Varchar(50),
	Calle Varchar(50),
	Altura int,
	Piso Varchar(2),
	Depto Varchar(1)
)

Go

----Creación Tabla Tipos Documentos----

CREATE TABLE TIPOSDOCUMENTOS (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(50) UNIQUE
);


----Inserto Datos Tipos Documentos----

INSERT INTO TIPOSDOCUMENTOS (Id, Nombre)
VALUES 
    (1, 'DNI'),
    (2, 'PAS'),
    (3, 'LC'),
	(4, 'LE');


----Creación Tabla Usuarios----

Create Table USUARIOS(
 Id int Primary key identity(1,1),
 Nombre Varchar(50),
 Apellido Varchar(50),
 Contacto Varchar(50),
 TipoDocumento Varchar(50),
 Ndocumento Varchar(50) unique,
 Usuario Varchar(50) unique,
 Contraseña Varchar(50),
 PalabraSeguridad varchar(50),---------------------------
 TipoUsuario int,
 Habilitado Varchar(1)

)
GO


----Inserto datos Usuarios----
Insert into USUARIOS
(NDocumento, Usuario, Contraseña, TipoUsuario, Habilitado)
Values(2,'Admin@gmail.com','2',2,'S'),
	  (1,'Cliente@gmail.com','1',1,'S');

Go


----Creación Tabla Entrega----
Create Table TIPOSENTREGA(

	Id int identity (1,1),
	Nombre Varchar(50) null,
	Costo Money null,
	Habilitado Varchar(1)
)
Go


----Inserto datos Tipo Entrega----
Insert into TIPOSENTREGA(Nombre, Costo, Habilitado)
Values('Retiro en Local', 0, 'S'),
      ('Envío CABA', 1000, 'S'),
	  ('Envío GBA', 1500, 'S')

Go



---- Crea Tabla COMPRAS----
Create table COMPRAS(
    Id int Primary Key identity(1,1),
	IdUsuario int Foreign key references USUARIOS(Id) not null,
	PrecioVenta money,
	CostoEnvio money,
	PrecioTotal money,
	MetodoEntrega Varchar(50),
	MedioPago varchar (50),
	FechaCompra date, 
	Estado varchar(30),
	Pais Varchar(50),
	Provincia Varchar (50),
	Ciudad Varchar(50),
	Calle Varchar(50),
	Altura int,
	Piso Varchar(2),
	Depto Varchar(1)
	
)
GO

---- Crea Tabla MediosPago----
Create table MEDIOSPAGO(
    Id int Primary Key identity(1,1),
	Nombre Varchar (50)
)
GO

INSERT INTO MEDIOSPAGO (Nombre)
VALUES ('Tarjeta Débito')

INSERT INTO MEDIOSPAGO (Nombre)
VALUES ('Transferencia ')

INSERT INTO MEDIOSPAGO (Nombre)
VALUES ('Efectivo')

INSERT INTO MEDIOSPAGO (Nombre)
VALUES ('Mercado pago (Dinero en cuenta)')



Create table DETALLESCOMPRAS(

 Id int identity (1,1),
 IdCompra int foreign key References Compras(Id),
 IdArticulo int,
 Cantidad int,
 Precio Money

)
Go

CREATE TABLE ESTADOCOMPRA(
	Id int identity (1,1),
	Estado varchar(30)
)
Go
INSERT INTO ESTADOCOMPRA(Estado)
VALUES('Pendiente de pago')

INSERT INTO ESTADOCOMPRA(Estado)
VALUES('Pendiente de envio')

INSERT INTO ESTADOCOMPRA(Estado)
VALUES('Cancelado')

INSERT INTO ESTADOCOMPRA(Estado)
VALUES('Finalizada')

Go

----SP Registro USUARIO----
Create Procedure RegistrarUsuario(
@Nombre Varchar(50),
@Apellido Varchar(50),
@TipoDocumento Varchar(3),
@NDocumento varchar(50),
@Contacto varchar(50),
@Usuario Varchar(50),
@Contraseña Varchar(50),
@PalabraSeguridad varchar(50)---------------------------------------------
)
As
 Insert Into USUARIOS(Nombre,Apellido,TipoDocumento, Ndocumento, Contacto,Usuario,Contraseña,PalabraSeguridad,
					  TipoUsuario, Habilitado) output inserted.Id 

Values(@Nombre, @Apellido, @TipoDocumento, @NDocumento, @Contacto, @Usuario,@Contraseña,@PalabraSeguridad ,'1', 'S')


Go



----SP Registro DOMICILIO----

Create Procedure RegistrarDomicilio(
@IdUsuario int,
@Pais Varchar(50),
@Provincia Varchar(50),
@Ciudad Varchar(50),
@Calle Varchar(50),
@Altura int,
@Piso int,
@Depto Varchar(50)

)
As
	Insert Into DOMICILIOS(IdUsuario, Pais, Provincia, Ciudad, Calle, Altura, Piso, Depto) 
	output inserted.Id 
	Values(@IdUsuario, @Pais, @Provincia, @Ciudad, @Calle, @Altura,@Piso,@Depto)

Go


---- SP ACTUALIZAR DOMICILIO -----
Create Procedure ActualizarDomicilio(
@IdUsuario int,
@Pais Varchar(50),
@Provincia Varchar(50),
@Ciudad Varchar(50),
@Calle Varchar(50),
@Altura int,
@Piso int,
@Depto Varchar(50)

)
As
	Update DOMICILIOS Set Pais = @Pais where IdUsuario = @IdUsuario
	Update DOMICILIOS Set Provincia = @Provincia where IdUsuario = @IdUsuario
	Update DOMICILIOS Set Ciudad = @Ciudad where IdUsuario = @IdUsuario
	Update DOMICILIOS Set Calle = @Calle where IdUsuario = @IdUsuario
	Update DOMICILIOS Set Altura = @Altura where IdUsuario = @IdUsuario
	Update DOMICILIOS Set Piso = @Piso where IdUsuario = @IdUsuario
	Update DOMICILIOS Set Depto = @Depto where IdUsuario = @IdUsuario

Go



----SP Agregar Compra----

Create Procedure RegistrarCompra(
@IdUsuario int,
@PrecioVenta money,
@CostoEnvio money,
@PrecioTotal Money,
@MetodoEntrega varchar (50),
@MedioPago varchar(50),
@FechaCompra Datetime,
@Estado varchar(50),
@Pais varchar (50),
@Provincia Varchar(50),
@Ciudad Varchar(50),
@Calle Varchar(50),
@Altura int,
@Piso int,
@Depto Varchar(50)
)
As

	Insert into COMPRAS(IdUsuario,PrecioVenta,CostoEnvio,PrecioTotal,MetodoEntrega,MedioPago, FechaCompra, Estado, Pais, Provincia, Ciudad, Calle,Altura, Piso, Depto)
	output inserted.Id 
	Values(@IdUsuario,@PrecioVenta,@CostoEnvio,@PrecioTotal,@MetodoEntrega,@MedioPago, @FechaCompra, @Estado, @Pais, @Provincia, @Ciudad, @Calle, @Altura,@Piso,@Depto)

Go


----SP DETALLE COMPRAS----
Create Procedure RegistrarDetalleCompra(
@IdCompra int,
@IdArticulo int ,
@Cantidad int,
@Precio money
)
As

	Insert into DETALLESCOMPRAS(IdCompra, IdArticulo,Cantidad,Precio) 
	Values(@IdCompra, @IdArticulo, @Cantidad, @Precio * @Cantidad)

Go


----SP ActualizarDatosUsuarios----
Create Procedure ActualizarDatosUsuario(
@IdUsuario int,
@Contacto varchar(50) ,
@Provincia varchar(50),
@Ciudad varchar(50),
@Calle Varchar(50),
@Altura int,
@Piso Varchar(2),
@Depto Varchar(50)
)
As
	Update USUARIOS Set Contacto = @Contacto Where Id = @IdUsuario

	Update DOMICILIOS Set Provincia = @Provincia Where IdUsuario = @IdUsuario
    Update DOMICILIOS Set Ciudad = @Ciudad Where IdUsuario = @IdUsuario
	Update DOMICILIOS Set Calle = @Calle Where IdUsuario = @IdUsuario
	Update DOMICILIOS Set Altura = @Altura Where IdUsuario = @IdUsuario
	Update DOMICILIOS Set Piso = @Piso Where IdUsuario = @IdUsuario
	Update DOMICILIOS Set Depto = @Depto Where IdUsuario = @IdUsuario
	
	
Go


   
