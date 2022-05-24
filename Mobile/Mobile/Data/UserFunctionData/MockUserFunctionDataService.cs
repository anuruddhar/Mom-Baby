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
21/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Models.Common;
using Mobile.Models.Login;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
#endregion

namespace Mobile.Data {

    public class MockUserFunctionDataService : IUserFunctionDataService {
        public List<UserFunction> LocalUserFunction;

        //# Todo#
        public MockUserFunctionDataService() {
            LocalUserFunction = new List<UserFunction>();
            //LocalUserSetting.Add(new UserSetting() { UserId = GlobalSetting.Instance.User.UserName, Key = UserSettingKey.FAVOURITE_MENUS, Values = "mnuStandardInitialization,mnuLightInitialization" });
        }

        public AsyncTableQuery<UserFunction> AsQueryable() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllItemAsync() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteItemAsync(UserFunction item) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Task<UserFunction> GetItemAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<UserFunction> GetItemAsync(Expression<Func<UserFunction, bool>> predicate) {
            throw new NotImplementedException();
        }

        public Task<List<UserFunction>> GetItemsAsync() {
            throw new NotImplementedException();
        }

        public Task<List<UserFunction>> GetItemsAsync<TValue>(Expression<Func<UserFunction, bool>> predicate = null, Expression<Func<UserFunction, TValue>> orderBy = null) {
            throw new NotImplementedException();
        }

        public Task<int> GetRowCount() {
            throw new NotImplementedException();
        }

        public Task<int> InsertItemAsyn(UserFunction item) {
            throw new NotImplementedException();
        }

        public Task<int> SaveAllItemAsync(IEnumerable<UserFunction> items) {
            throw new NotImplementedException();
        }

        public Task<int> SaveItemAsync(UserFunction item) {
            throw new NotImplementedException();
        }

        public Task<int> UpdateItemAsyn(UserFunction item) {
            throw new NotImplementedException();
        }
    }
}
