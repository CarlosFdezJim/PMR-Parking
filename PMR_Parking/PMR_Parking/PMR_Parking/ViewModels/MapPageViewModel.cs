using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMR_Parking.ViewModels
{
    public class MapPageViewModel
    {

        public MapPageViewModel()
        {

        }

        public class PMR_Places
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }

        }

        internal async Task<List<PMR_Places>> LoadParking()
        {
            //Call the api to get the vehicles nearby

            //This are the hardcoded data
            List<PMR_Places> vehicleLocations = new List<PMR_Places>
            {
                new PMR_Places{Latitude=37.183209075599997,Longitude= -3.5937831606200001},
                new PMR_Places{Latitude=37.14756044186225,Longitude= -3.612191898406863},
                new PMR_Places{Latitude=37.1538373002,Longitude= -3.60669756014},
                new PMR_Places{Latitude=37.1546079136,Longitude= -3.6031969292},
                new PMR_Places{Latitude=37.154052681,Longitude= -3.59920624015},
                new PMR_Places{Latitude=37.1518872449,Longitude= -3.59519387218},
                new PMR_Places{Latitude=37.1517375971, Longitude= -3.60184339368},
                new PMR_Places{Latitude= 37.1517390065, Longitude=-3.60188540946 },
                new PMR_Places{Latitude= 37.1558701316, Longitude= -3.60257955103},
                new PMR_Places{Latitude= 37.1557000438, Longitude= -3.60055173953},
                new PMR_Places{Latitude= 37.1564868287, Longitude= -3.59961724514},


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
