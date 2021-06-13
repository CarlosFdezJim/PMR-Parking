using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Geolocator;
using Firebase.Auth;
using Newtonsoft.Json;

namespace PMR_Parking
{
    [DesignTimeVisible(true)]
    public partial class MainPage : Shell
    {
        public string WebAPIKey = "AIzaSyCAZ9naHd6BbLzYeiIVuJYgbYJtV2cUryc";

        public MainPage()
        {
            InitializeComponent();
            GetProfileInformationAndRefreshToken();

            //Localizar();
        }

        async private void GetProfileInformationAndRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            try
            {
                //This is the saved firebaseauthentication that was saved during the time of login
                var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                //Here we are Refreshing the token
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                //Now lets grab user information
                //MyUserName.Text = savedfirebaseauth.User.Email;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Oh no !  Token expired", "OK");
            }



        }

        void Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new Login());

        }

        private async void Localizar()
        {
            //var locator = CrossGeolocator.Current; //Acceso a la API
            //locator.DesiredAccuracy = 50; //Precisión (en metros)
            //if (locator.IsGeolocationAvailable) //Servicio existente en el dispositivo
            //{
            //    if (locator.IsGeolocationEnabled) //GPS activado en el dispositivo
            //    {
            //        if (!locator.IsListening) //Comprueba si el dispositivo escucha al servicio
            //        {
            //            await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5); //Inicio de la escucha
            //        }
            //        locator.PositionChanged += (cambio, args) =>
            //        {
            //            //var loc = args.Position;
            //            //lon.Text = loc.Longitude.ToString();
            //            //longi = double.Parse(lon.Text);
            //            //lat.Text = loc.Latitude.ToString();
            //            //lati = double.Parse(lat.Text);
            //        };
            //    }
            //}
        }

        private async void MostrarMapa(object sender, EventArgs e)
        {
            //MapLaunchOptions options = new MapLaunchOptions { Name = "Mi posición actual" };
            //await Map.OpenAsync(lati, longi, options);
        }
    }
}
