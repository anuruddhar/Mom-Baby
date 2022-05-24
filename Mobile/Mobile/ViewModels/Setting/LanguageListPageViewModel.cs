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
using Acr.UserDialogs;
using Mobile.Bluetooth;
using Mobile.Enum;
using Mobile.Helpers;
using Mobile.Models.Bluetooth;
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
    public class LanguageListPageViewModel : ViewModelBase {

        #region Private Variables
        private List<LanguageModel> _languageModels;
        private SettingPageItem _selectedSettingPageItem;
        private ObservableCollection<SettingPageItem> _languages;
        #endregion

        #region Properties
        public ICommand ItemTappedCommand { get; private set; }

        public ObservableCollection<SettingPageItem> Languages {
            get { return _languages; }
            set { SetProperty(ref _languages, value); }
        }
        #endregion

        #region Constructor
        public LanguageListPageViewModel(INavigationService navigationService,
                                         IEventAggregator eventAggregator,
                                         IUserDialogs dialogs,
                                         ICommonFunction commonFunction) :
            base(navigationService, eventAggregator, dialogs, commonFunction, Message.MSG_SET_030) {
            Languages = new ObservableCollection<SettingPageItem>();
            ItemTappedCommand = new DelegateCommand<SettingPageItem>(async settingPageItem => await OnItemSelected(settingPageItem));
        }
        #endregion

        #region Methods

        #region Lifecycle hooks & Related Methods
        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                await PopulateData(parameters);
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private Task PopulateData(INavigationParameters parameters) {
            return Task.Run(() => {
                _languageModels = Utils.GetLanguage();
                Languages = new ObservableCollection<SettingPageItem>();
                int i = 1;
                foreach (var item in _languageModels) {
                    Languages.Add(new SettingPageItem() { ID = i, Image = item.Image, Description = item.Description, Details = item.ID, IsInvokeOtherPage = true });
                    i += 1;
                }
            });
        }
        #endregion

        #region Common
        private async Task OnItemSelected(SettingPageItem settingPageItem) {
            try {
                NavigationParameters param = new NavigationParameters();
                param.Add(AppConstant.NavigationParameterName.CALL_BACK_REQUIRED, true);
                param.Add(AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE, AppConstant.NavigationParameterName.CALL_BACK_LANGUAGE_SELECTED);
                param.Add(AppConstant.NavigationParameterName.SETTING_ITEM, settingPageItem);
                await NavigationService.GoBackAsync(param);
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }
        #endregion

        #endregion

    }
}
