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
using Mobile.Droid.Renderers;
using Mobile.Views.Base;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
#endregion

[assembly: ExportRenderer(typeof(CustomContentPage), typeof(CustomContentPageRenderer))]
namespace Mobile.Droid.Renderers {
    public class CustomContentPageRenderer : PageRenderer {
        Context _Context;
        public CustomContentPageRenderer(Context context) : base(context) {
            _Context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e) {
            base.OnElementChanged(e);
            if (e.NewElement != null && Context != null) {
                var toolbar = (Context as MainActivity).FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
                if (toolbar == null) return;
                toolbar.NavigationIcon = Context.GetDrawable(Resource.Drawable.ico_com_back);
                
                //We are using existing property to set subtitle in renderer, 
                //Although you can have your own property instead ClassId but you have to create a BasePage.
            }
        }

        //protected override void OnLayout(bool changed, int l, int t, int r, int b) {
        //    base.OnLayout(changed, l, t, r, b);
        //    var actionBar = ((Activity)_Context).ActionBar;
        //    if(actionBar != null) {
        //        actionBar.SetIcon(Resource.Drawable.ico_com_back);
        //    }

        //    //actionBar.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.YourImageInDrawable));
        //}
    }
}