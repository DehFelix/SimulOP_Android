using System;

using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Text;
using Android.Views;
using SimulOP.Core;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace SimulOP.Fragments
{
    public class bomba_singularidade : SupportFragment
    {
        private Singularidade singularidade;
        private string comprimentoEqv;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static bomba_singularidade NewInstance()
        {
            var frag1 = new bomba_singularidade { Arguments = new Bundle() };
            return frag1;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.bomba_singularidade, container, false);

            // Inputs
            TextInputLayout comprimentoInput = view.FindViewById<TextInputLayout>(Resource.Id.textInBombaSingularidade);

            MainActivity main = (MainActivity)this.Activity;

            // Chequa se o objeto fluido da main activity jah foi criado, se sim copia o valor dele para o fluido privado dessa classe
            if (main.Singularidade != null)
            {
                if (main.Singularidade.ComprimentoEqv != 0)
                {
                    singularidade = main.Singularidade;
                    comprimentoInput.EditText.Text = singularidade.ComprimentoEqv.ToString();
                }
            }

            // EventHandler para os inputs
            comprimentoInput.EditText.TextChanged += ComprimentoTextInputLayout_ChangedText;

            // Continua com a operação do android
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return view;
        }

        private void ComprimentoTextInputLayout_ChangedText(object sender, TextChangedEventArgs e)
        {
            if (e.Text != null)
            {
                comprimentoEqv = Convert.ToString(e.Text);
            }
        }
        public override void OnDestroyView()
        {
            MainActivity main = (MainActivity)this.Activity;

            // Atualiza a Singularidade já existente
            if (main.Singularidade != null)
            {
                if (comprimentoEqv != null)
                {
                    if (comprimentoEqv != "") main.Singularidade.ComprimentoEqv = Convert.ToDouble(comprimentoEqv);
                }
            }
            // Cria um novo objeto Singularidade
            else if (comprimentoEqv != null)
            {
                if (comprimentoEqv != "")
                {
                    main.Singularidade = new Singularidade(Convert.ToDouble(comprimentoEqv));
                }
            }
            // Continua com a operação do android
            base.OnDestroyView();
        }
    }
}