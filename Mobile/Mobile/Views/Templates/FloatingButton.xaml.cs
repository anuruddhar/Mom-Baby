
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Views.Templates
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022        1.0        Anuruddha.Rajapaksha   		 Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
#endregion

namespace Mobile.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FloatingButton : Button
	{
		public FloatingButton ()
		{
			InitializeComponent ();
		}
    }
}