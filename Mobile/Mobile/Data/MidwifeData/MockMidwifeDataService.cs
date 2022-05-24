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
using Mobile.Models.Login;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
#endregion

namespace Mobile.Data {

    public class MockMidwifeDataService : IMidwifeDataService {
        public List<Midwife> LocalUser;


        public MockMidwifeDataService() {

        }

        public AsyncTableQuery<Midwife> AsQueryable() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllItemAsync() {
            throw new NotImplementedException();
        }

        public Task<int> DeleteItemAsync(Midwife item) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Task<Midwife> GetItemAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<Midwife> GetItemAsync(Expression<Func<Midwife, bool>> predicate) {
            throw new NotImplementedException();
        }

        public Task<List<Midwife>> GetItemsAsync() {
            throw new NotImplementedException();
        }

        public  Task<List<Midwife>> GetItemsAsync<TValue>(Expression<Func<Midwife, bool>> predicate = null, Expression<Func<Midwife, TValue>> orderBy = null) {
            return Task.Run(() => { return MidwifeMockData.Instance.LocalUsers; });
        }

        public Task<int> GetRowCount() {
            throw new NotImplementedException();
        }

        public Task<int> InsertItemAsyn(Midwife item) {
            throw new NotImplementedException();
        }

        public Task<int> SaveAllItemAsync(IEnumerable<Midwife> items) {
            throw new NotImplementedException();
        }

        public Task<int> SaveItemAsync(Midwife item) {
            throw new NotImplementedException();
        }

        public Task<int> UpdateItemAsyn(Midwife item) {
            throw new NotImplementedException();
        }
    }
}
