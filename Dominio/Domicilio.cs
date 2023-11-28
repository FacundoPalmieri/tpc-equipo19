using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Domicilio
    {
        public string Nacionalidad { get; set; }
        public string Provincia { get; set; }
        public string Partido { get; set; }
        public string Localidad { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int Piso { get; set; }
        public char Departamento { get; set; }
        public string Interseccion1 { get; set; }
        public string Interseccion2 { get; set; }
        public string Observaciones { get; set; }
    }
}
