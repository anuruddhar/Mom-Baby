#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Views.Templates
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022        1.0        Anuruddha.Rajapaksha   		 Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
#endregion

namespace Mobile.Views.Templates {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingIndicator : ContentPage {

        public string ActivityMessage { get; set; }

        public LoadingIndicator(string message) {
            InitializeComponent();
            ActivityMessage = message;
            lblActivityIndicatorMessage.Text = message;
        }
    }
}