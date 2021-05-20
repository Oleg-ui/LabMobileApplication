using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace LabWork
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "RateInfoTable.db";
        public static RateInfoRepository database;
        public static RateInfoRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new RateInfoRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new PageShell();
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
