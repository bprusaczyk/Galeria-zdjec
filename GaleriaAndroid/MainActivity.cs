using Android.App;
using Android.Widget;
using Android.OS;
using Android;
using Android.Content;
using System.Collections.Generic;
using Android.Runtime;

namespace GaleriaAndroid
{
    [Activity(Label = "GaleriaAndroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button dodaj;
        ListView lv;
        List<ObrazInfo> obrazy = new List<ObrazInfo>();
        GaleriaAdapter ga;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            dodaj = FindViewById<Button>(Resource.Id.dodaj);
            lv = FindViewById<ListView>(Resource.Id.listaMain);
            dodaj.Click += Dodaj_Click;
            ga = new GaleriaAdapter(this, obrazy);
            lv.Adapter = ga;
            lv.ItemClick += Lv_ItemClick;
        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(DuzyObrazekActivity));
            string sciezka = obrazy[e.Position].Sciezka;
            i.PutExtra("sciezka", sciezka);
            StartActivity(i);
        }

        private void Dodaj_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(Dodawanie));
            StartActivityForResult(i, 0);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                string sciezka = data.GetStringExtra("sciezka");
                string nazwa = data.GetStringExtra("nazwa");
                string opis = data.GetStringExtra("opis");
                obrazy.Add(new ObrazInfo { Nazwa = nazwa, Opis = opis, Sciezka = sciezka });
                ga.NotifyDataSetChanged();
            }
        }
    }
}

