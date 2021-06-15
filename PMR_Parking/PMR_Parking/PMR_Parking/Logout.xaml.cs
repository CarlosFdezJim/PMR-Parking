using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMR_Parking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logout : ContentPage
    {
        public string WebAPIkey = "AIzaSyDpJwmEi_i7lI2gDil8epd2AoPgUqiYfK4";

        public Logout()
        {
            InitializeComponent();

            GetProfileInformationAndRefreshTokenAsync();
        }


        private async void GetProfileInformationAndRefreshTokenAsync()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                //This is the saved firebaseauthentication that was saved during the time of login
                var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                //Here we are Refreshing the token
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                //Now lets grab user information
                MyUserName.Text = savedfirebaseauth.User.Email;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Oh no !  Token expired", "OK");
            }
        }
        private void Logout_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new RegisterPage());
        }
    }
}