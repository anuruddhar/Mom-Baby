#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Views
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022         1.0        Anuruddha.Rajapaksha   		 Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.ViewModels;
using Rg.Plugins.Popup.Pages;
using System;
#endregion

namespace Mobile.Views {
    public partial class SynchronizationPage : PopupPage {
        public SynchronizationPage() {
            try {
                InitializeComponent();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void AnimationView_OnFinish(object sender, System.EventArgs e) {

        }
    }
}
