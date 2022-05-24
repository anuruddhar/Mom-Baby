
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
using System.Collections.ObjectModel;
using System.Text;
#endregion	  

namespace Mobile.Core.Extensions
{
    public static class ObservableExtension {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source) {
            ObservableCollection<T> collection = new ObservableCollection<T>();

            foreach (T item in source) {
                collection.Add(item);
            }

            return collection;
        }
    }
}
