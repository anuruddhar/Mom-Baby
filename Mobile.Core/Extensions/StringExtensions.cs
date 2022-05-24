
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

namespace Mobile.Core.Extensions {
    public static class StringExtensions {


        //public static string IsNullOrEmpty(this string str) {
        //    return string.IsNullOrEmpty(str) ? "" : str;
        //}
        public static bool IsNullOrEmpty(this string text) {
            return string.IsNullOrEmpty(text);
        }

        public static string ToEmptyString(this string value) {
            return string.IsNullOrEmpty(value) ? string.Empty : value;
            //if (string.IsNullOrEmpty(value)) {
            //    value = string.Empty;
            //    return value;
            //}
            //return value;
        }

    }
}
