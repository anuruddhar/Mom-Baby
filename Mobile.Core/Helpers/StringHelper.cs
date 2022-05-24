#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.Core
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion


#region Namespace
using System;
using System.Collections.Generic;
using System.Text;

#endregion	  


namespace Mobile.Core.Helpers {
    public static class StringHelper {

        public static StringBuilder ListToCommaString(List<string> list) {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string item in list) {
                stringBuilder.Append("'").Append(item).Append("',");
            }
            if (stringBuilder.Length > 0) {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            return stringBuilder;
        }

        public static bool IsValid(string val) {
            return !string.IsNullOrEmpty(val);
        }

    }
}
