using System;
using SimulOP.Fragments;
using SimulOP.Core;
using SimulOP.Helpers;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;

using SupportToolBar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;


namespace SimulOP
{
    [Activity(Label = "SimulOP", MainLauncher = true, Theme ="@style/Theme.MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        // Controle da interfase
        BottomNavigationView btnNavView;
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        SupportToolBar toolBar;
        SupportActionBar actionBar;

        // Objetos para o calculo da bomba
        internal Fluido Fluido;
        internal Tubulacao Tubulacao;
        internal double[] EqBomba = new double[3];
        internal Bomba Bomba;
        internal Singularidade Singularidade;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.BombaMain);

            // Colocando a referência para a BottomNavigationView e desativando a animação
            btnNavView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            btnNavView.SetShiftMode(false, false);

            // SettingUp a tool bar com o menu
            toolBar = FindViewById<SupportToolBar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);
            actionBar = SupportActionBar;
            actionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            // Inicializando a Drawer e a navView
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            navigationView = FindViewById<NavigationView>(Resource.Id.navView);

            // Event handler para os botoes de navegacao e Drawer
            btnNavView.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            // Carrega o fragment HomeMain
            btnNavView.Visibility = ViewStates.Invisible;
            navigationView.Menu.GetItem(0).SetChecked(true);
            LoadFragment(Resource.Id.nav_home);
        }

        /// <summary>
        /// Cria o menu com a info
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_info, menu);
            return base.OnPrepareOptionsMenu(menu);
        }

        /// <summary>
        /// Botão de menu e info para a toolBar
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;
                case Resource.Id.info:
                    StartActivity(typeof(InfoActivity));
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        /// <summary>
        /// EventHandeler para os botões do BottomNavView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_home):
                    btnNavView.Visibility = ViewStates.Invisible;
                    actionBar.Title = "SimulOP";
                    LoadFragment(Resource.Id.nav_home);
                    break;
                case (Resource.Id.nav_bomba):
                    btnNavView.Visibility = ViewStates.Visible;
                    btnNavView.Menu.Clear();
                    btnNavView.InflateMenu(Resource.Menu.bottom_navigation_bomba);
                    btnNavView.SetShiftMode(false, false);
                    btnNavView.Menu.GetItem(0).SetChecked(true);
                    actionBar.Title = "Bomba";
                    LoadFragment(Resource.Id.menu_bomba_fluido);
                    break;
                case (Resource.Id.nav_trocador):
                    btnNavView.Visibility = ViewStates.Visible;
                    btnNavView.Menu.Clear();
                    btnNavView.InflateMenu(Resource.Menu.bottom_navigation_trocador);
                    btnNavView.SetShiftMode(false, false);
                    btnNavView.Menu.GetItem(0).SetChecked(true);
                    actionBar.Title = "Trocador";
                    LoadFragment(Resource.Id.menu_bomba_resultados);
                    break;
            }
            e.MenuItem.SetChecked(true);
            drawerLayout.CloseDrawers();
        }

        /// <summary>
        /// Carrega e atualiza o Fragment
        /// </summary>
        /// <param name="id"></param>
        void LoadFragment(int id)
        {
            SupportFragment fragment = null;
            switch (id)
            {
                case Resource.Id.nav_home:
                    fragment = Home_main.NewInstance();
                    break;
                case Resource.Id.menu_bomba_fluido:
                    fragment = bomba_fluido.NewInstance();
                    break;
                case Resource.Id.menu_bomba_tubulacao:
                    fragment = bomba_tubulacao.NewInstance();
                    break;
                case Resource.Id.menu_bomba_singularidade:
                    fragment = bomba_singularidade.NewInstance();
                    break;
                case Resource.Id.menu_bomba_bomba:
                    fragment = bomba_bomba.NewInstance();
                    break;
                case Resource.Id.menu_bomba_resultados:
                    fragment = bomba_resultados.NewInstance();
                    break;
            }
            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
               .Replace(Resource.Id.content_frame, fragment)
               .Commit();
        }
    }
}


