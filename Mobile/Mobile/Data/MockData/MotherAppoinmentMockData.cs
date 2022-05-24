

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
using Mobile.Models.Mother;
using System;
using System.Collections.Generic;
#endregion	  

namespace Mobile.Data {
    public class MotherAppoinmentMockData {

        #region Private Variables
        private static readonly Lazy<MotherAppoinmentMockData> LazySingleton = new Lazy<MotherAppoinmentMockData>(CreateSingleton);
        #endregion

        #region Properties
        public static MotherAppoinmentMockData Instance => LazySingleton.Value;

        public List<MotherAppoinment> LocalData { get; set; } = new List<MotherAppoinment>();
        #endregion

        #region Constructor
        private MotherAppoinmentMockData() {
            LoadData();
        }
        private static MotherAppoinmentMockData CreateSingleton() {
            return new MotherAppoinmentMockData();
        }
        #endregion

        #region Methods

        private void LoadData() {

        }
        #endregion

    }
}
