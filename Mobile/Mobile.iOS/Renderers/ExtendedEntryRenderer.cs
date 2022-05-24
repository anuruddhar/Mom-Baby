#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Core
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
21/09/2018         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using Mobile.Core.Controls;
using Mobile.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
#endregion	  


[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace Mobile.iOS.Renderers {
    public class ExtendedEntryRenderer : EntryRenderer {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || this.Element == null) return;

            if (e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName) {
                if (((ExtendedEntry)this.Element).IsBorderErrorVisible) {
                    this.Control.Layer.BorderColor = ((ExtendedEntry)this.Element).BorderErrorColor.ToCGColor();
                    this.Control.Layer.BorderWidth = new nfloat(0.8);
                    this.Control.Layer.CornerRadius = ((ExtendedEntry)this.Element).BorderRadious;
                } else {
                    this.Control.Layer.BorderColor = ((ExtendedEntry)this.Element).BorderColor.ToCGColor();
                    this.Control.Layer.CornerRadius = ((ExtendedEntry)this.Element).BorderRadious;
                    this.Control.Layer.BorderWidth = new nfloat(0.8);
                }

            }
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);

            // Disabling the keyboard
            if (((ExtendedEntry)e.NewElement).IsKeyBoardDisabled) {
                this.Control.InputView = new UIView();
            }
        }

    }
}