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
25/02/2019        1.0         Anuruddha.Rajapaksha   		 Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Android.Content;
using Android.Graphics;
using Mobile.Core.Controls;
using Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
#endregion

[assembly: ExportRenderer(typeof(RoundedSearchBar), typeof(RoundedSearchBarRenderer))]
namespace Mobile.Droid.Renderers {
    public class RoundedSearchBarRenderer : SearchBarRenderer {
        private RoundedSearchBar _Element;
        private Context _Context;

        public RoundedSearchBarRenderer(Context context) : base(context) {
            _Context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e) {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;

            _Element = (RoundedSearchBar)this.Element;

            if (Control != null) {
                Control.Background = _Context.GetDrawable(Resource.Drawable.rounded_searchbar_view);
                Control.Background.SetColorFilter(Xamarin.Forms.Color.FromHex("#46A9F4").ToAndroid(), PorterDuff.Mode.SrcAtop);
            }
        }
    }
}