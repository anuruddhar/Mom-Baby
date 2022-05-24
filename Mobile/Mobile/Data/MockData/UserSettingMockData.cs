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
10/03/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Helpers;
using Mobile.Models.Baby;
using Mobile.Models.Common;
using System;
using System.Collections.Generic;
#endregion	  

namespace Mobile.Data {
    public class UserSettingMockData {
        #region Private Variables
        private static readonly Lazy<UserSettingMockData> LazySingleton = new Lazy<UserSettingMockData>(CreateSingleton);
        #endregion

        #region Properties
        public static UserSettingMockData Instance => LazySingleton.Value;

        public UserSetting LocalData { get; set; } = new UserSetting();
        #endregion

        #region Constructor
        private UserSettingMockData() {
            LoadData();
        }
        private static UserSettingMockData CreateSingleton() {
            return new UserSettingMockData();
        }
        #endregion

        #region Methods

        private void LoadData() {
            LocalData = new UserSetting() { UserId = GlobalSetting.Instance.User.UserName, Key = AppConstant.UserSettingKey.FAVOURITE_MENUS, Values = "mnuMother,mnuBaby" };
        }
        #endregion
    }
}

