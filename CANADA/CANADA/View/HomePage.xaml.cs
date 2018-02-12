using System;
using System.Collections.Generic;
using CANADA.CustomControl;
using CANADA.Model;
using CANADA.ViewModel;
using Xamarin.Forms;

namespace CANADA.View
{
    public partial class HomePage : BaseContentPage
    {
        private HomeViewModel vm;
        private AboutCanandaListModel navparam;
        public HomePage()
        {
            InitPage();
        }
        public HomePage(AboutCanandaListModel args)
        {
            this.navparam = args;
            iApproveNavBar.MyNavigationBar.InitHeader(navparam.pagetitle, isMainPage: true); 
            InitPage();
        }
        private void InitPage()
        {
            try
            {
                InitializeComponent();
                vm = new HomeViewModel(App.NavigationServiceInstance,navparam);
                this.BindingContext = vm;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
