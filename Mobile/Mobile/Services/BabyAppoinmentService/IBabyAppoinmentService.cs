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
13/03/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobile.Models.Baby;
using Mobile.Models.Common;
#endregion	 


namespace Mobile.Services.BabyAppoinmentService {
    public interface IBabyAppoinmentService {
        Task<int> InsertItemAsyn(BabyAppoinment item);
    }
}
