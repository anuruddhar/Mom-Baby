
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
#endregion	  


namespace Mobile.Core.Extensions {
    public static class DateTimeExtensions {

        /*public static DateTime ToDateTime(this object value) {
            return Convert.ToDateTime(value);
        }*/

        public static DateTime ToDateTime(this object obj) {
            //return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddSeconds(((long)(epoch) / 1000000000));
            if(obj == null || obj.ToString() == "") {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            }
            return new DateTime((long)obj);
        }

        public static bool IsValid(this DateTime date) {
            return date > DateTime.MinValue;
        }
    }
}
