using System;
using SimulOP.Core;

using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;

using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Text;

namespace SimulOP.Fragments
{
    public class bomba_fluido : SupportFragment
    {
        private Fluido fluido;
        private string densidade;
        private string viscosidade;
        

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here            
        }

        public static bomba_fluido NewInstance()
        {
            var frag1 = new bomba_fluido { Arguments = new Bundle() };
            return frag1;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.bomba_fluido, container, false);

            // Inputs
            TextInputLayout densidadeInput = view.FindViewById<TextInputLayout>(Resource.Id.textInBombaDensidade);
            TextInputLayout viscosidadeInput = view.FindViewById<TextInputLayout>(Resource.Id.textInBombaViscosidade);

            MainActivity main = (MainActivity)this.Activity;

            // Chequa se o objeto fluido da main activity jah foi criado, se sim copia o valor dele para o fluido privado dessa classe
            if (main.Fluido != null)
            {
                if (main.Fluido.Densidade != 0)
                {
                    fluido = main.Fluido;
                    viscosidadeInput.EditText.Text = fluido.Viscosidade.ToString();
                    densidadeInput.EditText.Text = fluido.Densidade.ToString();
                }
            }

            // EventHandler para os inputs
            densidadeInput.EditText.TextChanged += DensidadeTextInputLayout_ChangedText;
            viscosidadeInput.EditText.TextChanged += ViscosidadeTextInputLayout_ChangedText;                      

            // Continua com a operação do android
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return view;
        }

        /// <summary>
        /// Event handler para a densidade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DensidadeTextInputLayout_ChangedText(object sender, TextChangedEventArgs e)
        {
            if (e.Text != null)
            {
                densidade = Convert.ToString(e.Text);
            }
        }

        /// <summary>
        /// Event handler para a viscosidade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViscosidadeTextInputLayout_ChangedText(object sender, TextChangedEventArgs e)
        {
            if (e.Text != null)
            {
                viscosidade = Convert.ToString(e.Text);
            }
        }

        /// <summary>
        /// É chamada quando há mudança de fragmento, e atualiza ou cria o fluido da main activity
        /// </summary>
        public override void OnDestroyView()
        {
            MainActivity main = (MainActivity)this.Activity;

            // Atualiza o fluido já existente
            if (main.Fluido != null)
            {
                if (densidade != null)
                {
                    if (densidade != "") main.Fluido.Densidade = Convert.ToDouble(densidade);
                }

                if (viscosidade != null)
                {
                    if (viscosidade != "") main.Fluido.Viscosidade = Convert.ToDouble(viscosidade);
                }
            }
            // Cria um novo objeto fluido
            else if (densidade != null && viscosidade != null) 
            {
                if (densidade != "" && viscosidade != "")
                {
                    main.Fluido = new Fluido(Convert.ToDouble(densidade), Convert.ToDouble(viscosidade));
                }               
            }
            // Continua com a operação do android
            base.OnDestroyView();
        }
    }
}
