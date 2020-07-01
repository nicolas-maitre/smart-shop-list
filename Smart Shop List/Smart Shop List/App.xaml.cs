using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Smart_Shop_List.Services;
using Smart_Shop_List.Views;

namespace Smart_Shop_List
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
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
