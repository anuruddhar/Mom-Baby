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
20/02/2022         1.0          Anuruddha.Rajapaksha   	  Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Xamarin.Forms;
#endregion	  

namespace Mobile.Helpers {
    public interface ILoadingPageService {
        void InitLoadingPage(ContentPage loadingIndicatorPage = null);
        void ShowLoadingPage(string message);
        void HideLoadingPage();
    }
}