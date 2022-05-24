
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
using System.Linq;
using System.Text;
#endregion	  


namespace Mobile.Core.Extensions {
    public static class List {
        public static bool IsEmpty<T>(this IEnumerable<T> list) {
            if (list == null) {
                return true;
            }
            if (list is ICollection<T>) {
                return ((ICollection<T>)list).Count == 0;
            }
            return !list.Any();
        }

        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> list) {
            if (list == null) {
                return false;
            }
            if (list is ICollection<T>) {
                if( ((ICollection<T>)list).Count > 0) {
                    return true;
                }
            }

            return false;

        }
    }
}
