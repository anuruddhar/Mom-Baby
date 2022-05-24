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
using Xamarin.Forms;
#endregion

namespace Mobile.Core.Controls {
    public class CustomEditor : Editor {
        public static readonly BindableProperty BorderColorProperty =
               BindableProperty.Create(nameof(BorderColor), typeof(Xamarin.Forms.Color), typeof(ExtendedEntry), Xamarin.Forms.Color.Transparent, BindingMode.TwoWay);

        public Xamarin.Forms.Color BorderColor {
            get { return (Xamarin.Forms.Color)GetValue(BorderColorProperty); }
            set {
                SetValue(BorderColorProperty, value);
            }
        }
    }
}
