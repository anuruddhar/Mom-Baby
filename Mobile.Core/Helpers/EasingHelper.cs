
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.Core
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Core.Animations.Base;
using Xamarin.Forms;
#endregion	

namespace Mobile.Core.Helpers
{
    public static class EasingHelper {
        public static Easing GetEasing(EasingType type) {
            switch (type) {
                case EasingType.BounceIn:
                return Easing.BounceIn;
                case EasingType.BounceOut:
                return Easing.BounceOut;
                case EasingType.CubicIn:
                return Easing.CubicIn;
                case EasingType.CubicInOut:
                return Easing.CubicInOut;
                case EasingType.CubicOut:
                return Easing.CubicOut;
                case EasingType.Linear:
                return Easing.Linear;
                case EasingType.SinIn:
                return Easing.SinIn;
                case EasingType.SinInOut:
                return Easing.SinInOut;
                case EasingType.SinOut:
                return Easing.SinOut;
                case EasingType.SpringIn:
                return Easing.SpringIn;
                case EasingType.SpringOut:
                return Easing.SpringOut;
            }

            return null;
        }
    }
}
