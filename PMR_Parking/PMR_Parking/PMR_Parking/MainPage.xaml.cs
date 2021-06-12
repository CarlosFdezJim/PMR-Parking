using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Geolocator;

namespace PMR_Parking
{
    [DesignTimeVisible(true)]
    public partial class MainPage : Shell
    {
        //double lati;
        //double longi;

        public MainPage()
        {
            InitializeComponent();
            Localizar();
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
            //            var loc = args.Position;
            //            lon.Text = loc.Longitude.ToString();
            //            longi = double.Parse(lon.Text);
            //            lat.Text = loc.Latitude.ToString();
            //            lati = double.Parse(lat.Text);
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
