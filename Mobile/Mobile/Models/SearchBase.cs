
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Common
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
18/02/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
#endregion	  

namespace Mobile.Models {
    public abstract class SearchBase : IQueryStringConverter {
        public string ILCode { get; set; }
        public string UserId { get; set; }
        public int PageNo { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public string SearchString { get; set; }

        public SearchBase() {
            ILCode = string.Empty;
            UserId = string.Empty;
            PageNo = 1;
            ItemsPerPage = GlobalSetting.Instance.PageSize;
            TotalItems = 0;
            SearchString = string.Empty;
        }

        public virtual string ToQueryString() {
            return string.Format("ILCode={0}&UserId={1}&PageNo={2}&ItemsPerPage={3}&TotalItems={4}&SearchString={5}",
                                    ILCode,
                                    UserId,
                                    PageNo,
                                    ItemsPerPage,
                                    TotalItems,
                                    SearchString
                                 );
        }
    }
}
