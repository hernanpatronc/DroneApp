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
        Users cUser;
        public MobileServiceClient MobileService = new MobileServiceClient("https://dronevip.azurewebsites.net");
        internal NewZone(Users user)
        {
            InitializeComponent();
            cUser = user;
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
                UserPositions newUserPos = new UserPositions
                {
                    Name = Name.Text,
                    Lat = lat,
                    Long = longi,
                    Radius = Double.Parse(Radius.Text),
                    IsUser = false
                };
                await tableMobile.InsertAsync(newUserPos);
                await DisplayAlert("Nueva Zona", "Correctamente añadida", "Ok");
                //Navigation.RemovePage(Navigation.NavigationStack.ElementAt(Navigation.NavigationStack.Count - 2));
                await Navigation.PopAsync();
               
                //await Navigation.PushAsync(new MapsPage(cUser,cUserPositions));
               // Navigation.RemovePage(Navigation.NavigationStack.)
            }
            else
            {
                await DisplayAlert("Error", "Escriba una longitud válida", "Ok");
            }
                
           
        }

        private void Lat_TextChanged(object sender, TextChangedEventArgs e)
        {
            Lat.Text = Lat.Text.Replace(".", ",");
        }

        private void Long_TextChanged(object sender, TextChangedEventArgs e)
        {
            Long.Text = Long.Text.Replace(".", ",");
        }
    }
}
