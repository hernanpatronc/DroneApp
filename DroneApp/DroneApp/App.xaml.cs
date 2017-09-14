using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DroneApp
{
    public partial class App : Application
    {
        List<Users> userList = new List<Users>();
        public App()
        {
            InitializeComponent();
            var navPage = new NavigationPage(new DroneApp.LoginPage());
            navPage.Title = "DronesVIP";
            
            navPage.BarBackgroundColor = Color.BurlyWood;
            navPage.BarTextColor = Color.OrangeRed;
            MainPage = navPage;
            
        }
        List<Users> usuarios = new List<Users>();
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
