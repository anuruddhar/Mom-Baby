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
18/02/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Core.Helpers;
using Mobile.Models;
using Mobile.Models.Abstract;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
#endregion	  

namespace Mobile.Data {

    public class DataService<T> : IDataService<T>, IDisposable where T : Base, new() {
        protected static readonly AsyncLock Locker = new AsyncLock();
        protected SQLiteAsyncConnection database;

        public DataService() {
            database = App.Database.sqlLiteDatabase;
        }

        public async Task<T> GetItemAsync(int id) {
            try {
                using (await Locker.LockAsync()) {
                    return await database.Table<T>().Where(i => i.PrimaryId == id).FirstOrDefaultAsync();
                }
            } catch (Exception) {
                return null;
            }

        }

        //public async Task<T> GetItemAsync(Expression<Func<T, bool>> predicate) =>
        //   await database.FindAsync<T>(predicate);
        public async Task<T> GetItemAsync(Expression<Func<T, bool>> predicate) {
            try {
                using (await Locker.LockAsync()) {
                    return await database.FindAsync<T>(predicate);
                }
            } catch (Exception) {
                return null;
            }

        }

        public async Task<List<T>> GetItemsAsync() {
            try {
                using (await Locker.LockAsync()) {
                    return await database.Table<T>().ToListAsync();
                }
            } catch (Exception) {
                return null;
            }
        }

        public async Task<List<T>> GetItemsAsync(Expression<Func<T, bool>> predicate = null) {
            using (await Locker.LockAsync()) {
                var query = database.Table<T>();

                if (predicate != null) {
                    query = query.Where(predicate);
                }

                return await query.ToListAsync();
            }
        }

        public async Task<List<T>> GetItemsAsync<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null) {
            try {
                using (await Locker.LockAsync()) {
                    var query = database.Table<T>();

                    if (predicate != null) {
                        query = query.Where(predicate);
                    }

                    if (orderBy != null) {
                        query = query.OrderBy<TValue>(orderBy);
                    }

                    return await query.ToListAsync();
                }
            } catch (Exception) {
                return null;
            }

        }

        public AsyncTableQuery<T> AsQueryable() {
            try {
                using (Locker.LockAsync()) {
                    return database.Table<T>();
                }
            } catch (Exception) {
                return null;
            }

        }


        public async Task<int> GetRowCount() {
            try {
                using (await Locker.LockAsync()) {
                    return await database.Table<T>().CountAsync();
                }
            } catch (Exception) {
                return 0;
            }
        }

        public async Task<int> InsertItemAsyn(T item) {
            try {
                using (await Locker.LockAsync()) {
                    int val = await database.InsertAsync(item);
                    return val;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<int> UpdateItemAsyn(T item) {
            try  {
                if(item is IAuditInfo) {
                    ((IAuditInfo)item).UpdateAudit();
                }
                using (await Locker.LockAsync()) {
                    int val = await database.UpdateAsync(item);
                    return val;
                }
            } catch (Exception ex) {
                throw ex;
            }

        }

        public async Task<int> SaveItemAsync(T item) {
            try {
                using (await Locker.LockAsync()) {
                    if (item.PrimaryId != 0) {
                        int val = await database.UpdateAsync(item);
                        return val;
                    } else {
                        int val = await database.InsertAsync(item);
                        return val;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }

        }

        public async Task<int> SaveAllItemAsync(IEnumerable<T> items) {
            try {
                using (await Locker.LockAsync()) {
                    int val = await database.InsertAllAsync(items);
                    return val;
                }
            } catch (Exception ex) {
                throw ex;
            }

        }

        public async Task<int> DeleteItemAsync(T item) {
            try {
                using (await Locker.LockAsync()) {
                    int val = await database.DeleteAsync(item);
                    return val;
                }
            } catch (Exception ex) {
                throw ex;
            }

        }

        public async Task<int> DeleteAllItemAsync() {
            try {
                using (await Locker.LockAsync()) {
                    //return await database.ExecuteScalarAsync<int>($"DELETE FROM {typeof(T).Name}");
                    int val = await database.ExecuteScalarAsync<int>($"DELETE FROM {TableName()}");
                    return val;// 1;
                }
            } catch (Exception ex) {
                throw ex;
            }

        }

        public string TableName() {
            var tableAttribute = typeof(T).GetCustomAttributes(typeof(TableAttribute), true)[0] as TableAttribute;
            if (tableAttribute != null) {
                return tableAttribute.Name;
            }
            return null;
        }


        #region IDispose Region
        private bool disposed = false;

        protected async virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    await DisposeDbConnectionAsync();
                }
            }
            this.disposed = true;
        }

        private async Task DisposeDbConnectionAsync() {
            using (await Locker.LockAsync()) {
                if (database == null) {
                    return;
                }

                await Task.Factory.StartNew(() => {
                    database.GetConnection().Close();
                    database.GetConnection().Dispose();
                    database = null;

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                });
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
