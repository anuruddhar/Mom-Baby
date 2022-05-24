#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Helpers
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
21/02/2022        1.0         Anuruddha.Rajapaksha   		  Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using SQLite;
#endregion	  
namespace Mobile.Models.Login {


    [Table("APPLICABLE_FUNCTION")]
    public class UserFunction : Base {

        [Column(MidwifeDataColumn.USER_NAME)]
        public string UserName { get; set; }

        [Column(UserFunctionDataColumn.FUNCTION_CODE)]
        public string FunctionCode { get; set; }

        [Column(UserFunctionDataColumn.FUNCTION_NAME)]
        public string FunctionName { get; set; }


    }

    public static class UserFunctionDataColumn {
        public const string USER_NAME = "USER_NAME";
        public const string FUNCTION_CODE = "FUNCTION_CODE";
        public const string FUNCTION_NAME = "FUNCTION_NAME";
    }
}
