using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace DroneApp
{
    public partial class MainPage : CarouselPage
    {
        List<UserPositions> cUserPositions;
        Users cUser;
        internal MainPage(Users user, List<UserPositions> userPos)
        {
            cUser = user;
            cUserPositions = userPos;
            InitializeComponent();
        }
        void OnCursos(object sender, EventArgs args)
        {
           Navigation.PushAsync(new Cursos());
        }
        void OnHome(object sender, EventArgs args)
        {
            //App.Current.MainPage = new LoginPage();
        }
        void OnAlumnos(object sender, EventArgs args)
        {

        }
        void OnANAC(object sender, EventArgs args)
        {
            Navigation.PushAsync(new PDFList());
        }
        void OnEANA(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MapsPage(cUser,cUserPositions));
        }
        void Button_Clicked(object sender, EventArgs args)
        {

        }

        private async void OnVideos(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Esto fue lo escaneado", result.Text, "OK");
                });
            };

            // Navigate to our scanner page
            await Navigation.PushAsync(scanPage);
        }
    }
}
