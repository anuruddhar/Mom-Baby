
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.ViewModels
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version           Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
 19/02/2020         1.0           Anuruddha.Rajapaksha   		   Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Prism.Mvvm;
using System.Windows.Input;
#endregion

namespace Mobile.Models.Common {
    public class CustomToolBarItem : BindableBase {

        #region Private Variables
        private string _id;
        private string _svgIcon;
        private string _text;
        private ICommand _iCommand;
        #endregion

        #region Properties
        public string Id {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public string SvgIcon {
            get { return _svgIcon; }
            set { SetProperty(ref _svgIcon, value); }
        }

        public string Text {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }


        public ICommand ICommand {
            get { return _iCommand; }
            set { SetProperty(ref _iCommand, value); }
        }
        #endregion

        #region Constructor
        public CustomToolBarItem() { }
        #endregion
    }
}
