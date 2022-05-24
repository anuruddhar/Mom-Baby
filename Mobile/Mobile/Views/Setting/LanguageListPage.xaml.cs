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
20/02/2022        	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Views.Base;
using System;
using Xamarin.Forms;
#endregion	  

namespace Mobile.Views {
    public partial class LanguageListPage : CustomContentPage {

        #region Private Variables
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public LanguageListPage() {
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
