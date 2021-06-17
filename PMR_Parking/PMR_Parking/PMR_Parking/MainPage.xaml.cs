using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Firebase.Auth;
using Newtonsoft.Json;

// Esta clase engloba al Master (Menú de navegación) y Details ( Páginas  de detalles)

namespace PMR_Parking
{

    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Master = new Master(); //menú lateral
            this.Detail = new NavigationPage(new Detail()); //detalles

            App.MasterDet = this;
        }
    }
}
