Use CATALOGO_P3_DB
Go

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

Insert into USUARIOS
(NDocumento, Usuario, Contraseña, TipoUsuario, Habilitado)
Values(2,'Admin@gmail.com','2',2,'S'),
	  (1,'Cliente@gmail.com','1',1,'S');

Go


Select * from USUARIOS