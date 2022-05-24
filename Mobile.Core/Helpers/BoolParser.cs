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


namespace Mobile.Core.Helpers
{
    /// <summary>
    /// Parse strings into true or false bools using relaxed parsing rules
    /// </summary>
    public static class BoolParser {
        /// <summary>
        /// Get the boolean value for this string
        /// </summary>
        public static bool GetValue(string value) {
            return IsTrue(value);
        }

        /// <summary>
        /// Determine whether the string is not True
        /// </summary>
        public static bool IsFalse(string value) {
            return !IsTrue(value);
        }

        /// <summary>
        /// Determine whether the string is equal to True
        /// </summary>
        public static bool IsTrue(string value) {
            try {

                if (value == null) {
                    return false;
                }
                value = value.Trim().ToLower();

                if (value == "true") {
                    return true;
                }

                if (value == "1") {
                    return true;
                }
                return false;
            } catch {
                return false;
            }
        }
    }
}
