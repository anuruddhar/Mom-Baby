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
using Mobile.Models.Baby;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
#endregion

namespace Mobile.Data {
    public class MockBabyDataService : IBabyDataService {
        public List<Baby> LocalData;

        public MockBabyDataService() {

        }

        public AsyncTableQuery<Baby> AsQueryable() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllItemAsync() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteItemAsync(Baby item) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Task<Baby> GetItemAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<Baby> GetItemAsync(Expression<Func<Baby, bool>> predicate) {
            throw new NotImplementedException();
        }

        public Task<List<Baby>> GetItemsAsync() {
            return Task.Run(() => { return BabyMockData.Instance.LocalData; });
        }

        public Task<List<Baby>> GetTodayItemsAsync() {
            return Task.Run(() => { return BabyMockData.Instance.LocalData.Where(i => i.NextAppointmentDate.Date == Convert.ToDateTime("2022-05-01").Date).ToList(); });
        }


        public Task<List<Baby>> GetItemsAsync<TValue>(Expression<Func<Baby, bool>> predicate = null, Expression<Func<Baby, TValue>> orderBy = null) {
            return Task.Run(() => { return BabyMockData.Instance.LocalData.Where(i => i.NextAppointmentDate.Date == Convert.ToDateTime("2022-05-01").Date).ToList(); });
        }

        public Task<int> GetRowCount() {
            throw new NotImplementedException();
        }

        public Task<int> InsertItemAsyn(Baby item) {
            return Task.Run(() => { 
                BabyMockData.Instance.LocalData.Add(item);
                SyncMockData.Instance.BabyDataToBeSynced += 1;
                return 1;
            });  
        }

        public Task<int> SaveAllItemAsync(IEnumerable<Baby> items) {
            throw new NotImplementedException();
        }

        public Task<int> SaveItemAsync(Baby item) {
            throw new NotImplementedException();
        }

        public Task<int> UpdateItemAsyn(Baby item) {
            return Task.Run(() => {
                BabyMockData.Instance.LocalData.Remove(BabyMockData.Instance.LocalData.Find(i => i.FirstName == item.FirstName));
                BabyMockData.Instance.LocalData.Add(item);
                return 1;
            });
        }
    }
}
