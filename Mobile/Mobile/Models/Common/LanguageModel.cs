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
20/02/2022       	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Enum;
using Mobile.Models.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
#endregion	  

namespace Mobile.Models.Common {
    public class LanguageModel : BindableBase {

        #region Private Variables
        private string _id;
        private string _image;
        private string _description;
        #endregion

        #region Properties
        public string ID {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public string Image {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        public string Description {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
        #endregion
    }
}
