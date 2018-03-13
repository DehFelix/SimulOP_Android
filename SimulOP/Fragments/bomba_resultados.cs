using System;
using System.Collections.Generic;
using SimulOP.Core;

using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;

using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Text;
using Android.Widget;

namespace SimulOP.Fragments
{
    class bomba_resultados : SupportFragment
    {
        private TextView resultado;
        private View view;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static bomba_resultados NewInstance()
        {
            return new bomba_resultados { Arguments = new Bundle() };
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.bomba_resultados, container, false);

            // Inputs
            Button btnCalcula = view.FindViewById<Button>(Resource.Id.btnBombaCalcula1);
            resultado = view.FindViewById<TextView>(Resource.Id.textBombaResultados1);

            // Event handler para o click
            btnCalcula.Click += BtnCalcula_Click;

            return view;
        }

        private void BtnCalcula_Click(object sender, EventArgs e)
        {
            MainActivity main = (MainActivity)this.Activity;

            main.Tubulacao.ListaSingulariedades = new List<Singularidade> { main.Singularidade };

            main.Bomba = new Bomba(new double[] { 0, main.EqBomba[0], main.EqBomba[1], main.EqBomba[2] }, main.Fluido, main.Tubulacao);

            main.Bomba.CalculaVazao();

            resultado.Text = "Calculado: " + (main.Bomba.Vazao * 3600).ToString() +"m^3";

            Snackbar.Make(view, "Calculado", Snackbar.LengthLong)
                .SetAction("OK!", v => { })
                .Show();            
        }
    }
}