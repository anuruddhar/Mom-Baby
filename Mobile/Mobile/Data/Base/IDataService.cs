#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Common
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
18/02/2022          1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
#endregion	  

namespace Mobile.Data {
    public interface IDataService<T> : IDisposable where T : Base,new() {
        Task<T> GetItemAsync(int id);
        Task<T> GetItemAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetItemsAsync();
        Task<List<T>> GetItemsAsync<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        AsyncTableQuery<T> AsQueryable();
        Task<int> GetRowCount();
        Task<int> InsertItemAsyn(T item);
        Task<int> UpdateItemAsyn(T item);
        Task<int> SaveItemAsync(T item);
        Task<int> SaveAllItemAsync(IEnumerable<T> items);
        Task<int> DeleteItemAsync(T item);
        Task<int> DeleteAllItemAsync();
    }
}
