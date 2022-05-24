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
using Android.Content;
using Android.Graphics.Drawables;
using Mobile.Core.Controls;
using Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
#endregion

[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(CustomTimePickerRenderer))]
namespace Mobile.Droid.Renderers {
    public class CustomTimePickerRenderer: TimePickerRenderer {
        Context _Context;

        public CustomTimePickerRenderer(Context context) : base(context) {
            _Context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TimePicker> e) {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            UpdateBorders();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null) return;

            if (e.PropertyName == CustomTimePicker.BorderColorProperty.PropertyName)
                UpdateBorders();
        }

        void UpdateBorders() {
            GradientDrawable shape = new GradientDrawable();
            shape.SetShape(ShapeType.Rectangle);
            shape.SetCornerRadius(3);

            if (((CustomTimePicker)this.Element).BorderColor != null) {
                shape.SetStroke(2, ((CustomTimePicker)this.Element).BorderColor.ToAndroid());
            } else {
                shape.SetStroke(2, Android.Graphics.Color.LightGray);
                this.Control.SetBackground(shape);
            }

            this.Control.SetBackground(shape);
        }
    }
}