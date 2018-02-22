
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Xamarin.Forms.Platform.Android;

namespace CANADA.Droid
{
    //[Activity(Label = "CANADA.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [Activity(Label = "CANADA", Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : FormsApplicationActivity
    {
        public static MainActivity CurrentActivity { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            
                base.OnCreate(bundle);
                CurrentActivity = this;
                global::Xamarin.Forms.Forms.Init(this, bundle);
                CachedImageRenderer.Init(true);
                LoadApplication(new App());
                
        }
            
           
    }
}

