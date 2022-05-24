#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.ViewModels
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version           Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
18/02/2022         1.0           Anuruddha.Rajapaksha   		   Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Acr.UserDialogs;
using Mobile.Helpers;
using Prism.Events;
using Prism.Navigation;
#endregion



namespace Mobile.ViewModels {
    public class PopupBaseViewModel : ViewModelBase {

        #region Private Variables

        #endregion

        #region Properties
        public PopupBaseViewModel(INavigationService navigationService,
                                  IEventAggregator eventAggregator,
                                  IUserDialogs dialogs,
                                  ICommonFunction commonFunction) 
            :base(navigationService, eventAggregator, dialogs, commonFunction, string.Empty) {
        }
        #endregion

        #region Constructor

        #endregion

        #region Methods
        protected override void OnPageAppearing() {
            GlobalSetting.Instance.IsPopupOpened = true;
        }

        protected override void OnPageDisappearing() {
            GlobalSetting.Instance.IsPopupOpened = false;
        }
        #endregion

    }
}
