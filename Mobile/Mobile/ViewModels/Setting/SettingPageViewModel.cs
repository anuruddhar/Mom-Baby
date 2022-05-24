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
20/02/2022          	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Acr.UserDialogs;
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
    public class SettingPageViewModel : ViewModelBase {

        #region Private Variables
        private List<LanguageModel> _languageModels;
        private LanguageModel _selectedLanguage;
        private SettingPageItem _selectedSettingPageItem;
        private ObservableCollection<SettingPageItem> _settingPageItems;
        #endregion

        #region Properties
        public ICommand ItemTappedCommand { get; private set; }

        public ObservableCollection<SettingPageItem> SettingPageItems {
            get { return _settingPageItems; }
            set { SetProperty(ref _settingPageItems, value); }
        }
        #endregion

        #region Constructor
        public SettingPageViewModel(INavigationService navigationService,
                                    IEventAggregator eventAggregator,
                                    IUserDialogs dialogs,
                                    ICommonFunction commonFunction) : 
            base(navigationService, eventAggregator, dialogs, commonFunction, Message.CAP_SETTINGS) {
            IsSubModuleMainPage = true;
            SettingPageItems = new ObservableCollection<SettingPageItem>();
            ItemTappedCommand = new DelegateCommand<SettingPageItem>(async settingPageItem => await OnSettingPageItemSelected(settingPageItem));
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

        protected override async void OnPageResume(INavigationParameters parameters) {
            try {
                if (IsCallBackRequired(parameters)) {
                    await InvokeCallBack(parameters);
                }
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private Task PopulateData(INavigationParameters parameters) {
            return Task.Run(() => {
                _languageModels = Utils.GetLanguage();
                _selectedLanguage =  _languageModels.Where(a => a.ID ==  ((string.IsNullOrEmpty(Settings.Language)) ? GlobalSetting.Instance.User.Language : Settings.Language)).SingleOrDefault();
                SettingPageItems.Add(new SettingPageItem() { ID = 1, Image = AppConstant.AppImgesSvg.IMG_MNU_PDT_NO, Description = GetDeviceNumber(), Details = CommonFunction.GetConvertedMessage(Message.MSG_SET_029), IsInvokeOtherPage = true });
                SettingPageItems.Add(new SettingPageItem() { ID = 2, Image = AppConstant.AppImgesSvg.IMG_MNU_LANGUAGE, Description = GetLanguage(), Details = CommonFunction.GetConvertedMessage(Message.MSG_SET_031), IsInvokeOtherPage = true });
                SettingPageItems.Add(new SettingPageItem() { ID = 3, Image = AppConstant.AppImgesSvg.IMG_MNU_CONNECTIONS, Description = CommonFunction.GetConvertedMessage(Message.MSG_SET_032), Details = CommonFunction.GetConvertedMessage(Message.MSG_SET_033), IsInvokeOtherPage = true });
                SettingPageItems.Add(new SettingPageItem() { ID = 6, Image = AppConstant.AppImgesSvg.IMG_MNU_LOCAL_DB, Description = CommonFunction.GetConvertedMessage(Message.MSG_SET_045), Details = CommonFunction.GetConvertedMessage(Message.MSG_SET_046), IsInvokeOtherPage = true });
                SettingPageItems.Add(new SettingPageItem() { ID = 7, Image = AppConstant.AppImgesSvg.IMG_MNU_ABOUT, Description = CommonFunction.GetConvertedMessage(Message.MSG_SET_038), Details = CommonFunction.GetConvertedMessage(Message.MSG_SET_039), IsInvokeOtherPage = true });
            });
        }

        private async Task InvokeCallBack(INavigationParameters parameters) {
            _callBackFunctionCode = (string)parameters[AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE];
            var item = (SettingPageItem)parameters[AppConstant.NavigationParameterName.SETTING_ITEM];
            switch (_callBackFunctionCode) {
                case AppConstant.NavigationParameterName.CALL_BACK_LANGUAGE_SELECTED:
                    _selectedSettingPageItem.Description = CommonFunction.GetConvertedMessage(Message.MSG_SET_030) + " - " + item.Description;
                    // GlobalSetting.Instance.User.UserLogin.CultureName = item.Details;
                    GlobalSetting.Instance.NetLanguage = item.Details;
                    Settings.Language = item.Details;
                    _selectedLanguage.Description = item.Description;
                    break;
                default:
                    break;
            }
        }

        private string GetDeviceNumber() {
            if (!string.IsNullOrEmpty(GlobalSetting.Instance.PDTNo)) {
                return CommonFunction.GetConvertedMessage(Message.MSG_SET_028) + " - "  + GlobalSetting.Instance.PDTNo;
            } else {
                return CommonFunction.GetConvertedMessage(Message.MSG_SET_028);
            }
        }

        private string GetLanguage() {
            if (_selectedLanguage != null
                && !string.IsNullOrEmpty(_selectedLanguage.Description)) {
                return CommonFunction.GetConvertedMessage(Message.MSG_SET_030) + " - " + _selectedLanguage.Description;
            } else {
                return CommonFunction.GetConvertedMessage(Message.MSG_SET_030);
            }
        }

        private string GetDeviceId() {
            return CrossDeviceInfo.Current.Id;
        }
        #endregion

        #region Common
        private async Task OnSettingPageItemSelected(SettingPageItem settingPageItem) {
            try {
                _selectedSettingPageItem = settingPageItem;
                switch (settingPageItem.ID) {
                    case 2:
                        await OpenLanguageSelection();
                        break;
                    case 6:
                        //DependencyService.Get<ILocalDB>().SendEmail();
                        await NavigationService.NavigateAsync(AppConstant.Screen.LOCAL_DB_PAGE);
                        break;
                    case 7:
                        await NavigationService.NavigateAsync(AppConstant.Screen.ABOUT_PAGE);
                        break;
                    default:
                        break;
                }
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private async Task OpenLanguageSelection() {
            try {
                await NavigationService.NavigateAsync(AppConstant.Screen.LANGUAGE_LIST_PAGE);
            } catch(Exception ex) {
                throw ex;
            }
        }
        #endregion

        #endregion

    }
}
