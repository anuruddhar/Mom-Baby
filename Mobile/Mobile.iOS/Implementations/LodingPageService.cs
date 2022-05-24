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
20/02/2019        1.0         Anuruddha.Rajapaksha   		 Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Helpers;
using Mobile.iOS.Implementations;
using Mobile.Views.Templates;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFPlatform = Xamarin.Forms.Platform.iOS.Platform;
#endregion

[assembly: Xamarin.Forms.Dependency(typeof(LodingPageService))]
namespace Mobile.iOS.Implementations {
    public class LodingPageService : ILoadingPageService {
        private UIView _nativeView;

        private bool _isInitialized;

        public void InitLoadingPage(ContentPage loadingIndicatorPage) {
            // check if the page parameter is available
            if (loadingIndicatorPage != null) {
                // build the loading page with native base
                loadingIndicatorPage.Parent = Xamarin.Forms.Application.Current.MainPage;

                loadingIndicatorPage.Layout(new Rectangle(0, 0,
                    Xamarin.Forms.Application.Current.MainPage.Width,
                    Xamarin.Forms.Application.Current.MainPage.Height));

                var renderer = loadingIndicatorPage.GetOrCreateRenderer();

                _nativeView = renderer.NativeView;

                _isInitialized = true;
            }
        }

        public void ShowLoadingPage(string message) {
            // check if the user has set the page or not
            if (!_isInitialized)
                InitLoadingPage(new LoadingIndicator(message)); // set the default page

            // showing the native loading page
            UIApplication.SharedApplication.KeyWindow.AddSubview(_nativeView);
        }

        private void XamFormsPage_Appearing(object sender, EventArgs e) {
            var animation = new Animation(callback: d => ((ContentPage)sender).Content.Rotation = d,
                start: ((ContentPage)sender).Content.Rotation,
                end: ((ContentPage)sender).Content.Rotation + 360,
                easing: Easing.Linear);
            animation.Commit(((ContentPage)sender).Content, "RotationLoopAnimation", 16, 800, null, null, () => true);
        }

        public void HideLoadingPage() {
            // Hide the page
            _nativeView.RemoveFromSuperview();
        }
    }

    internal static class PlatformExtension {
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement bindable) {
            var renderer = XFPlatform.GetRenderer(bindable);
            if (renderer == null) {
                renderer = XFPlatform.CreateRenderer(bindable);
                XFPlatform.SetRenderer(bindable, renderer);
            }
            return renderer;
        }
    }
}