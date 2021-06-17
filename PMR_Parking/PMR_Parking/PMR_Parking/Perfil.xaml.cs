using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMR_Parking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        public Perfil()
        {
            InitializeComponent();
            App.Current.MainPage.DisplayAlert("Alert", "Contenido no disponible aún, estamos trabajando en incluirlo lo más pronto posible.", "OK");
        }

    }
}