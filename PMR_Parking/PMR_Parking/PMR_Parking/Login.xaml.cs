using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace PMR_Parking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public string WebAPIKey = "AIzaSyCAZ9naHd6BbLzYeiIVuJYgbYJtV2cUryc";

        public Login()
        {
            InitializeComponent();
        }

        /**
         * @brief Método que se encarga de comprobar si el email y la contraseña del cliente corresponden con la que tenemos en la base de datos.
         * @param object sender
         * @param EventArgs e
         * @author Carlos Fdez
         */
        private async void Button_Login(object sender, EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(txtEmail.Text, txtPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                try
                {
                    await Navigation.PushAsync(new MainPage());
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                }
                catch (Exception)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "No se ha podido redireccionar", "OK");
                }
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Usuario o contraseña no correcto", "OK");
            }
        }

        /**
         * @brief Método nos redirecciona a la página de registro
         * @param object sender
         * @param EventArgs e
         * @author Carlos Fdez
         */
        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new RegisterPage());
                txtEmail.Text = "";
                txtPassword.Text = "";
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "No se ha podido redireccionar", "OK");
            }
        }
    }
}