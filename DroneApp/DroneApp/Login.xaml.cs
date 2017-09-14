using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DroneApp
{
    public partial class LoginPage : ContentPage
    {
        public MobileServiceClient MobileService = new MobileServiceClient("https://dronevip.azurewebsites.net");
        List<Users> userList;
        internal LoginPage()
        {
            InitializeComponent();
        }
        async void OnLogin(object sender, EventArgs e)
        {
            loading.IsVisible = true;
            loading.IsRunning = true;
            userList = await MobileService.GetTable<Users>().ToListAsync();
            var logUser = new Users {
                Dni = Dni.Text,
                Password = Password.Text
            };
            bool logged = false;
            Users cUser = new Users();
            foreach(var user in userList)
            {
                if (user.Dni == logUser.Dni && user.Password == logUser.Password)
                {
                    cUser = user;
                    logged = true;
                }
                    
            }
            if (logged)
                await Navigation.PushAsync(new MainPage(cUser));
            else
                await DisplayAlert("Login", "Dni o password incorrecto", "Ok");
            loading.IsVisible = false;
            loading.IsRunning = false;
        }

        void OnRegister(object sender, EventArgs e)
        {

            Navigation.PushAsync(new RegisterPage());
        }
    }
}
