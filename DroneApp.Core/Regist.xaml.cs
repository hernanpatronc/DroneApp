using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
//using Microsoft.WindowsAzure.MobileServices;

namespace DroneApp
{
    public partial class RegisterPage : ContentPage
    {
        List<string> dronesTypes = new List<string>(new string[] { "Ala Fija", "Ala Rotativa", "Aerostatico" });
        //public MobileServiceClient MobileService = new MobileServiceClient("https://dronevip.azurewebsites.net");
        internal RegisterPage()
        {
            InitializeComponent();
            Drone.ItemsSource = dronesTypes;
            Drone.SelectedIndex = 0;
        }
        void OnRegister(object sender, EventArgs e)
        {
            /*var tableMobile = MobileService.GetTable<Users>();
            var list = await tableMobile.ToListAsync();
            foreach(var user in list)
            {
                if (Dni.Text == user.Dni)
                {
                    await DisplayAlert("Registro", "DNI ya Registrado", "Ok");
                    return;
                }
            }
            await tableMobile.InsertAsync(new Users
            {
                Dni = Dni.Text,
                Name = Name.Text,
                Password = Password.Text,
                Drone = Drone.SelectedItem.ToString(),
                Tel = Tel.Text
            });
            await DisplayAlert("Registro", "Correctamente Registrado", "Ok");
            await Navigation.PushAsync(new LoginPage());*/
        }
    }
}
