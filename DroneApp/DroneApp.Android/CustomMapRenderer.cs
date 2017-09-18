using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using DroneApp;
using DroneApp.Droid;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Maps;
using Android.Gms.Maps.Model;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace DroneApp.Droid
{
    public class CustomMapRenderer : MapRenderer
    {
        List<CustomCircle> circles;
        bool isDrawn;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                circles = formsMap.Circles;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
            {
                //if (circles != null)
                foreach (var circle in circles)
                {
                    var circleOptions = new CircleOptions();
                    circleOptions.InvokeCenter(new LatLng(circle.Position.Latitude, circle.Position.Longitude));
                    circleOptions.InvokeRadius(circle.Radius);
                    circleOptions.InvokeFillColor(0X66FF0000);
                    circleOptions.InvokeStrokeColor(0X66FF0000);
                    circleOptions.InvokeStrokeWidth(0);

                    NativeMap.AddCircle(circleOptions);
                    isDrawn = true;
                }
                
            }
        }
    }
}