using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tarjeta
    {
        public int IdUsuario { get; set; }
        public char TipoTarjeta { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Banco { get; set; }
        public string MarcaTarjeta { get; set; }
        public bool Estado { get; set; }
    }
}
