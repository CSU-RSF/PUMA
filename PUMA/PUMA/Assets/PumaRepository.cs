using System.Collections.Generic;
using System.Linq;
using PUMA.Models;

namespace PUMA
{

    public class PumaRepository : DBConnection
	{

        public PumaRepository()
		{
            // Create the Puma Type table (only if it's not yet created)
            conn.CreateTable<Puma>();
		}

        public List<Puma> GetAllPumas()
        {
            // return a list of Puma Types saved to the table in the database
            return (from p in conn.Table<Puma>() select p).ToList();
        }

    }
}