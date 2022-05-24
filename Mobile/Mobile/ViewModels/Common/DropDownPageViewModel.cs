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
using Mobile.Helpers;
using Mobile.Models.Common;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
#endregion


namespace Mobile.ViewModels {
    public class DropDownPageViewModel : PopupBaseViewModel {

        #region Private Variables
        private string _messageTitle;
        private string _dataCategory;
        private string _titleCode;
        private ObservableCollection<DropDown> _dataList;
        #endregion

        #region Properties
        public ICommand ItemTappedCommand { get; private set; }
        public ICommand CancelButtonCommand { get; private set; }

        public ObservableCollection<DropDown> DataList {
            get { return _dataList; }
            set { SetProperty(ref _dataList, value); }
        }

        public string MessageTitle {
            get { return _messageTitle; }
            set { SetProperty(ref _messageTitle, value); }
        }
        #endregion

        #region Constructor
        public DropDownPageViewModel(INavigationService navigationService,
                                  IEventAggregator eventAggregator,
                                  IUserDialogs dialogs,
                                  ICommonFunction commonFunction)
            : base(navigationService, eventAggregator, dialogs, commonFunction) {
            ItemTappedCommand = new DelegateCommand<DropDown>(data => OnDataSelected(data));
            CancelButtonCommand = new DelegateCommand(async () => await OnCancel());
        }
        #endregion

        #region Methods
        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                _dataCategory = (string)parameters[AppConstant.NavigationParameterName.DROP_DOWN_DATA_CATEGORY];
                var dataList = (List<DropDown>)parameters[AppConstant.NavigationParameterName.DROP_DOWN_DATA_LIST];
                DataList = new ObservableCollection<DropDown>(dataList as List<DropDown>);
                _titleCode = (string)parameters[AppConstant.NavigationParameterName.TITLE];
                Title = CommonFunction.GetConvertedMessage(_titleCode);
                MessageTitle = Title;
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }


        private async void OnDataSelected(DropDown data) {
            try {
                NavigationParameters navigationParameters = new NavigationParameters();
                navigationParameters.Add(AppConstant.NavigationParameterName.CALL_BACK_REQUIRED, true);
                navigationParameters.Add(AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE, AppConstant.NavigationParameterName.CALL_BACK_DROP_DOWN_DATA_SELECTED);
                navigationParameters.Add(AppConstant.NavigationParameterName.DROP_DOWN_DATA, data);
                navigationParameters.Add(AppConstant.NavigationParameterName.DROP_DOWN_DATA_CATEGORY, _dataCategory);
                await NavigationService.GoBackAsync(navigationParameters);
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private async Task OnCancel() {
            await NavigationService.GoBackAsync();
        }
        #endregion

    }
}
