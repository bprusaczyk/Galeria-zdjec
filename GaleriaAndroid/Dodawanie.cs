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
using Android;

namespace GaleriaAndroid
{
    [Activity(Label = "Dodawanie")]
    public class Dodawanie : Activity
    {
        Button wybierz;
        Button dodaj;
        TextView sciezkaPliku;
        EditText nazwaPole;
        EditText opisPole;
        public static readonly int PickImageId = 1000;
        private string sciezka;
        private string nazwa;
        private string opis;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dodawanie);
            // Create your application here
            wybierz = FindViewById<Button>(Resource.Id.wybierz);
            dodaj = FindViewById<Button>(Resource.Id.dodaj);
            sciezkaPliku = FindViewById<TextView>(Resource.Id.sciezkaPliku);
            nazwaPole = FindViewById<EditText>(Resource.Id.nazwa);
            opisPole = FindViewById<EditText>(Resource.Id.opis);
            wybierz.Click += Wybierz_Click;
            dodaj.Click += Dodaj_Click;
        }

        private void Dodaj_Click(object sender, EventArgs e)
        {
            if(sciezka==null || sciezka.Equals(string.Empty))
            {
                Toast.MakeText(Application.Context, "Wybierz obraz", ToastLength.Long).Show();
                return;
            }
            nazwa = nazwaPole.Text;
            opis = opisPole.Text;
            Intent i = new Intent(this, typeof(MainActivity));
            i.PutExtra("sciezka", sciezka);
            i.PutExtra("nazwa", nazwa);
            i.PutExtra("opis", opis);
            SetResult(Result.Ok, i);
            Finish();
        }

        private void Wybierz_Click(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                sciezkaPliku.Text = uri.ToString();
                sciezka = uri.ToString();
            }
        }
    }
}
