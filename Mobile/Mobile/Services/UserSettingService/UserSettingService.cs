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
using Mobile.Enum;
using Mobile.Models.Common;
#endregion	 

namespace Mobile.Services {
    public class UserSettingService : BaseService, IUserSettingService {

        public UserSettingService(IRequestProvider requestProvider) : base(requestProvider, "UserSetting") { }

        public async Task<List<UserSetting>> GetUserSettings(string userId) {
            List<UserSetting> data;

            var builder = new UriBuilder(GlobalSetting.Instance.Server) {
                Path = $"{_apiUrlBase}/{userId}"
            };
            var uri = builder.ToString();
            try {
                data = await _requestProvider.GetAsync<List<UserSetting>>(uri, GlobalSetting.Instance.AuthToken);
            } catch (HttpRequestExceptionEx exception) when (exception.HttpCode == System.Net.HttpStatusCode.NotFound) {
                data = null;
            }
            return data;
        }

        public async Task<UserSetting> GetUserSettingByKey(string userId, string key) {
            UserSetting data;

            var builder = new UriBuilder(GlobalSetting.Instance.Server) {
                Path = $"{_apiUrlBase}/{userId}/{key}"
            };
            var uri = builder.ToString();
            try {
                data = await _requestProvider.GetAsync<UserSetting>(uri, GlobalSetting.Instance.AuthToken);
            } catch (HttpRequestExceptionEx exception) when (exception.HttpCode == System.Net.HttpStatusCode.NotFound) {
                data = null;
            }
            return data;
        }

        public async Task<AppResult> SaveUserSetting(UserSetting userSetting) {
            AppResult data;

            var builder = new UriBuilder(GlobalSetting.Instance.Server) {
                Path = $"{_apiUrlBase}"
            };
            var uri = builder.ToString();
            try {
                data = await _requestProvider.PostAsync<UserSetting, AppResult>(uri, userSetting, GlobalSetting.Instance.AuthToken);
            } catch (HttpRequestExceptionEx exception) when (exception.HttpCode == System.Net.HttpStatusCode.NotFound) {
                data = null;
            }
            return data;
        }
    }
}
