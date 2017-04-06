using SQLite;
using PUMA.Models;
using System.Collections.ObjectModel;

namespace PUMA
{
    public class DBConnection
    {
        protected static SQLiteConnection conn { get; set; }

        // Initialize connection if it hasn't already been initialized
        public DBConnection(SQLiteConnection newConn = null) 
        {
            if (conn == null) { conn = newConn; } 
        }

        // Seed database with Puma info
        public void SeedDB()
        {
            ObservableCollection<Puma> pumas = new ObservableCollection<Puma>(App.PumasRepo.GetAllPumas());
            if (pumas.Count == 0)
            {
                conn.Insert(new Puma() { Name = "Cougar", Description = "Cougar Description..." });
                conn.Insert(new Puma() { Name = "Florida Panther", Description = "Florida Panther Description..." });
                conn.Insert(new PumaImage() { PumaId = 1, ImageFilename = "Cougar1.jpg", Credit = "Cougar1 Credit" });
                conn.Insert(new PumaImage() { PumaId = 2, ImageFilename = "FloridaPanther1.jpg", Credit = "FloridaPanther1 Credit" });
                conn.Insert(new PumaImage() { PumaId = 1, ImageFilename = "Cougar2.jpg", Credit = "Cougar2 Credit" });
            }
        }

        //TODO: Develop example JSON data pull from external database and store locally (instead of a seed file)
    }
}
