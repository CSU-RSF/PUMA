using Xamarin.Forms;

namespace PUMA.Views
{
    public partial class PumaDetailPage : TabbedPage
    {
        public PumaDetailPage(int pumaId)
        {
            int PumaId = pumaId;

            var imagesPage = new NavigationPage(new PumaImagesPage(PumaId));
            imagesPage.Title = "Images";

            var infoPage = new NavigationPage(new PumaInfoPage());
            infoPage.Title = "Info";

            Children.Add(imagesPage);
            Children.Add(infoPage);

        }
    }
}
