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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobile.Core.RequestProvider;
using Mobile.Data;
using Mobile.Enum;
using Mobile.Helpers;
using Mobile.Models.Common;
#endregion	 

namespace Mobile.Services {
    public class MockUserSettingService : IUserSettingService {
        public async Task<List<UserSetting>> GetUserSettings(string userId) {
            return await Task.Run(async () => {
                await Task.Delay(100);
                return new List<UserSetting>();
            });
        }

        public async Task<UserSetting> GetUserSettingByKey(string userId, string key) {
            return await Task.Run(async () => {
                await Task.Delay(100);
                return UserSettingMockData.Instance.LocalData;
            });
        }

        public async Task<AppResult> SaveUserSetting(UserSetting userSetting) {
            return await Task.Run(async () => {
                await Task.Delay(100);
                return new AppResult() { Success = true };
            });
        }
    }
}
