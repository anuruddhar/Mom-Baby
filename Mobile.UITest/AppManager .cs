#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.UITest
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
 22/07/2019         1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System;
using Xamarin.UITest;
#endregion

namespace Mobile.UITest {
    static class AppManager {
        const string ApkPath = "../../../Binaries/TaskyDroid.apk";
        const string AppPath = "../../../Binaries/TaskyiOS.app";
        const string IpaBundleId = "com.xamarin.samples.taskytouch";

        static IApp app;
        public static IApp App {
            get {
                if (app == null)
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return app;
            }
        }

        static Platform? platform;
        public static Platform Platform {
            get {
                if (platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return platform.Value;
            }

            set {
                platform = value;
            }
        }

        public static void StartApp() {
            if (Platform == Platform.Android) {
                app = ConfigureApp
                    .Android
                    // Used to run a .apk file:
                    // .ApkFile(ApkPath)
                    .InstalledApp("com.mombaby.uat")
                    .StartApp();
            }

            if (Platform == Platform.iOS) {
                app = ConfigureApp
                    .iOS
                    // Used to run a .app file on an ios simulator:
                    .AppBundle(AppPath)
                    // Used to run a .ipa file on a physical ios device:
                    //.InstalledApp(ipaBundleId)
                    .StartApp();
            }
        }
    }
}
