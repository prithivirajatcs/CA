using CANADA.Interface;
using CANADA.Services;
using Xamarin.Forms;

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
            try
            {
                InitializeComponent();
                IsTestModeEnabled = false;
                //MyApplicationDataSource = new StubDataSource();
                MyApplicationDataSource = new RestDataSource(Constants.Environment);
                NavigationServiceInstance = DependencyService.Get<INavigationService>();
                try
                {
                    NavigationServiceInstance.CreatePageMap();
                }
                catch (System.Exception ex)
                {

                }


                if (IsTestModeEnabled == false)
                {
                    NavigationServiceInstance.NavigateTo(Enum.PageName.LOGIN, "", true);
                }
            }
            catch (System.Exception ex)
            {

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
