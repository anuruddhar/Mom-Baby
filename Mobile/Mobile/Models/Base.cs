
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
18/02/2022        	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Helpers;
using Newtonsoft.Json;
using Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
#endregion	  


namespace Mobile.Models {
    public class Base : BindableBase {
        [PrimaryKey, AutoIncrement, Column("PRIMARY_ID")]
        [JsonIgnore]
        public int PrimaryId { get; set; }
    }

    public static class BaseDataColumn {
        public const string PRIMARY_ID = "PRIMARY_ID";
    }

}
