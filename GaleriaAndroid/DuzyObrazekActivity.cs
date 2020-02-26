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
using Android.Graphics;

namespace GaleriaAndroid
{
    [Activity(Label = "DuzyObrazekActivity")]
    public class DuzyObrazekActivity : Activity
    {
        ImageView iv;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.duzyobrazek);
            iv = FindViewById<ImageView>(Resource.Id.duzyObraz);
            string sciezka = Intent.GetStringExtra("sciezka");
            iv.SetImageURI(Android.Net.Uri.Parse(sciezka));
        }
    }
}