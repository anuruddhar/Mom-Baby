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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobile.Core.RequestProvider;
using Mobile.Data;
using Mobile.Data.MockData;
using Mobile.Enum;
using Mobile.Models.Baby;
using Mobile.Models.Common;
#endregion	 

namespace Mobile.Services {

    public class BabyService : BaseService, IBabyService {

        public BabyService(IRequestProvider requestProvider) : base(requestProvider, "BabyService") { }

        public Task<int> InsertItemAsyn(Baby item) {
            return Task.Run(() => {
                BabyMockData.Instance.LocalData.Add(item);
                return 1;
            });
        }

        public Task<int> UpdateItemAsyn(Baby item) {
            return Task.Run(() => {
                BabyMockData.Instance.LocalData.Remove(BabyMockData.Instance.LocalData.Find(i => i.FirstName == item.FirstName));
                BabyMockData.Instance.LocalData.Add(item);
                return 1;
            });
        }

    }
}
