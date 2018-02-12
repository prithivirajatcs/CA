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

    }
}
