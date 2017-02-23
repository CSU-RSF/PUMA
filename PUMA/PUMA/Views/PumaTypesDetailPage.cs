using Xamarin.Forms;

namespace PUMA.Views
{
    public partial class PumaTypesDetailPage : TabbedPage
    {
        public PumaTypesDetailPage(int pumaTypeId)
        {
            int PumaTypeId = pumaTypeId;

            var imagesPage = new NavigationPage(new PumaTypeImagesPage(PumaTypeId));
            imagesPage.Title = "Images";

            var infoPage = new NavigationPage(new PumaTypeInfoPage());
            infoPage.Title = "Info";

            Children.Add(imagesPage);
            Children.Add(infoPage);

        }
    }
}
