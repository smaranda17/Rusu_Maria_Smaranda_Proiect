using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rusu_Maria_Smaranda_Proiect.Data;
using System.IO;

namespace Rusu_Maria_Smaranda_Proiect
{
    public partial class App : Application
    {
        static FilmsListDatabase database;

        public static FilmsListDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new
                        FilmsListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FilmsList.db1"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
