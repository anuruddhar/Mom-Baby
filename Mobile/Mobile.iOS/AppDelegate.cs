
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.Core
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
using FFImageLoading.Forms.Platform;
using Foundation;
using Lottie.Forms.iOS.Renderers;
using Prism;
using Prism.Ioc;
using UIKit;
#endregion


namespace Mobile.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Rg.Plugins.Popup.Popup.Init();
            global::Xamarin.Forms.Forms.Init();
            LeoJHarris.FormsPlugin.iOS.EnhancedEntryRenderer.Init();
            CachedImageRenderer.Init();
            AnimationViewRenderer.Init();
            LoadApplication(new App(new iOSInitializer()));
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes {
                Font = UIFont.FromName("Open Sans", 20)
            });
            return base.FinishedLaunching(app, options);

        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {

        }
    }
}
