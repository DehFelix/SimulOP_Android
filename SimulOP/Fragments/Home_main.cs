using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace SimulOP.Fragments
{
    public class Home_main : SupportFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static Home_main NewInstance()
        {
            var frag2 = new Home_main { Arguments = new Bundle() };
            return frag2;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.HomeMain, null);
        }
    }
}