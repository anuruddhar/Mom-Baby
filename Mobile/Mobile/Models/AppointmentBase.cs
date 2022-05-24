#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Common
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
12/03/2022        	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Enum;
using Newtonsoft.Json;
using Prism.Mvvm;
using SQLite;
using System;
#endregion	  

namespace Mobile.Models {

    public class AppointmentBase : Base {

        [Column(AppoinmentBaseDataColumn.INSTRUCTION)]
        public string Instruction { get; set; } = string.Empty;

        [Column(AppoinmentBaseDataColumn.DATETIME)]
        public DateTime DateTime { get; set; } = DateTime.Now;

        [Column(AppoinmentBaseDataColumn.USER_ID)]
        public string UserId { get; set; } = GlobalSetting.Instance.User.Name;

        [Column(AppoinmentBaseDataColumn.SATISFACTION_ID)]
        public Satisfaction SatisfactionId { get; set; } = Satisfaction.Notavailable;

        [Column(AppoinmentBaseDataColumn.SIGNER_NAME)]
        public string SignerName { get; set; } = string.Empty;

        [Column(AppoinmentBaseDataColumn.SIGNATURE)]
        public byte[] Signature { get; set; } = null;

    }

    public static class AppoinmentBaseDataColumn {
        public const string INSTRUCTION = "INSTRUCTION";
        public const string DATETIME = "DATETIME";
        public const string USER_ID = "USER_ID";
        public const string SATISFACTION_ID = "SATISFACTION_ID";
        public const string SIGNER_NAME = "SIGNER_NAME";
        public const string SIGNATURE = "SIGNATURE";
    }

}
