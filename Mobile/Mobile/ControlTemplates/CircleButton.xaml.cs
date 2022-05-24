#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Helpers
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
22/02/2022        1.0          Anuruddha.Rajapaksha   	  Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
#endregion


namespace Mobile.ControlTemplates {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CircleButton : Button {
        public CircleButton() {
            InitializeComponent();
        }
    }
}