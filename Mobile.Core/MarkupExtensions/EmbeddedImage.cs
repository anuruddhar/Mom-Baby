
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
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
#endregion	  

namespace Mobile.Core.MarkupExtensions {
    public class EmbeddedImage : IMarkupExtension {

        public string ResourceId { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider) {
            if (!string.IsNullOrEmpty(ResourceId)) {
                return ImageSource.FromResource(ResourceId);
            }
            return null;

        }
    }
}
