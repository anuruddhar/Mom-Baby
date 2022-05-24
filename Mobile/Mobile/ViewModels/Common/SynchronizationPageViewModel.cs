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
using Mobile.Logic;
using Mobile.Models.Common;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
#endregion

namespace Mobile.ViewModels {
    public class SynchronizationPageViewModel : PopupBaseViewModel {

        #region Private Variables
        private string _processIndicationAnimation = AppConstant.AnimationFile.UPLOADING;
        private string _sucessIndicationAnimation = AppConstant.AnimationFile.SUCESS;
        private string _failedIndicationAnimation = AppConstant.AnimationFile.DOWNLOAD_FAILED;
        private string _message;
        private ISyncLogic _iSyncLogic;
        private bool _downLoadInProgress = true;
        private bool _downLoadSucess = false;
        private bool _downLoadFailed = false;
        private AppResult _appResult;
        private NavigationParameters _navigationParameters;
        private IPageDialogService _iPageDialogService;
        #endregion

        #region Properties
        public ICommand OkButtonCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }

        public string ProcessIndicationAnimation {
            get { return _processIndicationAnimation; }
            set { SetProperty(ref _processIndicationAnimation, value); }
        }

        public string SucessIndicationAnimation {
            get { return _sucessIndicationAnimation; }
            set { SetProperty(ref _sucessIndicationAnimation, value); }
        }

        public string FailedIndicationAnimation {
            get { return _failedIndicationAnimation; }
            set { SetProperty(ref _failedIndicationAnimation, value); }
        }

        public string Message {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public bool DownLoadInProgress {
            get { return _downLoadInProgress; }
            set { SetProperty(ref _downLoadInProgress, value); }
        }

        public bool DownLoadSucess {
            get { return _downLoadSucess; }
            set { SetProperty(ref _downLoadSucess, value); }
        }

        public bool DownLoadFailed {
            get { return _downLoadFailed; }
            set { SetProperty(ref _downLoadFailed, value); }
        }
        #endregion

        #region Constructor
        public SynchronizationPageViewModel(INavigationService navigationService,
                                            IEventAggregator eventAggregator,
                                            IUserDialogs dialogs,
                                            ICommonFunction commonFunction,
                                            IPageDialogService dialogService)
        : base(navigationService, eventAggregator, dialogs, commonFunction) {
            _iPageDialogService = dialogService;
            OkButtonCommand = new DelegateCommand(OnOK);
            CloseCommand = new DelegateCommand(OnClose);
        }
        #endregion

        #region Methods
        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                _iSyncLogic = (ISyncLogic)parameters[AppConstant.NavigationParameterName.I_SYNC_LOGIC];
                _iSyncLogic.IPageDialogService = _iPageDialogService;
                _iSyncLogic.UpdateUI += _iSyncLogic_UpdateUI;

                ProcessIndicationAnimation = _iSyncLogic.AnimationFileName;
                Message = CommonFunction.GetConvertedMessage(_iSyncLogic.ClientMessage);
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private void _iSyncLogic_UpdateUI(string messageCode) {
            Message = CommonFunction.GetConvertedMessage(messageCode);
        }

        protected override async void OnPageNavigatedTo(INavigationParameters parameters) {
            try {
                DownLoadInProgress = true;
                DownLoadSucess = false;
                DownLoadFailed = false;
                _appResult = await _iSyncLogic.Synchronize();
                if (_appResult.Success) {
                    await OnSucess();
                } else {
                    OnFaied(CommonFunction.GetConvertedMessage(_appResult.ResultID));
                }
            } catch (Exception ex) {
                OnFaied(ex.Message);
            }
        }

        private async Task OnSucess() {
            DownLoadInProgress = false;
            DownLoadSucess = true;
            DownLoadFailed = false;
            await Task.Delay(1250);
            await NavigationService.GoBackAsync(GetNavigationParameters(AppConstant.NavigationParameterName.CALL_BACK_DATA_SYNC_SUCESS));
        }

        private void OnClose() {

        }

        private void OnFaied(string message) {
            DownLoadInProgress = false;
            DownLoadSucess = false;
            DownLoadFailed = true;
            Message = message;
        }

        private async void OnOK() {
            await NavigationService.GoBackAsync(GetNavigationParameters(AppConstant.NavigationParameterName.CALL_BACK_DATA_SYNC_FAILED));
        }

        private NavigationParameters GetNavigationParameters(string callBackFunctionCode) {
            _navigationParameters = new NavigationParameters();
            _navigationParameters.Add(AppConstant.NavigationParameterName.CALL_BACK_REQUIRED, true);
            _navigationParameters.Add(AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE, callBackFunctionCode);
            return _navigationParameters;
        }
        #endregion

    }
}
