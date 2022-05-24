
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
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion	

namespace Mobile.Core.RequestProvider
{
    public interface IRequestProvider {
        Task<TResult> GetAsync<TResult>(string uri, string token = "");

        Task<TResult> GetStreamAsync<TResult>(string uri, string token = "");

        Task<TResult> PostAsync<TData,TResult>(string uri, TData data, string token = "", List<KeyValuePair<string, string>> headers = null);

        Task<TResult> PutAsync<TData,TResult>(string uri, TData data, string token = "", List<KeyValuePair<string, string>> headers = null);

        Task PutNoContentAsync<TResult>(string uri, TResult data, string token = "", List<KeyValuePair<string, string>> headers = null);

        Task<int> PatchAsync<TData>(string uri, TData data, string token = "", List<KeyValuePair<string, string>> headers = null);

        Task DeleteAsync(string uri, string token = "", List<KeyValuePair<string, string>> headers = null);
    }
}
