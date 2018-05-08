using Android.App;
using Android.Widget;
using Android.OS;
using SCMRepartidor.Modelos;
using System.Collections.Generic;
using SCMRepartidor.Droid.Adapters;
using Android.Content;

namespace SCMRepartidor.Droid
{
    [Activity(Label = "SCM-Repartidor", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        ListView listPedidos;
        IPedidosRepository repo;
        PedidosAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            listPedidos = FindViewById<ListView>(Resource.Id.listPedidos);
            repo = new ApiPedidosRepository();
            obtenerTodosLosPedidos();
            listPedidos.ItemClick += onItemClick;        
        }

		protected override void OnResume()
		{
            base.OnResume();
            obtenerTodosLosPedidos();
		}

		private void onItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var peidoIntent = new Intent(this, typeof(PedidoDetalleActivity));
            peidoIntent.PutExtra("MyData", adapter[e.Position].PedidoID);
            StartActivity(peidoIntent);
        }

        public async void obtenerTodosLosPedidos()
        {
            Pedido pedido = new Pedido();
            List<Pedido> pedidos = await repo.ObtenerTodosLosPedidos(pedido);
            //listcatalogoProductos = productos;
            if (pedidos != null)
            {
                adapter = new PedidosAdapter(this, pedidos);
                //Asignar a la lista
                listPedidos.Adapter = adapter;
            }
            else
            {
                Toast.MakeText(this, "Error al obtener los pedidos", ToastLength.Short).Show();
            }
        }
    }
}

