using System.Collections.ObjectModel;
using PUMA.Models;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace PUMA.Views
{
    public partial class PumaImagesPage : CarouselPage
    {
        public PumaImagesPage(int pumaId)
        {
            InitializeComponent();
            //ObservableCollection<PumaImage> pumaImages = new ObservableCollection<PumaImage>(App.PumaImageRepo.PumaImages(pumaId));
            //ItemsSource = pumaImages;
            GetImages(pumaId);
        }

        protected async void GetImages(int pumaId)
        {
            ObservableCollection<PumaImage> pumaImages = await App.PumaImageRepo.PumaApiImages(pumaId);
            ItemsSource = pumaImages;
        }
        
    }
}
