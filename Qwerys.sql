Use CATALOGO_P3_DB
Go


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

INSERT INTO Provincias (Nombre) VALUES ('Buenos Aires'), ('Ciudad Autónoma de Buenos Aires');

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

----SP Registro USUARIO----
Create Procedure RegistrarUsuario(
@Nombre Varchar(50),
@Apellido Varchar(50),
@TipoDocumento Varchar(3),
@NDocumento varchar(50),
@Contacto varchar(50),
@Usuario Varchar(50),
@Contraseña Varchar(50)
)
As
 Insert Into USUARIOS(Nombre,Apellido,TipoDocumento, Ndocumento, Contacto,Usuario,Contraseña, 
					  TipoUsuario, Habilitado) output inserted.Id 

Values(@Nombre, @Apellido, @TipoDocumento, @NDocumento, @Contacto, @Usuario,@Contraseña ,1, 'S')


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
	Insert Into DOMICILIOS(IdUsuario, Pais, Provincia, Ciudad, Calle, Altura, Piso, Depto) output inserted.Id Values(@IdUsuario, @Pais, @Provincia, @Ciudad, @Calle, @Altura,@Piso,@Depto)

Go




