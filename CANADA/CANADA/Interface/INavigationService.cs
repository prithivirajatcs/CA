using System;
using CANADA.Enum;

namespace CANADA.Interface
{
    public interface INavigationService
    {
        void SetAppContext(object context);
        void NavigateTo(PageName page, object param, bool isStartPage = false);
        void GotoHomePage();
        void GoBack();
        void CreatePageMap();
        T GetPageInstance<T>(Enum.PageName page) where T : new();
    }
}
