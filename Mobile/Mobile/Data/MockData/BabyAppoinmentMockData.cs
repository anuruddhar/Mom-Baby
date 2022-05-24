
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
18/03/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Models.Baby;
using System;
using System.Collections.Generic;
#endregion	  

namespace Mobile.Data {
    public class BabyAppoinmentMockData {

        #region Private Variables
        private static readonly Lazy<BabyAppoinmentMockData> LazySingleton = new Lazy<BabyAppoinmentMockData>(CreateSingleton);
        #endregion

        #region Properties
        public static BabyAppoinmentMockData Instance => LazySingleton.Value;

        public List<BabyAppoinment> LocalData { get; set; } = new List<BabyAppoinment>();
        #endregion

        #region Constructor
        private BabyAppoinmentMockData() {
            LoadData();
        }
        private static BabyAppoinmentMockData CreateSingleton() {
            return new BabyAppoinmentMockData();
        }
        #endregion

        #region Methods

        private void LoadData() {

        }
        #endregion

    }
}
