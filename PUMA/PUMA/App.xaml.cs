using SQLite;
using Xamarin.Forms;

namespace PUMA
{
    public partial class App : Application
    {
        // Create variables to hold repository instances
        public static PumaTypeRepository PumaTypesRepo { get; private set; }
        public static PumaTypeImageRepository PumaTypeImageRepo { get; private set; }

        // Initialize app
        public App(string dbPath)
        {
            // Initialize SQLite connection and DBConnection class to hold connection
            SQLiteConnection newConn = new SQLiteConnection(dbPath);
            DBConnection dbConn = new DBConnection(newConn);

            // Initialize Repositories and seed database
            PumaTypesRepo = new PumaTypeRepository();
            PumaTypeImageRepo = new PumaTypeImageRepository();
            dbConn.SeedDB();

            InitializeComponent();

            // Initialize MainPage as a NavigationPag
            this.MainPage = new NavigationPage(new MainPage());

            //TODO: Logo and icon guidelines for each platform
            //TODO: Implement PCL settings solution
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
