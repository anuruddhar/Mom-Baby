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
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobile.Models.Baby;
using Mobile.Models.Common;
using Mobile.Models.Login;
using Mobile.Models.Mother;
using Mobile.Models.PDF;
using SQLite;

#endregion	

namespace Mobile.Data {
    public class LocalDatabase {
        public readonly SQLiteAsyncConnection sqlLiteDatabase;

        public LocalDatabase(string dbPath) {
            sqlLiteDatabase = new SQLiteAsyncConnection(dbPath);
            Task.Run(async () => { await CreateTableLoginData(); });
        }

        private async Task CreateTableLoginData() {
            await sqlLiteDatabase.CreateTableAsync<Baby>();
            await sqlLiteDatabase.CreateTableAsync<Mother>();
            await sqlLiteDatabase.CreateTableAsync<BabyAppoinment>();
            await sqlLiteDatabase.CreateTableAsync<MotherAppoinment>();
            await sqlLiteDatabase.CreateTableAsync<Midwife>();
            await sqlLiteDatabase.CreateTableAsync<UserFunction>();
            await sqlLiteDatabase.CreateTableAsync<UserSetting>();
            await sqlLiteDatabase.CreateTableAsync<ErrorLog>();
            await sqlLiteDatabase.CreateTableAsync<PDTFile>();
        }

        private void DeleteDatabase(string dbPath) {
            sqlLiteDatabase.DeleteAsync(dbPath);
        }

    }
}
