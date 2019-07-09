
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using SQLite;
using StarterKit.Common.Helper.Interface;
using StarterKit.UI.Droid.Helper;
using Unity;

namespace StarterKit.UI.Droid
{
    [Activity(Label = "StarterKit.UI", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(savedInstanceState);
                global::Xamarin.FormsMaps.Init(this, savedInstanceState);
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);



                // BootStrapper.Initialize(new SQLiteConnection(FileAccessHelper.GetLocalFilePath("otisdb")));
                // RegisterDeviceServices();
                LoadApplication(new App());
            }
            catch (System.Exception ex)
            {

                 
            }
        }

        void RegisterDeviceServices()
        {
            BootStrapper.Container.RegisterSingleton<ILocalizationService, LocalizationService>();

           // BootStrapper.Container.RegisterSingleton<IDialogService, DialogService>();
        }
    }
}