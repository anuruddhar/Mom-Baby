#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Setting
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
13/07/2018         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Core.Controls;
using Mobile.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
#endregion

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace Mobile.iOS.Renderers {
    public class CustomPickerRenderer : PickerRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e) {
            base.OnElementChanged(e);

            var element = (CustomPicker)this.Element;

            if (this.Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image)) {
                var downarrow = UIImage.FromBundle(element.Image);
                Control.RightViewMode = UITextFieldViewMode.Always;
                Control.RightView = new UIImageView(downarrow);
            }
        }
    }
}