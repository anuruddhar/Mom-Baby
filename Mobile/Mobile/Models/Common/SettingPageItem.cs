#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Setting
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022          1.0             Anuruddha.Rajapaksha   					    Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Prism.Mvvm;
#endregion



namespace Mobile.Models.Common {
    public class SettingPageItem : BindableBase {

        #region Private Variables
        private int _id;
        private string _image;
        private string _description;
        private string _details;
        private bool isInvokeOtherPage;
        #endregion

        #region Properties
        public int ID {
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

        public string Details {
            get { return _details; }
            set { SetProperty(ref _details, value); }
        }

        public bool IsInvokeOtherPage {
            get { return isInvokeOtherPage; }
            set { SetProperty(ref isInvokeOtherPage, value); }
        }
        #endregion

    }
}
