using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Dominio
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
