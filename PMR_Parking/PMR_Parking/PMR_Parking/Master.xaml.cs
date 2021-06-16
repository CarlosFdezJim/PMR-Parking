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
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private async void btnPerfil_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;  //Esconder menú lateral
            await App.MasterDet.Detail.Navigation.PushAsync(new Page1());
        }

        private async void btnCardPMR_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;  //Esconder menú lateral
            await App.MasterDet.Detail.Navigation.PushAsync(new Page2());
        }

        private async void btnAparcamiento_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;  //Esconder menú lateral
            await App.MasterDet.Detail.Navigation.PushAsync(new PMR_Maps());
        }

        private async void btnPolicia_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;  //Esconder menú lateral
            await App.MasterDet.Detail.Navigation.PushAsync(new Policia());
        }
    }
}