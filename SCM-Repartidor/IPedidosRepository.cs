using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SCMRepartidor.Modelos;

namespace SCMRepartidor
{
    public interface IPedidosRepository
    {
        Task<List<Pedido>> ObtenerTodosLosPedidos(Pedido pedido);
        Task<List<Pedido>> LeerPedidosActivos(Pedido pedido);
        Task<bool> AvanzarPedido(Pedido pedido);
        Task<Pedido> ObtenerPedidoPorId(Pedido pedido);
    }
}
