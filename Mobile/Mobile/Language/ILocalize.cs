
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
using System.Globalization;
#endregion	  

namespace Mobile {
    /// <summary>
    /// Implementations of this interface MUST convert iOS and Android
    /// platform-specific locales to a value supported in .NET because
    /// ONLY valid .NET cultures can have their RESX resources loaded and used.
    /// </summary>
    /// <remarks>
    /// Lists of valid .NET cultures can be found here:
    ///   http://www.localeplanet.com/dotnet/
    ///   http://www.csharp-examples.net/culture-names/
    /// You should always test all the locales implemented in your application.
    /// </remarks>
    public interface ILocalize {
        ///	<summary>
        /// This method must evaluate platform-specific locale settings
        /// and convert them (when necessary) to a valid .NET locale.
        /// </summary>
        CultureInfo GetCurrentCultureInfo(string _netLanguage);

        /// <summary>
        /// CurrentCulture and CurrentUICulture must be set in the platform project, 
        /// because the Thread object can't be accessed in a PCL.
        /// </summary>
        void SetLocale(CultureInfo ci);
    }

    /// <summary>
    /// Helper class for splitting locales like
    ///   iOS: ms_MY, gsw_CH
    ///   Android: in-ID
    /// into parts so we can create a .NET culture (or fallback culture)
    /// </summary>
    public class PlatformCulture {
        public PlatformCulture(string platformCultureString) {
            if (String.IsNullOrEmpty(platformCultureString))
                throw new ArgumentException("Expected culture identifier", "platformCultureString"); // in C# 6 use nameof(platformCultureString)

            PlatformString = platformCultureString.Replace("_", "-"); // .NET expects dash, not underscore
            var dashIndex = PlatformString.IndexOf("-", StringComparison.Ordinal);
            if (dashIndex > 0) {
                var parts = PlatformString.Split('-');
                LanguageCode = parts[0];
                LocaleCode = parts[1];
            } else {
                LanguageCode = PlatformString;
                LocaleCode = "";
            }
        }
        public string PlatformString { get; private set; }
        public string LanguageCode { get; private set; }
        public string LocaleCode { get; private set; }
        public override string ToString() {
            return PlatformString;
        }
    }
}
