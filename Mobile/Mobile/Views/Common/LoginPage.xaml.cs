

#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Views
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022       1.0         Anuruddha.Rajapaksha   		  Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Events;
using Mobile.ViewModels;
using Mobile.Views.Base;
using Prism.Unity;
using System;
using Xamarin.Forms;
#endregion	  

namespace Mobile.Views {
    public partial class LoginPage : ContentPage {
        public LoginPage() {
            try {
                InitializeComponent();
                TransitionNavigationPage.SetHasNavigationBar(this, false);
            } catch (System.Exception ex) {
                throw ex;
            }
        }

        //protected override void OnAppearing() {
        //    GlobalSetting.Instance.EventAggregator.GetEvent<SetRootPageEvent>().Subscribe(onNavigateToHomePage);
        //}

        //protected override void OnDisappearing() {
        //    GlobalSetting.Instance.EventAggregator.GetEvent<SetRootPageEvent>().Unsubscribe(onNavigateToHomePage);
        //}

        //private void onNavigateToHomePage(string value) {
        //    Application.Current.MainPage = new TransitionNavigationPage(new HomePage());
        //}

    }
}


