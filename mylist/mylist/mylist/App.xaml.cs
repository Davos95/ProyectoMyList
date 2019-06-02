using mylist.Configuration;
using mylist.Models;
using mylist.Tools;
using mylist.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace mylist
{
    public partial class App : Application
    {
        public StorageSession session;
        private static IoCConfiguration _Locator;
        public static IoCConfiguration Locator
        {
            get
            {
                return _Locator = _Locator ?? new IoCConfiguration();
            }
        }

        public App()
        {
            InitializeComponent();
            this.session = new StorageSession();


            MainPage = new NavigationPage(new MasterPage());
        }

        protected async override void OnStart()
        {
            USER usuario = await this.session.GetStorageUser();

            if (usuario != null)
            {
                MainPage = new NavigationPage(new MasterPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginView());
            }

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
