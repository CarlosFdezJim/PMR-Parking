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
    public partial class Policia : ContentPage
    {
        public Policia()
        {
            InitializeComponent();
        }

        private void LlamarPolicia(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open(txtNumero.Text);
            }
            catch (Exception)
            {
                DisplayAlert("No se pudo realizar la llamada", "Intentelo más tarde", "Ok");
            }

        }
    }
}