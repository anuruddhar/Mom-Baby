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
using Mobile.Data;
using Mobile.Models.Baby;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion	  

namespace Mobile {
    public class BabyDataService : DataService<Baby>, IBabyDataService {
        public async Task<List<Baby>> GetTodayItemsAsync() {
            return await GetItemsAsync(i => i.NextAppointmentDate == DateTime.Today);
        }
    }
}
