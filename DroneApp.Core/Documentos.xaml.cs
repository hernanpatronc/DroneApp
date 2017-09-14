using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DroneApp
{
    public partial class Documentos : ContentPage
    {
        internal Documentos(string pdf)
        {
            InitializeComponent();
            pdfView.Uri = pdf;
        }
    }

    public class PDFView : WebView
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create(propertyName: "Uri",
                returnType: typeof(string),
                declaringType: typeof(PDFView),
                defaultValue: default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
    }

}
