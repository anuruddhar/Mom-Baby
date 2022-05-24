
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Common
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022       	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
#endregion	  

namespace Mobile {
    public class L10n {
        const string ResourceId = "Mobile.Language.AppResources";

        static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, IntrospectionExtensions.GetTypeInfo(typeof(L10n)).Assembly));

        public static void SetLocale(CultureInfo ci) {
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        /// <remarks>
        /// Maybe we can cache this info rather than querying every time
        /// </remarks>
        [Obsolete]
        public static string Locale() {
            return DependencyService.Get<ILocalize>().GetCurrentCultureInfo(GlobalSetting.Instance.NetLanguage).ToString();
        }

        public static string Localize(string key, string comment) {
            //var netLanguage = Locale();

            // Platform-specific
            string result = ResMgr.Value.GetString(key, DependencyService.Get<ILocalize>().GetCurrentCultureInfo(GlobalSetting.Instance.NetLanguage));

            if (result == null) {
                result = key;
            }
             
            return result.Replace("\\r\\n", Environment.NewLine);
        }
    }
}
