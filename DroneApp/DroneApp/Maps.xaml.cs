using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;

namespace DroneApp
{
    public partial class MapsPage : ContentPage
    {
        public MobileServiceClient MobileService = new MobileServiceClient("https://dronevip.azurewebsites.net");
        UserPositions cUserPos = new UserPositions();
        bool cUserPosExists = false;
        async void FillMap()
        {
            var circles = new List<CustomCircle>();

            var position = new Position(-34.5, -58.6);
            circles.Add(new CustomCircle
            {
                Position = position,
                Radius = 10000.0
            });
            var pin = new Pin
            {
                Type = PinType.Generic,
                Position = position,
                Label = "Zona1"
            };
            customMap.Pins.Add(pin);

            var position2 = new Position(-34.3, -58.7);
            circles.Add(new CustomCircle
            {
                Position = position2,
                Radius = 10000.0
            });
            var pin2 = new Pin
            {
                Type = PinType.Generic,
                Position = position2,
                Label = "Zona2"
            };
            customMap.Pins.Add(pin2);
            customMap.Circles = circles;
            var userPosTable = MobileService.GetTable<UserPositions>();
            var userPosList = await userPosTable.Where((userPos) => userPos.IsUser).ToListAsync();
            foreach (var userPos in userPosList)
            {
                if (userPos.Name == cUser.Name)
                {
                    cUserPosExists = true;
                    cUserPos = userPos;
                }
                var pinPerson = new Pin
                {
                    Type = PinType.Generic,
                    Position = new Position(userPos.Lat, userPos.Long),
                    Label = userPos.Name
                };
                customMap.Pins.Add(pinPerson);
            }
            /*var zonePosList = await userPosTable.Where((userPos) => !(userPos.IsUser)).ToListAsync();

            foreach (var zonePos in zonePosList)
            {
                circles.Add(new CustomCircle
                {
                    Position = new Position(zonePos.Lat, zonePos.Long),
                    Radius = zonePos.Radius
                });
                var pinZone = new Pin
                {
                    Type = PinType.Generic,
                    Position = new Position(zonePos.Lat, zonePos.Long),
                    Label = zonePos.Name
                };
                customMap.Pins.Add(pinZone);
            }
            */
            

            //Position uPos = await locator.GetPositionAsync()
            var usPos = await CrossGeolocator.Current.GetPositionAsync();
            Position uPos = new Position(usPos.Latitude, usPos.Longitude);
            if (cUserPosExists)
            {
                cUserPos.Lat = uPos.Latitude;
                cUserPos.Long = uPos.Longitude;
                await userPosTable.UpdateAsync(cUserPos);
            }
            else
            {
                cUserPos.Name = cUser.Name;
                cUserPos.Lat = uPos.Latitude;
                cUserPos.Long = uPos.Longitude;
                cUserPos.IsUser = true;
                cUserPos.Radius = 10.0;
                await userPosTable.InsertAsync(cUserPos);
            }
            
            
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(uPos, Distance.FromMiles(10.0)));
        }
        Users cUser;
        internal MapsPage(Users user)
        {
            InitializeComponent();
            CrossGeolocator.Current.PositionChanged += async (sender, e) => {
                var pos = e.Position;

                cUserPos.Lat = pos.Latitude;
                cUserPos.Long = pos.Longitude;
                await MobileService.GetTable<UserPositions>().UpdateAsync(cUserPos);
            };
           
           
            cUser = user;
            
            FillMap();
        }
    }
    public class CustomCircle
    {
        public Position Position { get; set; }
        public double Radius { get; set; }
    }
    public class CustomMap : Map
    {
        public List<CustomCircle> Circles { get; set; }
    }
}
