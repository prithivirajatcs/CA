﻿using System;
using Xamarin.Forms;
using CANADA.CustomControl;
using CANADA.ViewModel;

namespace CANADA.View
{
    public partial class LoginPage : BaseContentPage
    {

        #region "Properties"
        private LoginViewModel vm;
        #endregion

        #region "Methods"

        public LoginPage()
        {
            InitPage();
        }
        public LoginPage(object args)
        {
            this.ControlTemplate = null;
            InitPage();
        }
        private void InitPage()
        {
            try
            {
                InitializeComponent();
                vm = new LoginViewModel(App.NavigationServiceInstance);
                this.BindingContext = vm;
            }
            catch (Exception ex)
            {

            }


        }
        #endregion

        #region "Events"

        protected override void OnDisappearing()
        {
            try
            {
                vm.IsBusy = false;
            }
            catch (Exception ex)
            {

            }

            base.OnDisappearing();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


        #endregion

        #region "Events"
        void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (vm.UserName != null)
            {
                BoxViewUserName.Color = Color.FromHex("#BCD432");
                Textbox.TextColor = Color.FromHex("#00465B");
                UserIcon.Source = "UsernameSelected.png";
            }
        }

        void Handle_Foocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (vm.Password != null)
            {
                BoxViewPassword.Color = Color.FromHex("#BCD432");
                Password.TextColor = Color.FromHex("#00465B");
                UserPassword.Source = "PasswordSelected.png";
            }

        }

        void Handle_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(vm.UserName))
            {
                BoxViewUserName.Color = Color.FromHex("#E3E3E3");
                Textbox.TextColor = Color.FromHex("#B9B9B9");
                UserIcon.Source = "Username.png";
            }
            else
            {
                BoxViewUserName.Color = Color.FromHex("#BCD432");
                Textbox.TextColor = Color.FromHex("#00465B");
                UserIcon.Source = "UsernameSelected.png";
            }

        }

        void Handle_Unfoocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(vm.Password))
            {
                BoxViewPassword.Color = Color.FromHex("#E3E3E3");
                Password.TextColor = Color.FromHex("#B9B9B9");
                UserPassword.Source = "Password.png";

            }
            else
            {
                BoxViewPassword.Color = Color.FromHex("#BCD432");
                Password.TextColor = Color.FromHex("#00465B");
                UserPassword.Source = "PasswordSelected.png";

            }
        }

        #endregion
    }
}
