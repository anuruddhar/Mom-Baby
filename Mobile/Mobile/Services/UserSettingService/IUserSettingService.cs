#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   API Services
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
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobile.Models.Common;
#endregion	 

namespace Mobile.Services {
    public interface IUserSettingService {
        Task<AppResult> SaveUserSetting(UserSetting userSetting);
        Task<List<UserSetting>> GetUserSettings(string userId);
        Task<UserSetting> GetUserSettingByKey(string userId, string key);
    }
}
