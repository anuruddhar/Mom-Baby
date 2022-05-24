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
15/03/2022          1.0             Anuruddha.Rajapaksha   					    Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Acr.UserDialogs;
using Mobile.Data;
using Mobile.Enum;
using Mobile.Helpers;
using Mobile.Models.Common;
using Plugin.DeviceInfo;
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
using Xamarin.Forms;
#endregion

namespace Mobile.ViewModels {
    public class LocalDBPageViewModel : ViewModelBase {


        #region Private Variables
        private SettingPageItem _selectedSettingPageItem;
        private ObservableCollection<SettingPageItem> _settingPageItems;
        public Prism.Services.IPageDialogService _iPageDialogService { get; set; }
        #endregion

        #region Properties
        public ICommand ItemTappedCommand { get; private set; }

        public ObservableCollection<SettingPageItem> SettingPageItems {
            get { return _settingPageItems; }
            set { SetProperty(ref _settingPageItems, value); }
        }
        #endregion

        #region Constructor
        public LocalDBPageViewModel(INavigationService navigationService,
                                    IEventAggregator eventAggregator,
                                    IUserDialogs dialogs,
                                    ICommonFunction commonFunction,
                                    Prism.Services.IPageDialogService dialogService) :
            base(navigationService, eventAggregator, dialogs, commonFunction, "") {
            IsSubModuleMainPage = true;
            SettingPageItems = new ObservableCollection<SettingPageItem>();
            ItemTappedCommand = new DelegateCommand<SettingPageItem>(async settingPageItem => await OnSettingPageItemSelected(settingPageItem));
            _iPageDialogService = dialogService;
         }
        #endregion

        #region Lifecycle hooks & Related Methods
        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                await PopulateData(parameters);
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        protected override async void OnPageResume(INavigationParameters parameters) {

        }

        private Task PopulateData(INavigationParameters parameters) {
            return Task.Run(() => {
                SettingPageItems = new ObservableCollection<SettingPageItem>();
                SettingPageItems.Add(new SettingPageItem() { ID = 1, Image = "", Description = CommonFunction.GetConvertedMessage(Message.MSG_SET_046), Details = "", IsInvokeOtherPage = true });
            });
        }
        #endregion

        #region Methods
        private async Task OnSettingPageItemSelected(SettingPageItem settingPageItem) {
            try {
                _selectedSettingPageItem = settingPageItem;
                switch (settingPageItem.ID) {
                    case 1:
                        DependencyService.Get<ILocalDB>().SendEmail();
                        break;
                    default:
                        break;
                }
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }
        #endregion
    }
}
