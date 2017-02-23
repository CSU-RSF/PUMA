using System.Collections.Generic;
using System.Linq;
using PUMA.Models;

namespace PUMA
{

    public class PumaTypeRepository : DBConnection
	{

        public PumaTypeRepository()
		{
            // Create the Puma Type table (only if it's not yet created)
            conn.CreateTable<PumaType>();
		}

        public List<PumaType> GetAllPumaTypes()
        {
            // return a list of Puma Types saved to the table in the database
            return (from p in conn.Table<PumaType>() select p).ToList();
        }

    }
}