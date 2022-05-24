
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Droid.Implementations
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
25/02/2022        1.0         Anuruddha.Rajapaksha   		 Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Android.Views;
using Prism.Events;
#endregion

namespace Mobile.Droid {
    public class Globals {
        private static Window window;
        private static IEventAggregator eventAggregator;

        public static Window Window {
            get {
                return window;
            }
            set {
                window = value;
            }
        }
        
        public static IEventAggregator EventAggregator {
            get {
                return eventAggregator;
            }
            set {
                eventAggregator = value;
            }
        }
    }
}