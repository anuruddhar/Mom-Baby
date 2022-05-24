
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Views.Base
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version        Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022        1.0           Anuruddha.Rajapaksha   		Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Enum;
using Xamarin.Forms;
#endregion


namespace Mobile.Views.Base {
    public class TransitionNavigationPage : NavigationPage {
        public static readonly BindableProperty TransitionTypeProperty =
             BindableProperty.Create("TransitionType", typeof(TransitionType), typeof(TransitionNavigationPage), TransitionType.SlideFromLeft);

        public TransitionType TransitionType {
            get { return (TransitionType)GetValue(TransitionTypeProperty); }
            set { SetValue(TransitionTypeProperty, value); }
        }

        public TransitionNavigationPage() : base() {
        }

        public TransitionNavigationPage(Page root) : base(root) {
        }
    }
}
