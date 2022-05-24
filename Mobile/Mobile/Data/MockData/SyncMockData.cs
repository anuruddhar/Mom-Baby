#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Test Data
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
17/03/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Models.Baby;
using System;
using System.Collections.Generic;
#endregion	  

namespace Mobile.Data.MockData {
    public class SyncMockData {
        #region Private Variables
        private static readonly Lazy<SyncMockData> LazySingleton = new Lazy<SyncMockData>(CreateSingleton);
        #endregion

        #region Properties
        public static SyncMockData Instance => LazySingleton.Value;

        public int MotherHealthDataToBeSynced = 2;
        public int BabyHealthDataToBeSynced = 3;
        public int MotherDataToBeSynced = 1;
        public int BabyDataToBeSynced = 0;
        #endregion

        #region Constructor
        private SyncMockData() {
            LoadData();
        }
        private static SyncMockData CreateSingleton() {
            return new SyncMockData();
        }
        #endregion

        #region Methods

        private void LoadData() {

        }
        #endregion
    }
}
