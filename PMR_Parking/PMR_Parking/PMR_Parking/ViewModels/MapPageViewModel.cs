using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMR_Parking.ViewModels
{
    class MapPageViewModel
    {

        public MapPageViewModel()
        {
        }

        public class VehicleLocations
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }

        }

        internal async Task<List<VehicleLocations>> LoadVehicles()
        {
            //Call the api to get the vehicles nearby

            //This are the hardcoded data
            List<VehicleLocations> vehicleLocations = new List<VehicleLocations>
            {
                new VehicleLocations{Latitude=28.128888,Longitude=82.296891},
                new VehicleLocations{Latitude=28.130061,Longitude=82.297364},
                new VehicleLocations{Latitude=28.129550,Longitude=82.298887},
                new VehicleLocations{Latitude=28.127336,Longitude=82.292106},

            };
            return vehicleLocations;
        }

        //internal async Task<System.Collections.Generic.List<Xamarin.Forms.GoogleMaps.Position>> LoadRoute()
        //{
        //    var googleDirection = await ApiServices.ServiceClientInstance.GetDirections($"28.127612", $"82.309793", $"28.163485", $"82.314771");
        //    if (googleDirection.Routes != null && googleDirection.Routes.Count > 0)
        //    {
        //        var positions = (Enumerable.ToList(PolylineHelper.Decode(googleDirection.Routes.First().OverviewPolyline.Points)));
        //        return positions;
        //    }
        //    else
        //    {
        //        await App.Current.MainPage.DisplayAlert("Alert", "Add your payment method inside the Google Maps console.", "Ok");
        //        return null;

        //    }

        //}


    }
}
