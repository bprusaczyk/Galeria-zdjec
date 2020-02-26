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

namespace GaleriaAndroid
{
    class GaleriaAdapter : BaseAdapter<ObrazInfo>
    {
        List<ObrazInfo> lista = new List<ObrazInfo>();
        Activity context;

        public GaleriaAdapter(Activity context, List<ObrazInfo> items)   : base()
        {
            this.context = context;
            lista = items;
        }

        public override ObrazInfo this[int position]
        {
            get
            {
                return lista.ElementAt<ObrazInfo>(position);
            }
        }

        public override int Count
        {
            get
            {
                return lista.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = lista[position];
            View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.poleListy, null);
            }
            view.FindViewById<ImageView>(Resource.Id.zdjecie).SetImageURI(Android.Net.Uri.Parse(item.Sciezka));
            view.FindViewById<TextView>(Resource.Id.nazwaLista).Text = item.Nazwa;
            view.FindViewById<TextView>(Resource.Id.opisLista).Text = item.Opis;
            return view;
        }
    }
}