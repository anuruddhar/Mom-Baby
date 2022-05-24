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
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
#endregion	 

namespace Mobile.Views {
    public partial class ToolBarItemsPage : PopupPage {

        #region Private Variables
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ToolBarItemsPage() {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e) {
            ((ListView)sender).SelectedItem = null;
        }
        #endregion

        #region Methods
        #endregion

    }
}
