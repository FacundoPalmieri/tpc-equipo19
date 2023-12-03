using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;
using Dominio;
using static System.Net.Mime.MediaTypeNames;
namespace Negocio
{
    public class CarritoNegocio
    {
        public List<Carrito> listacarrito { get; set; } = new List<Carrito>();
        public List<Articulo> Carrito { get; set; }

        public void Agregar(Articulo seleccionado, int cantidadselec)
        {
            Carrito carritoItem = new Carrito
            {
                Articulo = seleccionado,
                Cantidad = cantidadselec,
                Total = seleccionado.Precio * cantidadselec
            };

            listacarrito.Add(carritoItem);
        }

        public List<Carrito> ListarCarrito()
        {
            return listacarrito;
        }

        public decimal CalcularTotalCarrito()
        {
            decimal total = 0;
            foreach (var item in listacarrito)
            {
                total += item.Total*item.Cantidad;
            }
            return total;
        }

        

    }
}
