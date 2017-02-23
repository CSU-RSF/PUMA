using System;
using System.Collections.ObjectModel;
using System.Linq;
using PUMA.Models;
using Xamarin.Forms;

namespace PUMA
{ 
    public partial class PumaTypesPage : ContentPage
    {

        public PumaTypesPage()
        {
            InitializeComponent();

            // Get all Puma Types, store them in a collection, then make them the source of the PumaTypesPage.xaml Listview
            ObservableCollection<PumaType> pumaTypes = new ObservableCollection<PumaType>(App.PumaTypesRepo.GetAllPumaTypes());
            pumaTypesList.ItemsSource = pumaTypes;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (pumaTypesList.SelectedItem != null)
            {
                var selectedItem = e.SelectedItem as PumaType;
                var detailPage = new PUMA.Views.PumaTypesDetailPage(selectedItem.Id);
                detailPage.BindingContext = selectedItem;
                pumaTypesList.SelectedItem = null;
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
