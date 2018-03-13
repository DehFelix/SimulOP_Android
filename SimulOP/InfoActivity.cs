using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.Design.Widget;
using Android.Support.V7.App;

using SupportToolBar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;

namespace SimulOP
{
    [Activity(Label = "InfoActivity", Theme = "@style/Theme.MyTheme")]
    public class InfoActivity : AppCompatActivity
    {
        //public const string EXTRA_NAME = "Informações";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Load o layout HomeInfo
            SetContentView(Resource.Layout.HomeInfo);

            // Inicializando a actionBar
            SupportToolBar toolbar = FindViewById<SupportToolBar>(Resource.Id.toolbar_info);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            //string infoName = Intent.GetStringExtra(EXTRA_NAME);

            // Inicializando a collapsing Tool Bar 
            CollapsingToolbarLayout collapsingToolBar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar_info);
            collapsingToolBar.Title = "Informações";
            LoadBackDrop();
        }

        /// <summary>
        /// Botão de voltar para a a main
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        /// <summary>
        /// Carrega a imagem na view
        /// </summary>
        private void LoadBackDrop()
        {
            ImageView imageView = FindViewById<ImageView>(Resource.Id.backdrop_info);
            imageView.SetImageResource(Resource.Drawable.icon_simulop);
        }
    }
}