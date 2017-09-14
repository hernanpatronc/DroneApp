using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using DroneApp;
using DroneApp.iOS;
using Xamarin.Forms.Maps.iOS;
using MapKit;
using Xamarin.Forms.Platform.iOS;
using CoreLocation;
using ObjCRuntime;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace DroneApp.iOS
{
    public class CustomMapRenderer : MapRenderer
    {
        MKCircleRenderer circleRenderer;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;
                if (nativeMap != null)
                {
                    nativeMap.RemoveOverlays(nativeMap.Overlays);
                    nativeMap.OverlayRenderer = null;
                    circleRenderer = null;
                }
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                var nativeMap = Control as MKMapView;
                var circles = formsMap.Circles;

                nativeMap.OverlayRenderer = GetOverlayRenderer;
                foreach (var circle in circles)
                {
                    var circleOverlay = MKCircle.Circle(new CoreLocation.CLLocationCoordinate2D(circle.Position.Latitude, circle.Position.Longitude), circle.Radius);
                    nativeMap.AddOverlay(circleOverlay);
                }
                
            }
        }
        MKOverlayRenderer GetOverlayRenderer(MKMapView mapView, IMKOverlay overlayWrapper)
        {
            if (circleRenderer == null && !Equals(overlayWrapper, null))
            {
                var overlay = Runtime.GetNSObject(overlayWrapper.Handle) as IMKOverlay;
                circleRenderer = new MKCircleRenderer(overlay as MKCircle)
                {
                    FillColor = UIColor.Red,
                    Alpha = 0.4f
                };
            }
            return circleRenderer;
        }
    }
}