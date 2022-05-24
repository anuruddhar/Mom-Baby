#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.UITest
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
 22/07/2019         1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
#endregion

namespace Mobile.UITest {
    public class PlatformQuery {
        public Func<AppQuery, AppQuery> Android {
            set {
                if (AppManager.Platform == Platform.Android)
                    current = value;
            }
        }

        public Func<AppQuery, AppQuery> iOS {
            set {
                if (AppManager.Platform == Platform.iOS)
                    current = value;
            }
        }

        Func<AppQuery, AppQuery> current;
        public Func<AppQuery, AppQuery> Current {
            get {
                if (current == null)
                    throw new NullReferenceException("Trait not set for current platform");

                return current;
            }
        }
    }
}
