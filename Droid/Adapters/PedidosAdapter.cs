using System;
using System.Collections.Generic;
using System.Net;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using SCMRepartidor.Modelos;

namespace SCMRepartidor.Droid.Adapters
{
    public class PedidosAdapter : BaseAdapter<Pedido>
    {
        private Activity context;
        private List<Pedido> items;
        IPedidosRepository repo;

        public PedidosAdapter(Activity context, List<Pedido> items)
        {
            this.context = context;
            this.items = items;
            repo = new ApiPedidosRepository();
        }

        public override Pedido this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.itemPedidos, null);
            view.FindViewById<TextView>(Resource.Id.tvEstatus).Text = "Estatus: " + item.Estado;
            view.FindViewById<TextView>(Resource.Id.tvFecha).Text = "Fecha del pedido: " + item.FechaPedido.ToString();
            view.FindViewById<TextView>(Resource.Id.tvTelefono).Text = "Telefono: " + item.Telefono;
            view.FindViewById<TextView>(Resource.Id.tvLatitud).Text = "Latitud: " + item.Latitud;
            view.FindViewById<TextView>(Resource.Id.tvLongitud).Text = "Longitud: " + item.Longitud;
            if (item.Estado.Equals("CA"))
            {
                view.FindViewById<TextView>(Resource.Id.tvEstatus).SetTextColor(Color.Red);
            }
            else if (item.Estado.Equals("CO"))
            {
                view.FindViewById<TextView>(Resource.Id.tvEstatus).SetTextColor(Color.Green);
            }
            else if (item.Estado.Equals("PR"))
            {
                view.FindViewById<TextView>(Resource.Id.tvEstatus).SetTextColor(Color.Yellow);
            }
            else if(item.Estado.Equals("EN"))
            {
                view.FindViewById<TextView>(Resource.Id.tvEstatus).SetTextColor(Color.Blue);
            }
            else{
                view.FindViewById<TextView>(Resource.Id.tvEstatus).SetTextColor(Color.White);
            }
            /*Button btnCancelar = view.FindViewById<Button>(Resource.Id.btnCancelarPedido);
            btnCancelar.Click += delegate {
                mostrarDialogoCancelar(item);
            };*/
            return view;
        }

        /*private void mostrarDialogoCancelar(Pedido item)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(context);
            alert.SetTitle("Confirmar pedido");
            alert.SetMessage("Desea cancelar el pedido seleccionado?");
            alert.SetPositiveButton("Cancelar pedido", (senderAlert, args) => {
                item.Estado = "CA";
                repo.ActualizarEstadoPedido(item);
                Toast.MakeText(context, "Cancelado!", ToastLength.Short).Show();
                context.Finish();
            });

            alert.SetNegativeButton("Continuar pedido", (senderAlert, args) => {
                //Toast.MakeText(context, "", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }*/

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

    }
}