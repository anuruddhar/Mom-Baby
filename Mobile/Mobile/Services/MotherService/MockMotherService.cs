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
using Mobile.Helpers;
using Mobile.Models.Common;
using Mobile.Models.Mother;
#endregion

namespace Mobile.Services {

    public class MockMotherService : IMotherService {

        public Task<int> InsertItemAsyn(Mother item) {
            return Task.Run(() => {
                MotherMockData.Instance.LocalData.Add(item);
                return 1;
            });
        }


        public Task<int> UpdateItemAsyn(Mother item) {
            return Task.Run(() => {
                MotherMockData.Instance.LocalData.Remove(MotherMockData.Instance.LocalData.Find(i => i.FirstName == item.FirstName));
                MotherMockData.Instance.LocalData.Add(item);
                return 1;
            });
        }
    }
}
