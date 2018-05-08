
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SCMRepartidor.Modelos;

namespace SCMRepartidor.Droid
{
    [Activity(Label = "PedidoDetalleActivity")]
    public class PedidoDetalleActivity : Activity
    {
        IPedidosRepository repo;
        Pedido pedidoActual;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PedidoDetalle);
            repo = new ApiPedidosRepository();
            string pedidoId = Intent.GetStringExtra("MyData") ?? "";
            pedidoActual = new Pedido();
            pedidoActual.PedidoID = pedidoId;
            obtenerPedidoActual();
            Button btnPreparar = FindViewById<Button>(Resource.Id.btnAvanzar);
            Button btnEntregar = FindViewById<Button>(Resource.Id.btnEntregar);
            Button btnCompletar = FindViewById<Button>(Resource.Id.btnCompletar);
            Button btnCancelar = FindViewById<Button>(Resource.Id.btnCancelar);

            btnPreparar.Click += BtnPreparar_Click;
            btnEntregar.Click += BtnEntregar_Click;
            btnCompletar.Click += BtnCompletar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        public async void obtenerPedidoActual(){
            pedidoActual = await repo.ObtenerPedidoPorId(pedidoActual);
            TextView tvEstado = FindViewById<TextView>(Resource.Id.tvEstado);
            TextView tvDescripcion = FindViewById<TextView>(Resource.Id.tvDescripcion);
            TextView tvFecha = FindViewById<TextView>(Resource.Id.tvFecha);
            TextView tvTelefono = FindViewById<TextView>(Resource.Id.tvTelefono);
            TextView tvLatitud = FindViewById<TextView>(Resource.Id.tvLatitud);
            TextView tvLongitud = FindViewById<TextView>(Resource.Id.tvLongitud);
            tvEstado.Text = "Estado: " + pedidoActual.Estado;
            tvDescripcion.Text = "Desc: " + pedidoActual.DescripcionProducto;
            tvFecha.Text = "Fecha: " + pedidoActual.FechaPedido;
            tvTelefono.Text = "Telefono: " + pedidoActual.Telefono;
            tvLatitud.Text = "Latitud: " + pedidoActual.Latitud;
            tvLongitud.Text = "Longitud: " + pedidoActual.Longitud;

        }

        void BtnPreparar_Click(object sender, EventArgs e)
        {
            pedidoActual.Estado = "PR";
            repo.AvanzarPedido(pedidoActual);
            Finish();
        }

        void BtnEntregar_Click(object sender, EventArgs e)
        {
            pedidoActual.Estado = "EN";
            repo.AvanzarPedido(pedidoActual);
            Finish();
        }

        void BtnCompletar_Click(object sender, EventArgs e)
        {
            pedidoActual.Estado = "CO";
            repo.AvanzarPedido(pedidoActual);
            Finish();
        }

        void BtnCancelar_Click(object sender, EventArgs e)
        {
            pedidoActual.Estado = "CA";
            repo.AvanzarPedido(pedidoActual);
            Finish();
        }

    }
}
