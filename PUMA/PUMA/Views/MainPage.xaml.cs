using System;
using Xamarin.Forms;

namespace PUMA
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();            
        }

        public async void ToIntroduction(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HTMLPage("Introduction.html"));
        }

        public async void ToPumaTypes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PumaTypesPage());
        }

        public async void ToPumaHabitats(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PumaHabitatsPage());
        }

    }
}
