
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Delivery
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
13/02/2020         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Core.Controls;
using Mobile.iOS.Renderers;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
#endregion

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace Mobile.iOS.Renderers {
    public class CustomSwitchRenderer : SwitchRenderer {
        Version version = new Version(ObjCRuntime.Constants.Version);
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e) {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;
            var view = (CustomSwitch)Element;
            if (!string.IsNullOrEmpty(view.SwitchThumbImage)) {
                if (version > new Version(6, 0)) {   //n iOS 6 and earlier, the image displayed when the switch is in the on position.  
                    Control.OnImage = UIImage.FromFile(view.SwitchThumbImage.ToString());
                    //n iOS 6 and earlier, the image displayed when the switch is in the off position.  
                    Control.OffImage = UIImage.FromFile(view.SwitchThumbImage.ToString());
                } else {
                    Control.ThumbTintColor = view.SwitchThumbColor.ToUIColor();
                }
            }
            //The color used to tint the appearance of the thumb.  
            Control.ThumbTintColor = view.SwitchThumbColor.ToUIColor();
            //Control.BackgroundColor = view.SwitchBGColor.ToUIColor();  
            //The color used to tint the appearance of the switch when it is turned on.  
            Control.OnTintColor = view.SwitchOnColor.ToUIColor();
            //The color used to tint the outline of the switch when it is turned off.  
            Control.TintColor = view.SwitchOffColor.ToUIColor();
        }
    }
}