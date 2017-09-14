using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DroneApp
{
    public partial class PDFList : ContentPage
    {
        public PDFList()
        {
            InitializeComponent();
            List<PDF> pdfList = new List<PDF>();
            pdfList.Add(new PDF
            {
                Title = "La Era de los Drones",
                Author = "Silvia Perez",
                ImageUrl = "drones.png"
            });
            pdfList.Add(new PDF
            {
                Title = "Manual de Instrucciones",
                Author = "Gerardo Montez",
                ImageUrl = "drones.png"
            });
            pdfList.Add(new PDF
            {
                Title = "Que puedo hacer con mi drone",
                Author = "Drones VIP",
                ImageUrl = "drones.png"
            });
            pdfList.Add(new PDF
            {
                Title = "Recomendaciones de Seguridad",
                Author = "Drones VIP",
                ImageUrl = "drones.png"
            });
            PDFListView.ItemsSource = pdfList;
        }

        private void PDFListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Debug.WriteLine((e.Item as PDF).Title.ToLower().Replace(" ", "") + ".pdf");
            Navigation.PushAsync(new Documentos((e.Item as PDF).Title.ToLower().Replace(" ","") + ".pdf"));
        }
    }
    public class PDF
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
    }
}
