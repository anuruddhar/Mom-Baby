#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.ViewModels
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
using Mobile.Views.Base;
using System;
using Xamarin.Forms;
#endregion

namespace Mobile.Views {
    public partial class DiscrepancyPage : CustomContentPage {

        #region Private Variables
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public DiscrepancyPage() {
            InitializeComponent();
        }
        #endregion

        #region EventHandler
        private void OnDiscrepancyTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e) {
            try {
                ((ListView)sender).SelectedItem = null;
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion

        #region Methods
        #endregion

    }
}
