using System;
using Xamarin.Forms;
using PUMA.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PUMA
{
    public partial class MainPage : ContentPage
    {
        readonly IList<PumaRepository> pumas = new ObservableCollection<PumaRepository>();
        readonly ExternalDBConnection externalDB = new ExternalDBConnection();

        public MainPage()
        {
            InitializeComponent();
        }

        public async void ToIntroduction(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HTMLPage("Introduction.html"));
        }

        public async void ToPumas(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PumasPage());
        }

        public async void ToPumaHabitats(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PumaHabitatsPage());
        }

    }
}
