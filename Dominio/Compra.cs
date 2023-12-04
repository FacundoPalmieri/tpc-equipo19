using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public List<Articulo> ListaDeArticulos { get; set; }
        public decimal PrecioTotal { get; set; }
        public string MedioPago { get; set; }
        public int Orden { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Piso { get; set; }
        public string Depto { get; set; }

    }
}
