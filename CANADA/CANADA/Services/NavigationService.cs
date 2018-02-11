using System;
using System.Collections.Generic;
using System.Diagnostics;
using CANADA.CustomControl;
using CANADA.Enum;
using CANADA.Interface;
using CANADA.Services;
using CANADA.View;
using Xamarin.Forms;

[assembly: Dependency(typeof(NavigationService))]
namespace CANADA.Services
{
    public class NavigationService : INavigationService
    {
        public static Dictionary<PageName, Type> PageMapping = new Dictionary<PageName, Type>();
        private ContentPage appContext;

        public NavigationService()
        {
        }

        public void CreatePageMap()
        {
            #region "Page Mapping Init"
            PageMapping.Clear();
            PageMapping.Add(PageName.LOGIN, typeof(LoginPage));

            //iApprove Page Mapping for Navigation
            //PageMapping.Add(PageName.LOGIN, typeof(LoginPage));
            //PageMapping.Add(PageName.HOME, typeof(HomePage));
            #endregion
        }

        public void NavigateTo(PageName page, object param, bool isStartPage = false)
        {
            try
            {
                BaseContentPage screenObj = null;
                if (param != null)
                {
                    try
                    {
                        screenObj = (BaseContentPage)Activator.CreateInstance(PageMapping[page], param);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message.ToString());
                    }
                }
                else
                {
                    screenObj = (BaseContentPage)Activator.CreateInstance(PageMapping[page]);
                }

                if (!isStartPage)
                {
                    if (screenObj != null)
                    {
                        if (App.IsMasterDetailFlow)
                        {
                            //((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushAsync(screenObj, true);

                            ((MasterDetailPage)Application.Current.MainPage).Detail = screenObj;
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(() => { Application.Current.MainPage.Navigation.PushAsync(screenObj, true); });

                        }
                    }
                }
                else
                {
                    SetStartPage(screenObj);
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }

        }

        public void SetStartPage(Page page)
        {

            Application.Current.MainPage = new CustomNavigationPage(page);
            App.CustomNavigation = Application.Current.MainPage.Navigation;
        }

        public T GetPageInstance<T>(PageName page) where T : new()
        {
            return (T)Activator.CreateInstance(PageMapping[page]);
        }

        public void SetAppContext(object context)
        {
            this.appContext = (ContentPage)context;
        }

        public void GotoHomePage()
        {
            Application.Current.MainPage.Navigation.PopToRootAsync(true);
        }

        public void GoBack()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
