using System;
namespace NegocioRepartidorApp
{
    public class Pedido
    {


        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public int Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public int Estado { get; set; }
        public int Total { get; set; }
        }
    }

//PedidoID, cliente, telefono, producto, estado,