using System;
using System.Windows.Input;
using CANADA.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CANADA.CustomControl;
using CANADA.Interface;
using System.IO;

namespace CANADA.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class iApproveNavBar : ContentView
    {

        ICommonUtility utility = DependencyService.Get<ICommonUtility>();

        bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;

                OnPropertyChanged("IsBusy");
            }
        }
        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var navStack = App.CustomNavigation.NavigationStack;
            var bindingContext = navStack[navStack.Count - 1].BindingContext;    
        }

        public static iApproveNavBar MyNavigationBar { get; set; }
        public iApproveNavBar()
        {
            InitializeComponent();
            MyNavigationBar = this;
            if (Device.OS == TargetPlatform.iOS)
            {
                MainContent.Padding = new Thickness(0, 20, 0, 0);
                MainContent.HeightRequest = 70;
                HeaderParentGrid.RowDefinitions[0].Height = 70;
            }
        }

        //Events
        //Methods
        public void OnBackButtonPressed(object sender, EventArgs args)
        {

        }


        public void OnHamburgerButtonPressed(object sender, EventArgs args)
        {

            //Show Hamburger Menu Here
            if (HamburgerCommand != null)
            {
               
            }
        }
        public void OnLogoutPressed(object sender, EventArgs args)
        {
            try
            {
                if (App.CustomNavigation.NavigationStack.Count > 0)
                {
                    if (App.CustomNavigation.NavigationStack.Count == 2)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            var result = await App.Current.MainPage.DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
                            if (result)
                            {
                                App.Logout();
                            }
                        });
                    }
                    else
                    {
                        App.NavigationServiceInstance.GoBack();
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
        public void InitHeader(string title, bool isMainPage = false)
        {
            HeaderTitle.Text = title;
            HeaderTitle.HorizontalTextAlignment = TextAlignment.Start;
            HeaderTitle.IsVisible = true;
            userProfileSection.IsVisible = false;
        }
        public ICommand SearchCommand { get; set; }
        public ICommand SearchTextEntryCommand { get; set; }
        public ICommand HamburgerCommand { get; set; }
        public ICommand ClearFilterCommand { get; set; }

    }
}
