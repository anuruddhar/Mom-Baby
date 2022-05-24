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
26/09/2018         	  1.0         Anuruddha.Rajapaksha   					        Initial Version
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

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace Mobile.iOS.Renderers {
    public class CustomEditorRenderer : EditorRenderer {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || this.Element == null) return;

            if (e.PropertyName == CustomDatePicker.BorderColorProperty.PropertyName) {
                if (((CustomEditor)this.Element).BorderColor != null) {
                    this.Control.Layer.BorderColor = ((CustomEditor)this.Element).BorderColor.ToCGColor();
                    this.Control.Layer.BorderWidth = new nfloat(0.8);
                    this.Control.Layer.CornerRadius = 2;

                } else {
                    this.Control.Layer.BorderColor = UIColor.LightGray.CGColor;
                    this.Control.Layer.BorderWidth = new nfloat(0.8);
                    this.Control.Layer.CornerRadius = 2;
                }
            }
        }
    }
}