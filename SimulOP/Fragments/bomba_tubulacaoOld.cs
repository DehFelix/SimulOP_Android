/*
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
    public class bomba_tubulacao : SupportFragment
    {
        private Tubulacao tubulacao;
        private string diametro;
        private string comprimento;
        private string rugosidade;
        private string elevacao;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static bomba_tubulacao NewInstance()
        {
            var frag1 = new bomba_tubulacao { Arguments = new Bundle() };
            return frag1;
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.bomba_tubulacao, container, false);

            // Inputs
            TextInputLayout diametroInput = view.FindViewById<TextInputLayout>(Resource.Id.textInBombaDiametro);
            TextInputLayout comprimentoInput = view.FindViewById<TextInputLayout>(Resource.Id.textInBombaComprimento);
            TextInputLayout rugosidadeInput = view.FindViewById<TextInputLayout>(Resource.Id.textInBombaRugosidade);
            TextInputLayout elevacaoInput = view.FindViewById<TextInputLayout>(Resource.Id.textInBombaElevacao);
            
            MainActivity main = (MainActivity)this.Activity;

            // Chequa se o objeto fluido da main activity jah foi criado, se sim copia o valor dele para o fluido privado dessa classe
            if (main.Tubulacao != null)
            {
                if (main.Tubulacao.Diametro != 0)
                {
                    tubulacao = main.Tubulacao;
                    diametroInput.EditText.Text = main.Tubulacao.Diametro.ToString();
                    comprimentoInput.EditText.Text = main.Tubulacao.Comprimento.ToString();
                    rugosidadeInput.EditText.Text = main.Tubulacao.Rugosidade.ToString();
                    elevacaoInput.EditText.Text = main.Tubulacao.Elevacao.ToString();
                }
            }

            // EventHandler para os inputs
            diametroInput.EditText.TextChanged += DiametroInputLayout_ChangedText;
            comprimentoInput.EditText.TextChanged += ComprimentoInputLayout_ChangedText;
            rugosidadeInput.EditText.TextChanged += RugosidadeInputLayout_ChangedText;
            elevacaoInput.EditText.TextChanged += ElevacaoInputLayout_ChangedText;

            // Continua com a opera��o do android
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.bomba_tubulacao, null);
        }

        /// <summary>
        /// Event handler para a eleva��o
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ElevacaoInputLayout_ChangedText(object sender, TextChangedEventArgs e)
        {
            if (e.Text != null)
            {
                elevacao = Convert.ToString(e.Text);
            }
        }

        /// <summary>
        /// Event handler para a rugosidade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RugosidadeInputLayout_ChangedText(object sender, TextChangedEventArgs e)
        {
            if (e.Text != null)
            {
                rugosidade = Convert.ToString(e.Text);
            }
        }

        /// <summary>
        /// Event handler para o comprimento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComprimentoInputLayout_ChangedText(object sender, TextChangedEventArgs e)
        {
            if (e.Text != null)
            {
                comprimento = Convert.ToString(e.Text);
            }
        }

        /// <summary>
        /// Event handler para o diametro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiametroInputLayout_ChangedText(object sender, TextChangedEventArgs e)
        {
            if (e.Text != null)
            {
                diametro = Convert.ToString(e.Text);
            }
        }

        /// <summary>
        /// � chamada quando h� mudan�a de fragmento, e atualiza ou cria a Tubula��o da main activity
        /// </summary>
        public override void OnDestroyView()
        {
            MainActivity main = (MainActivity)this.Activity;

            // Atualiza o fluido j� existente
            if (main.Tubulacao != null)
            {
                if (diametro != null)
                {
                    if (diametro != "") main.Tubulacao.Diametro = Convert.ToDouble(diametro);                   
                }

                if (comprimento != null)
                {
                    if (comprimento != "") main.Tubulacao.Comprimento = Convert.ToDouble(comprimento);
                }

                if (rugosidade != null)
                {
                    if (rugosidade != "") main.Tubulacao.Rugosidade = Convert.ToDouble(rugosidade);
                }

                if (elevacao != null)
                {
                    if (elevacao != "") main.Tubulacao.Elevacao = Convert.ToDouble(elevacao);
                }
            }
            // Cria um novo objeto Tubula��o
            else if (diametro != null && comprimento != null && rugosidade != null && elevacao != null)
            {
                if (diametro != "" && comprimento != "" && rugosidade != "" && elevacao != "")
                {
                    main.Tubulacao = new Tubulacao(Convert.ToDouble(diametro), Convert.ToDouble(comprimento), Convert.ToDouble(rugosidade), Convert.ToDouble(elevacao));
                }                
            }
            // Continua com a opera��o do android
            base.OnDestroyView();
        }
    }
}
*/