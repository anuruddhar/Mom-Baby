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
using Mobile.Models.Mother;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
#endregion


namespace Mobile.Data.MotherAppoinmentData {
    public class MockMotherAppoinmentDataService : IMotherAppoinmentDataService {


        public List<MotherAppoinment> LocalData;

        public AsyncTableQuery<MotherAppoinment> AsQueryable() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllItemAsync() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteItemAsync(MotherAppoinment item) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Task<MotherAppoinment> GetItemAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<MotherAppoinment> GetItemAsync(Expression<Func<MotherAppoinment, bool>> predicate) {
            throw new NotImplementedException();
        }

        public Task<List<MotherAppoinment>> GetItemsAsync() {
            throw new NotImplementedException();
        }

        public Task<List<MotherAppoinment>> GetItemsAsync<TValue>(Expression<Func<MotherAppoinment, bool>> predicate = null, Expression<Func<MotherAppoinment, TValue>> orderBy = null) {
            throw new NotImplementedException();
        }

        public Task<int> GetRowCount() {
            throw new NotImplementedException();
        }

        public Task<int> InsertItemAsyn(MotherAppoinment item) {
            return Task.Run(() => {
                MotherAppoinmentMockData.Instance.LocalData.Add(item);
                SyncMockData.Instance.MotherHealthDataToBeSynced += 1;
                return 1;
            });
        }

        public Task<int> SaveAllItemAsync(IEnumerable<MotherAppoinment> items) {
            throw new NotImplementedException();
        }

        public Task<int> SaveItemAsync(MotherAppoinment item) {
            throw new NotImplementedException();
        }

        public Task<int> UpdateItemAsyn(MotherAppoinment item) {
            throw new NotImplementedException();
        }
    }
}
