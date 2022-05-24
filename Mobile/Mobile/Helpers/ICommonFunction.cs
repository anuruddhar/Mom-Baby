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
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Enum;
using Mobile.Models.Common;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
#endregion

namespace Mobile.Helpers {
    public interface ICommonFunction {
        Task CreateAppMenuGroup();
        ObservableCollection<AppMenuGroup> AuthorizedAppMenuGroups { get; set; }
        ObservableCollection<AppMenuItem> GetFavouriteAppMenus();
        bool IsAuthorized(string functionCode);
        Task ChangeFavouriteMenu(AppMenuItem appMenuItem);
        Task DisplayMessage(INavigationService navigationService, MessageType messageType, string titleCode, string messageCode, object[] values = null, bool isConfirm = false, string confirmationForFunctionCode = "", bool isYesNo = false);
        Task DisplayDiscrepancy(INavigationService navigationService, string titleCode, string discreoancyMessageCode, List<Discrepancy> discrepancies, bool isConfirm = false, string confirmationForFunctionCode = "", bool isYesNo = false);
        Task DisplayDeviceInfo();
        string GetConvertedMessage(string messageCode);
        string GetConvertedMessage(string messageCode, object[] values);
        bool ValidateFutureDate(DateTime selectedDate);
        bool ValidatePastDate(DateTime selectedDate);
        bool ValidateWeight(decimal weight);
        void ShowActivityIndicator(string message);
        void HideActivityIndicator();
    }
}
