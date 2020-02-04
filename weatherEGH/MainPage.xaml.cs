using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace weatherEGH
{



    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Weather> get;
        public MainPage()
        {
            InitializeComponent();
        }
        async void btnLocation_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    lblLatitude.Text = "Latitude: " + location.Latitude.ToString();
                    lblLongitude.Text = "Longitude:" + location.Longitude.ToString();
                    await getWeatherToday(location.Latitude.ToString(), location.Longitude.ToString());
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Faild", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Faild", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild", ex.Message, "OK");
            }

        }


        public async Task getWeatherToday(String lat, String lon)

        {
            var request = RestService.For<WeatherApi>("https://api.openweathermap.org");
            var response = await request.getInfo(lat,lon);

            
            Info mInfo = response.Main;
            lblTemperature.Text = Convert.ToString(Math.Round((mInfo.Temp - 273.15), 2)) + " °C";
            lblCityName.Text = response.Name;


        }
    }
}
