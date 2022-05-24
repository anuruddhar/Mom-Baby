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
using Mobile.Helpers;
#endregion

[assembly: Xamarin.Forms.Dependency(typeof(Mobile.Droid.Implementations.CloseApp))]
namespace Mobile.Droid.Implementations {
    public class CloseApp : ICloseApp {
        public void Close() {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}