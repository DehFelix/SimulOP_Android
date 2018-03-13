using System;
using SimulOP.Core;

using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;

using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Text;

namespace SimulOP.Fragments
{
    public class bomba_bomba : SupportFragment
    {
        private double[] eqBomba = new double[3];
        private string eqA;
        private string eqB;
        private string eqC;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static bomba_bomba NewInstance()
        {
            var frag1 = new bomba_bomba { Arguments = new Bundle() };
            return frag1;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.bomba_bomba, container, false);

            // Inputs
            TextInputLayout eqAInput = view.FindViewById<TextInputLayout>(Resource.Id.textInBombaEqA);
            TextInputLayout eqBInput = view.FindViewById<TextInputLayout>(Resource.Id.textInBombaEqB);
            TextInputLayout eqCInput = view.FindViewById<TextInputLayout>(Resource.Id.textInBombaEqC);
            
            MainActivity main = (MainActivity)this.Activity;

            // Chequa se o objeto fluido da main activity jah foi criado, se sim copia o valor dele para o fluido privado dessa classe
            if (main.EqBomba != null)
            {
                if (main.EqBomba[0] != 0)
                {
                    eqBomba = main.EqBomba;
                    eqAInput.EditText.Text = main.EqBomba[0].ToString();
                    eqBInput.EditText.Text = main.EqBomba[1].ToString();
                    eqCInput.EditText.Text = main.EqBomba[2].ToString();
                }
            }

            // EventHandler para os inputs
            eqAInput.EditText.TextChanged += EqATextInputLayout_ChangedText;
            eqBInput.EditText.TextChanged += EqBTextInputLayout_ChangedText;
            eqCInput.EditText.TextChanged += EqCTextInputLayout_ChangedText;
            
            // Continua com a operação do android
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return view;
        }

        private void EqATextInputLayout_ChangedText(object sender, TextChangedEventArgs e)
        {
            if (e.Text != null)
            {
                eqA = Convert.ToString(e.Text);
            }
        }

        private void EqBTextInputLayout_ChangedText(object sender, TextChangedEventArgs e)
        {
            if (e.Text != null)
            {
                eqB = Convert.ToString(e.Text);
            }
        }

        private void EqCTextInputLayout_ChangedText(object sender, TextChangedEventArgs e)
        {
            if (e.Text != null)
            {
                eqC = Convert.ToString(e.Text);
            }
        }

        /// <summary>
        /// É chamada quando há mudança de fragmento, e atualiza ou cria a Bomba da main activity
        /// </summary>
        public override void OnDestroyView()
        {
            MainActivity main = (MainActivity)this.Activity;

            // Atualiza a Bomba já existente
            if (main.EqBomba != null)
            {
                if (eqA != null)
                {
                    if (eqA != "") main.EqBomba[0] = Convert.ToDouble(eqA);
                }

                if (eqB != null)
                {
                    if (eqB != "") main.EqBomba[1] = Convert.ToDouble(eqB);
                }

                if (eqC != null)
                {
                    if (eqC != "") main.EqBomba[2] = Convert.ToDouble(eqC);
                }
            }
            // Cria um novo objeto Bomba
            else if (eqA != null && eqB != null && eqC != null)
            {
                if (eqA != "" && eqC != "" && eqC != "")
                {
                    main.EqBomba = new double[4] { 0, Convert.ToDouble(eqA), Convert.ToDouble(eqB), Convert.ToDouble(eqC) };
                }
            }
            // Continua com a operação do android
            base.OnDestroyView();
        }
    }
}