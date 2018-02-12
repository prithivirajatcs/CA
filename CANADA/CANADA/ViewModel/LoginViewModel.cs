using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
//using Plugin.Connectivity;
using System.Diagnostics;
using CANADA.Interface;
using CANADA.Model;
using CANADA.Services;
using System.IO;

namespace CANADA.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region "Properties"
        public INavigationService navigationService;

        string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                CheckLoginStatus();
                OnPropertyChanged("UserName");
            }
        }


        string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                CheckLoginStatus();
                OnPropertyChanged("Password");
            }
        }

        Color _loginButtonBackgroundColor;
        public Color LoginButtonBackgroundColor
        {
            get
            {
                return _loginButtonBackgroundColor;
            }
            set
            {
                _loginButtonBackgroundColor = value;

                OnPropertyChanged("LoginButtonBackgroundColor");
            }
        }

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



        Color _loginButtonTextColor;
        public Color LoginButtonTextColor
        {
            get
            {
                return _loginButtonTextColor;
            }
            set
            {
                _loginButtonTextColor = value;

                OnPropertyChanged("LoginButtonTextColor");
            }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand RememberMeCommand { get; set; }
        public ICommand ForgotPasswordCmd { get; set; }
        #endregion

        #region "Events And Methods"

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        /// <summary>
        /// Used to handle Login Button
        /// </summary>
        /// <param name="navService"></param>

        public LoginViewModel(INavigationService navService)
        {
            navigationService = navService;

            UserName = string.Empty;
            Password = string.Empty;

            LoginButtonBackgroundColor = (Color)Application.Current.Resources["BannerColor"];
            LoginButtonTextColor = (Color)Application.Current.Resources["LoginActiveTextColor"];


            this.LoginCommand = new Command((action) =>
           {

                this.IsBusy = true;
               UserInfoModel loginmodel = new UserInfoModel();
               var currentApp = Application.Current as App;
                   
                   if (App.IsTestModeEnabled)
                   {
                       loginmodel.User_Name = "test";
                       loginmodel.Password = "test";
                   }

                AboutCanandaListModel resposeList = App.MyApplicationDataSource.GetAboutList().Result;
               this.IsBusy = false;
               App.NavigationServiceInstance.NavigateTo(Enum.PageName.HOME, resposeList, false);


           });


            this.ForgotPasswordCmd = new Command(() =>
            {
            });
        }

        private void CheckLoginStatus()
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                //LoginButtonBackgroundColor = (Color)Application.Current.Resources["Primary"];
                LoginButtonBackgroundColor = Color.FromHex("#00465B");
                //LoginButtonTextColor = (Color)Application.Current.Resources["LoginInActiveTextColor"];
                LoginButtonTextColor = Color.FromHex("#BCD432");
            }
            else
            {
                LoginButtonBackgroundColor = (Color)Application.Current.Resources["BannerColor"];
                LoginButtonTextColor = (Color)Application.Current.Resources["LoginInActiveTextColor"];
            }

        }
        #endregion
    }
}
