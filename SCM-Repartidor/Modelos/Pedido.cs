﻿using System;
namespace SCMRepartidor.Modelos
{
    public class Pedido
    {
        public string PedidoID { get; set; }
        public string Cliente { get; set; }
        public string Telefono { get; set; }
        public string Producto { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal Precio { get; set; }
        public string DescripcionProducto { get; set; }
        public string Estado { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
