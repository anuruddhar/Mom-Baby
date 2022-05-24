
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Setting
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
14/03/2022        	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Views.Base;
using System;
using Xamarin.Forms;
#endregion	  

namespace Mobile.Views {
    public partial class LocalDBPage : CustomContentPage {

        #region Private Variables
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public LocalDBPage() {
            InitializeComponent();
        }
        #endregion

        #region EventHandler
        private void OnItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e) {
            try {
                ((ListView)sender).SelectedItem = null;
            } catch (Exception) {
            }
        }
        #endregion

        #region Methods
        #endregion

    }
}
