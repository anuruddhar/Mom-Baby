#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.ViewModels
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
using Acr.UserDialogs;
using Mobile.Helpers;
using Plugin.DeviceInfo;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
#endregion

namespace Mobile.ViewModels {
    public class AboutPageViewModel : ViewModelBase {

        #region Private Variables
        private string _applogoImage = AppConstant.AppImges.IMG_APPLOGO;
        private string _headerInfomation;
        private string _detailInformation;
        private string _osVersion;
        private string _deviceModel;
        private string _uniqueId;
        #endregion

        #region Properties
        public string AppLogoImage {
            get { return _applogoImage; }
            set { SetProperty(ref _applogoImage, value); }
        }

        public string HeaderInformation {
            get { return _headerInfomation; }
            set { SetProperty(ref _headerInfomation, value); }
        }

        public string DetailInformation {
            get { return _detailInformation; }
            set { SetProperty(ref _detailInformation, value); }
        }

        public string DeviceModel {
            get { return _deviceModel; }
            set { SetProperty(ref _deviceModel, value); }
        }

        public string OsVersion {
            get { return _osVersion; }
            set { SetProperty(ref _osVersion, value); }
        }

        public string UniqueId {
            get { return _uniqueId; }
            set { SetProperty(ref _uniqueId, value); }
        }
        #endregion

        #region Constructor
        public AboutPageViewModel(INavigationService navigationService,
                                  IEventAggregator eventAggregator,
                                  IUserDialogs dialogs,
                                  ICommonFunction commonFunction)
            : base(navigationService, eventAggregator, dialogs, commonFunction, Message.CAP_SETTINGS_ABOUT) {
            IsSubModuleMainPage = true;
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
                HeaderInformation = "Mom & Baby";
                DetailInformation = "Version " + CrossDeviceInfo.Current.AppVersion;
                OsVersion = CrossDeviceInfo.Current.Platform.ToString();
                UniqueId = CrossDeviceInfo.Current.Id;
                DeviceModel = DeviceInfo.Manufacturer + " (" + DeviceInfo.Model + ")";
            });
        }
        #endregion

        #region Others
        #endregion

        #endregion
    }
}
