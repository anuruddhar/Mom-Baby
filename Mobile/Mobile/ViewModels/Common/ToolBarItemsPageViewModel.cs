#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Helpers
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
21/02/2022         1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Acr.UserDialogs;
using Mobile.Core.Extensions;
using Mobile.Events;
using Mobile.Helpers;
using Mobile.Models.Common;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
#endregion

namespace Mobile.ViewModels {
    public class ToolBarItemsPageViewModel : PopupBaseViewModel {

        #region Private Variables
        private ObservableCollection<CustomToolBarItem> _toolBarItems = new ObservableCollection<CustomToolBarItem>();
        #endregion

        #region Properties
        public ICommand SelectMenuCommand { get; private set; }

        public ObservableCollection<CustomToolBarItem> CustomToolBarItems {
            get { return _toolBarItems; }
            set { SetProperty(ref _toolBarItems, value); }
        }
        #endregion

        #region Constructor
        public ToolBarItemsPageViewModel(INavigationService navigationService,
                                         IEventAggregator eventAggregator,
                                         IUserDialogs dialogs,
                                         ICommonFunction commonFunction)
            : base(navigationService, eventAggregator, dialogs, commonFunction) {
            SelectMenuCommand = new DelegateCommand<CustomToolBarItem>(dsm => OnSelectMenu(dsm));
            CancelItemCommand = new DelegateCommand(OnCancel);
            CustomToolBarItems = new ObservableCollection<CustomToolBarItem>();
            CustomToolBarItems.Add(new CustomToolBarItem() { Text = "" });
        }
        #endregion

        #region Methods
        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                CustomToolBarItems = new ObservableCollection<CustomToolBarItem>();
                var customToolBarItems = (List<CustomToolBarItem>)parameters[AppConstant.NavigationParameterName.TOOL_BAR_ITEMS];
                if (customToolBarItems.IsNotNullOrEmpty()) {
                    foreach (CustomToolBarItem item in customToolBarItems) {
                        CustomToolBarItems.Add(item);
                    }
                }
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        protected override void OnPageNavigatedFrom(INavigationParameters parameters) {
            GlobalSetting.Instance.IsToolbarOpened = false;
        }

        private void OnCancel() {
            NavigationService.GoBackAsync();
        }

        private void OnSelectMenu(CustomToolBarItem customToolBarItem) {
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add(AppConstant.NavigationParameterName.TOOL_BAR_SELECTED_COMMAND, customToolBarItem.ICommand);
            NavigationService.GoBackAsync(navigationParameters);
        }
        #endregion
    }
}
