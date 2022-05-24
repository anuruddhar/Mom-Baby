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
10/03/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Data.MockData;
using Mobile.Models.Common;
using Mobile.Models.Mother;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
#endregion

namespace Mobile.Data {
    public class MockMotherDataService : IMotherDataService {
        public List<Mother> LocalData;

        public MockMotherDataService() {

        }

        public AsyncTableQuery<Mother> AsQueryable() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllItemAsync() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteItemAsync(Mother item) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Task<Mother> GetItemAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<Mother> GetItemAsync(Expression<Func<Mother, bool>> predicate) {
            throw new NotImplementedException();
        }

        public Task<List<Mother>> GetItemsAsync() {
            return Task.Run(() => { return MotherMockData.Instance.LocalData; });
        }

        public Task<List<Mother>> GetTodayItemsAsync() {
            return Task.Run(() => { return MotherMockData.Instance.LocalData.Where(i => i.NextAppointmentDate.Date == Convert.ToDateTime("2022-05-01").Date).ToList(); });
        }

        public Task<List<Mother>> GetItemsAsync<TValue>(Expression<Func<Mother, bool>> predicate = null, Expression<Func<Mother, TValue>> orderBy = null) {
            return Task.Run(() => { return MotherMockData.Instance.LocalData.Where(i => i.NextAppointmentDate.Date == Convert.ToDateTime("2022-05-01").Date).ToList(); });
        }

        public Task<UserSetting> GetItemsByKey(string userId, string key) {
            throw new NotImplementedException();
        }

        public Task<int> GetRowCount() {
            throw new NotImplementedException();
        }

        public Task<int> InsertItemAsyn(Mother item) {
            return Task.Run(() => {
                MotherMockData.Instance.LocalData.Add(item);
                SyncMockData.Instance.MotherDataToBeSynced += 1;
                return 1;
            });
        }

        public Task<int> SaveAllItemAsync(IEnumerable<Mother> items) {
            throw new NotImplementedException();
        }

        public Task<int> SaveItemAsync(Mother item) {
            throw new NotImplementedException();
        }

        public Task<int> UpdateItemAsyn(Mother item) {
            return Task.Run(() => {
                MotherMockData.Instance.LocalData.Remove(MotherMockData.Instance.LocalData.Find(i => i.FirstName == item.FirstName));
                MotherMockData.Instance.LocalData.Add(item);
                return 1;
            });
        }

    }
}
