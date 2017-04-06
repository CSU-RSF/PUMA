using System;
using System.Collections.ObjectModel;
using System.Linq;
using PUMA.Models;
using Xamarin.Forms;

namespace PUMA
{ 
    public partial class PumasPage : ContentPage
    {

        public PumasPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            // Get all Puma Types from database, store them in a collection
            //ObservableCollection<Puma> pumas = new ObservableCollection<Puma>(App.PumasRepo.GetAllPumas());
            //pumasList.ItemsSource = pumas;

            // Get all Puma Types from external API call, store them in a collection
            ExternalDBConnection externalConnection = new ExternalDBConnection();
            ObservableCollection<Puma> pumas = new ObservableCollection<Puma>(await externalConnection.GetAll());

            // Make pumas the source of the PumasPage.xaml Listview
            pumasList.ItemsSource = pumas;
            base.OnAppearing();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (pumasList.SelectedItem != null)
            {
                var selectedItem = e.SelectedItem as Puma;
                var detailPage = new PUMA.Views.PumaDetailPage(selectedItem.Id);
                detailPage.BindingContext = selectedItem;
                pumasList.SelectedItem = null;
                await Navigation.PushAsync(detailPage);
            }
        }

        //public async void OnNewButtonClicked(object sender, EventArgs args)
        //{
        //    statusMessage.Text = "";
        //    await App.PlantRepo.AddNewPlantAsync(newPlant.Text);
        //    statusMessage.Text = App.PlantRepo.StatusMessage;
        //}

        //public async void OnGetButtonClicked(object sender, EventArgs args)
        //{
        //    statusMessage.Text = "";
        //    ObservableCollection<Plant> plants = new ObservableCollection<Plant>(await App.PlantRepo.GetAllPlantsAsync());
        //    plantsList.ItemsSource = plants;
        //}
    }
}
