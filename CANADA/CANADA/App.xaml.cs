using System;
using Xamarin.Forms;
using CANADA.Interface;
using CANADA.Services;
using CANADA.ViewModel;

namespace CANADA
{
    public partial class App : Application
    {
        public static INavigationService NavigationServiceInstance;
        public static INavigation CustomNavigation;
        public static ICommonUtility MyUtility;
        public static IDataSource MyApplicationDataSource;
        public static bool IsMasterDetailFlow = false;
        public static bool IsTestModeEnabled = false;
        public static ContentPage presentContentPage;

        public App()
        {
            InitializeComponent();
            //TODO Comment before build
            IsTestModeEnabled = true;
            //MyApplicationDataSource = new StubDataSource();
            MyApplicationDataSource = new RestDataSource(Constants.Environment);
            MyUtility = DependencyService.Get<ICommonUtility>();
            NavigationServiceInstance = DependencyService.Get<INavigationService>();
            NavigationServiceInstance.CreatePageMap();
            // MainPage = new camerapocPage();




            //TODO: Enable this for RT POC
            if (IsMasterDetailFlow)
            {
                // MainPage = new MasterMainPage();
            }
            else
            {
                NavigationServiceInstance.NavigateTo(Enum.PageName.LOGIN, "", true);
            }

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

 

        public static void Logout()
        {
            App.NavigationServiceInstance.GoBack();
        }
    }
}
