﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DroneApp
{
    public partial class MainPage : CarouselPage
    {
        public MainPage()
        {
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
            Navigation.PushAsync(new MapsPage());
        }
        void OnVideos(object sender, EventArgs args)
        {

        }
    }
}
