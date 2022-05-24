
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
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
#endregion	


namespace Mobile.Models.Common {

    public class AppResult {

        public bool Success { get; set; }
        public string ResultID { get; set; } = string.Empty;
        public object Result { get; set; }
        public string UserMessage { get; set; } = string.Empty;
        public Dictionary<string, List<KeyValuePair<string, int>>> ResultValue { get; set; }


        private IDictionary<Type, IResultObject> _Results = new Dictionary<Type, IResultObject>();
        public IDictionary<Type, IResultObject> Results {
            get { return _Results; }
            set { _Results = value; }
        }

        public T GetResult<T>() {
            IResultObject resultObject;

            if (_Results.TryGetValue(typeof(T), out resultObject)) {
                return (T)resultObject;
            }

            throw new Exception("Not a Result object");
        }

        public AppResult() : this(true) { }

        public AppResult(bool success) {
            this.Success = success;
            this.ResultID = string.Empty;
            this.Results = new Dictionary<Type, IResultObject>();
        }

        public AppResult(bool success, string resultId) {
            this.Success = success;
            this.ResultID = resultId;
            this.Results = new Dictionary<Type, IResultObject>();
        }

        public static AppResult Default() {
            return new AppResult(true);
        }
    }
}
