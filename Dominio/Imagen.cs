using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public int Id { get; set; }
        public int IdCodigoArticulo { get; set; }
        public string ImagenUrl { get; set; }
        public List<string> ListaDeImagenes { get; set; }
    
        public Imagen()
        {

        }
        

        public static implicit operator Imagen(string v)
        {
            throw new NotImplementedException();
        }


        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();

            lista.Add(this);

            return lista;
        }
    }
}
