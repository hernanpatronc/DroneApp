using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DroneApp
{
    public partial class MapsPage : ContentPage
    {
        public MapsPage()
        {
            InitializeComponent();
            var random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 20; i++)
            {
                var pinPerson = new Pin
                {
                    Type = PinType.Generic,
                    Position = new Position(-34.0 -random.NextDouble(), -58.0 - random.NextDouble()),
                    Label = "Usuario" + i
                };
                customMap.Pins.Add(pinPerson);
            }

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(-34.459358, -58.828393),
                Label = "Pilar",
                Address = "Prohibido Volar"
            };

            var position = new Position(-34.459358, -58.828393);
            customMap.Circles = new List<CustomCircle>();
            customMap.Circles.Add(new CustomCircle
            {
                Position = position,
                Radius = 10000
            });
            
            customMap.Pins.Add(pin);

            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(-34.7, -58.3),
                Label = "Martinez",
                Address = "Pedir Permiso de vuelo"
            };

            var position2 = new Position(-34.7, -58.3);
            customMap.Circles.Add(new CustomCircle
            {
                Position = position2,
                Radius = 10000
            });

            customMap.Pins.Add(pin2);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(10.0)));
            
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
