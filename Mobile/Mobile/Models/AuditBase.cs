#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Model
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
06/03/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using SQLite;
using System;
#endregion	  

namespace Mobile.Models {
    public class AuditBase : Base {
        [Column(AuditBaseDataColumn.CREATED_DATETIME)]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        [Column(AuditBaseDataColumn.CREATED_USER_ID)]
        public string CreatedUserId { get; set; } = GlobalSetting.Instance.User.Name;
        [Column(AuditBaseDataColumn.UPDATED_DATETIME)]
        public DateTime UpdatedDateTime { get; set; } = DateTime.Now;
        [Column(AuditBaseDataColumn.UPDATED_USER_ID)]
        public string UpdatedUserId { get; set; } = GlobalSetting.Instance.User.Name;
    }

    public static class AuditBaseDataColumn {
        public const string CREATED_DATETIME = "CREATED_DATETIME";
        public const string CREATED_USER_ID = "CREATED_USER_ID";
        public const string UPDATED_DATETIME = "UPDATED_DATETIME";
        public const string UPDATED_USER_ID = "UPDATED_USER_ID";
    }
}
