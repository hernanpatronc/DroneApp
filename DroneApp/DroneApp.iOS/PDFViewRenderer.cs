using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using DroneApp.iOS;
using DroneApp;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Net;
using System.IO;

[assembly: ExportRenderer(typeof(PDFView), typeof(PDFViewRenderer))]
namespace DroneApp.iOS
{
    public class PDFViewRenderer : ViewRenderer<PDFView, UIWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<PDFView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new UIWebView());
            }
            if (e.OldElement != null)
            {
                // Cleanup
            }
            if (e.NewElement != null)
            {
                var customWebView = Element as PDFView;
                string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, string.Format("Content/{0}", WebUtility.UrlEncode(customWebView.Uri)));
                Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
                Control.ScalesPageToFit = true;
            }
        }
    }
}