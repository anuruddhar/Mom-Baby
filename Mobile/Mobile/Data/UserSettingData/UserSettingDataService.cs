#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Local Data Service
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
using System.Threading.Tasks;
using Mobile.Models.Common;
#endregion	  

namespace Mobile.Data {
    public class UserSettingDataService : DataService<UserSetting>, IUserSettingDataService {

        public async Task<UserSetting> GetItemsByKey(string userId, string key) {
            return await GetItemAsync(i => i.UserId == userId && i.Key == key);
        }
    }
}
