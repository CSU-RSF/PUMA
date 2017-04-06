using System.Collections.Generic;
using System.Linq;
using PUMA.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PUMA
{

    public class PumaImageRepository : DBConnection
    {
        public string StatusMessage { get; set; }
        ExternalDBConnection externalConnection = new ExternalDBConnection();

        public PumaImageRepository()
        {
            // Create the Puma Type Image table (only if it's not yet created)
            conn.CreateTable<PumaImage>();
        }

        // return a list of Puma Type Images saved to the table in the database
        public List<PumaImage> GetAllPumasImages()
        {
            return (from p in conn.Table<PumaImage>() select p).ToList();
        }

        // return a list of Puma Type Images for the Puma Type specified
        public List<PumaImage> PumaImages(int pumaId)
        {
            return conn.Table<PumaImage>().Where(p => p.PumaId.Equals(pumaId)).ToList();
        }

        // return a list of Puma Type Images for the Puma Type specified
        public async Task<ObservableCollection<PumaImage>> PumaApiImages(int pumaId)
        {
            ObservableCollection<PumaImage> pumaImages = await externalConnection.GetImages(pumaId);
            return pumaImages;
        }

    }
}