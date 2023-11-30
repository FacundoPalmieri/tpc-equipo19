Use CATALOGO_P3_DB
Go


----Creci�n Tabla Paises----
Create table PAISES(
    Id int Primary Key identity(1,1),
	Nombre varchar(50) null,
)
GO

----Inserto Datos Paises----

Insert Into PAISES(Nombre) Values('Argentina')

Go


----Creci�n Tabla Provincias----
Create Table PROVINCIAS(
	Id int primary key identity(1,1),
	Nombre Varchar(50)
)

Go


----Inserto Datos Provincias----

INSERT INTO Provincias (Nombre) VALUES ('Buenos Aires'), ('Ciudad Aut�noma de Buenos Aires');

Go





----Creaci�n Tabla Ciudades----

Create Table CIUDADES (
	Id int primary key identity(1,1),
	IdProvincia int Foreign key references PROVINCIAS(Id),
	Nombre Varchar(50) 
	)

Go

----Inserto Datos Ciudades----
INSERT INTO CIUDADES (IdProvincia, Nombre) VALUES
(1, 'La Matanza'),
(1, 'Mor�n'),
(1, 'Ituzaing�'),
(1, 'Merlo'),
(1, 'Moreno'),
(1, 'Hurlingham'),
(1, 'Tres de Febrero'),
(2, 'Ciudad Aut�noma de Buenos Aires');

Go




----Creaci�n Tabla Domicilios----

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



----Creaci�n Tabla Tipos Documentos----

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





----Creaci�n Tabla Usuarios----

Create Table USUARIOS(
 Id int Primary key identity(1,1),
 Nombre Varchar(50),
 Apellido Varchar(50),
 Contacto Varchar(50),
 TipoDocumento Varchar(50),
 Ndocumento Varchar(50) unique,
 Usuario Varchar(50) unique,
 Contrase�a Varchar(50),
 TipoUsuario int,
 Habilitado Varchar(1)

)
GO



----Inserto datos Usuarios----
Insert into USUARIOS
(NDocumento, Usuario, Contrase�a, TipoUsuario, Habilitado)
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
@Contrase�a Varchar(50)
)
As
 Insert Into USUARIOS(Nombre,Apellido,TipoDocumento, Ndocumento, Contacto,Usuario,Contrase�a, 
					  TipoUsuario, Habilitado) output inserted.Id 

Values(@Nombre, @Apellido, @TipoDocumento, @NDocumento, @Contacto, @Usuario,@Contrase�a ,1, 'S')


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




