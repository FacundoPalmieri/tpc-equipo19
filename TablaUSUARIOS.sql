Use CATALOGO_P3_DB
Go

Create Table USUARIOS(
	Id Int Not Null Primary key Identity (1,1),
	Usuario Varchar(100) Not Null unique,
	Contraseña Varchar(100) Not Null,
	TipoUsuario int Not Null,
	Estado bit Not Null
);

Go

