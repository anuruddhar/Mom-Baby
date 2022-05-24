
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
using Android.Graphics;
using Android.Widget;
using Mobile.Core.Controls;
using Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
#endregion


[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace Mobile.Droid.Renderers {


    public class CustomSwitchRenderer : SwitchRenderer {

        Context _Context;
        private CustomSwitch view;

        public CustomSwitchRenderer(Context context) : base(context) {
            _Context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e) {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;
            view = (CustomSwitch)Element;
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean) {
                if (this.Control != null) {
                    if (this.Control.Checked) {
                        this.Control.TrackDrawable.SetColorFilter(view.SwitchOnColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
                    } else {
                        this.Control.TrackDrawable.SetColorFilter(view.SwitchOffColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
                    }
                    this.Control.CheckedChange += this.OnCheckedChange;
                    UpdateSwitchThumbImage(view);
                }
                //Control.TrackDrawable.SetColorFilter(view.SwitchBGColor.ToAndroid(), PorterDuff.Mode.Multiply);  
            }
        }

        private void UpdateSwitchThumbImage(CustomSwitch view) {
            if (!string.IsNullOrEmpty(view.SwitchThumbImage)) {
                view.SwitchThumbImage = view.SwitchThumbImage.Replace(".jpg", "").Replace(".png", "");
                int imgid = (int)typeof(Resource.Drawable).GetField(view.SwitchThumbImage).GetValue(null);
                // #ToDo: With Nuget update didint work. Need to check
                // Control.SetThumbResource(Resource.Drawable.icon);
            } else {
                Control.ThumbDrawable.SetColorFilter(view.SwitchThumbColor.ToAndroid(), PorterDuff.Mode.Multiply);
                // Control.SetTrackResource(Resource.Drawable.track);  
            }
        }

        private void OnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            if (this.Control.Checked) {
                this.Control.TrackDrawable.SetColorFilter(view.SwitchOnColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
            } else {
                this.Control.TrackDrawable.SetColorFilter(view.SwitchOffColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
            }
        }
        protected override void Dispose(bool disposing) {
            this.Control.CheckedChange -= this.OnCheckedChange;
            base.Dispose(disposing);
        }

    }
}