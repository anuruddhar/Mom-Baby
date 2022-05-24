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
using Android;
using Android.Content;
using Android.Graphics;
using Android.Support.V4.App;
using Android.Views;
using Android.Views.Animations;
using Mobile;
using Mobile.Droid.Renderers;
using Mobile.Enum;
using Mobile.Views.Base;

using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
#endregion

[assembly: ExportRenderer(typeof(TransitionNavigationPage), typeof(TransitionNavigationPageRenderer))]
namespace Mobile.Droid.Renderers {
    public class TransitionNavigationPageRenderer : NavigationPageRenderer {
        Context _Context;
        // private Android.Support.V7.Widget.Toolbar toolbar;
        // private TransitionType _transitionType = TransitionType.Default;

        public TransitionNavigationPageRenderer(Context context) : base(context) {
            _Context = context;
        }

        //// Following Code is implemented to show transition for Login and Main Page as the SetupPageTransition is not called
        public override void AddView(Android.Views.View child) {
            base.AddView(child);
            child.Visibility = ViewStates.Visible;

            var animation = AnimationUtils.LoadAnimation(Context, Resource.Animation.flip_in);
            animation.AnimationEnd += (sender, e) => child.Animation = null;
            child.Animation = animation;
        }


        protected override void SetupPageTransition(FragmentTransaction transaction, bool isPush) {
            switch (GlobalSetting.TransitionType) {
                case TransitionType.None:
                    return;
                case TransitionType.Default:
                    return;
                case TransitionType.Fade:
                    transaction.SetCustomAnimations(Resource.Animation.fade_in, Resource.Animation.fade_out,
                                                    Resource.Animation.fade_out, Resource.Animation.fade_in);
                    break;
                case TransitionType.Flip:
                    transaction.SetCustomAnimations(Resource.Animation.flip_in, Resource.Animation.flip_out,
                                                    Resource.Animation.flip_out, Resource.Animation.flip_in);
                    break;
                case TransitionType.Scale:
                    transaction.SetCustomAnimations(Resource.Animation.scale_in, Resource.Animation.scale_out,
                                                    Resource.Animation.scale_out, Resource.Animation.scale_in);
                    break;
                case TransitionType.SlideFromLeft:
                    if (isPush) {
                        transaction.SetCustomAnimations(Resource.Animation.enter_left, Resource.Animation.exit_right,
                                                        Resource.Animation.enter_right, Resource.Animation.exit_left);
                    } else {
                        transaction.SetCustomAnimations(Resource.Animation.enter_right, Resource.Animation.exit_left,
                                                        Resource.Animation.enter_left, Resource.Animation.exit_right);
                    }
                    break;
                case TransitionType.SlideFromRight:
                    if (isPush) {
                        transaction.SetCustomAnimations(Resource.Animation.enter_right, Resource.Animation.exit_left,
                                                        Resource.Animation.enter_left, Resource.Animation.exit_right);
                    } else {
                        transaction.SetCustomAnimations(Resource.Animation.enter_left, Resource.Animation.exit_right,
                                                        Resource.Animation.enter_right, Resource.Animation.exit_left);
                    }
                    break;
                case TransitionType.SlideFromTop:
                    if (isPush) {
                        transaction.SetCustomAnimations(Resource.Animation.enter_top, Resource.Animation.exit_bottom,
                                                        Resource.Animation.enter_bottom, Resource.Animation.exit_top);
                    } else {
                        transaction.SetCustomAnimations(Resource.Animation.enter_bottom, Resource.Animation.exit_top,
                                                        Resource.Animation.enter_top, Resource.Animation.exit_bottom);
                    }
                    break;
                case TransitionType.SlideFromBottom:
                    if (isPush) {
                        transaction.SetCustomAnimations(Resource.Animation.enter_bottom, Resource.Animation.exit_top,
                                                        Resource.Animation.enter_top, Resource.Animation.exit_bottom);
                    } else {
                        transaction.SetCustomAnimations(Resource.Animation.enter_top, Resource.Animation.exit_bottom,
                                                        Resource.Animation.enter_bottom, Resource.Animation.exit_top);
                    }
                    break;
                default:
                    return;
            }
        }
    }
}