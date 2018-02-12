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

        public static IDataSource MyApplicationDataSource;
        public static bool IsMasterDetailFlow = false;
        public static bool IsTestModeEnabled = false;
        public static ContentPage presentContentPage;

        public App()
        {
            InitializeComponent();
            IsTestModeEnabled = true;
            MyApplicationDataSource = new RestDataSource();
            NavigationServiceInstance = DependencyService.Get<INavigationService>();
            NavigationServiceInstance.CreatePageMap();
            NavigationServiceInstance.NavigateTo(Enum.PageName.LOGIN, "", true);
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
