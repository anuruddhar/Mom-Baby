#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.Android
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Acr.UserDialogs;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using FFImageLoading.Forms.Platform;
using Mobile.Views.Base;
// using J = Java.IO;
using Lottie.Forms.Droid;
using Prism;
using Prism.Events;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Mobile.Helpers.AppConstant;
#endregion

namespace Mobile.Droid {
    [Activity(
        Label = ApplicationName.UAT,
        Icon = "@mipmap/ic_launcher",
        Theme = "@style/splashscreen",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode,
        ScreenOrientation = ScreenOrientation.Portrait
        )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {

        protected override void OnCreate(Bundle bundle) {
            // Name of the MainActivity theme you had there before.
            // Or you can use global::Android.Resource.Style.ThemeHoloLight
            base.SetTheme(Resource.Style.MainTheme);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Globals.Window = Window;

            //Issue(Android.OS.FileUriExposedException  Message=file:///storage/emulated/0/Pictures/SQLite.db3 exposed beyond app through ClipData.Item.getUri()) Fixed: In LocalDB->SendEmail
            // https://forums.xamarin.com/discussion/97273/launch-camera-activity-with-saving-file-in-external-storage-crashes-the-app
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());

            base.OnCreate(bundle);

            CopyFontFiles();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;


            global::Rg.Plugins.Popup.Popup.Init(this, bundle);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);
            CachedImageRenderer.Init(true);
            GlobalSetting.Instance.Context = this;
            // For #-----XamarinEssentials------# 
            // Xamarin.Essentials.Platform.Init(this, bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LeoJHarris.FormsPlugin.Droid.EnhancedEntryRenderer.Init(this);
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            SetScreenDimension();

            DisplayCrashReport();

            AnimationViewRenderer.Init();
            UserDialogs.Init(this);

            var application = new App(new AndroidInitializer());
            var EventAggregator = application.Container.Resolve<IEventAggregator>();
            Globals.EventAggregator = EventAggregator;

            LoadApplication(application);


            Android.Support.V7.Widget.Toolbar toolbar
                    = this.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            // HTTPS ignore certificate [This is no longer required, in RequestProvider->CreateHttpClient method this is corrected]
            // https://forums.xamarin.com/discussion/69210/https-ignore-certificate
            // System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        private async Task CopyFontFiles() {
            FileHelper fileHelper = new FileHelper();

            fileHelper.CreateAppFolderPath();

            if (CheckAppPermissions()) {
                using (Stream stream = this.Assets.Open(PrintConstant.ENGLISH_FONT_NAME)) {
                    using (var dest = File.OpenWrite(fileHelper.GetEnglishFontPath())) {
                        await stream.CopyToAsync(dest);
                    }
                }

                using (Stream stream = this.Assets.Open(PrintConstant.ENGLISH_ITALIC_FONT_NAME)) {
                    using (var dest = File.OpenWrite(fileHelper.GetEnglishItalicFontPath())) {
                        await stream.CopyToAsync(dest);
                    }
                }

            }

        }

        public bool CheckAppPermissions() {
            if ((int)Build.VERSION.SdkInt < 23) {
                return true;
            }

            if (!(ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted) && !(ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) == (int)Permission.Granted)) {
                var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
                ActivityCompat.RequestPermissions(this, permissions, 0); // REQUEST_FOLDER_PERMISSION 
                return false;
            }
            return true;

        }


        // For #-----XamarinEssentials------# 
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void SetScreenDimension() {
            var width = Resources.DisplayMetrics.WidthPixels;
            var height = Resources.DisplayMetrics.HeightPixels;
            var density = Resources.DisplayMetrics.Density;
            App.ScreenWidth = (width - 0.5f) / density;
            App.ScreenHeight = (height - 0.5f) / density;
        }


        public override bool OnOptionsItemSelected(IMenuItem item) {
            // check if the current item id is equals to the back button id
            if (item.ItemId == 16908332) // xam forms nav bar back button id
            {
                // retrieve the current xamarin 
                // forms page instance
                var currentpage = (CustomContentPage)Xamarin.Forms.Application.Current.
                     MainPage.Navigation.NavigationStack.LastOrDefault();

                // check if the page has subscribed to the custom back button event
                if (currentpage?.CustomBackButtonAction != null) {
                    // invoke the Custom back button action
                    currentpage?.CustomBackButtonAction.Invoke();
                    // and disable the default back button action
                    return false;
                }

                // if its not subscribed then go ahead with the default back button action
                return base.OnOptionsItemSelected(item);
            } else {
                // since its not the back button click, pass the event to the base
                return base.OnOptionsItemSelected(item);
            }
        }

        #region Error handling
        private static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs) {
            var newExc = new Exception("TaskSchedulerOnUnobservedTaskException", unobservedTaskExceptionEventArgs.Exception);
            LogUnhandledException(newExc);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs) {
            var newExc = new Exception("CurrentDomainOnUnhandledException", unhandledExceptionEventArgs.ExceptionObject as Exception);
            LogUnhandledException(newExc);
        }

        internal static void LogUnhandledException(Exception exception) {
            try {
                const string errorFileName = "Fatal.log";
                var libraryPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).AbsolutePath;
                    //System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // iOS: Environment.SpecialFolder.Resources
                var errorFilePath = Path.Combine(libraryPath, errorFileName);
                var errorMessage = String.Format("Time: {0}!&#x0a;Error: Unhandled Exception!&#x0a;{1}",DateTime.Now, exception.ToString());
                File.WriteAllText(errorFilePath, errorMessage);

                // Log to Android Device Logging.
                // Android.Util.Log.Error("Crash Report", errorMessage);

            } catch {
                // just suppress any error logging exceptions
            }
        }

        /// <summary>
        // If there is an unhandled exception, the exception information is diplayed 
        // on screen the next time the app is started (only in debug configuration)
        /// </summary>
        [Conditional("DEBUG")]
        private void DisplayCrashReport() {
            const string errorFilename = "Fatal.log";
            var libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var errorFilePath = Path.Combine(libraryPath, errorFilename);

            if (!File.Exists(errorFilePath)) {
                return;
            }

            var errorText = File.ReadAllText(errorFilePath);
            new AlertDialog.Builder(this)
                .SetPositiveButton("Clear", (sender, args) => {
                    File.Delete(errorFilePath);
                })
                .SetNegativeButton("Close", (sender, args) => {
                    // User pressed Close.
                })
                .SetMessage(errorText)
                .SetTitle("Crash Report")
                .Show();
        }
        #endregion

        protected override void OnResume() {
            base.OnResume();
        }

        protected override void OnPause() {
            base.OnPause();
        }

        protected override void OnDestroy() {
            base.OnDestroy();
        }
    }

    public class AndroidInitializer : IPlatformInitializer {
        public void RegisterTypes(IContainerRegistry container) {
            // Register any platform specific implementations
        }
    }

}