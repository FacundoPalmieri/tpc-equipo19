Alter Procedure RegistrarUsuario(
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



