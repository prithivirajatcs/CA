using System;
using CANADA.ViewModel;
using Xamarin.Forms;
using CANADA.Enum;
using CANADA.View;

namespace CANADA.CustomControl
{
    public class BaseContentPage : ContentPage
    {
        public static ControlTemplate controlTemplate;

        private Page page;
        bool IsMenuSet = false;
        public BaseContentPage()
        {
            BackgroundColor = Color.White;
            var indicator = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Color = Color.Black,
                IsVisible = false
            };
            NavigationPage.SetHasNavigationBar(this, false);

            this.ControlTemplate = new ControlTemplate(typeof(iApproveNavBar));
        }

        public void SetChildPage(Page childPage)
        {
            this.page = childPage;
        }
        private object sourceData = "";
        public void SetSourceData<T>(T viewModel) where T : new()
        {
            this.sourceData = (T)(object)viewModel;
        }
        public T GetSourceData<T>() where T : new()
        {
            return (T)(object)this.sourceData;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

 
        }
       


    }
}
