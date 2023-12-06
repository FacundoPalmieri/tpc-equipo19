using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public enum TipoUsuario
    {
        Cliente = 1,
        Administrador = 2
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Contacto { get; set; }
        public string TipoDocumento { get; set; }
        public string NDocumento { get; set; }
        public string User{ get; set; }
        public string Password { get; set; }
        public string PalabraSeguridad { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public bool Habilitado { get; set; }

        public Usuario(String user, String password, bool admin)
        {
            User = user;
            Password = password;
            TipoUsuario = admin ? TipoUsuario.Administrador : TipoUsuario.Cliente;

        }

        public Usuario() { }
        public bool EsAdministrador()
        {
            return TipoUsuario == TipoUsuario.Administrador;
        }


    }
}
