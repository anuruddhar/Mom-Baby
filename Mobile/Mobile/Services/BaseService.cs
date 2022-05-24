#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Wip
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
18/02/2022          	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Core.RequestProvider;
using Mobile.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion	 

namespace Mobile.Services {
    public class BaseService {
        protected readonly IRequestProvider _requestProvider;
        protected readonly string _apiUrlBase;
        protected List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();

        public BaseService(IRequestProvider requestProvider, string api) {
            _requestProvider = requestProvider;
            _apiUrlBase = $"{GlobalSetting.EndPoint}{api}";
            headers.Add(new KeyValuePair<string, string>("Workstation", GlobalSetting.Instance.PDTNo));
        }


    }
}
