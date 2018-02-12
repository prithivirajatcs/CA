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
        public void InitHeader(string title, bool isMainPage = false)
        {
            HeaderTitle.Text = title;
            HeaderTitle.HorizontalTextAlignment = TextAlignment.Start;
            HeaderTitle.IsVisible = true;
        }

    }
}
