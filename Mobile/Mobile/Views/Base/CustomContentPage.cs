#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.Views.Base
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version        Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022        1.0           Anuruddha.Rajapaksha   		Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Helpers;
using Mobile.ViewModels;
using System;
using Xamarin.Forms;
#endregion


namespace Mobile.Views.Base {
    public class CustomContentPage : ContentPage, INavigationActionBarConfig {

        #region Private Variables
        #endregion

        #region Properties
        public int BackButtonStyle { get; set; } = 3;

        // Following Three Properties not working as expected. Have to check later
        public static readonly BindableProperty EnableBackButtonOverrideProperty =
                    BindableProperty.Create(
                    nameof(EnableBackButtonOverride),
                    typeof(bool),
                    typeof(CustomContentPage),
                    false);

        public Action CustomBackButtonAction { get; set; }

        public bool EnableBackButtonOverride {
            get {
                return (bool)GetValue(EnableBackButtonOverrideProperty);
            }
            set {
                SetValue(EnableBackButtonOverrideProperty, value);
            }
        }
        #endregion

        #region Constructor
        public CustomContentPage() {
            ToolbarItem toolbarItem = new ToolbarItem();
            toolbarItem.Icon = "ico_com_more";
            toolbarItem.Priority = 1;
            toolbarItem.AutomationId = "tlbMore";
            toolbarItem.Order = ToolbarItemOrder.Primary;
            toolbarItem.Clicked += ToolbarItem_Clicked;
            this.ToolbarItems.Add(toolbarItem);
        }
        #endregion

        #region Event Handlers
        private void ToolbarItem_Clicked(object sender, EventArgs e) {
            ((ViewModelBase)BindingContext).InvokeCustomToobarCommand.Execute(sender);
        }
        #endregion

        #region Methods
        protected override bool OnBackButtonPressed() {
            ((ViewModelBase)BindingContext).BackButtonPressedCommand.Execute(null);
            return true;
        }
        #endregion

    }
}
