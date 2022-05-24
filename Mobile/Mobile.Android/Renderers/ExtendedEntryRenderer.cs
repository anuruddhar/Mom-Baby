#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Droid.Implementations
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
25/02/2022        1.0         Anuruddha.Rajapaksha   		 Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Mobile.Core.Controls;
using Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#endregion


[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace Mobile.Droid.Renderers {
    public class ExtendedEntryRenderer : EntryRenderer {
        Context _Context;

        public ExtendedEntryRenderer(Context context) : base(context) {
            _Context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            UpdateBorders();

            if (((ExtendedEntry)e.NewElement).IsKeyBoardDisabled) {
                UpdateKeyBoardDisable(e);
            }
            
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null) return;

            if (e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName) {
                UpdateBorders();
            }
                
        }

        private void OnPropertyChanging(object sender, PropertyChangingEventArgs propertyChangingEventArgs) {

            if (((ExtendedEntry)sender).IsKeyBoardDisabled) {
                // Check if the view is about to get Focus
                if (propertyChangingEventArgs.PropertyName == VisualElement.IsFocusedProperty.PropertyName) {
                    // incase if the focus was moved from another Entry
                    // Forcefully dismiss the Keyboard 
                    InputMethodManager imm = (InputMethodManager)this.Context.GetSystemService(Context.InputMethodService);
                    imm.HideSoftInputFromWindow(this.Control.WindowToken, 0);
                }
            }
        }

        void UpdateBorders() {
            GradientDrawable shape = new GradientDrawable();
            shape.SetShape(ShapeType.Rectangle);
            shape.SetCornerRadius(((ExtendedEntry)this.Element).BorderRadious);

            if (((ExtendedEntry)this.Element).IsBorderErrorVisible) {
                shape.SetStroke(2, ((ExtendedEntry)this.Element).BorderErrorColor.ToAndroid());
            } else {
                shape.SetStroke(2, ((ExtendedEntry)this.Element).BorderColor.ToAndroid());
                this.Control.SetBackground(shape);
            }

            this.Control.SetBackground(shape);
        }

        void UpdateKeyBoardDisable(ElementChangedEventArgs<Entry> e) {
            if (e.NewElement != null) {
                ((ExtendedEntry)e.NewElement).PropertyChanging += OnPropertyChanging;
            }

            if (e.OldElement != null) {
                ((ExtendedEntry)e.OldElement).PropertyChanging -= OnPropertyChanging;
            }

            // Disable the Keyboard on Focus
            this.Control.ShowSoftInputOnFocus = false;
        }

    }
}