using PMR_Parking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace PMR_Parking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PMR_Maps : ContentPage
    {
        MapPageViewModel mapPageViewModel;
        public PMR_Maps()
        {
            InitializeComponent();

            BindingContext = mapPageViewModel = new MapPageViewModel();

            ApplyMapTheme();
        }

        private void ApplyMapTheme()
        {
            var assembly = typeof(PMR_Maps).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"PMR_Parking.MapResources.MapTheme.json");
            string themeFile;
            using (var reader = new System.IO.StreamReader(stream))
            {

                themeFile = reader.ReadToEnd();
                map.MapStyle = MapStyle.FromJson(themeFile);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var contents = await mapPageViewModel.LoadVehicles();

            if (contents != null)
            {
                foreach (var item in contents)
                {
                    Pin VehiclePins = new Pin()
                    {
                        Label = "Cars",
                        Type = PinType.Place,
                        Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png" }),
                        Position = new Position(Convert.ToDouble(item.Latitude), Convert.ToDouble(item.Longitude)),
                    };
                    map.Pins.Add(VehiclePins);
                }
            }

            //This is your location and it should be near to your car location.
            var positions = new Position(28.126825, 82.297106);//Latitude, Longitude
            map.MoveToRegion(MapSpan.FromCenterAndRadius(positions, Distance.FromMeters(500)));
        }

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            var positions = new Position(28.126825, 82.297106);//Latitude, Longitude
            map.MoveToRegion(MapSpan.FromCenterAndRadius(positions, Distance.FromMeters(500)));

            Device.StartTimer(TimeSpan.FromSeconds(5), () => TimerStarted());


        }

        private bool TimerStarted()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                Compass.Start(SensorSpeed.UI, applyLowPassFilter: true);
                Compass.ReadingChanged += Compass_ReadingChanged;
                map.Pins.Clear();
                map.Polylines.Clear();
                //Get the cars nearrby from api but here we are hardcoding the contents
                var contents = await mapPageViewModel.LoadVehicles();
                if (contents != null)
                {
                    foreach (var item in contents)
                    {
                        Pin VehiclePins = new Pin()
                        {
                            Label = "Cars",
                            Type = PinType.Place,
                            Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(item.Latitude), Convert.ToDouble(item.Longitude)),
                            Rotation = ToRotationPoints(headernothvalue)
                        };
                        map.Pins.Add(VehiclePins);
                    }
                }
            }

            );
            Compass.Stop();
            return true;
        }

        private float ToRotationPoints(object headernothvalue)
        {
            return (float)headernothvalue;
        }

        double headernothvalue;
        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            var data = e.Reading;
            headernothvalue = data.HeadingMagneticNorth;
        }
    }
}