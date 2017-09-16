using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

namespace DroneApp
{
    public partial class NewZone : ContentPage
    {
        
        public MobileServiceClient MobileService = new MobileServiceClient("https://dronevip.azurewebsites.net");
        internal NewZone()
        {
            InitializeComponent();
        }
        async void OnNewZone(object sender, EventArgs e)
        {
            var tableMobile = MobileService.GetTable<UserPositions>();
            loading.IsVisible = true;
            loading.IsRunning = true;
            double lat;
            double longi;
            bool isLatCorrect = false;
            if (Double.TryParse(Lat.Text, out lat))
            {
                isLatCorrect = true;
            }
            else
            {
                await DisplayAlert("Error", "Escriba una latitud válida", "Ok");
            }
            if (Double.TryParse(Long.Text,out longi) && isLatCorrect)
            {
               
                await tableMobile.InsertAsync(new UserPositions
                {
                    Name = Name.Text,
                    Lat = lat,
                    Long = longi,
                    Radius = Double.Parse(Radius.Text),
                    IsUser = false
                });
                await DisplayAlert("Nueva Zona", "Correctamente añadida", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Escriba una longitud válida", "Ok");
            }
                
           
        }
    }
}
