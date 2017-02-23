using System.Collections.Generic;
using System.Linq;
using PUMA.Models;

namespace PUMA
{

    public class PumaTypeImageRepository : DBConnection
    {
        public string StatusMessage { get; set; }

        public PumaTypeImageRepository()
        {
            // Create the Puma Type Image table (only if it's not yet created)
            conn.CreateTable<PumaTypeImage>();
        }

        // return a list of Puma Type Images saved to the table in the database
        public List<PumaTypeImage> GetAllPumaTypesImages()
        {
            return (from p in conn.Table<PumaTypeImage>() select p).ToList();
        }

        // return a list of Puma Type Images for the Puma Type specified
        public List<PumaTypeImage> PumaTypeImages(int pumaTypeId)
        {
            return conn.Table<PumaTypeImage>().Where(p => p.PumaTypeId.Equals(pumaTypeId)).ToList();
        }

    }
}