
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
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
#endregion	

namespace Mobile {
    // You exclude the 'Extension' suffix when using in Xaml markup
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) {
            if (Text == null)
                return string.Empty;

            // Do your translation lookup here, using whatever method you require
            var translated = L10n.Localize(Text, Text);

            return translated;
        }
    }
}
