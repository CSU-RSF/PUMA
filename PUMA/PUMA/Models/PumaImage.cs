using SQLite;
using Xamarin.Forms;
using System;

namespace PUMA.Models
{
    [Table("PumaImage")]
    public class PumaImage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int PumaId { get; set; }

        [MaxLength(250)]
        public string ImageFilename { get; set; }

        [MaxLength(250)]
        public string Credit { get; set; }

        public ImageSource ImageSource
        {
            //get { return ImageSource.FromResource(string.Format("PUMA.Resources.Images.{0}.ID{1}.Carousel.{2}", this.GetType().Name.Replace("Image", ""), PumaId, ImageFilename)); }
            get { return string.Format("http://129.82.38.57:61045/api/{0}/{1}/images/{2}", "Pumas", PumaId, Id); }
        }

    }
}
