
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Helpers
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022        1.0         Anuruddha.Rajapaksha   		  Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Plugin.Settings;
using Plugin.Settings.Abstractions;
#endregion


namespace Mobile.Helpers {
    public static class Settings {

        private static ISettings AppSettings => CrossSettings.Current;

        public static string GeneralSettings {
            get => AppSettings.GetValueOrDefault(nameof(GeneralSettings), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(GeneralSettings), value);
        }

#if DEBUG
        public static bool UseMock {
            get => AppSettings.GetValueOrDefault(nameof(UseMock), true); // You can change here.
            set => AppSettings.AddOrUpdateValue(nameof(UseMock), value);
        }
#else
        public static bool UseMock {
            get => AppSettings.GetValueOrDefault(nameof(UseMock), false); // Dont't change here
            set => AppSettings.AddOrUpdateValue(nameof(UseMock), value);
        }
#endif


#if DEBUG
        public static string DeviceId {
            get => AppSettings.GetValueOrDefault(nameof(DeviceId), "PDT001");
            set => AppSettings.AddOrUpdateValue(nameof(DeviceId), value);
        }
#else
        public static string DeviceId {
            get => AppSettings.GetValueOrDefault(nameof(DeviceId), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(DeviceId), value);
        }
#endif

        public static string Language {
            get => AppSettings.GetValueOrDefault(nameof(Language), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Language), value);
        }

        public static string ApplicationUrl {
            get => AppSettings.GetValueOrDefault(nameof(ApplicationUrl), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ApplicationUrl), value);
        }

    }
}
