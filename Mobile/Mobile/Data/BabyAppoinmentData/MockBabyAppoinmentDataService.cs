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
12/03/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Data.MockData;
using Mobile.Models.Baby;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
#endregion

namespace Mobile.Data.BabyAppoinmentData {
    public class MockBabyAppoinmentDataService : IBabyAppoinmentDataService {

        public List<BabyAppoinment> LocalData;

        public AsyncTableQuery<BabyAppoinment> AsQueryable() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllItemAsync() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteItemAsync(BabyAppoinment item) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Task<BabyAppoinment> GetItemAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<BabyAppoinment> GetItemAsync(Expression<Func<BabyAppoinment, bool>> predicate) {
            throw new NotImplementedException();
        }

        public Task<List<BabyAppoinment>> GetItemsAsync() {
            throw new NotImplementedException();
        }

        public Task<List<BabyAppoinment>> GetItemsAsync<TValue>(Expression<Func<BabyAppoinment, bool>> predicate = null, Expression<Func<BabyAppoinment, TValue>> orderBy = null) {
            throw new NotImplementedException();
        }

        public Task<int> GetRowCount() {
            throw new NotImplementedException();
        }

        public Task<int> InsertItemAsyn(BabyAppoinment item) {
            return Task.Run(() => {
                BabyAppoinmentMockData.Instance.LocalData.Add(item);
                SyncMockData.Instance.BabyHealthDataToBeSynced += 1;
                return 1;
            });
        }

        public Task<int> SaveAllItemAsync(IEnumerable<BabyAppoinment> items) {
            throw new NotImplementedException();
        }

        public Task<int> SaveItemAsync(BabyAppoinment item) {
            throw new NotImplementedException();
        }

        public Task<int> UpdateItemAsyn(BabyAppoinment item) {
            throw new NotImplementedException();
        }
    }
}
