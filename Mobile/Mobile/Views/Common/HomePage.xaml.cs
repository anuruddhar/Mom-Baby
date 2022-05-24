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
using Mobile.Helpers;
using Mobile.Models.Common;
using Mobile.ViewModels;
using Mobile.Views.Base;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
#endregion	  

namespace Mobile.Views {
    public partial class HomePage : ContentPage {

        #region Private Variables
        private bool _isDrawerOpened;
        private bool _isLogOffTriggered = false;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public HomePage() {
            try {
                InitializeComponent();
                TransitionNavigationPage.SetHasNavigationBar(this, false);
                _isDrawerOpened = false;
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion

        #region Event Handlers
        protected override void OnSizeAllocated(double width, double height) {
            base.OnSizeAllocated(width, height);
            drawer.TranslateTo(-drawer.Width, 0, 100, Easing.Linear);
        }
        private void HeaderTapped(object sender, EventArgs args) {
            ((HomePageViewModel)BindingContext).OnMenuShowHideCommand.Execute(((AppMenuGroup)((Button)sender).CommandParameter));
        }

        private void OnMenuTapped(object sender, ItemTappedEventArgs e) {
            try {
                ((ListView)sender).SelectedItem = null;
                OpenOtherScreen((AppMenuItem)e.Item);
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void OnFavouriteChanged(object sender, EventArgs e) {
            var appMenuItem = ((AppMenuItem)(((Button)sender).CommandParameter));
            appMenuItem.ChangeFavorite();
            RefreshFavorite(appMenuItem);
        }

        private void OnMainMenu_Clicked(object sender, EventArgs e) {
            ShowHideDrawer();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e) {
            ShowHideDrawer();
        }

        protected override bool OnBackButtonPressed() {
            ((ViewModelBase)BindingContext).BackButtonPressedCommand.Execute(null);
            return true;
        }
        #endregion

        #region Methods

        private void ShowHideDrawer() {
            if (_isDrawerOpened) {
                HideDrawer();
            } else {
                ShowDrawer();
            }
            _isDrawerOpened = !_isDrawerOpened;
        }

        private void HideDrawer() {
            drawer.TranslateTo(-drawer.Width, 0, AppConstant.Others.LOAD_DELAY, Easing.CubicOut);
        }

        private void ShowDrawer() {
           drawer.TranslateTo(0, 0, AppConstant.Others.LOAD_DELAY, Easing.CubicIn);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e) {
            ((ListView)sender).SelectedItem = null;
        }

        public void OpenOtherScreen(AppMenuItem appMenuItem) {
            ((HomePageViewModel)BindingContext).OnMenuTappedCommand.Execute(appMenuItem);
        }

        public void RefreshFavorite(AppMenuItem appMenuItem) {
            ((HomePageViewModel)BindingContext).ChangeFavouriteColletionCommand.Execute(appMenuItem);
        }
        #endregion

    }
}
