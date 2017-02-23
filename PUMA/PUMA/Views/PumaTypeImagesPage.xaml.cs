using System.Collections.ObjectModel;
using PUMA.Models;

using Xamarin.Forms;

namespace PUMA.Views
{
    public partial class PumaTypeImagesPage : CarouselPage
    {
        public PumaTypeImagesPage(int pumaTypeId)
        {
            InitializeComponent();
            ObservableCollection<PumaTypeImage> pumaTypeImages = new ObservableCollection<PumaTypeImage>(App.PumaTypeImageRepo.PumaTypeImages(pumaTypeId));
            ItemsSource = pumaTypeImages;
        }
    }
}
