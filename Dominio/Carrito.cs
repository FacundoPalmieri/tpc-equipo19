﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public object style;

        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

    }
}
