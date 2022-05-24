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
using Mobile.Models.Common;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Mobile.Helpers.AppConstant;
#endregion

namespace Mobile.Data {
    public class MockUserSettingDataService : IUserSettingDataService {
        public List<UserSetting> LocalUserSetting;

        //# Todo#
        public MockUserSettingDataService() {
            LocalUserSetting = new List<UserSetting>();

            LocalUserSetting.Add(new UserSetting() { UserId = GlobalSetting.Instance.User.UserName, Key = UserSettingKey.FAVOURITE_MENUS, Values = "mnuMother,mnuBaby,mnuMotherList,mnuMotherCreate,mnuBabyCreate" });
        }

        public async Task<UserSetting> GetItemsByKey(string userId, string key) {
            return await Task.Run(async () => {
                await Task.Delay(100);
                return LocalUserSetting.Where(i => i.UserId == userId && i.Key == key).SingleOrDefault();
            });
        }

        public async Task<int> SaveItemAsync(UserSetting item) {
            return await Task.Run(async () => {
                await Task.Delay(100);
                LocalUserSetting.Add(item);
                return 1;
            });
        }

        public async Task<int> UpdateItemAsyn(UserSetting item) {
            return await Task.Run(async () => {
                await Task.Delay(100);
                return 1;
            });
        }

        public AsyncTableQuery<UserSetting> AsQueryable() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllItemAsync() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteItemAsync(UserSetting item) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Task<UserSetting> GetItemAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<UserSetting> GetItemAsync(Expression<Func<UserSetting, bool>> predicate) {
            throw new NotImplementedException();
        }

        public Task<List<UserSetting>> GetItemsAsync() {
            throw new NotImplementedException();
        }

        public Task<List<UserSetting>> GetItemsAsync<TValue>(Expression<Func<UserSetting, bool>> predicate = null, Expression<Func<UserSetting, TValue>> orderBy = null) {
            throw new NotImplementedException();
        }

        public Task<int> GetRowCount() {
            throw new NotImplementedException();
        }

        public Task<int> InsertItemAsyn(UserSetting item) {
            throw new NotImplementedException();
        }

        public Task<int> SaveAllItemAsync(IEnumerable<UserSetting> items) {
            throw new NotImplementedException();
        }
    }
}
