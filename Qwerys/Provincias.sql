Create Table PROVINCIAS(
	Id int primary key identity(1,1),
	Nombre Varchar(50)
)

Go

INSERT INTO Provincias (Nombre) VALUES ('Buenos Aires'), ('Ciudad Autónoma de Buenos Aires');
