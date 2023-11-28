Create Table CIUDADES (
	Id int primary key identity(1,1),
	IdProvincia int Foreign key references PROVINCIAS(Id),
	Nombre Varchar(50) 
	)

Go

INSERT INTO CIUDADES (IdProvincia, Nombre) VALUES
(1, 'La Matanza'),
(1, 'Morón'),
(1, 'Ituzaingó'),
(1, 'Merlo'),
(1, 'Moreno'),
(1, 'Hurlingham'),
(1, 'Tres de Febrero'),
(2, 'Ciudad Autónoma de Buenos Aires');

