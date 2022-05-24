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
21/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobile.Core.RequestProvider;
using Mobile.Models.Common;
using Mobile.Models.Mother;
#endregion

namespace Mobile.Services {
    public interface IMotherService {
        Task<int> InsertItemAsyn(Mother item);
        Task<int> UpdateItemAsyn(Mother item);
    }

}
