#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.ViewModels
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version           Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
 19/02/2020         1.0           Anuruddha.Rajapaksha   		   Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Acr.UserDialogs;
using GTS.Mobile.Logic.Delivery;
using Mobile.Data;
using Mobile.Enum;
using Mobile.Helpers;
using Mobile.Logic;
using Mobile.Models.Common;
using Prism.AppModel;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
#endregion

namespace Mobile.ViewModels {
    public class ViewModelBase : BindableBase, INavigationAware, IPageLifecycleAware, IDestructible, IConnectionDecider, IConfirmNavigation, IInitializeAsync {

        #region Private Variables
        private string _title;
        private string _activityIndicatorMessage;
        private bool _isSubModleMainPage = false;
        private bool _isRefreshing;
        private bool _isPageOntheBackground = false;
        private bool _isShowActivityIndicator;
        private string _closeButtonIcon = AppConstant.AppIcons.ICO_COM_CLOSE;
        private string _forwardArrowImage = AppConstant.AppImgesSvg.IMG_LIST_NAVIGATE_ARROW;
        private string _itemsIcon = AppConstant.AppIcons.ICO_COM_ITEMS;
        private string _dateTimePickerIcon = AppConstant.AppIcons.ICO_COM_MODIFY_DATE;
        private string _cancelItemIcon = AppConstant.AppIcons.ICO_COM_CANCEL;
        private string _manulBarcodeEntryIcon = AppConstant.AppIcons.ICO_COM_MANNAUL;
        private string _confirmIcon = AppConstant.AppIcons.ICO_COM_CONFIRM;
        private string _floatingButtonIcon;
        private bool _isEnableFloatingButton = true;

        protected string Loading;
        protected string Saving;


        protected string _callBackFunctionCode;
        protected bool IsNormalPage { get; set; } = true;
        protected string TitleCode { get; set; } = string.Empty;
        protected IUserDialogs Dialogs { get; set; }
        protected ICommonFunction CommonFunction { get; set; }
        private IErrorLogDataService _errorLogDataService;


        protected List<CustomToolBarItem> _customToolBarItems;
        protected CustomToolBarItem customToolBarItem;

        // To Fix double tap issue
        protected Boolean _isRunning = false;
        protected Object _lockObject = new Object();



        #region SyncData
        private bool _isDataToBeSynced = false;
        private int _dataToBeSyncedCount = 0;
        private string _synchronizationImage = AppConstant.AppImgesSvg.IMG_LIST_NOTIFICATION_SYNC;
        private string _syncMessage = string.Empty;
        #endregion

        #endregion

