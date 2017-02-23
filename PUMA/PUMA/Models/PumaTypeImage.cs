using SQLite;
using Xamarin.Forms;

namespace PUMA.Models
{
    [Table("puma_type_images")]
    public class PumaTypeImage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int PumaTypeId { get; set; }

        [MaxLength(250)]
        public string ImageFilename { get; set; }

        [MaxLength(250)]
        public string Credit { get; set; }

        public ImageSource ImageSource
        {
            get { return ImageSource.FromResource(string.Format("PUMA.Resources.Images.{0}.ID{1}.Carousel.{2}", this.GetType().Name.Replace("Image", ""), PumaTypeId, ImageFilename)); }
        }

    }
}
