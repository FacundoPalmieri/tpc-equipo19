using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MedioPagos
    {
        public int IdUsuario { get; set; }
        public List<Tarjeta> ListaDeTarjetas { get; set; }
    }
}