        #region Properties
        public INavigationService NavigationService { get; private set; }
        public IEventAggregator EventAggregator { get; private set; }
        public ICommand CancelItemCommand { get; protected set; }
        public ICommand ConfirmCommand { get; protected set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand FloatingButtonCommand { get; protected set; }
        public ICommand BackButtonPressedCommand { get; protected set; }
        public ICommand InvokeCustomToobarCommand { get; protected set; }

        #region SyncData
        public ICommand SyncCommand { get; private set; }

        public bool IsDataToBeSynced {
            // et { return _isDataToBeSynced; }
            get { return (DataToBeSyncedCount > 0) ? true : false; }
            set { SetProperty(ref _isDataToBeSynced, value); }
        }

        public int DataToBeSyncedCount {
            get { return _dataToBeSyncedCount; }
            set { SetProperty(ref _dataToBeSyncedCount, value); }
        }

        public string SyncMessage {
            get { return _syncMessage; }
            set { SetProperty(ref _syncMessage, value); }
        }

        public string SynchronizationImage {
            get { return _synchronizationImage; }
            set { SetProperty(ref _synchronizationImage, value); }
        }

        public ISyncLogic SyncLogic { get; set; }
        #endregion

        public string DeleteImage { get; set; } = AppConstant.AppImgesSvg.IMG_LIST_DELETE;

        public string Title {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ActivityIndicatorMessage {
            get { return _activityIndicatorMessage; }
            set { SetProperty(ref _activityIndicatorMessage, value); }
        }

        public bool IsShowActivityIndicator {
            get { return _isShowActivityIndicator; }
            set { SetProperty(ref _isShowActivityIndicator, value); }
        }

        public bool IsRefreshing {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        public bool IsSubModuleMainPage {
            get { return _isSubModleMainPage; }
            set {
                _isSubModleMainPage = value;
                IsNormalPage = false;
            }
        }

        public string ForwardArrowImage {
            get { return _forwardArrowImage; }
            set { SetProperty(ref _forwardArrowImage, value); }
        }

        public string ItemsIcon {
            get { return _itemsIcon; }
            set { SetProperty(ref _itemsIcon, value); }
        }

        public string CloseButtonIcon {
            get { return _closeButtonIcon; }
            set { SetProperty(ref _closeButtonIcon, value); }
        }

        public bool IsEnableFloatingButton {
            get { return _isEnableFloatingButton; }
            set { SetProperty(ref _isEnableFloatingButton, value); }
        }

        public string FloatingButtonIcon {
            get { return _floatingButtonIcon; }
            set { SetProperty(ref _floatingButtonIcon, value); }
        }

        public string DateTimePickerIcon {
            get { return _dateTimePickerIcon; }
            set { SetProperty(ref _dateTimePickerIcon, value); }
        }

        public string CancelItemIcon {
            get { return _cancelItemIcon; }
            set { SetProperty(ref _cancelItemIcon, value); }
        }

        public string ManualBarcodeEntryIcon {
            get { return _manulBarcodeEntryIcon; }
            set { SetProperty(ref _manulBarcodeEntryIcon, value); }
        }

        public string ConfirmIcon {
            get { return _confirmIcon; }
            set { SetProperty(ref _confirmIcon, value); }
        }
        #endregion

        #region Constructor
        public ViewModelBase(INavigationService navigationService,
                             IEventAggregator eventAggregator,
                             IUserDialogs dialogs,
                             ICommonFunction commonFunction,
                             string titleCode) {
            try {
                NavigationService = navigationService;
                EventAggregator = eventAggregator;
                Dialogs = dialogs;
                CommonFunction = commonFunction;

                _errorLogDataService = new ErrorLogDataService();

                BackButtonPressedCommand = new DelegateCommand(OnBackButtonPressed);
                InvokeCustomToobarCommand = new DelegateCommand(InvokeCustomToobar);
                SyncCommand = new DelegateCommand(async () => await SynchronizeData());
                _customToolBarItems = new List<CustomToolBarItem>();
                TitleCode = titleCode;
                Loading = CommonFunction.GetConvertedMessage(Message.CAP_LOADING);
                Saving = CommonFunction.GetConvertedMessage(Message.CAP_SAVING);
                if (!string.IsNullOrEmpty(TitleCode)) {
                    Title = CommonFunction.GetConvertedMessage(TitleCode);
                }
                IsShowActivityIndicator = false;

            } catch (Exception ex) {
                throw ex;
            }
        }


        #endregion

        #region Methods

        #region PageLifeCycle
        public void OnAppearing() {
            if (IsSubModuleMainPage) {
                GlobalSetting.TransitionType = TransitionType.Flip;
            }
            this.OnPageAppearing();
        }

        protected virtual void OnPageAppearing() { }

        public void OnDisappearing() {
            OnPageDisappearing();
        }

        protected virtual void OnPageDisappearing() { }
        #endregion

        #region NavigationLifeCycle
        public async Task InitializeAsync(INavigationParameters parameters) {
            try {
                AddCommonToolbarItems();
                if (IsSubModuleMainPage) {
                    GlobalSetting.TransitionType = TransitionType.Flip;
                } else if (IsNormalPage) {
                    GlobalSetting.TransitionType = TransitionType.SlideFromRight;
                }
                await OnInitializeAsync(parameters);
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        protected virtual Task OnInitializeAsync(INavigationParameters parameters) { return Task.FromResult<object>(null); }

        public async void OnNavigatedTo(INavigationParameters parameters) {
            try {
                await CheckSynchronizeData();

                if (!_isPageOntheBackground) {
                    OnPageNavigatedTo(parameters);
                } else {
                    if (parameters != null && parameters.ContainsKey(AppConstant.NavigationParameterName.TOOL_BAR_SELECTED_COMMAND)) {
                        OnToolbarItemClicked((ICommand)parameters[AppConstant.NavigationParameterName.TOOL_BAR_SELECTED_COMMAND]);
                    } else {
                        OnPageResume(parameters);
                    }
                }
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        protected virtual void OnPageNavigatedTo(INavigationParameters parameters) { }

        protected virtual void OnPageResume(INavigationParameters parameters) { }


        public bool CanNavigate(INavigationParameters parameters) {
            return true;
        }

        public void OnNavigatedFrom(INavigationParameters parameters) {
            _isPageOntheBackground = true;
            this.OnPageNavigatedFrom(parameters);
        }

        protected virtual void OnPageNavigatedFrom(INavigationParameters parameters) { }

        private void OnBackButtonPressed() {
            if (!GlobalSetting.Instance.IsPopupOpened) {
                OnPageBackButtonPressed();
            }
        }

        protected virtual void OnPageBackButtonPressed() { NavigationService.GoBackAsync(); }
        #endregion

        #region Common
        public void Destroy() { }

        protected void AddCommonToolbarItems() {
            if (_customToolBarItems.Where(i => i.Text == CommonFunction.GetConvertedMessage(Message.BTN_HOME_001)).Count() == 0) {
                customToolBarItem = new CustomToolBarItem();
                // #Todo#
                //customToolBarItem.SvgIcon = AppConstant.AppImgesSvg.IMG_MNU_TOOLBAR_ITEM_DISPLAY;
                customToolBarItem.Text = CommonFunction.GetConvertedMessage(Message.BTN_HOME_001);
                //customToolBarItem.ICommand = new DelegateCommand(async () => await OpenMotherPage());
                _customToolBarItems.Add(customToolBarItem);
            }
        }

        private void InvokeCustomToobar() {
            try {
                if (!GlobalSetting.Instance.IsToolbarOpened) {
                    GlobalSetting.Instance.IsToolbarOpened = true;
                    NavigationParameters navigationParameters = new NavigationParameters();
                    navigationParameters.Add(AppConstant.NavigationParameterName.TOOL_BAR_ITEMS, _customToolBarItems);
                    NavigationService.NavigateAsync(AppConstant.Screen.TOOLBAR_ITEMS_PAGE, navigationParameters);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void OnToolbarItemClicked(ICommand command) {
            command.Execute(null);
        }

        protected virtual void OnPageToobarItemClicked(string functionCode) { }


        protected bool IsCallBackRequired(INavigationParameters parameters) {
            if (parameters.ContainsKey(AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE)) {
                if (parameters.ContainsKey(AppConstant.NavigationParameterName.MESSAGE_YES_NO)
                   && (bool)parameters[AppConstant.NavigationParameterName.MESSAGE_YES_NO]) {
                    return true;
                } else {
                    if (parameters[AppConstant.NavigationParameterName.CALL_BACK_REQUIRED] != null) {
                        return (bool)parameters[AppConstant.NavigationParameterName.CALL_BACK_REQUIRED];
                    } else {
                        return false;
                    }
                }
            } else {
                return false;
            }
        }



        #region UserMessages
        protected void DisplayAlert(string title, string message) {
            Application.Current.MainPage.DisplayAlert(CommonFunction.GetConvertedMessage(title), CommonFunction.GetConvertedMessage(message), "OK");
        }

        protected void DisplayConfirmationAlert(string title, string message) {
            Application.Current.MainPage.DisplayAlert(CommonFunction.GetConvertedMessage(title), CommonFunction.GetConvertedMessage(message), "Yes", "No");
        }

        protected void DisplayToast(string message) {
            var toastConfig = new ToastConfig(CommonFunction.GetConvertedMessage(message));
            toastConfig.SetDuration(3000);
            toastConfig.SetBackgroundColor(Color.DimGray);


            UserDialogs.Instance.Toast(toastConfig);
        }

        public async Task DisplayDiscrepancy(string titleCode, string discrepancyMessageCode, List<Discrepancy> discrepancies, bool isConfirm = false, string confirmationForFunctionCode = "", bool isYesNo = false) {
            HideActivityIndicator();
            await CommonFunction.DisplayDiscrepancy(NavigationService, titleCode, discrepancyMessageCode, discrepancies, isConfirm, confirmationForFunctionCode, isYesNo);
        }

        public async Task DisplayMessage(MessageType messageType, string titleCode, string messageCode, object[] values = null, bool isConfirm = false, string confirmationForFunctionCode = "", bool isYesNo = false) {
            HideActivityIndicator();
            if (messageType == MessageType.Validation || messageType == MessageType.Error) {
                PlayBeep();
            }
            await CommonFunction.DisplayMessage(NavigationService, messageType, titleCode, messageCode, values, isConfirm, confirmationForFunctionCode, isYesNo);
        }

        protected async Task ShowErrorMessage(bool isDisplayMessage, Exception ex) {
            if (isDisplayMessage) {
                PlayBeep();
                await DisplayMessage(MessageType.Error, Title, Message.ERR_UN_EXPECTED);
            }
            ErrorLog errorLog = new ErrorLog();
            errorLog.Source = ex.Source;
            errorLog.Message = ex.Message;
            errorLog.Error = ex.ToString();
            errorLog.DateTime = DateTime.Now;
            await this._errorLogDataService.InsertItemAsyn(errorLog);
        }

        #region PlayBeepSound
        protected void PlayBeep() {
            var stream = GetStreamFromFile();
            var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            audio.Load(stream);
            audio.Play();
        }
        private Stream GetStreamFromFile() {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(AppConstant.AppSound.BEEP);
            return stream;
        }
        #endregion
        #endregion

        #region ActivityIndicator
        protected void ShowActivityIndicator(string messageCode) {
            CommonFunction.ShowActivityIndicator(CommonFunction.GetConvertedMessage(messageCode));
        }

        protected void HideActivityIndicator() {
            CommonFunction.HideActivityIndicator();
        }
        #endregion

        public void RunTheMethod(Action method) {
            //await Task.Run(() => {
            lock (_lockObject) {
                if (_isRunning) { return; } else { _isRunning = true; }
            }

            method();

            _isRunning = false;
            //}
            // );
        }
        #endregion

        #region SyncData
        private async Task SynchronizeData() {
            if (ConnectionDecider.Instance.IsOnline()) {
                DataToBeSyncedCount = 0;
                OnSynchronizeData();
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add(AppConstant.NavigationParameterName.I_SYNC_LOGIC, SyncLogic);
                await NavigationService.NavigateAsync(AppConstant.Screen.SYNCHRONIZATION_PAGE, navigationParameters);
            } else {
                await DisplayMessage(MessageType.Message, Message.MSG_COM_027, Message.MSG_COM_001);
            }
        }

        protected virtual void OnSynchronizeData() { }

        private async Task CheckSynchronizeData() {
            await OnCheckSynchronizeData();
            SyncMessage = string.Format(CommonFunction.GetConvertedMessage(SyncMessage), DataToBeSyncedCount.ToString());
        }

        protected virtual Task OnCheckSynchronizeData() { return Task.FromResult<object>(null); }
        #endregion

        #region Notification
        protected async Task SendDeliveryNotification(int notificationType , int minutes) {
            var navigationParameters = new NavigationParameters();
            DeliveryNotificationSyncLogic.Instance.NotificationType = notificationType;
            DeliveryNotificationSyncLogic.Instance.Minutes = minutes;
            navigationParameters.Add(AppConstant.NavigationParameterName.I_SYNC_LOGIC, DeliveryNotificationSyncLogic.Instance);
            await NavigationService.NavigateAsync(AppConstant.Screen.SYNCHRONIZATION_PAGE, navigationParameters);
        }
        #endregion

        #region Connection Decider
        public async Task<bool> DoOnlineProcessing() {
            return await OnDoOnlineProcessing();
        }

        protected virtual Task<bool> OnDoOnlineProcessing() {
            return Task.FromResult(true);
        }

        public async Task<bool> DoOfflineProcessing() {
            return await OnDoOfflineProcessing();
        }

        protected virtual Task<bool> OnDoOfflineProcessing() {
            return Task.FromResult(false);
        }

        public async Task<bool> TryLater() {
            await DisplayMessage(MessageType.Message, this.Title, Message.ERR_UNABLE_TO_CONNECT);
            return await OnTryLater();
        }

        protected virtual Task<bool> OnTryLater() {
            return Task.FromResult(false);
        }

        #endregion

        #endregion
    }
}
