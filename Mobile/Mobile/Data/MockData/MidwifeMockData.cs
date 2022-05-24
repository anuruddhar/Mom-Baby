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
18/02/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Models.Login;
using System;
using System.Collections.Generic;
#endregion	  

namespace Mobile.Data {
    public class MidwifeMockData {
        #region Private Variables
        private static readonly Lazy<MidwifeMockData> LazySingleton = new Lazy<MidwifeMockData>(CreateSingleton);
        #endregion

        #region Properties
        public static MidwifeMockData Instance => LazySingleton.Value;

        public List<Midwife> LocalUsers { get; set; } = new List<Midwife>();
        public List<UserFunction> LocalUserFunctions { get; set; } = new List<UserFunction>();
        #endregion

        #region Constructor
        private MidwifeMockData() {
            LoadUserFunctions();
            LoadUsers();
        }
        private static MidwifeMockData CreateSingleton() {
            return new MidwifeMockData();
        }
        #endregion

        #region Methods

        private void LoadUserFunctions() {
            UserFunction userFunction1 = new UserFunction() {
                UserName = "883143261v",
                FunctionCode = "mnuFunction1",
                FunctionName = "mnuName1",
            };
            LocalUserFunctions.Add(userFunction1);

            UserFunction userFunction2 = new UserFunction() {
                UserName = "873143261v",
                FunctionCode = "mnuFunction1",
                FunctionName = "mnuName1",
            };
            LocalUserFunctions.Add(userFunction2);
        }

        private void LoadUsers() {
            LocalUsers.Add(new Midwife() { UserName = "833143261v", Password = "UAT@123", FirstName = "Udani", LastName = "Rajapaksha", Nic = "833143261v", Email = "anuruddha.rajapaksa@gmail.com", Phone = "715078963", Language = "en-US", MidwifeId = 1, Latitude = 5.947726815, Longitude = 80.53528468 });
            LocalUsers.Add(new Midwife() { UserName = "823143261v", Password = "UAT@123", FirstName = "Chamila", LastName = "Rajapaksha", Nic = "823143261v", Email = "anuruddha.rajapaksa@gmail.com", Phone = "715078963", Language = "en-US", MidwifeId = 2, Latitude = 5.947726815, Longitude = 80.53528468 });
        }
        #endregion

    }
}
