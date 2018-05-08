﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using SCMRepartidor.Modelos;

namespace SCMRepartidor
{
    public class ApiPedidosRepository : IPedidosRepository
    {

        HttpClient client;
        private readonly string ApiLocation = @"https://scm-pizzas.azurewebsites.net/api/";
        public ApiPedidosRepository()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Pedido>> ObtenerTodosLosPedidos(Pedido pedido)
        {
            var uri = new Uri(string.Format(ApiLocation + "Pedidos/ObtenerTodosLosPedidos", string.Empty));
            var json = JsonConvert.SerializeObject(pedido);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<List<Pedido>>(content);
                return lista;
            }
            return null;
        }

        public async Task<List<Pedido>> LeerPedidosActivos(Pedido pedido)
        {
            var uri = new Uri(string.Format(ApiLocation + "Pedidos/PedidosPorEstado", string.Empty));
            var json = JsonConvert.SerializeObject(pedido);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<List<Pedido>>(content);
                return lista;
            }
            return null;
        }

        public async Task<bool> AvanzarPedido(Pedido solicitud)
        {
            var uri = new Uri(string.Format(ApiLocation + "Pedidos/ActualizarEstadoPedido", string.Empty));
            var json = JsonConvert.SerializeObject(solicitud);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                //var lista = JsonConvert.DeserializeObject<List<Pedido>>(resultado);

                return true;
            }
            return false;
        }

        public async Task<Pedido> ObtenerPedidoPorId(Pedido solicitud)
        {
            var uri = new Uri(string.Format(ApiLocation + "Pedidos/PedidoPorId", string.Empty));
            var json = JsonConvert.SerializeObject(solicitud);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<Pedido>(resultado);

                return lista;
            }
            return null;
        }
            /*public async Task<List<Pedido>> LeerProductos()
    {
       var uri = new Uri(string.Format(ApiLocation + "Productos", string.Empty));
       var response = await client.GetAsync(uri);
       if (response.IsSuccessStatusCode)
       {
           var content = await response.Content.ReadAsStringAsync();
           var lista = JsonConvert.DeserializeObject<List<Producto>>(content);

           return lista;
       }
       return null;
    }

    public async Task<List<Pedido>> LeerTodosPedidosPorTelefono(Pedido solicitud)
    {
       var uri = new Uri(string.Format(ApiLocation + "Pedidos/PedidosPorTelefono", string.Empty));
       var json = JsonConvert.SerializeObject(solicitud);
       var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
       var response = await client.PostAsync(uri, stringContent);
       if (response.IsSuccessStatusCode)
       {
           var resultado = await response.Content.ReadAsStringAsync();
           var lista = JsonConvert.DeserializeObject<List<Pedido>>(resultado);

           return lista;
       }
       return null;
    }

    public async Task<bool> ActualizarEstadoPedido(Pedido solicitud)
    {
       var uri = new Uri(string.Format(ApiLocation + "Pedidos/ActualizarEstadoPedido", string.Empty));
       var json = JsonConvert.SerializeObject(solicitud);
       var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
       var response = await client.PostAsync(uri, stringContent);
       if (response.IsSuccessStatusCode)
       {
           var resultado = await response.Content.ReadAsStringAsync();
           //var lista = JsonConvert.DeserializeObject<List<Pedido>>(resultado);

           return true;
       }
       return false;
    }

    public async Task<bool> RegistrarPedido(Pedido pedido)
    {
       var uri = new Uri(string.Format(ApiLocation + "Pedidos/insertarPedido", string.Empty));
       var json = JsonConvert.SerializeObject(pedido);
       var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
       var response = await client.PostAsync(uri, stringContent);
       if (response.IsSuccessStatusCode)
       {
           var resultado = await response.Content.ReadAsStringAsync();
           //var lista = JsonConvert.DeserializeObject<List<Pedido>>(resultado);

           return true;
       }
       return false;
    }*/
        }
    }
