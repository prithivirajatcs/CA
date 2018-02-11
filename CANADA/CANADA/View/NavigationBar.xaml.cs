using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CANADA.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationBar : ContentView
    {
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

        public static NavigationBar MyNavigationBar { get; set; }

        public NavigationBar()
        {
            InitializeComponent();

            MyNavigationBar = this;

            //if (Device.OS == TargetPlatform.iOS)
            //{
            //    MainContent.Padding = new Thickness(0, 20, 0, 0);
            //    MainContent.HeightRequest = 70;
            //    HeaderParentGrid.RowDefinitions[0].Height = 70;
            //}
        }

        //public void OnHamburgerButtonPressed(object sender, EventArgs args)
        //{
        //    if (!string.IsNullOrEmpty(UtilService.globalId))
        //    {
        //        UserName.Text = UtilService.Instance.RawUserProfile.userProfileName;

        //        if (Constants.Environment == "QA")
        //        {
        //            Version.Text = "V " + DependencyService.Get<IAppVersion>().Version + " - " + Constants.Environment;
        //        }
        //        else
        //        {
        //            Version.Text = "V " + DependencyService.Get<IAppVersion>().Version;
        //        }

        //    }
        //    //Show Hamburger Menu Here
        //    if (HamburgerCommand != null)
        //    {
        //        //HamburgerCommand.Execute(null);
        //        userProfileSection.IsVisible = !userProfileSection.IsVisible;
        //        if (userProfileSection.IsVisible)
        //        {
        //            menuHamburger.Source = "Close.png";
        //        }
        //        else
        //        {
        //            menuHamburger.Source = "Menubar.png";

        //        }
        //    }
        //}


        //public void OnLogoutPressed(object sender, EventArgs args)
        //{
        //    try
        //    {
        //        if (App.CustomNavigation.NavigationStack.Count > 0)
        //        {
        //            if (App.CustomNavigation.NavigationStack.Count == 2)
        //            {
        //                Device.BeginInvokeOnMainThread(async () =>
        //                {
        //                    var result = await App.Current.MainPage.DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
        //                    if (result)
        //                    {
        //                        App.Logout();
        //                    }
        //                });
        //            }
        //            else
        //            {
        //                App.NavigationServiceInstance.GoBack();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}

        public void InitHeader(string title, bool isMainPage = false, bool isNoIcons = false)


        {
            HeaderTitle.Text = title;
            HeaderTitle.HorizontalTextAlignment = TextAlignment.Start;
            HeaderTitle.IsVisible = true;
        }

        //    if (isNoIcons)
        //    {

        //        menuBack.IsVisible = false;
        //        menuHamburger.IsVisible = false;

        //        return;
        //    }

        //    //Left Side icons visible/invisible
        //    menuBack.IsVisible = !isMainPage;
        //    menuHamburger.IsVisible = isMainPage;
        //    userProfileSection.IsVisible = false;

        //}

        public ICommand HamburgerCommand { get; set; }

    }
}
