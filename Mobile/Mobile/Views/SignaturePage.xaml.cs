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
12/03/2022          1.0             Anuruddha.Rajapaksha   					    Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion


#region Namespace
using Mobile.ViewModels;
using Mobile.Views.Base;
#endregion

namespace Mobile.Views {
    public partial class SignaturePage : CustomContentPage {


        #region Private Variables
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public SignaturePage() {
            InitializeComponent();
            ( (SignaturePageViewModel)BindingContext ).GetImageStreamAsync = signaturePadView.GetImageStreamAsync;
        }
        #endregion

        #region Methods
        #endregion

    }
}
