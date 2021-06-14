using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMR_Parking
{
    public partial class App : Application
    {
        //public static MasterDetailPage MasterDet { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());

            //if (!string.IsNullOrEmpty(Preferences.Get("MyFirebaseRefreshToken", "")))
            //{
            //    MainPage = new NavigationPage(new Login2());
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new Logout());
            //}

            //MainPage = MainPage = new NavigationPage(new MainPage());

            //MainPage = new Login(); //Login
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
