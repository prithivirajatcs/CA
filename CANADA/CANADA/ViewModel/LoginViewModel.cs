using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using CANADA.Interface;
using CANADA.Model;
using Xamarin.Forms;

namespace CANADA.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
        }

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

        public LoginViewModel(INavigationService navService)
        {
            navigationService = navService;

                UserName = string.Empty;
                Password = string.Empty;
                LoginButtonBackgroundColor = (Color)Application.Current.Resources["BannerColor"];
                LoginButtonTextColor = (Color)Application.Current.Resources["LoginActiveTextColor"];


            this.LoginCommand = new Command((action) =>
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //{
                //    Application.Current.MainPage.DisplayAlert("", "Please check your internet connection", "OK");
                //}
                //else
                //{
                    UserInfoModel loginmodel = new UserInfoModel();
                    var currentApp = Application.Current as App;
                    if (ValidateLogin())
                    {
                        this.IsBusy = true;
                        if (App.IsTestModeEnabled)
                        {
                            loginmodel.User_Name = "CAWipro";
                            loginmodel.Password = "Wipro123";
                            //UtilService.UserName = "akarthsu";
                            //UtilService.Password = "Autumn17";
                        App.NavigationServiceInstance.NavigateTo(Enum.PageName.HOME, "", false);
                        }

                    //}
                }

            });

        }
        public bool ValidateLogin()
        {
            try
            {
                if (!string.IsNullOrEmpty((UserName.Trim())) && !string.IsNullOrEmpty((Password.Trim())) && UserName != Password)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }

        }
        private void CheckLoginStatus()
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                LoginButtonBackgroundColor = Color.FromHex("#00465B");
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
