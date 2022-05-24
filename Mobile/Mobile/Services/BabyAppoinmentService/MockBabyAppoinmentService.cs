#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   API Services
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
using Mobile.Data;
using Mobile.Models.Baby;
using System.Threading.Tasks;
#endregion	 

namespace Mobile.Services.BabyAppoinmentService {

    public class MockBabyAppoinmentService : IBabyAppoinmentService {

        public Task<int> InsertItemAsyn(BabyAppoinment item) {
            return Task.Run(() => {
                BabyAppoinmentMockData.Instance.LocalData.Add(item);
                return 1;
            });
        }
    }
}
