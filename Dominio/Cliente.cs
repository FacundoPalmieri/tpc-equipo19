using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : UsuarioAdm
    {
        public int Id { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public Domicilio Domicilio { get; set; }
        public char Sexo { get; set; }
        public string Telefono { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }    




    }
}
