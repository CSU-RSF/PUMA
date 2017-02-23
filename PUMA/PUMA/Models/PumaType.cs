using SQLite;
using Xamarin.Forms;

namespace PUMA.Models
{
    [Table("puma_types")]
    public class PumaType
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Type { get; set; }

        public string Description { get; set; }

        // Dynamically pulls from Resources.Images.PumaType image folder unique to the PumaType Id and gets the corresponding thumnail.jpg image
        public ImageSource Thumbnail
        {
            get { return ImageSource.FromResource(string.Format("PUMA.Resources.Images.{0}.ID{1}.thumbnail.jpg", this.GetType().Name, Id)); }
        }

    }
}
