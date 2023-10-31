using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public int IdUsuario { get; set; }
        public List<Articulo> ListaDeArticulos { get; set; }
        public decimal PrecioTotal { get; set; }
        public int Orden { get; set; }
        public DateTime FechaCompra { get; set; }
        public bool Estado { get; set; }
    }
}
