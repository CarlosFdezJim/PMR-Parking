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
    public partial class RegisterPage : ContentPage
    {

        public string WebAPIKey = "AIzaSyCAZ9naHd6BbLzYeiIVuJYgbYJtV2cUryc";

        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void Button_Register(object sender, EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);
                string gettoken = auth.FirebaseToken;
                await Navigation.PushAsync(new MainPage());
                
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}