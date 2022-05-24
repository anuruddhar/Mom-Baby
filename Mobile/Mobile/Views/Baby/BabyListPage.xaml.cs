
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Views
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version        Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
06/03/2022        1.0           Anuruddha.Rajapaksha   		Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Models.Map;
using Mobile.ViewModels;
using Mobile.Views.Base;
using Xamarin.Forms;
using Tab = SegmentedControl.FormsPlugin.Abstractions;
#endregion


namespace Mobile.Views {
    public partial class BabyListPage : ScanPage {

        #region Private Variables
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public BabyListPage() {
            try {
                InitializeComponent();
            } catch (System.Exception ex) {
                throw ex;
            }
           
        }

        #endregion

        #region Event Handlers
        private void OnCustomerTapped(object sender, ItemTappedEventArgs e) {
            ((ListView)sender).SelectedItem = null;
        }

        private void OnBindingContextChanged(object sender, System.EventArgs e) {
            if (BindingContext != null) {
                var s = ((CustomMap)sender);
                ((BabyListPageViewModel)BindingContext).SetCustomMapCommand.Execute(s);
            }
        }

        private void OnTabValueChanged(object sender, Tab.ValueChangedEventArgs e) {
            if (BindingContext != null) {
                var s = ((Tab.SegmentedControl)sender);
                ((BabyListPageViewModel)BindingContext).SetTabClickedCommand.Execute(e);
            }
        }
        #endregion

        #region Methods
        #endregion
    }
}

