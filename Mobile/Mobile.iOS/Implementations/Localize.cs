#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Localization
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
03/07/2018        1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.iOS.Implementations;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using Mobile;
#endregion	  

[assembly: Dependency(typeof(Localize))]
namespace Mobile.iOS.Implementations {
    public class Localize : ILocalize {

        #region Interface Implementation
        public void SetLocale(CultureInfo ci) {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public CultureInfo GetCurrentCultureInfo(string _netLanguage) {
            var netLanguage = "en";
            /*var androidLocale = Java.Util.Locale.Default; //Java.Util.Locale.Default; Java.Util.Locale.English; Java.Util.Locale.Taiwan;
            netLanguage = AndroidToDotnetLanguage(androidLocale.ToString().Replace("_", "-"));*/

            //netLanguage = "fr-FR";
            netLanguage = _netLanguage;//"zh-TW";

            // this gets called a lot - try/catch can be expensive so consider caching or something
            CultureInfo ci = null;
            try {
                ci = new CultureInfo(netLanguage);
            } catch (CultureNotFoundException e1) {
                // iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
                // fallback to first characters, in this case "en"
                try {
                    // var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage)); #todo uncomment and fix
                    // ci = new CultureInfo(fallback); #todo uncomment and fix
                } catch (CultureNotFoundException e2) {
                    // iOS language not valid .NET culture, falling back to English
                    ci = new CultureInfo("en");
                }
            }

            return ci;
        }
        #endregion

        #region Methods
        private string AndroidToDotnetLanguage(string androidLanguage) {
            var netLanguage = androidLanguage;

            //certain languages need to be converted to CultureInfo equivalent
            switch (androidLanguage) {
                case "ms-BN":   // "Malaysian (Brunei)" not supported .NET culture
                case "ms-MY":   // "Malaysian (Malaysia)" not supported .NET culture
                case "ms-SG":   // "Malaysian (Singapore)" not supported .NET culture
                    netLanguage = "ms"; // closest supported
                    break;
                case "in-ID":  // "Indonesian (Indonesia)" has different code in  .NET 
                    netLanguage = "id-ID"; // correct code for .NET
                    break;
                case "gsw-CH":  // "Schwiizertüütsch (Swiss German)" not supported .NET culture
                    netLanguage = "de-CH"; // closest supported
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }

            return netLanguage;
        }

        //private string ToDotnetFallbackLanguage(PlatformCulture platCulture) { #todo uncomment and fix
        //    var netLanguage = platCulture.LanguageCode; // use the first part of the identifier (two chars, usually);

        //    switch (platCulture.LanguageCode) {
        //        case "gsw":
        //            netLanguage = "de-CH"; // equivalent to German (Switzerland) for this app
        //            break;
        //            // add more application-specific cases here (if required)
        //            // ONLY use cultures that have been tested and known to work
        //    }
        //    return netLanguage;
        //}
        #endregion
    }
}