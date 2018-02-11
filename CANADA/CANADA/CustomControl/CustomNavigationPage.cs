using System;
using CANADA.Interface;
using Xamarin.Forms;

namespace CANADA.CustomControl
{
    public class CustomNavigationPage : NavigationPage
    {
        #region "Properties"
        public INavigationService navigationService;
        #endregion

        #region "Overloading Constructor"
        public CustomNavigationPage(Page content, bool isMenuVisible = true)
            : base(content)
        {

            #region MenuIcon
            if (isMenuVisible)
            {
            }
            #endregion MenuIcon
        }

        #endregion

        #region "Methods"
        private void GenerateAction()
        {
            //IMessageHandler messageHandler = new EUJIT.Services.MessageHandler(App.presentContentPage);  //DependencyService.Get<IMessageHandler>();
            //messageHandler.NegativeButtonHandler += (sender, e) =>
            //{

            //};
            //messageHandler.PositiveButtonHandler += (sender, e) =>
            //{
            //    //Application.Current.MainPage.Navigation.PopToRootAsync(true);
            //    App.NavigationServiceInstance.NavigateTo(Enum.PageName.LOGIN, null, true);

            //};
            //messageHandler.ShowMessageConfirm("Are you sure, you want Logout", "Logout", "Yes", "No");
        }
        #endregion
        public CustomNavigationPage()
        {
        }
    }
}
