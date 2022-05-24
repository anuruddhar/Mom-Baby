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
using Mobile.Models.Mother;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace Mobile.Data {
    public class MotherDataService : DataService<Mother>, IMotherDataService {
        public async Task<List<Mother>> GetTodayItemsAsync() {
            return await GetItemsAsync(i => i.NextAppointmentDate == DateTime.Today);
        }
    }
}
